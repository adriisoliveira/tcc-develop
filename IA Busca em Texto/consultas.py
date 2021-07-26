import nltk
import pymysql
   

    
def getUrl(idurl):
    retorno = ''
    conexao = pymysql.connect(host='localhost', user='root', passwd='bahia', db='indice')
    cursor = conexao.cursor()
    cursor.execute('select url from urls where idurl = %s', idurl)
    if cursor.rowcount > 0:
        retorno = cursor.fetchone()[0]
    
    cursor.close()
    conexao.close()
    return retorno

def frequenciaScore(linhas):
    contagem = dict([linha[0],0] for linha in linhas)
    for linha in linhas:
        contagem[linha[0]] += 1
    return contagem

def getIdPalavra(palavra):
    retorno = -1
    stemmer = nltk.stem.RSLPStemmer()
    conexao = pymysql.connect(host='localhost', user='root', passwd='bahia', db='indice')
    cursor = conexao.cursor()
    cursor.execute('select idpalavra from palavras where palavra = %s', stemmer.stem(palavra))
    if cursor.rowcount > 0:
        retorno = cursor.fetchone()[0]
    cursor.close()
    conexao.close()
    return retorno

def buscaMaisPalavras(consulta):
    listacampos = 'p1.idurl'
    listatabelas = ''
    listaclausulas = ''
    palavrasid = []
    
    palavras = consulta.split(' ')
    numerotabela = 1
    for palavra in palavras:
        idpalavra = getIdPalavra(palavra)
        if idpalavra > 0:
            palavrasid.append(idpalavra)
            if numerotabela > 1:
                listatabelas += ', '
                listaclausulas += ' and '
                listaclausulas += 'p%d.idurl = p%d.idurl and ' % (numerotabela - 1, numerotabela)
            listacampos += ', p%d.localizacao' % numerotabela
            listatabelas += ' palavra_localizacao p%d' % numerotabela
            listaclausulas += 'p%d.idpalavra = %d' % (numerotabela, idpalavra)
            numerotabela += 1
    consultacompleta = 'select %s from %s where %s' % (listacampos, listatabelas, listaclausulas)
    
    conexao = pymysql.connect(host='localhost', user='root', passwd='bahia', db='indice')
    cursor = conexao.cursor()
    cursor.execute(consultacompleta)
    linhas = [linha for linha in cursor]
    cursor.close()
    conexao.close()
    
    return linhas, palavrasid

#linhas, palavrasid = buscaMaisPalavras('python programação')
   
def localizacaoScore(linhas):
    localizacoes = dict([linha[0], 1000000] for linha in linhas)
    for linha in linhas:
        soma = sum(linha[1:])
        if soma < localizacoes[linha[0]]:
            localizacoes[linha[0]] = soma
    return localizacoes
     
#localizacaoScore(linhas)

def distanciaScore(linhas):
    if len(linhas[0]) <= 2:
        return dict([(linha[0], 1.0) for linha in linhas])
    distancias = dict([(linha[0], 1000000) for linha in linhas])
    for linha in linhas:
        dist = sum([abs(linha[i] - linha[i - 1]) for i in range(2, len(linha))])
        if dist < distancias[linha[0]]:
            distancias[linha[0]] = dist
    return distancias

#distanciaScore(linhas)

def contagemLinksScore(linhas):
    contagem = dict([linha[0],1.0] for linha in linhas)
    conexao = pymysql.connect(host='localhost', user='root', passwd='bahia', db='indice')
    cursor = conexao.cursor()
    for i in contagem:
        cursor.execute('select count(*) from url_ligacao where idurl_destino = %s', i)
        contagem[i] = cursor.fetchone()[0]
    cursor.close()
    conexao.close()
    return contagem
    


def pesquisa (consulta):
    linhas, palavrasid = buscaMaisPalavras(consulta)
    #scores = dict([linha[0],0] for linha in linhas)
    
    #scores = localizacaoScore(linhas)
    #scores = distanciaScore(linhas)
    scores = contagemLinksScore(linhas)
    scoresordenado = sorted([(score, url) for (url, score) in scores.items()], reverse = 1)
    for (score, idurl) in scoresordenado[0:10]:
        print('%f\t%s' %(score, getUrl(idurl)))
        
#pesquisa('python programação')    



def buscaUmaPalavra (palavra):
    idpalavra = getIdPalavra(palavra)
    conexao = pymysql.connect(host='localhost', user='root', passwd='bahia', db='indice')
    cursor = conexao.cursor()
    cursor.execute('select urls.url from palavra_localizacao plc inner join urls on plc.idurl = urls.idurl where plc.idpalavra = %s', idpalavra)
    paginas = set()
    for url in cursor:
        #print(url[0])
        paginas.add(url[0])
        
    print('Paginas encontradas: ' + str(len(paginas)))
    for url in paginas:
        print(url)
    cursor.close()
    conexao.close()
    
#buscaUmaPalavra('Programação')
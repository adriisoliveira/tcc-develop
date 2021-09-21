import nltk
import pymysql

from conexao import conexaoBanco
conexao = conexaoBanco()

def normalizaMaior(notas):
    menor = 0.00001
    maximo = max(notas.values())
    if maximo == 0:
        maximo = menor
    return dict([(id, float (nota) / maximo) for (id, nota) in notas.items()])
    
def normalizaMenor(notas):
    menor = 0.00001
    minimo = min(notas.values())
    return dict([(id, float(minimo) / max(menor, nota)) for (id, nota) in notas.items()])
    
def calculaPageRank(iteracoes):
    cursorLimpaTabela = conexao.cursor()
    cursorLimpaTabela.execute('delete from page_rank')
    cursorLimpaTabela.execute('insert into page_rank select idurl, 1.0 from urls')
    for i in range(iteracoes):
        print("Iteração " + str(i+1))
        cursorUrl = conexao.cursor()
        cursorUrl.execute('select idurl from urls')
        for url in cursorUrl:
          pr = 0.15
          cursorLinks = conexao.cursor()
          cursorLinks.execute('select distinct(idurl_origem) from url_ligacao where idurl_destino = %s', url[0])
          for link in cursorLinks:
              cursorPageRank = conexao.cursor()
              cursorPageRank.execute('select nota from page_rank where idurl = %s', link[0])
              linkPageRank = cursorPageRank.fetchone()[0]
              cursorQuantidade = conexao.cursor()
              cursorQuantidade.execute('select count(*) from url_ligacao where idurl_origem = %s', link[0])
              linkQuantidade = cursorQuantidade.fetchone()[0]
              pr += 0.85 * (linkPageRank / linkQuantidade)    
          cursorAtualiza = conexao.cursor()
          cursorAtualiza.execute('update page_rank set nota = %s where idurl = %s', (pr, url[0]))
    cursorUrl.close()    
    cursorLinks.close()  
    cursorAtualiza.close()
    cursorPageRank.close()
    cursorQuantidade.close()
    cursorLimpaTabela.close()
    conexao.close()
    
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
    return normalizaMaior(contagem)

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
   
def localizacaoScore(linhas):
    localizacoes = dict([linha[0], 1000000] for linha in linhas)
    for linha in linhas:
        soma = sum(linha[1:])
        if soma < localizacoes[linha[0]]:
            localizacoes[linha[0]] = soma
    return normalizaMenor(localizacoes)
     

def distanciaScore(linhas):
    if len(linhas[0]) <= 2:
        return dict([(linha[0], 1.0) for linha in linhas])
    distancias = dict([(linha[0], 1000000) for linha in linhas])
    for linha in linhas:
        dist = sum([abs(linha[i] - linha[i - 1]) for i in range(2, len(linha))])
        if dist < distancias[linha[0]]:
            distancias[linha[0]] = dist
    return normalizaMenor(distancias)


def contagemLinksScore(linhas):
    contagem = dict([linha[0],1.0] for linha in linhas)
    conexao = pymysql.connect(host='localhost', user='root', passwd='bahia', db='indice')
    cursor = conexao.cursor()
    for i in contagem:
        cursor.execute('select count(*) from url_ligacao where idurl_destino = %s', i)
        contagem[i] = cursor.fetchone()[0]
    cursor.close()
    conexao.close()
    return normalizaMaior(contagem)
    
def pageRankScore(linhas):
    pageranks = dict([linha[0], 1.0] for linha in linhas)
    conexao = pymysql.connect(host='localhost', user='root', passwd='bahia', db='indice')
    cursor = conexao.cursor()
    for i in pageranks:
        cursor.execute('select nota from page_rank where idurl = %s', i)
        pageranks[i] = cursor.fetchone()[0]
    
    cursor.close()
    conexao.close()
    return normalizaMaior(pageranks)
    
def textoLinkScore(linhas, palavrasid):
    contagem = dict([linha[0], 0] for linha in linhas)
    conexao = pymysql.connect(host='localhost', user='root', passwd='bahia', db='indice')
    for id in palavrasid:
        cursor = conexao.cursor()
        cursor.execute('select ul.idurl_origem, ul.idurl_destino from url_palavra up inner join url_ligacao ul on up.idurl_ligacao = ul.idurl_ligacao where up.idpalavra = %s', id)
        for (idurl_origem, idurl_destino) in cursor:
            if idurl_destino in contagem:
                cursorRank = conexao.cursor()
                cursorRank.execute('select nota from page_rank where idurl = %s', idurl_origem)
                pr = cursorRank.fetchone()[0]
                contagem[idurl_destino] += pr
    cursor.close()
    conexao.close()
    cursorRank.close()
    return normalizaMaior(contagem)

#linhas, palavrasid = buscaMaisPalavras('python programação')
#textoLinkScore(linhas, palavrasid)
    
def pesquisa (consulta):
    linhas, palavrasid = buscaMaisPalavras(consulta)
    #scores = dict([linha[0],0] for linha in linhas)
    #scores = frequenciaScore(linhas)
    #scores = localizacaoScore(linhas)
    #scores = distanciaScore(linhas)
    #scores = contagemLinksScore(linhas)
    #scores = pageRankScore(linhas)
    scores = textoLinkScore(linhas, palavrasid)
    scoresordenado = sorted([(score, url) for (url, score) in scores.items()], reverse = 1)
    for (score, idurl) in scoresordenado[0:10]:
        print('%f\t%s' %(score, getUrl(idurl)))
        
pesquisa('python programação')

def pesquisaPeso(consulta):
    linhas, palavrasid = buscaMaisPalavras(consulta)
    totalscores = dict([linha[0], 0] for linha in linhas)
    pesos = [(1.0, frequenciaScore(linhas)),
             (1.0, localizacaoScore(linhas)),
             (1.0, distanciaScore(linhas)),
             (1.0, contagemLinksScore(linhas)),
             (1.0, pageRankScore(linhas)),
             (1.0, textoLinkScore(linhas, palavrasid))]
    for (peso, scores) in pesos:
        for url in totalscores:
            totalscores[url] += peso * scores[url]
    totalscores = normalizaMaior(totalscores)
    scoresordenado = sorted([(score, url) for (url, score) in totalscores.items()], reverse = 1)
    for (score, idurl) in scoresordenado[0:10]:
        print('%f\t%s' %(score, getUrl(idurl)))
        
pesquisaPeso('python programação')        

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
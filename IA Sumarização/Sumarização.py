import re
import nltk
import spacy
import heapq
import string
from IPython.core.display import HTML
from goose3 import Goose

texto = ''
texto_original = ''
texto_formatado = ''

nltk.download('punkt')
nltk.download('stopwords')
stopwords = nltk.corpus.stopwords.words('portuguese')
lista_sentencas = nltk.sent_tokenize(texto_original)
frequencia_palavras = nltk.FreqDist(nltk.word_tokenize(texto_formatado))
melhores_sentencas = heapq.nlargest(3, nota_sentencas, key=nota_sentencas.get)

g = Goose()
url = 'https://iaexpert.academy/2020/11/09/ia-preve-resultado-das-eleicoes-americanas/'
artigo = g.extract(url)
artigo_original = artigo.cleaned_text
artigo_formatado = preprocessamento(artigo_original)

lista_artigos = ['https://iaexpert.academy/2020/11/06/ia-detecta-deep-fakes-produzidos-com-tecnicas-recentes/',
                 'https://iaexpert.academy/2020/11/13/facebook-apresenta-novo-algoritmo-deteccao-fake-news/',
                 'https://iaexpert.academy/2020/11/16/automl-aspectos-aplicacoes/']

pln = spacy.load('pt')


def preprocessamento(texto):
  texto_formatado = texto.lower()
  tokens = []
  for token in nltk.word_tokenize(texto_formatado):
    tokens.append(token)

  tokens = [palavra for palavra in tokens if palavra not in stopwords and palavra not in string.punctuation]
  texto_formatado = ' '.join([str(elemento) for elemento in tokens if not elemento.isdigit()])

  return texto_formatado

def sumarizar(texto, quantidade_sentencas):
  texto_original = texto
  texto_formatado = preprocessamento(texto_original)

  frequencia_palavras = nltk.FreqDist(nltk.word_tokenize(texto_formatado))
  frequencia_maxima = max(frequencia_palavras.values())
  for palavra in frequencia_palavras.keys():
    frequencia_palavras[palavra] = (frequencia_palavras[palavra] / frequencia_maxima)
  lista_sentencas = nltk.sent_tokenize(texto_original)
  
  nota_sentencas = {}
  for sentenca in lista_sentencas:
    for palavra in nltk.word_tokenize(sentenca):
      if palavra in frequencia_palavras.keys():
        if sentenca not in nota_sentencas.keys():
          nota_sentencas[sentenca] = frequencia_palavras[palavra]
        else:
          nota_sentencas[sentenca] += frequencia_palavras[palavra]

  import heapq
  melhores_sentencas = heapq.nlargest(quantidade_sentencas, nota_sentencas, key=nota_sentencas.get)

  return lista_sentencas, melhores_sentencas, frequencia_palavras, nota_sentencas

lista_sentencas, melhores_sentencas, frequencia_palavras, nota_sentencas = sumarizar(artigo_original, 5)

def visualiza_resumo(titulo, lista_sentencas, melhores_sentencas):
  texto = ''
  display(HTML(f'<h1>Resumo do texto - {titulo}</h1>'))
  for i in lista_sentencas:
    if i in melhores_sentencas:
      texto += str(i).replace(i, f"<mark>{i}</mark>")
    else:
      texto += i
  display(HTML(f""" {texto} """))
  
visualiza_resumo('Eleições', lista_sentencas, melhores_sentencas)

def preprocessamento_lematizacao(texto):
  texto = texto.lower()
  texto = re.sub(r" +", ' ', texto)

  documento = pln(texto)
  tokens = []
  for token in documento:
    tokens.append(token.lemma_)
  
  tokens = [palavra for palavra in tokens if palavra not in stopwords and palavra not in string.punctuation]
  texto_formatado = ' '.join([str(elemento) for elemento in tokens if not elemento.isdigit()])
  
  return texto_formatado

def sumarizar_lematizacao(texto, quantidade_sentencas):
  texto_original = texto
  # Chamada para a outra função de pré-processamento
  texto_formatado = preprocessamento_lematizacao(texto_original)

  frequencia_palavras = nltk.FreqDist(nltk.word_tokenize(texto_formatado))
  frequencia_maxima = max(frequencia_palavras.values())
  for palavra in frequencia_palavras.keys():
    frequencia_palavras[palavra] = (frequencia_palavras[palavra] / frequencia_maxima)
  lista_sentencas = nltk.sent_tokenize(texto_original)
  
  nota_sentencas = {}
  for sentenca in lista_sentencas:
    for palavra in nltk.word_tokenize(sentenca):
      if palavra in frequencia_palavras.keys():
        if sentenca not in nota_sentencas.keys():
          nota_sentencas[sentenca] = frequencia_palavras[palavra]
        else:
          nota_sentencas[sentenca] += frequencia_palavras[palavra]

  import heapq
  melhores_sentencas = heapq.nlargest(quantidade_sentencas, nota_sentencas, key=nota_sentencas.get)

  return lista_sentencas, melhores_sentencas, frequencia_palavras, nota_sentencas



for url in lista_artigos:
  #print(url)
  g = Goose()
  artigo = g.extract(url)
  lista_sentencas, melhores_sentencas, _, _ = sumarizar_lematizacao(artigo.cleaned_text, 5)
  visualiza_resumo(artigo.title, lista_sentencas, melhores_sentencas)




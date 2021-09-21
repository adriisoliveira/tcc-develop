#pip install wordcloud
#pip install nltk

import nltk
import string
from wordcloud import WordCloud
import matplotlib.pyplot as plt

texto = ''
nltk.download('punkt')
nltk.download('stopwords')
stopwords = nltk.corpus.stopwords.words('portuguese')
stopwords.append('ser')
stopwords.append('além')

def preprocessamento(texto):
  texto_formatado = texto.lower()
  tokens = []
  for token in nltk.word_tokenize(texto_formatado):
    tokens.append(token)

  tokens = [palavra for palavra in tokens if palavra not in stopwords and palavra not in string.punctuation]
  texto_formatado = ' '.join([str(elemento) for elemento in tokens if not elemento.isdigit()])

  return texto_formatado

def wordcloud(texto):
  conteudo_formatado = preprocessamento(texto)
  plt.figure(figsize=(50,50))
  plt.axis('off')
  plt.imshow(WordCloud().generate(conteudo_formatado))
  return plt.savefig('cloud.jpg')
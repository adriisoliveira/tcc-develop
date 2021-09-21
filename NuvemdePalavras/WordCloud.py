import re
import nltk
import string
import heapq
from wordcloud import WordCloud
import matplotlib.pyplot as plt

nltk.download('punkt')
nltk.download('stopwords')

stopwords = nltk.corpus.stopwords.words('portuguese')
#stopwords.append('ser')
texto_original = ''
#
#stopwords.append('além')

def preprocessamento(texto):
  texto = re.sub(r'\s+', ' ', texto)
  texto_formatado = texto.lower()
  tokens = []
  for token in nltk.word_tokenize(texto_formatado):
    tokens.append(token)

  tokens = [palavra for palavra in tokens if palavra not in stopwords and palavra not in string.punctuation]
  texto_formatado = ' '.join([str(elemento) for elemento in tokens if not elemento.isdigit()])

  return texto_formatado

#texto_formatado = preprocessamento(texto_original)
#print (texto_original)
#print('-------------------')
#print(texto_formatado)

def geraNuvem(texto):
  texto_formatado = preprocessamento(texto)
  plt.figure(figsize=(20,20))
  plt.axis('off')
  wordcloud = plt.imshow(WordCloud().generate(texto_formatado))
  wordcloud.to_file("wordcloud.png")
  return wordcloud
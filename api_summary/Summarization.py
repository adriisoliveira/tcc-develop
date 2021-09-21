#python -m spacy download pt_core_news_sm
#pip install heapq
#pip install spacy

import re
import nltk
import spacy
import heapq
import string
from IPython.core.display import HTML
from goose3 import Goose

pln = spacy.load("pt_core_news_sm")
nltk.download('punkt')
nltk.download('stopwords')
stopwords = nltk.corpus.stopwords.words('portuguese')

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
    melhores_sentencas = heapq.nlargest(quantidade_sentencas, nota_sentencas, key=nota_sentencas.get)
    return melhores_sentencas


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
    melhores_sentencas = heapq.nlargest(quantidade_sentencas, nota_sentencas, key=nota_sentencas.get)
    return melhores_sentencas
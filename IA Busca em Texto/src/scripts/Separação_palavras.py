import re
import nltk
#nltk.download()

stop1 = ['é']
stop2 = nltk.corpus.stopwords.words('portuguese')
stop2

#buscar qualquer caracter que não seja uma palavra
splitter = re.compile('\W+')
stemmer = nltk.stem.RSLPStemmer()
lista_palavras = []
#vai quebrar quando achar um caractere com aquela característica
lista = [p for p in splitter.split('Este lugar é apavorante a b c c++') if p != '']
for p in lista:
    if p.lower() not in stop2:
        if len(p) > 1: 
            lista_palavras.append(stemmer.stem(p).lower())
            
stemm

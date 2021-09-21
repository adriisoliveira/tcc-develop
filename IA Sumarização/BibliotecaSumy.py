import nltk
nltk.download('punkt')

#!pip install sumy
#!pip install goose3

from goose3 import Goose
g = Goose()
url = 'https://iaexpert.academy/2020/11/09/ia-preve-resultado-das-eleicoes-americanas/'
artigo_portugues = g.extract(url)


from sumy.parsers.plaintext import PlaintextParser
from sumy.nlp.tokenizers import Tokenizer
from sumy.summarizers.luhn import LuhnSummarizer


def Summy(artigo_portugues):
    parser = PlaintextParser.from_string(artigo_portugues.cleaned_text, Tokenizer('portuguese'))
    sumarizador = LuhnSummarizer()
    resumo = sumarizador(parser.document, 5)
    for sentenca in resumo:
        print(sentenca)
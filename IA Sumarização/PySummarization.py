import nltk
nltk.download('punkt')
from goose3 import Goose

#!pip install pysummarization
#!pip install goose3

url = 'https://en.wikipedia.org/wiki/Artificial_intelligence'
artigo_ingles = g.extract(url)

from pysummarization.nlpbase.auto_abstractor import AutoAbstractor
from pysummarization.tokenizabledoc.simple_tokenizer import SimpleTokenizer
from pysummarization.abstractabledoc.top_n_rank_abstractor import TopNRankAbstractor

auto_abstractor = AutoAbstractor()
auto_abstractor.tokenizable_doc = SimpleTokenizer()
auto_abstractor.delimiter_list = [".", "\n"]
abstractable_doc = TopNRankAbstractor()
resumo = auto_abstractor.summarize(artigo_ingles.cleaned_text, abstractable_doc)

artigo_ingles.cleaned_text

resumo

for sentenca in resumo['summarize_result']:
  print(sentenca)
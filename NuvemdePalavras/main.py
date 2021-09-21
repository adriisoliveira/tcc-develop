#pip install flask
from flask import Flask, request

from WordCloud import geraNuvem

app = Flask("Nuvem de Palavras")

@app.route("/teste", methods=["GET"])
def helloWorld():
    teste = 'Hello world'
    return teste

@app.route("/wordcloud", methods=["POST"])
def geraNuvemPalavras():
  texto = request.get_json()
  nuvem = geraNuvem(texto)
  return nuvem


app.run()

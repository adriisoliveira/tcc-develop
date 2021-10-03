from flask import Flask, jsonify, request
from flask_cors import CORS
#pip install -U flask-cors
from Summarization import preprocessamento, sumarizar, sumarizar_lematizacao
from threading import Thread
import json

app = Flask(__name__)
CORS(app)

@app.route("/summy", methods=['POST'])
def summyLuhn():
    text = str(request.json["text"])
    qnt_linhas = int(request.json["qnt"])
    #new_text = text['new_text']
    topWords = 5
    distancia = 5
    summy = sumarizar_lematizacao(text,topWords,distancia,qnt_linhas)
    return json.dumps({"Text":summy})
    #return jsonify(summy)

@app.route("/word", methods=['POST'])
def word():
    text = json.loads(request.data)
    new_text = text['new_text']
    wordcloud(new_text)
    return {"summy":"A imagem foi salva"}

@app.route("/teste", methods=['GET','POST'])
def teste():
    teste = "OK"
    return json.dumps({"Text":teste})


if __name__ == '__main__':
    app.run(debug=True)

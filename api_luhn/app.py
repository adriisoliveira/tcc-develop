from flask import Flask, jsonify, request
from Summarization import preprocessamento, sumarizar, sumarizar_lematizacao
import json

app = Flask(__name__)

@app.route("/summy", methods=['POST'])
def summyLuhn():
    text = json.loads(request.data)
    qnt = json.loads(request.data)
    top = json.loads(request.data)
    dist = json.loads(request.data)
    qnt_linhas = qnt['qnt_linhas']
    new_text = text['new_text']
    topWords = top['topWords']
    distancia = dist['distancia']
    summy = sumarizar_lematizacao(new_text,topWords,distancia,qnt_linhas)
    return {"Text":summy}


if __name__ == '__main__':
    app.run(debug=True)
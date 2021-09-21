from flask import Flask, jsonify, request
from Summarization import preprocessamento, sumarizar, sumarizar_lematizacao
import json

app = Flask(__name__)

@app.route("/summy", methods=['POST'])
def summy():
    text = json.loads(request.data)
    qnt = json.loads(request.data)
    qnt_linhas = qnt['qnt_linhas']
    new_text = text['new_text']
    summy = sumarizar_lematizacao(new_text, qnt_linhas)
    return {"summy":summy}


if __name__ == '__main__':
    app.run(debug=True)
#!/usr/bin/python3

from flask import Flask, request, jsonify

app = Flask(__name__)

@app.route("/api/transaction",methods=["POST"])
def transacao():
    response = {"aprovado":True,"novoLimite":10}
    return jsonify(response)

if __name__ == '__main__':
    app.run(debug=True)
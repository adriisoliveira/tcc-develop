from flask import Flask, jsonify, request
from Process import wordcloud
import json

app = Flask(__name__)

@app.route("/word", methods=['POST'])
def word():
    text = json.loads(request.data)
    new_text = text['new_text']
    wordcloud(new_text)
    return {"summy":"A imagem foi salva"}

if __name__ == '__main__':
    app.run(debug=True)
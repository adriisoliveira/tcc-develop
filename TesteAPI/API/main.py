from fastapi import FastAPI

from pydantic import BaseModel

app = FastAPI()

#Rota Raiz
@app.get("/")
def raiz():
  return{"Ola":"Mundo"}

#Criar Model

#Criar base de dados

#Rota get All

#Rota Get ID

#Rota Insere
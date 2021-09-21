#!/usr/bin/python3

import os
import tempfile

import pytest

from app import app

@pytest.fixture
def client():
    app.config['TESTING'] = True
    client = app.test_client()

    yield client

def test_valid_transaction(client):
    card = {
            "status": True,
            "number":123456,
            "limit":1000,
            "transaction":{
                "amount":500
            }
        }
    rv = client.post("/api/transaction",json=card)    
    assert  True == rv.get_json().get("aprovado")    
    assert  500 == rv.get_json().get("novoLimite")

def test_above_limit(client):
    card = {
            "status": True,
            "number":123456,
            "limit":1000,
            "transaction":{
                "amount":1500
            }
        }
    rv = client.post("/api/transaction",json=card)    
    assert  False == rv.get_json().get("aprovado")
    assert  "Compra acima do limite" in rv.get_json().get("motivo")

def test_blocked_card(client):
    card = {
            "status": False,
            "number":123456,
            "limit":1000,
            "transaction":{
                "amount":500
            }
        }
    rv = client.post("/api/transaction",json=card)    
    assert  False == rv.get_json().get("aprovado")
    assert  "Cartao bloqueado" in rv.get_json().get("motivo")
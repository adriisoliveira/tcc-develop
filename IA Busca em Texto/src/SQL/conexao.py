import pymysql

def conexaoBanco():
  conexao = pymysql.connect(host='localhost', user='root', passwd='bahia', db='indice', autocommit = True)
  return conexaoBanco
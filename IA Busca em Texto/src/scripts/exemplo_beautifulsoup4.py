from bs4 import BeautifulSoup
import urllib3

#desativar warnings
urllib3.disable_warnings(urllib3.exceptions.InsecureRequestWarning())
http = urllib3.PoolManager()
#pagina = http.request('GET', 'http://iaexpert.com.br')
pagina = http.request('GET', 'https://pt.wikipedia.org/wiki/Linguagem_de_programa%C3%A7%C3%A3o')

#todos os dados da página
sopa = BeautifulSoup(pagina.data,"lxml")

#print(sopa)
print(sopa.title)
print(sopa.title.string)

links = sopa.find_all('a')
print (links)
len(links)

for link in links:
    print(link.get('href'))
    print(link.contents)
import requests
import pandas as pd
import random
import string

def pop_veiculos(qtde):

    url = "http://localhost:5097/api/Veiculo"
    data = pd.read_csv("documentos/Dados carro.csv")
    print(data.head())

    for i in range (0,qtde):

        input = { "numeroChassi" : str(random.randrange(1 , 9)) + "BR" + "".join(random.choices(string.ascii_uppercase, k=7)) + "0" + str(random.randrange(999999)),
                "marca" : data['car'][i],
                "modelo" : data['model'][i],
                "ano" : int(2022 - data['age'][i]),
                "cor" : random.choice(['Branco', 'Preto', 'Vermelho', 'Azul', 'Prata']),
                "valor" : float(data['price'][i])*(1.25 + random.random()),
                "quilometragem" : int(data['mileage'][i]*1000),
                "acessorios" : random.choice(['ar-condicionado', 'som', 'radio bluetooth', 'teto solar']),
                "versaoSistema" : str(random.randrange(1 , 9)) + "." + str(random.randrange(9)) + "." + str(random.randrange(9)),
                "motor" : round(data['engV'][i], 1),
                "proprietarioID" : random.randrange(1 , 20),
                "vendedorId" : random.randrange(1 , 20)
                }

        #print(input)
        r = requests.post(url, json=input, verify=False)
        print(r.text)


def pop_proprietarios(qtde):

    url = "http://localhost:5097/api/Proprietario"

    for i in range (0, qtde):

        nome = str(random.choice(["Jose","Vinicius","Matheus","Nicolas","Mark","Vilmar","Maria","Amanda","Marina","Debora","Ana","Gabriela",'Vanessa','Rochelle','Marta','Joana','Bianca','Dyanna','Darlene','Erica','Leonardo','Francisco','Ricardo','Adriana']))
        sobrenome = str(random.choice(["Silva","Souza","De Toni","Oliveira","Rodrigues","Machado","Melim","Pereira","Django","Flask"," de Castela","Boehm", "Moberg", "Vicente", "Martinez","Schubert","Wagner","Chopin","Brahms","Docker","DockerHub","Jupyter","Laravel","NodeJS"]))
        pessoa_juridica = random.randint(0,1)
        if pessoa_juridica == 1:
            doc = str(random.randrange(99999999999999)) # CNPJ
        else:
            doc = str(random.randrange(99999999999)) # CPF

        input = {
                "nome": nome + " " + sobrenome,
                "cpfCnpj": doc,
                "enderecoCidade": random.choice(['Curitiba', 'Campo Largo', 'Colombo', 'Sao Jose dos Pinhais', 'Rio de Janeiro', 'Sao Paulo','Manaus','Porto Alegre','Balneario Camboriu']),
                "enderecoRua": "Rua " + random.choice(['Coronel Marcos', '7° de Setembro', 'da Independencia', 'Sao Joao', 'Egon Schmitt', ' Maria Mariguazzo','Brasil', 'Paraguai', 'Roma', 'Albina de Lorena']),
                "enderecoNumero": random.randint(10, 9999),
                "email": nome.lower() + sobrenome.lower() + "@" + random.choice(["gmail","hotmail","outlook"]) + ".com"
                }

        #print(input)
        r = requests.post(url, json=input, verify=False)
        print(r.text)

def pop_vendedores(qtde):

    url = "http://localhost:5097/api/Vendedor"

    for i in range (0, qtde):

        nome = random.choice(["Henrique","Miguel","Pedro","Thiago","Sophia","Alice","Laura","Isabella","Hanna","Rayane","Amadeus","Mario","Thomas","Ludwig", "Jonas","John","Pablo","Manuel","Carlos","Otto","Rodolfo"])
        sobrenome = random.choice(["Carvalho","Almeida","Amarante","Bianchi","da Fonseca","Figueira","Lopez","Underberg","Tchaikovski", "Beethoven","Mozart","Newton","Euler","Laplace","Lagrange","Moore"])
        input = {
                "nome": nome + " " + sobrenome,
                "salario": random.randint(1212, 3000) + round(random.random(), 2)
                }

        #print(input)
        r = requests.post(url, json=input, verify=False)
        print(r.text)

pop_proprietarios(20)
pop_vendedores(20)
pop_veiculos(50)

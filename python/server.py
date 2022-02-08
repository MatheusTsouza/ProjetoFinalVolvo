import socket
import modelo

HOST = 'localhost'
PORT = 50000

s = socket.socket(socket.AF_INET, socket.SOCK_STREAM)
s.bind((HOST,PORT))
s.listen()
print("aguardando")
conn, ender = s.accept()
print("conectado",ender)

while True:
    data = conn.recv(1024)

    a = data.decode()
    b = a.split(";")

    quilometragem = b[0]
    ano = b[1]
    valor = b[2]



    preco = modelo.predizer(quilometragem,ano,valor,"Volkswagen")
    preco = str(preco)

    if not data:
        print('fechando conexão')
        conn.close()
        break
    conn.sendall(str.encode(preco))

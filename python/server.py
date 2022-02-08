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

    decoded_data = data.decode()
    values = decoded_data.split(";")

    quilometragem = values[0]
    ano = values[1]
    motor = values[2]
    marca = values[3]

    preco = modelo.predizer(quilometragem, ano, motor, marca)
    preco = str(preco)

    if not data:
        print('fechando conexao')
        conn.close()
        break
    conn.sendall(str.encode(preco))

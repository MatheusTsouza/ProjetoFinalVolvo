import pandas as pd
import joblib
import datetime

#colunas = x_train.columns.to_list()
data = {'mileage': [0.0],
        'age': [0.0],
        'engV': [0.0],
        'car_Acura': [0.0],
        'car_Alfa Romeo': [0.0],
        'car_Aro': [0.0],
        'car_Audi': [0.0],
        'car_BMW': [0.0],
        'car_BYD': [0.0],
        'car_Bogdan': [0.0],
        'car_Buick': [0.0],
        'car_Chery': [0.0],
        'car_Chevrolet': [0.0],
        'car_Chrysler': [0.0],
        'car_Citroen': [0.0],
        'car_Dacia': [0.0],
        'car_Dadi': [0.0],
        'car_Daewoo': [0.0],
        'car_Daihatsu': [0.0],
        'car_Dodge': [0.0],
        'car_FAW': [0.0],
        'car_Fiat': [0.0],
        'car_Ford': [0.0],
        'car_GAZ': [0.0],
        'car_GMC': [0.0],
        'car_Geely': [0.0],
        'car_Great Wall': [0.0],
        'car_Groz': [0.0],
        'car_Hafei': [0.0],
        'car_Honda': [0.0],
        'car_Huanghai': [0.0],
        'car_Hyundai': [0.0],
        'car_Infiniti': [0.0],
        'car_Isuzu': [0.0],
        'car_JAC': [0.0],
        'car_Jaguar': [0.0],
        'car_Jeep': [0.0],
        'car_Kia': [0.0],
        'car_Land Rover': [0.0],
        'car_Lexus': [0.0],
        'car_Lifan': [0.0],
        'car_Lincoln': [0.0],
        'car_MG': [0.0],
        'car_MINI': [0.0],
        'car_Mazda': [0.0],
        'car_Mercedes-Benz': [0.0],
        'car_Mercury': [0.0],
        'car_Mitsubishi': [0.0],
        'car_Nissan': [0.0],
        'car_Opel': [0.0],
        'car_Peugeot': [0.0],
        'car_Porsche': [0.0],
        'car_Renault': [0.0],
        'car_Rover': [0.0],
        'car_Saab': [0.0],
        'car_Samand': [0.0],
        'car_Samsung': [0.0],
        'car_Seat': [0.0],
        'car_Skoda': [0.0],
        'car_Smart': [0.0],
        'car_SsangYong': [0.0],
        'car_Subaru': [0.0],
        'car_Suzuki': [0.0],
        'car_TATA': [0.0],
        'car_Toyota': [0.0],
        'car_UAZ': [0.0],
        'car_VAZ': [0.0],
        'car_Volkswagen': [0.0],
        'car_Volvo': [0.0],
        'car_ZAZ': [0.0],
        'car_ZX': [0.0],
        'car_??UAZ': [0.0]
        }

def predizer(quilometragem, ano, engV, marca):
    quilometragem = float(quilometragem)
    ano = int(ano)

    if "." in engV:
        engV = float(engV)
    elif "," in engV:
        engV = engV.replace(",",".")
        engV = float(engV)
    quilometragem = quilometragem/1000 # Converte para k
    idade = datetime.date.today().year - ano # Calcula a idade do carro

    data['mileage'] = quilometragem
    data['age'] = idade
    data['engV'] = engV
    data['car_' + marca] = 1
    input = pd.DataFrame(data)
    predicao = model.predict(input)
    return predicao[0]

model = joblib.load("python/modelo_preco_carro.joblib")
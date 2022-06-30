from suds import client
from suds.client import Client
from suds.xsd.doctor import Import, ImportDoctor
imp=Import('http://www.w3.org/2001/XMLSchema',location='http://www.w3.org/2001/XMLSchema.xsd')
imp.filter.add('http://tempuri.org/')
url = "https://localhost:44398/ValidarUsuarios.asmx?wsdl"
client = Client(url, doctor=ImportDoctor(imp))

def login(email, psw):
    validado = client.service.ValidarUsuario(email,psw)
    return validado
import sys
from logging import root
from suds import client
from suds.client import Client
from suds.xsd.doctor import Import, ImportDoctor
from Historial import HistorialC


imp=Import('http://www.w3.org/2001/XMLSchema',location='http://www.w3.org/2001/XMLSchema.xsd')
imp.filter.add('http://tempuri.org/')
url = "https://localhost:44356/WSHistorial.asmx?wsdl"
client = Client(url, doctor=ImportDoctor(imp))

def dHistorial(email):
    datos = client.service.BuscarCli(email)
    hs = HistorialC(datos.diffgram[0].Table.ID_REPARACION, datos.diffgram[0].Table.ID_DISPOSITIVO, datos.diffgram[0].Table.RUT_CLIENTE, datos.diffgram[0].Table.CLINOM, datos.diffgram[0].Table.RUT_ADMIN, datos.diffgram[0].Table.ADMINOM, datos.diffgram[0].Table.DESCRIPCION, datos.diffgram[0].Table.ESTADO, datos.diffgram[0].Table.ID_FASE )
    return hs
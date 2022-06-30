from logging import root
from suds import client
from suds.client import Client
from suds.xsd.doctor import Import, ImportDoctor
from OrdenCompra import OrdenCompra


imp=Import('http://www.w3.org/2001/XMLSchema',location='http://www.w3.org/2001/XMLSchema.xsd')
imp.filter.add('http://tempuri.org/')
url = "https://localhost:44356/WSHistorial.asmx?wsdl"
client = Client(url, doctor=ImportDoctor(imp))

def OrdenC(id_historial):
    datos = client.service.BuscarOrden(id_historial)
    Orden = OrdenCompra(datos.diffgram[0].Table.ORDEN_COMPRA, datos.diffgram[0].Table.SESION, datos.diffgram[0].Table.PRECIO, datos.diffgram[0].Table.ID_REPARACION)
    return Orden

def OrdenP(id_historial):
    Pagada = client.service.OrdenPagada(id_historial)
    return Pagada
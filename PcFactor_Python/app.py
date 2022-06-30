from flask import Flask, render_template, flash, request, redirect,url_for, session
from flask import render_template, request, Flask
from transbank.error.transbank_error import TransbankError
from transbank.webpay.webpay_plus.transaction import Transaction
import WSLogin
import WSHistorial
import WSOrdenCompra

correo = ""
datos = ""
app = Flask(__name__)
app.secret_key = "thisisaencryptedmessage"

@app.route('/')
def home():
    return render_template('index.html')

@app.route('/login', methods =["POST","GET"])
def login():
    if request.method == "POST":
        user = request.form["correo"]
        psswd = request.form["password"]
        validado = WSLogin.login(user,psswd)
        if validado == 3:
            session["user"] = user
            return homeLog()
        else:
            print("Error")
    return render_template('login.html')    

@app.route('/home')
def homeLog():
    return render_template('ingresado.html')
    
@app.route('/registro')
def registro():
    return render_template('registro.html')   

@app.route("/historial")
def historial():
    datos = WSHistorial.dHistorial(session["user"])
    datos2 = WSOrdenCompra.OrdenC(datos.Id_Dispo)
    buy_order = datos2.Orden
    session_id = datos2.Sesion
    amount = datos2.Precio
    return_url = request.url_root + '/commit'

    create_request = {
        "buy_order": buy_order,
        "session_id": session_id,
        "amount": amount,
        "return_url": return_url
    }

    response = Transaction.create(buy_order, session_id, amount, return_url)
    return render_template('Estado.html', historialCli = datos, request=create_request, response=response)

@app.route("/commit", methods=["POST"])
def webpay_plus_commit():
    token = request.form.get("token_ws")
    response = Transaction.commit(token=token)
    datos = WSHistorial.dHistorial(session["user"])
    WSOrdenCompra.OrdenP(datos.Id_Dispo)
    print(datos.Id_Dispo)

    return render_template('commit.html', token=token, response=response)

if __name__ == '__main__':
    app.run(debug=True)
from simple_salesforce import Salesforce
from flask import Flask, request

app = Flask(__name__)

@app.route('/', methods=['POST'])
def UploadData():
    # Salesforce Authentication Values
    username = request.form.get("username")
    password = request.form.get("password")
    token = request.form.get("token")

    # Item Data Values
    organization = request.form.get("organization")
    item_sum = request.form.get("sum")

    sf = Salesforce(
        username=username,
        password=password,
        security_token=token
    )

    acquisition_values = {
        "Account__c": organization,
        "Weight__c": item_sum,
        "Tapin_Expense__c": "0"
    }

    sf.Acquisition__c.create(acquisition_values)

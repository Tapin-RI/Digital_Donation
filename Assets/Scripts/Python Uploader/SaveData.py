from simple_salesforce import Salesforce
import csv
import os

# Anonymous Account ID: 0013h00000QYlflAAD

directory = os.getcwd()

username = ""
password = ""
token = ""

with open(directory + "\\Assets\\Scripts\\Python Uploader\\Creds.csv") as csvfile:
    reader = csv.reader(csvfile)

    items = list(reader)

    username = items[0][0]
    password = items[0][1]
    token = items[0][2]

sf = Salesforce(
    username=username,
    password=password,
    security_token=token
)

acquisition_values = {
    "Account__c": "0013h00000QYlflAAD",
    "Weight__c": "100",
    "Tapin_Expense__c": "0"
}

sf.Acquisition__c.create(acquisition_values)

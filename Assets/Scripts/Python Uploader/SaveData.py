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

    sf = Salesforce(
        username=items[0][0],
        password=items[0][1],
        security_token=items[0][2]
    )

with open(directory + "\\Assets\\SAVE_DATA\\export.csv") as csvfile:
    reader = csv.reader(csvfile)
    items = list(reader)

    org_name = items[0][0]
    weight_sum = 0

    for i in range(1, len(items[0])):
        weight_sum += float(items[0][i])

    acquisition_values = {
        "Account__c": org_name,
        "Weight__c": weight_sum,
        "Tapin_Expense__c": "0"
    }

    sf.Acquisition__c.create(acquisition_values)

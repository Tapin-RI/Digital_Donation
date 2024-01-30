import os
import csv

directory = os.getcwd()

rows = []

org_name = ""
item_values = []

with open(directory + "\\Assets\\SAVE_DATA\\export.csv", "r", newline="", encoding="UTF-8") as file:
    reader = csv.reader(file)
    rows = list(reader)
    
org_name = rows[0][0]

for i in range(1, len(rows) - 1):
    item_values.append(rows[i][0])

print(org_name)
print(item_values)

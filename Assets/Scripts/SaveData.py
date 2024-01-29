import os
import csv

directory = os.getcwd()

print(directory)

with open(directory + "\\test.csv", "w", newline="") as file:
    print("Hello, World!")
    writer = csv.writer(file)
    writer.writerow(["Test Test 123"])

import os
import sys
import json


args = sys.argv[1:]
version = ""

model_json = args[0]
with open(model_json, "r") as jsonFile:
    data = json.load(jsonFile)
    version = data['info']['version']


print(version)
version = version.replace('v', '')


config_file = os.path.join(os.getcwd(), '.openapi-generator', 'config.json')

with open(config_file, "r") as jsonFile:
    config_data = json.load(jsonFile)

config_data["packageVersion"] = version

with open(config_file, "w") as jsonFile:
    json.dump(config_data, jsonFile, indent=4)


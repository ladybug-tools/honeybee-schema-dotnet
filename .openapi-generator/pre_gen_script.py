import os
import urllib.request, json

version = os.getenv('VERSION')

version = version.replace('v', '')

print(version)

config_file = os.path.join(os.getcwd(),'.openapi-generator','config.json')

with open(config_file, "r") as jsonFile:
    config_data = json.load(jsonFile)

config_data["packageVersion"] = version

with open(config_file, "w") as jsonFile:
    json.dump(config_data, jsonFile, indent=4)
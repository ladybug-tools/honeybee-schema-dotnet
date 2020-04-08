import os
import sys
import urllib.request
import json


args = sys.argv[1:]
version = ""

if args == []:
    source_json_url = "https://www.ladybug.tools/honeybee-schema/model.json"
    json_url = urllib.request.urlopen(source_json_url)
    data = json.loads(json_url.read())
    version = data['info']['version'][0]
else:
    version = args[0]

print(version)
version = version.replace('v', '')


config_file = os.path.join(os.getcwd(), '.openapi-generator', 'config.json')

with open(config_file, "r") as jsonFile:
    config_data = json.load(jsonFile)

config_data["packageVersion"] = version

with open(config_file, "w") as jsonFile:
    json.dump(config_data, jsonFile, indent=4)



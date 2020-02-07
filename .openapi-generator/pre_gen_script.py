import os
import urllib.request, json

source_json_url = "https://www.ladybug.tools/honeybee-schema/model.json"

json_url = urllib.request.urlopen(source_json_url)
data = json.loads(json_url.read())
version = data['info']['version']
print(version)

config_file = os.path.join(os.getcwd(),'.openapi-generator','config.json')

with open(config_file, "r") as jsonFile:
    config_data = json.load(jsonFile)

config_data["packageVersion"] = version

with open(config_file, "w") as jsonFile:
    json.dump(config_data, jsonFile, indent=4)
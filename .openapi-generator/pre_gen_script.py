import os
import sys
import json
import shutil


args = sys.argv[1:]
version = ""

model_json = args[0]
with open(model_json, "r") as jsonFile:
    data = json.load(jsonFile)
    version = data['info']['version']


print(version)
version = version.replace('v', '')


config_file = os.path.join(os.getcwd(), 'openapi-config.json')

with open(config_file, "r") as jsonFile:
    config_data = json.load(jsonFile)

config_data["packageVersion"] = version
package_name = config_data["packageName"]

with open(config_file, "w") as jsonFile:
    json.dump(config_data, jsonFile, indent=4)


def cleanup(projectName):
    root = os.path.dirname(os.path.dirname(__file__))
    # remove docs
    target_folder = os.path.join(root, 'docs')
    if os.path.exists(target_folder):
        shutil.rmtree(target_folder)
    # remove Model folder
    target_folder = os.path.join(root, 'src', projectName, 'Model')
    if os.path.exists(target_folder):
        shutil.rmtree(target_folder)
    # remove interface
    target_folder = os.path.join(root, 'src', projectName, 'interface')
    if os.path.exists(target_folder):
        shutil.rmtree(target_folder)


cleanup(package_name)

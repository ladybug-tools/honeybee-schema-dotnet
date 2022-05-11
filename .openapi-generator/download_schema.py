import os
import urllib.request
import json
import shutil
import sys


def download(url, dir):
    json_url = urllib.request.urlopen(url)
    data = json.loads(json_url.read())

    json_file = os.path.basename(url)
    save_path = os.path.join(dir, json_file)
    print(f'Saving {json_file} to {save_path}')

    with open(save_path, "w") as j:
        json.dump(data, j, indent=4)


args = sys.argv[1:]
if args == []:
    base_url = "https://www.ladybug.tools/honeybee-schema"
else:
    base_url = f"https://github.com/ladybug-tools/honeybee-schema/releases/download/{args[0]}"  # v1.17.0

# base_url = "https://www.ladybug.tools/honeybee-schema"


saving_dir = os.path.join(os.getcwd(), '.openapi-docs')
# clean up the folder
if os.path.exists(saving_dir):
    shutil.rmtree(saving_dir)
os.mkdir(saving_dir)


# model
json_file1 = f"{base_url}/model_inheritance.json"
# simulation-parameter
json_file2 = f"{base_url}/simulation-parameter_inheritance.json"
# validation report
json_file3 = f"{base_url}/validation-report.json"

files = [
    json_file1,
    json_file1.replace("inheritance.json", "mapper.json"),
    json_file2,
    json_file2.replace("inheritance.json", "mapper.json"),
    json_file3
    ]

for f in files:
    download(f, saving_dir)

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


saving_dir = os.path.join(os.getcwd(), '.openapi-docs')
# clean up the folder
if os.path.exists(saving_dir):
    shutil.rmtree(saving_dir)
os.mkdir(saving_dir)

base_url = "https://www.ladybug.tools/honeybee-schema"

args = sys.argv[1:]
if args != []:
    base_url = args[0] 


# downlaod model
json_file = f"{base_url}/model_inheritance.json"
download(json_file, saving_dir)

# download model mapper
mapper_json = json_file.replace("inheritance.json", "mapper.json")
download(mapper_json, saving_dir)

# downlaod simulation-parameter
json_file = f"{base_url}/simulation-parameter_inheritance.json"
download(json_file, saving_dir)

# download simulation-parameter mapper
mapper_json = json_file.replace("inheritance.json", "mapper.json")
download(mapper_json, saving_dir)

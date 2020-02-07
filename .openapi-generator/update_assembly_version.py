import re, os, json

config_file = os.path.join(os.getcwd(),'.openapi-generator','config.json')

with open(config_file, "r") as jsonFile:
    config_data = json.load(jsonFile)

schema_version = config_data["packageVersion"]

assembly_file = os.path.join(os.getcwd(),'src', 'HoneybeeDotNet', 'Properties','AssemblyInfo.cs')

with open(assembly_file, "r") as csFile:
    s = csFile.read()
with open(assembly_file, 'w') as f:
    s = re.sub("\d+\.?\d+\.?\d+\.?\*", schema_version + '.*' , s)
    f.write(s)

import re
import os
import json
import urllib.request
import subprocess 


# Check the version from config
config_file = os.path.join(os.getcwd(), '.openapi-generator', '.openapi-config.json')
with open(config_file, "r") as jsonFile:
    config_data = json.load(jsonFile)

schema_version = config_data["packageVersion"]
print(f'Schema_version: {schema_version}')
new_version = f'{schema_version}.0'

package_name = config_data["packageName"]

# Check the version from nuget
api = f'https://api.nuget.org/v3-flatcontainer/{package_name.lower()}/index.json'
with urllib.request.urlopen(api) as r:
    data = json.loads(r.read())
    versions = data['versions']
    if versions != []:
        new_version = versions[-1]
        print(f'Found latest version on Nuget: {new_version}')


# increment version
version_digits = new_version.split('.')


print(len(version_digits))
if len(version_digits) == 3:
    new_version = f'{new_version}.1'
elif version_digits[-1] != '0':
    v = int(version_digits[-1]) + 1
    version_digits = version_digits[0:-1]
    version_digits.append(str(v))
    new_version = '.'.join(version_digits)



print(f'New version: {new_version}')


# update the version
assembly_file = os.path.join(os.getcwd(), 'src', package_name, f'{package_name}.csproj')

with open(assembly_file, encoding='utf-8', mode='r') as csFile:
    s = csFile.read()
with open(assembly_file, encoding='utf-8', mode='w') as f:
    s = re.sub(r"(?<=\SVersion\>)\S+(?=\<\/)", new_version, s)
    print(f"Update AssemblyVersion to: {new_version}")
    f.write(s)


import json
import re
import os


def replace_global_defaults(source_json, resource_file):
    with open(source_json, "rb") as jsonFile:
        data = json.load(jsonFile)

    # interfaces = {}
    schema_objs = data['components']['schemas']

    # GlobalConstructionSet
    schema_globalConstructionSet = schema_objs['GlobalConstructionSet']['allOf'][1]['properties']
    globalConstructionSet = {}
    for key in schema_globalConstructionSet.keys():
        globalConstructionSet[key] = schema_globalConstructionSet[key]['default']

    # GlobalModifierSet
    schema_globalModifierSet = schema_objs['GlobalModifierSet']['allOf'][1]['properties']
    globalModifierSet = {}
    for key in schema_globalModifierSet.keys():
        globalModifierSet[key] = schema_globalModifierSet[key]['default']

    # print(json.dumps(globalConstructionSet))
    add_to_csharp_resource(resource_file, json.dumps(globalConstructionSet), json.dumps(globalModifierSet))


def add_to_csharp_resource(resource_file, globalConstructionSet, globalModifierSet):
    f = open(resource_file, "rt", encoding='utf-8')
    data = f.read()
    f.close()

    # add GlobalConstructionSet
    data = replace_resource(data, 'GlobalConstructionSet', globalConstructionSet)
    # add GlobalModifierSet
    data = replace_resource(data, 'GlobalModifierSet', globalModifierSet)
    
    f = open(resource_file, "wt", encoding='utf-8')
    f.write(data)
    f.close()


def replace_resource(data, name, new_data):
    rex = f'<data name="{name}" xml:space="preserve">[^\n]+\<\/value><\/data>\n'
    replace_new = f'<data name="{name}" xml:space="preserve"><value>{new_data}</value></data>\n'
    data = re.sub(rex, replace_new, data)
    return data


def fix_cs_files(src_folder):
    files = ['ModelEnergyProperties.cs', 'ModelRadianceProperties.cs']

    for f in files:
        f = os.path.join(src_folder, f)
        fix_model_properties(f)


def fix_model_properties(cs_file):
    f = open(cs_file, "rt", encoding='utf-8')
    data = f.read()
    f.close()
    # GlobalConstructionSet
    rex = r'public GlobalConstructionSet GlobalConstructionSet { get; protected set; } '
    replace_new = r'public GlobalConstructionSet GlobalConstructionSet { get; protected set; } = GlobalConstructionSet.Default;'
    data = re.sub(rex, replace_new, data)
    # GlobalConstructionSet
    rex = r'public GlobalModifierSet GlobalModifierSet { get; protected set; } '
    replace_new = r'public GlobalModifierSet GlobalModifierSet { get; protected set; } = GlobalModifierSet.Default;'
    data = re.sub(rex, replace_new, data)

    f = open(cs_file, "wt", encoding='utf-8')
    f.write(data)
    f.close()
    return data


json_file = r'.openapi-docs/model_inheritance.json'
resource_file = r'src/HoneybeeSchema/Resource.resx'
src_folder = r'src/HoneybeeSchema/Model'
replace_global_defaults(json_file, resource_file)
fix_cs_files(src_folder)

import os
import sys
import json
import shutil
import re
import time


def get_package_name():
    config_file = os.path.join(os.getcwd(), 'openapi-config.json')
    with open(config_file, "r") as jsonFile:
        config_data = json.load(jsonFile)

    package_name = config_data["packageName"]
    return package_name


def get_allof_types(obj, allofList):

    if isinstance(obj, (str, float, int)):
        return

    if 'anyOf' in list(obj.keys()):
        uitems = []
        for uitem in obj['anyOf']:
            typeKeys = uitem.keys()
            if '$ref' in typeKeys:
                ref_type = uitem['$ref'].split('/')[-1]
                uitems.append(ref_type)
            elif 'type' in typeKeys:
                value_type = uitem['type']
                uitems.append(value_type)
        allofList.append(uitems)
    else:
        for vv in obj.values():
            if type(vv) == dict:
                get_allof_types(vv, allofList)
            elif type(vv) == list:
                for item in vv:
                    get_allof_types(item, allofList)


def fix_constructor(read_data):
    regexs = [
        r"(?<=(\w|\d)),\s*,\s*(?=\w)",
        r"(?<=\(\n\s{12})\s*(,)(?=\s\w*.*, \/\/ Required parameters)", # remove "," at begining of required
        r"(?<=\/\/ Required parameters\n\s{12})(,\s){1,}(?=\s*\w)",      # remove "," at begining of optional
        r"(?<=\w)(,\s){2,}(?=\s*\/\/ Required parameters\s*\n\s*(\w|,))",
        r"(,\s)+(?=\s*\/\/ Optional parameters)",
        r"(,\s)+(?=\s*\/\/ Required parameters\n\s+\/\/ Optional parameters)",
        r"(,)(?=\s*\)\/\/ BaseClass)",
        r"(?<=\(\n\s{12})\s*(,)(?=\s*\/\/ Required parameters)"  # remove "," before "//Required parameters" when there is no required
    ]

    replace_new = [
        ", ",
        "",   # remove "," at begining of required
        "",   # remove "," at begining of optional
        ", ",  # remove one comma of in two or more commas before "//Required parameters"
        " ",
        "",   # remove commas before "//Required parameters" when there is no optional perameters
        "",
        ""
    ]
    data = read_data
    for i, rex in enumerate(regexs):
        replace = replace_new[i]
        if re.findall(rex, data) != []:
            data = re.sub(rex, replace, data)
    return data


def get_enums(mapperJson):
    with open(mapperJson, "rb") as jsonFile:
        data = json.load(jsonFile)
        enumItems = data['enums']
        full_enum_names = []
        for key in enumItems.keys():
            name_space = enumItems[key].title().replace('_', '', 1).split('.')[0]
            full_enum_name = f"{name_space}.{key}" #HoneybeeSchema.Roughness
            full_enum_names.append(full_enum_name)

    return full_enum_names


def replace_decimal(read_data):
    data = read_data
    replace_source = ['decimal', '1M', '2M', '3M', '4M', '5M', '6M', '7M', '8M', '9M', '0M']
    replace_new = ['double', '1', '2', '3', '4', '5', '6', '7', '8', '9', '0']
    for s, n in zip(replace_source, replace_new):
        data = data.replace(s, n)
    print("|---Replacing %s to %s" % ('decimal', 'double'))
    return data


def replace_AnyType(read_data):
    data = read_data
    replace_source = ['AnyType']
    replace_new = ['object']
    for s, n in zip(replace_source, replace_new):
        data = data.replace(s, n)
    print("|---Replacing %s to %s" % ('AnyType', 'object'))
    return data
    

def replace_anyof_type(read_data, anyof_types):
    data = read_data
    for items in anyof_types:
        if len(items) > 0:
            replace_source = "AnyOf%s" % ("".join(items).replace('number', 'double'))
            replace_new = "AnyOf<%s>" % (",".join(items).replace('number', 'double'))
            rex = "(%s)(?=[ >])" % replace_source # find replace_source only with " "(space) or ">" follows
            if re.findall(rex, data) != []:
                data = re.sub(rex, replace_new, data)
                print("|---Replacing %s to %s" % (replace_source, replace_new))
    return data


def check_csfiles(source_folder, anyof_types):
    # go through all files and replce AnyOf types

    class_files = [x for x in os.listdir(source_folder) if x.endswith(".cs")]


    for f in class_files:
        cs_file = os.path.join(source_folder, f)
        # remove enum file
        class_name = f"{f.split('/')[-1].replace('.cs','')}"

        print("\n-Checking %s" % cs_file)
        # read data
        f = open(cs_file, "rt", encoding='utf-8')
        data = f.read()
        # take care of anyof type
        data = replace_anyof_type(data, anyof_types)
        data = replace_AnyType(data)
        # replace decimal/number to double
        # data = replace_decimal(data)
        data = fix_constructor(data)
        f.close()

        # save data
        f = open(cs_file, "wt", encoding='utf-8')
        f.write(data)
        f.close()


def get_allof_types_from_json(source_json_url):
    # load schema json, and get all union types
    unitItem = []

    with open(source_json_url, "rb") as jsonFile:
        data = json.load(jsonFile)

    for sn, sp in data['components']['schemas'].items():
        if 'properties' in sp:
            props = sp['properties']
        elif 'allOf' in sp:
            all_objs = sp['allOf']
            for obj in all_objs:
                if 'properties' in obj:
                    props = obj['properties']
        else:
            # skip enum type
            continue
        get_allof_types(props, unitItem)
    return unitItem


def check_types(source_json_url, mapper_json):
    all_types = get_allof_types_from_json(source_json_url)

    root = os.path.dirname(os.path.dirname(__file__))
    source_folder = os.path.join(root, 'src', name_space, 'Model')
    check_csfiles(source_folder, all_types)


def cleanup(projectName):
    root = os.path.dirname(os.path.dirname(__file__))
    # remove unused test folder
    target_folder = os.path.join(root, 'src', f'{projectName}.Test')
    if os.path.exists(target_folder):
        shutil.rmtree(target_folder)
    # remove Client folder
    target_folder = os.path.join(root, 'src', projectName, 'Client')
    if os.path.exists(target_folder):
        shutil.rmtree(target_folder)
    # remove all *AllOf.cs files
    target_folder = os.path.join(root, 'src', projectName, 'Model')
    class_files = [x for x in os.listdir(target_folder) if x.endswith("AllOf.cs")]
    for f in class_files:
        cs_file = os.path.join(target_folder, f)
        os.remove(cs_file)
    # remove all *AllOf.md files
    docs_folder = os.path.join(root, 'docs')
    print(f"Checking {docs_folder}")
    class_files = [x for x in os.listdir(docs_folder) if x.endswith("AllOf.md")]
    for f in class_files:
        cs_file = os.path.join(docs_folder, f)
        os.remove(cs_file)
 


args = sys.argv[1:]
if args == []:
    raise ValueError("Missing a json path. eg: python3 post_gen_script.py \".openapi-docs/model_inheritance.json\"")
    # json_file = os.path.join(os.getcwd(), '.openapi-docs', 'model.json')
else:
    json_file = args[0]

name_space = get_package_name()
mapper_json = json_file.replace("inheritance.json", "mapper.json")

time.sleep(1)
# clean up first
cleanup(name_space)
print(f"post processing {json_file} with {mapper_json}")

check_types(json_file, mapper_json)

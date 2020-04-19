import os
import sys
import urllib.request
import json
import shutil
import re
import time

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
        r"(,\s*,)(?=\s*\/\/ Required parameters\n\s+\b)",
        r"(,)(?=\s*\/\/ Optional parameters)",
        r"(,)(?=\s*\/\/ Required parameters\n\s+\/\/ Optional parameters)",
        r"(,)(?=\s*\)\/\/ BaseClass)",
        r"(?<=\()(\s*,)(?=\s*\/\/ Required parameters)"
    ]

    replace_new = [
        ",",
        " ",
        "",
        "",
        ""
    ]
    data = read_data
    for i, rex in enumerate(regexs):
        replace = replace_new[i]
        if re.findall(rex, data) != []:
            data = re.sub(rex, replace, data)
    return data


def replace_decimal(read_data):
    data = read_data
    replace_source = ['decimal', '1M', '2M', '3M', '4M', '5M', '6M', '7M', '8M', '9M', '0M']
    replace_new = ['double', '1', '2', '3', '4', '5', '6', '7', '8', '9', '0']
    for s, n in zip(replace_source, replace_new):
        data = data.replace(s, n)
    print("|---Replacing %s to %s" % ('decimal', 'double'))
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
        print("\n-Checking %s" % cs_file)
        # read data
        f = open(cs_file, "rt", encoding='utf-8')
        data = f.read()
        # take care of anyof type
        data = replace_anyof_type(data, anyof_types)
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

    if source_json_url.startswith('https:'):
        json_url = urllib.request.urlopen(source_json_url)
        data = json.loads(json_url.read())
    else:
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
        get_allof_types(props, unitItem)
    return unitItem


def check_anyof_types(source_json_url):
    all_types = get_allof_types_from_json(source_json_url)

    root = os.path.dirname(os.path.dirname(__file__))
    source_folder = os.path.join(root, 'src', 'HoneybeeSchema', 'Model')
    check_csfiles(source_folder, all_types)


def cleanup():
    root = os.path.dirname(os.path.dirname(__file__))
    # remove Client folder
    target_folder = os.path.join(root, 'src', 'HoneybeeSchema', 'Client')
    if os.path.exists(target_folder):
        shutil.rmtree(target_folder)
    # remove all *AllOf.cs files
    target_folder = os.path.join(root, 'src', 'HoneybeeSchema', 'Model')
    class_files = [x for x in os.listdir(target_folder) if x.endswith("AllOf.cs")]
    for f in class_files:
        cs_file = os.path.join(target_folder, f)
        os.remove(cs_file)


args = sys.argv[1:]
if args == []:
    json_file = os.path.join(os.getcwd(), 'model.json')
else:
    json_file = args[0]

time.sleep(3)
cleanup()
print(f"post processing with {json_file}")
check_anyof_types(json_file)





# regex = r"(,\s*,)(?=\s*\/\/ Required parameters\n\s+\b)"
# replace_new = ""

# test_str = ("ndition, AperturePropertiesAbridged properties, string identifier, , // Required parameters\n"
# "            bool isO")

# test_str1 = re.sub(regex, replace_new, test_str)
# print(test_str1)

# test_str2 =fix_constructor(test_str)
# print(test_str2)
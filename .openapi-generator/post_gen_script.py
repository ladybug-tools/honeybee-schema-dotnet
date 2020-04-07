import os, sys
import urllib.request, json
import shutil


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


def replace_decimal(read_data):
    data = read_data
    replace_source = ['decimal', '1M', '2M', '3M', '4M', '5M', '6M', '7M', '8M', '9M', '0M']
    replace_new = ['double', '1', '2', '3', '4', '5', '6', '7', '8', '9', '0']
    for s, n in zip(replace_source, replace_new):
        data = data.replace(s, n)
    print("\n---Replacing %s to %s" % ('decimal', 'double'))
    return data


def replace_anyof_type(read_data, anyof_types):
    data = read_data
    for items in anyof_types:
        if len(items) > 0:
            replace_source = "AnyOf%s" % ("".join(items))
            replace_new = "AnyOf<%s>" % (",".join(items).replace('number', 'double'))
            data = data.replace(replace_source, replace_new)
            print("\n---Replacing %s to %s" % (replace_source, replace_new))
    return data


def check_csfiles(source_folder, anyof_types):
    # go through all files and replce AnyOf types

    class_files = [x for x in os.listdir(source_folder) if x.endswith(".cs")]

    for f in class_files:
        cs_file = os.path.join(source_folder, f)
        print("\n-Checking %s\n" % cs_file)

        # read data
        f = open(cs_file, "rt", encoding='utf-8')
        data = f.read()
        # take care of anyof type
        data = replace_anyof_type(data, anyof_types)
        # replace decimal/number to double
        data = replace_decimal(data)
        f.close()

        # save data
        f = open(cs_file, "wt", encoding='utf-8')
        f.write(data)
        f.close()


def get_allof_types_from_json(source_json_url):
    # load schema json, and get all union types
    unitItem = []

    json_url = urllib.request.urlopen(source_json_url)
    data = json.loads(json_url.read())
    for sn, sp in data['components']['schemas'].items():
        props = sp['properties']
        get_allof_types(props, unitItem)
    return unitItem


def check_anyof_types(source_json_url):
    all_types = get_allof_types_from_json(source_json_url)

    root = os.path.dirname(os.path.dirname(__file__))
    source_folder = os.path.join(root, 'src', 'HoneybeeSchema', 'Model')
    check_csfiles(source_folder, all_types)


def cleanup():
    root = os.path.dirname(os.path.dirname(__file__))
    target_folder = os.path.join(root, 'src', 'HoneybeeSchema', 'Client')
    if os.path.exists(target_folder):
        shutil.rmtree(target_folder)


json_url = sys.argv[1:][0]
cleanup()
print(f"post processing with {json_url}")
check_anyof_types(json_url)


import os
import urllib.request, json


def get_allof_types(obj, allofList):

  if isinstance(obj, (str, float, int)):
    return

  if 'anyOf' in list(obj.keys()):
    uitems =[]
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
        get_allof_types(vv,allofList)
            
      elif type(vv) == list:
        for item in vv:
            get_allof_types(item,allofList)



def replace_anyof_type(file_path, anyof_types):
  f = open(file_path, "rt", encoding='utf-8')
  data = f.read()

  for items in anyof_types:
    replace_source ="AnyOf%s" % ("".join(items))
    replace_new = "AnyOf<%s>" % (",".join(items).replace('number','decimal'))
    data = data.replace(replace_source, replace_new)
  f.close()

  f = open(file_path, "wt", encoding='utf-8')
  f.write(data)
  f.close()

def check_csfiles(source_folder, anyof_types):
  #go through all files and replce AnyOf types

  class_files = [x for x in os.listdir(source_folder) if x.endswith(".cs") ]

  for f in class_files:
    cs_file = os.path.join(source_folder,f)
    print("\n-Checking %s\n" % cs_file)
    replace_anyof_type(cs_file, anyof_types)


def get_allof_types_from_json(source_json_url):
 #load schema json, and get all union types
  unitItem = []

  json_url = urllib.request.urlopen(source_json_url)
  data = json.loads(json_url.read())
  for sn, sp in data['components']['schemas'].items():
    props = sp['properties']
    get_allof_types(props,unitItem)
  return unitItem

def check_anyof_types(source_json_url):
  all_types = get_allof_types_from_json(source_json_url)

  root = os.path.dirname(os.path.dirname(__file__))
  source_folder = os.path.join(root, 'src', 'HoneybeeDotNet', 'Model')
  check_csfiles(source_folder, all_types)


  

# print(unitItem)
# check_anyof_types("https://ladybug-tools-in2.github.io/honeybee-schema/model.json")

import re, os, json


root = os.path.dirname(os.path.dirname(__file__))
source_folder = os.path.join(root, 'src', 'HoneybeeSchema', 'Model')
abridged_file = os.path.join(root, 'src', 'HoneybeeSchema', 'Partial', 'NamedReferenceable.cs')

class_files = [x for x in os.listdir(source_folder) if (x.endswith("Abridged.cs") and not x.endswith("SetAbridged.cs") and not x.endswith("PropertiesAbridged.cs") and not x.endswith("ScheduleRuleAbridged.cs") ) ]



with open(abridged_file, "wt", encoding='utf-8') as abridgeFile:
    data = []
    data.append('namespace HoneybeeSchema\n')
    data.append('{\n')
    for f in class_files:
        type_name = f
        data.append('public partial class %s: INamed {}\n' % f.replace('.cs',''))
    data.append('public partial class ConstructionSetAbridged: INamed{}\n')
    data.append('}')
    abridgeFile.writelines(data)
    abridgeFile.close()

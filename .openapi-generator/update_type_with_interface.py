import re
import os
import json


root = os.path.dirname(os.path.dirname(__file__))
source_folder = os.path.join(root, 'src', 'HoneybeeSchema', 'Model')

# NamedReferenceable
class_files = [x for x in os.listdir(source_folder) if (x.endswith("Abridged.cs") and not x.endswith("SetAbridged.cs") and not x.endswith("PropertiesAbridged.cs") and not x.endswith("ScheduleRuleAbridged.cs"))]
abridged_file = os.path.join(root, 'src', 'HoneybeeSchema', 'BaseClasses', 'NamedReferenceable.cs')
with open(abridged_file, "wt", encoding='utf-8') as abridgeFile:
    data = []
    data.append('namespace HoneybeeSchema\n')
    data.append('{\n')
    for f in class_files:
        type_name = f
        data.append('public partial class %s: IIdentified {}\n' % f.replace('.cs', ''))
    data.append('public partial class ConstructionSetAbridged: IIdentified{}\n')
    data.append('}')
    abridgeFile.writelines(data)
    abridgeFile.close()


# EnergyWindowMaterial
class_files = [x for x in os.listdir(source_folder) if (x.startswith("EnergyWindowMaterial"))]
abridged_file = os.path.join(root, 'src', 'HoneybeeSchema', 'BaseClasses', 'EnergyWindowMaterial.cs')
with open(abridged_file, "wt", encoding='utf-8') as abridgeFile:
    data = []
    data.append('namespace HoneybeeSchema\n')
    data.append('{\n')
    for f in class_files:
        type_name = f
        data.append('public partial class %s: IEnergyWindowMaterial {}\n' % f.replace('.cs', ''))
    data.append('}')
    abridgeFile.writelines(data)
    abridgeFile.close()


# EnergyMaterial
class_files = [x for x in os.listdir(source_folder) if (x.startswith("EnergyMaterial"))]
abridged_file = os.path.join(root, 'src', 'HoneybeeSchema', 'BaseClasses', 'EnergyMaterial.cs')
with open(abridged_file, "wt", encoding='utf-8') as abridgeFile:
    data = []
    data.append('namespace HoneybeeSchema\n')
    data.append('{\n')
    for f in class_files:
        type_name = f
        data.append('public partial class %s: IEnergyMaterial {}\n' % f.replace('.cs', ''))
    data.append('}')
    abridgeFile.writelines(data)
    abridgeFile.close()
import json
import re
import os

regex = r"\"type\": \"number\"(?!,\s*\n\s*\"format)"
replace_new = "\"format\": \"double\", \"type\": \"number\""



json_file = os.path.join(os.getcwd(), 'model.json')

with open(json_file, "r") as csFile:
    s = csFile.read()
with open(json_file, 'w') as f:
    s = re.sub(regex, replace_new, s)
    f.write(s)
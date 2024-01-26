import subprocess
import os
import time


root = os.getcwd()
doc_folder = os.path.join(root, '.openapi-docs')
generator_folder = os.path.join(root, '.openapi-generator')

# '.openapi-docs/model_inheritance.json'
json1 = os.path.join(doc_folder, 'project-information_inheritance.json')


# run openapi tool to generate schema
template = f"{generator_folder}/templates/csharp"
config = f"{generator_folder}/.openapi-config.json"

# npx @openapitools/openapi-generator-cli generate -i ".openapi-docs/simulation-parameter_inheritance.json"  -t ".openapi-generator/templates/csharp" -g csharp -o . --skip-validate-spec -c .openapi-config.json  
# npx @openapitools/openapi-generator-cli generate -i ".openapi-docs/model_inheritance.json"  -t ".openapi-generator/templates/csharp" -g csharp -o . --skip-validate-spec -c .openapi-config.json 
subprocess.call(f"npx @openapitools/openapi-generator-cli generate -i {json1} -t {template} -g csharp -o . --skip-validate-spec -c {config}", shell=True)


# post process files
# python .openapi-generator/post_gen_script.py ".openapi-docs/simulation-parameter_inheritance.json"
# python .openapi-generator/post_gen_script.py ".openapi-docs/model_inheritance.json"
time.sleep(1)
subprocess.call(f"python {generator_folder}/post_gen_script.py {json1}", shell=True)

# update global default
time.sleep(1)
subprocess.call(f"python {generator_folder}/create_global_default.py", shell=True)


json1 = os.path.join(doc_folder, 'project-information_mapper.json')
# python .openapi-generator/create_interface.py ".openapi-docs/simulation-parameter_mapper.json"
# python .openapi-generator/create_interface.py ".openapi-docs/model_mapper.json"
time.sleep(1)
subprocess.call(f"python {generator_folder}/create_interface.py {json1}", shell=True)

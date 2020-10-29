# Install python, java, npm
# Install openapi-generator
#   npm install @openapitools/openapi-generator-cli@cli-4.3.0

# check version
# npx @openapitools/openapi-generator-cli version-manager list
# use 5.0.0

python .openapi-generator/downloadHoneybeeSchema.py
python .openapi-generator/pre_gen_script.py ".openapi-docs/model_inheritance.json"

npx @openapitools/openapi-generator-cli generate -i ".openapi-docs/simulation-parameter_inheritance.json"  -t ".openapi-generator/templates/csharp" -g csharp -o . --skip-validate-spec -c .openapi-generator/config.json  
npx @openapitools/openapi-generator-cli generate -i ".openapi-docs/model_inheritance.json"  -t ".openapi-generator/templates/csharp" -g csharp -o . --skip-validate-spec -c .openapi-generator/config.json 

python .openapi-generator/post_gen_script.py ".openapi-docs/simulation-parameter_inheritance.json"
python .openapi-generator/post_gen_script.py ".openapi-docs/model_inheritance.json"

python .openapi-generator/update_assembly_version.py

python .openapi-generator/create_interface.py ".openapi-docs/simulation-parameter_mapper.json"
python .openapi-generator/create_interface.py ".openapi-docs/model_mapper.json"

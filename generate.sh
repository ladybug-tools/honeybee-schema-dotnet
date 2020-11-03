python3 .openapi-generator/pre_gen_script.py ".openapi-docs/model_inheritance.json"

npx @openapitools/openapi-generator-cli generate -i ".openapi-docs/simulation-parameter_inheritance.json"  -t ".openapi-generator/templates/csharp" -g csharp -o . --skip-validate-spec -c .openapi-config.json  
npx @openapitools/openapi-generator-cli generate -i ".openapi-docs/model_inheritance.json"  -t ".openapi-generator/templates/csharp" -g csharp -o . --skip-validate-spec -c .openapi-config.json 

python3 .openapi-generator/post_gen_script.py ".openapi-docs/simulation-parameter_inheritance.json"
python3 .openapi-generator/post_gen_script.py ".openapi-docs/model_inheritance.json"

python3 .openapi-generator/update_assembly_version.py

python3 .openapi-generator/create_interface.py ".openapi-docs/simulation-parameter_mapper.json"
python3 .openapi-generator/create_interface.py ".openapi-docs/model_mapper.json"

# dotnet build -c Release -f netstandard2.0 src/HoneybeeSchema
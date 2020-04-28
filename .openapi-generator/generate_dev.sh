
python .openapi-generator/pre_gen_script.py
npx openapi-generator generate -i "https://www.ladybug.tools/honeybee-schema/simulation-parameter_inheritance.json"  -t ".openapi-generator/templates/csharp" -g csharp -o . --skip-validate-spec -c .openapi-generator/config.json  
npx openapi-generator generate -i "https://www.ladybug.tools/honeybee-schema/model_inheritance.json"  -t ".openapi-generator/templates/csharp" -g csharp -o . --skip-validate-spec -c .openapi-generator/config.json 
python .openapi-generator/post_gen_script.py "https://www.ladybug.tools/honeybee-schema/simulation-parameter_inheritance.json"
python .openapi-generator/post_gen_script.py "https://www.ladybug.tools/honeybee-schema/model_inheritance.json"
python .openapi-generator/update_assembly_version.py
python .openapi-generator/create_interface.py "https://www.ladybug.tools/honeybee-schema/simulation-parameter_mapper.json"
python .openapi-generator/create_interface.py "https://www.ladybug.tools/honeybee-schema/model_mapper.json"


npx openapi-generator generate -i ".openapi-docs/simulation-parameter_inheritance.json"  -t ".openapi-generator/templates/csharp" -g csharp -o . --skip-validate-spec -c .openapi-generator/config.json  
npx openapi-generator generate -i ".openapi-docs/model_inheritance.json"  -t ".openapi-generator/templates/csharp" -g csharp -o . --skip-validate-spec -c .openapi-generator/config.json 
python .openapi-generator/post_gen_script.py ".openapi-docs/simulation-parameter_inheritance.json"
python .openapi-generator/post_gen_script.py ".openapi-docs/model_inheritance.json"
python .openapi-generator/update_assembly_version.py
python .openapi-generator/create_interface.py ".openapi-docs/simulation-parameter_mapper.json"
python .openapi-generator/create_interface.py ".openapi-docs/model_mapper.json"

python .openapi-generator/pre_gen_script.py
npx openapi-generator generate -i "https://www.ladybug.tools/honeybee-schema/simulation-parameter_inheritance.json"  -t ".openapi-generator/templates/csharp" -g csharp -o . --skip-validate-spec -c .openapi-generator/config.json  
npx openapi-generator generate -i "https://www.ladybug.tools/honeybee-schema/model_inheritance.json"  -t ".openapi-generator/templates/csharp" -g csharp -o . --skip-validate-spec -c .openapi-generator/config.json 
python .openapi-generator/post_gen_script.py "https://www.ladybug.tools/honeybee-schema/simulation-parameter_inheritance.json"
python .openapi-generator/post_gen_script.py "https://www.ladybug.tools/honeybee-schema/model_inheritance.json"
python .openapi-generator/update_assembly_version.py
python .openapi-generator/create_interface.py "https://www.ladybug.tools/honeybee-schema/model_mapper.json"


# npx openapi-generator generate -i "test.json"  -t ".openapi-generator/templates/csharp" -g csharp -o . --skip-validate-spec -c .openapi-generator/config.json --type-mappings decimal=double
# java -jar .openapi-generator/openapi-generator.jar generate -i "test.json" -g csharp -t ".openapi-generator/templates/csharp" -o . --skip-validate-spec -c .openapi-generator/config.json
# java -jar .openapi-generator/swagger-codegen-cli.jar generate -i "test.json" -l csharp -t ".openapi-generator/templates/csharp" -o "temp" -c .openapi-generator/config.json --verbose

# java -jar .openapi-generator/openapi-generator.jar generate -i "test.json" -g csharp -o temp_apiGen --skip-validate-spec

# java -jar .openapi-generator/swagger-codegen-cli.jar generate -i "test.json" -l csharp --additional-properties targetFramework=v4.5 -o temp/
# java -jar .openapi-generator/swagger-codegen-cli.jar generate -i https://gist.githubusercontent.com/danielflower/5c5ae8a46a0a49aee508690c19b33ada/raw/b06ff4d9764b5800424f6a21a40158c35277ee65/petstore.json -l csharp --additional-properties targetFramework=v4.5 -o temp/

# npx openapi-generator generate -i "model.json"  -t ".openapi-generator/templates/csharp" -g csharp -o . --skip-validate-spec -c .openapi-generator/config.json
# python .openapi-generator/post_gen_script.py "model.json"
# python .openapi-generator/update_assembly_version.py
# python .openapi-generator/create_interface.py "https://www.ladybug.tools/honeybee-schema/model_mapper.json"
if [ -z "$1" ]
  then
    echo "Schema release version must be provided"
    echo "eg: bash .openapi-generator/generate.sh v1.17.0"
fi

export VERSION=$1

python .openapi-generator/downloadHoneybeeSchema.py "https://github.com/ladybug-tools/honeybee-schema/releases/download/$VERSION"
python .openapi-generator/pre_gen_script.py ".openapi-docs/model_inheritance.json"

npx @openapitools/openapi-generator-cli generate -i ".openapi-docs/simulation-parameter_inheritance.json"  -t ".openapi-generator/templates/csharp" -g csharp -o . --skip-validate-spec -c .openapi-generator/config.json  
npx @openapitools/openapi-generator-cli generate -i ".openapi-docs/model_inheritance.json"  -t ".openapi-generator/templates/csharp" -g csharp -o . --skip-validate-spec -c .openapi-generator/config.json 

python .openapi-generator/post_gen_script.py ".openapi-docs/simulation-parameter_inheritance.json"
python .openapi-generator/post_gen_script.py ".openapi-docs/model_inheritance.json"

python .openapi-generator/update_assembly_version.py

python .openapi-generator/create_interface.py ".openapi-docs/simulation-parameter_mapper.json"
python .openapi-generator/create_interface.py ".openapi-docs/model_mapper.json"

if [ -z "$1" ]
  then
    echo "Schema release version must be provided"
    echo "eg: bash .openapi-generator/generate.sh v1.17.0"
fi

export VERSION=$1

python .openapi-generator/pre_gen_script.py
npx openapi-generator generate -i "https://github.com/ladybug-tools/honeybee-schema/releases/download/$VERSION/simulation-parameter.json"  -t ".openapi-generator/templates/csharp" -g csharp -o . --skip-validate-spec -c .openapi-generator/config.json --type-mappings decimal=double 
npx openapi-generator generate -i "https://github.com/ladybug-tools/honeybee-schema/releases/download/$VERSION/model.json"  -t ".openapi-generator/templates/csharp" -g csharp -o . --skip-validate-spec -c .openapi-generator/config.json --type-mappings decimal=double
python .openapi-generator/post_gen_script.py
python .openapi-generator/update_assembly_version.py
python .openapi-generator/update_type_with_interface.py

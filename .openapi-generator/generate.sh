if [ -z "$1" ]
  then
    echo "Schema release version must be provided"
    echo "eg: bash .openapi-generator/generate.sh v1.17.0"
fi

export VERSION=$1

python .openapi-generator/pre_gen_script.py $VERSION
npx openapi-generator generate -i "https://github.com/ladybug-tools/honeybee-schema/releases/download/$VERSION/simulation-parameter_inheritance.json"  -t ".openapi-generator/templates/csharp" -g csharp -o . --skip-validate-spec -c .openapi-generator/config.json
npx openapi-generator generate -i "https://github.com/ladybug-tools/honeybee-schema/releases/download/$VERSION/model_inheritance.json"  -t ".openapi-generator/templates/csharp" -g csharp -o . --skip-validate-spec -c .openapi-generator/config.json
python .openapi-generator/post_gen_script.py "https://github.com/ladybug-tools/honeybee-schema/releases/download/$VERSION/simulation-parameter_inheritance.json"
python .openapi-generator/post_gen_script.py "https://github.com/ladybug-tools/honeybee-schema/releases/download/$VERSION/model_inheritance.json"
python .openapi-generator/update_assembly_version.py
python .openapi-generator/create_interface.py "https://github.com/ladybug-tools/honeybee-schema/releases/download/$VERSION/simulation-parameter_mapper.json"
python .openapi-generator/create_interface.py "https://github.com/ladybug-tools/honeybee-schema/releases/download/$VERSION/model_mapper.json"

from post_gen_script import check_anyof_types

# npx openapi-generator generate -i "https://ladybug-tools-in2.github.io/honeybee-schema/model.json"  -t ".openapi-generator/templates/csharp" -g csharp -o . --skip-validate-spec -c .openapi-generator/config.json

check_anyof_types("https://ladybug-tools-in2.github.io/honeybee-schema/model.json")

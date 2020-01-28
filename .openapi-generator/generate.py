from post_gen_script import check_anyof_types

# npx openapi-generator generate -i "https://www.ladybug.tools/honeybee-schema/model.json"  -t ".openapi-generator/templates/csharp" -g csharp -o . --skip-validate-spec -c .openapi-generator/config.json

check_anyof_types("https://www.ladybug.tools/honeybee-schema/model.json")

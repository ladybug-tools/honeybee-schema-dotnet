#!/bin/bash

rm -r build/
rm -r dist/
rm -r docs/
rm -r pollination_sdk/
rm -r test/
rm -r pollination_sdk.egg-info/


npx openapi-generator generate \
  -i https://api.pollination.cloud/sdk_openapi.json \
  -t .openapi-generator/templates/csharp \
  -g csharp \
  -o . \
  --skip-validate-spec \
  -c .openapi-generator/config.json


#!/bin/bash
if [ -z "$1" ]; then
  export URL="https://www.ladybug.tools/honeybee-schema"
else
  # Schema with release version
  # eg: bash download.sh v1.17.0
  export URL="https://github.com/ladybug-tools/honeybee-schema/releases/download/$1"
fi

echo "Base URL: $URL"
python3 src/downloadSchema.py "$URL"

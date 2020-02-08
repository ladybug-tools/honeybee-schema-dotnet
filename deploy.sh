#!/usr/bin/env bash

nuget pack src/HoneybeeSchema/HoneybeeSchema.csproj -Properties Configuration=Release -Version $BUILD_VERSION -Verbosity detailed && \
nuget push HoneybeeSchema.$BUILD_VERSION.nupkg -ApiKey $NUGET_API_KEY -Source https://api.nuget.org/v3/index.json
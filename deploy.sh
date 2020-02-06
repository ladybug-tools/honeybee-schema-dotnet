
nuget pack ./src/HoneybeeDotNet/HoneybeeDotNet.csproj -Build -Verbosity detailed

nuget push ./HoneybeeDotNet.*.nupkg -Verbosity detailed -ApiKey $ApiKey -Source https://api.nuget.org/v3/index.json

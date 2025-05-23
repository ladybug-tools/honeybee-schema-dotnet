[![Build](https://github.com/ladybug-tools/honeybee-schema-dotnet/actions/workflows/build_release.yaml/badge.svg)](https://github.com/ladybug-tools/honeybee-schema-dotnet/actions/workflows/build_release.yaml) [![NuGet Version](https://img.shields.io/nuget/v/HoneybeeSchema)](https://www.nuget.org/packages/HoneybeeSchema) [![NuGet Downloads](https://img.shields.io/nuget/dt/HoneybeeSchema)](https://www.nuget.org/packages/HoneybeeSchema)

# HoneybeeSchema - the C# library for the Honeybee Project Information Schema

Documentation for Honeybee project-information schema

This C# SDK is automatically generated by the [OpenAPI Generator](https://openapi-generator.tech) project:

- API version: 1.58.1
- SDK version: 1.58.1
- Build package: org.openapitools.codegen.languages.CSharpClientCodegen
    For more information, please visit [https://github.com/ladybug-tools/honeybee-schema](https://github.com/ladybug-tools/honeybee-schema)

## Frameworks supported


- .NET Core >=1.0
- .NET Framework >=4.5

## Dependencies


- [RestSharp](https://www.nuget.org/packages/RestSharp) - 105.1.0 or later
- [Json.NET](https://www.nuget.org/packages/Newtonsoft.Json/) - 7.0.0 or later
- [JsonSubTypes](https://www.nuget.org/packages/JsonSubTypes/) - 1.2.0 or later

The DLLs included in the package may not be the latest version. We recommend using [NuGet](https://docs.nuget.org/consume/installing-nuget) to obtain the latest version of the packages:

```
Install-Package RestSharp
Install-Package Newtonsoft.Json
Install-Package JsonSubTypes
```

NOTE: RestSharp versions greater than 105.1.0 have a bug which causes file uploads to fail. See [RestSharp#742](https://github.com/restsharp/RestSharp/issues/742)

## Installation

Run the following command to generate the DLL

- [Mac/Linux] `/bin/sh build.sh`
- [Windows] `build.bat`

Then include the DLL (under the `bin` folder) in the C# project, and use the namespaces:

```csharp
using HoneybeeSchema.Api;
using HoneybeeSchema.Client;
using HoneybeeSchema.Model;

```


## Packaging

A `.nuspec` is included with the project. You can follow the Nuget quickstart to [create](https://docs.microsoft.com/en-us/nuget/quickstart/create-and-publish-a-package#create-the-package) and [publish](https://docs.microsoft.com/en-us/nuget/quickstart/create-and-publish-a-package#publish-the-package) packages.

This `.nuspec` uses placeholders from the `.csproj`, so build the `.csproj` directly:

```
nuget pack -Build -OutputDirectory out HoneybeeSchema.csproj
```

Then, publish to a [local feed](https://docs.microsoft.com/en-us/nuget/hosting-packages/local-feeds) or [other host](https://docs.microsoft.com/en-us/nuget/hosting-packages/overview) and consume the new package via Nuget as usual.


## Getting Started

```csharp
using System.Collections.Generic;
using System.Diagnostics;
using HoneybeeSchema.Api;
using HoneybeeSchema.Client;
using HoneybeeSchema.Model;

namespace Example
{
    public class Example
    {
        public static void Main()
        {

        }
    }
}
```

## Documentation for API Endpoints

All URIs are relative to *http://localhost*

Class | Method | HTTP request | Description
------------ | ------------- | ------------- | -------------


## Documentation for Models

 - [Model.Autocalculate](docs/Autocalculate.md)
 - [Model.AutocalculateAllOf](docs/AutocalculateAllOf.md)
 - [Model.BuildingTypes](docs/BuildingTypes.md)
 - [Model.ClimateZones](docs/ClimateZones.md)
 - [Model.EfficiencyStandards](docs/EfficiencyStandards.md)
 - [Model.Location](docs/Location.md)
 - [Model.LocationAllOf](docs/LocationAllOf.md)
 - [Model.OpenAPIGenBaseModel](docs/OpenAPIGenBaseModel.md)
 - [Model.ProjectInfo](docs/ProjectInfo.md)
 - [Model.ProjectInfoAllOf](docs/ProjectInfoAllOf.md)


## Documentation for Authorization

All endpoints do not require authorization.

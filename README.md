[![Build](https://github.com/ladybug-tools/honeybee-schema-dotnet/actions/workflows/build_release.yaml/badge.svg)](https://github.com/ladybug-tools/honeybee-schema-dotnet/actions/workflows/build_release.yaml) [![NuGet Version](https://img.shields.io/nuget/v/HoneybeeSchema)](https://www.nuget.org/packages/HoneybeeSchema) [![NuGet Downloads](https://img.shields.io/nuget/dt/HoneybeeSchema)](https://www.nuget.org/packages/HoneybeeSchema)

# Honeybee Schema

This repository contains the strongly-typed .NET (C#) and TypeScript SDKs for the [Honeybee](https://github.com/ladybug-tools/honeybee-schema) project, part of [Ladybug Tools](https://www.ladybug.tools/). 

These SDKs provide representations of Honeybee schema objects for building energy and daylighting simulations, including:
- Radiance Materials (`Glass`, `Plastic`, `Light`, `Mirror`, `BSDF`, etc.)
- Energy Systems (`SHWSystem`, `Ventilation`, etc.)
- Built-in JSON serialization and deserialization
- Validation of parameters and object states

## SDKs

This repository maintains two primary SDKs:
1. **C# SDK** (`src/CSharpSDK`): A .NET Standard/Core compatible library.
2. **TypeScript SDK** (`src/TypescriptSDK`): A Node.js/Browser compatible library using `class-validator` and `class-transformer`.

## .NET / C# SDK

### Installation

You can install the package via NuGet:

```bash
dotnet add package HoneybeeSchema
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

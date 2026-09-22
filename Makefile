.PHONY: sync-google-form

NEW_RELEASE_VERSION ?= 0.0.1
download:
	cd ./.generator/SchemaGenerator && dotnet run --download --updateVersion

sdk:
	cd ./.generator/SchemaGenerator && dotnet run --download --genCsModel --genCsInterface --genTsModel --updateVersion

build:
	make cs-build
	make ts-build

test:
	make cs-test
	make ts-test

cs-sdk:
	cd ./.generator/SchemaGenerator && dotnet run --genCsModel --genCsInterface --updateVersion

cs-build:
	cd ./src/CSharpSDK && dotnet build

cs-test:
	cd ./src/CSharpSDK.Tests && dotnet test

ts-sdk:
	cd ./.generator/SchemaGenerator && dotnet run --genTsModel --updateVersion

ts-build:
	cd ./src/TypescriptSDK && npm i
	cd ./src/TypescriptSDK && npm version $(NEW_RELEASE_VERSION) --allow-same-version && npm run custom-pack
	cp ./src/TypescriptSDK/*.tgz ./

ts-test:
	cd ./src/TypescriptSDK.Tests && npm i ./../TypescriptSDK/*-$(NEW_RELEASE_VERSION).tgz
	cd ./src/TypescriptSDK.Tests && npm run test

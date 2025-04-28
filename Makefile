.PHONY: sync-google-form

NEW_RELEASE_VERSION ?= 0.0.1

sdk:
	cd ./.generator/SchemaGenerator && dotnet run --download --genCsModel --genCsInterface --genTsModel --updateVersion

cs-sdk:
	cd ./.generator/SchemaGenerator && dotnet run --genCsModel --genCsInterface --updateVersion

ts-sdk:
	cd ./.generator/SchemaGenerator && dotnet run --genTsModel --updateVersion


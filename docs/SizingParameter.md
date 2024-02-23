
# HoneybeeSchema.Model.SizingParameter

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Type** | **string** |  | [optional] [readonly] [default to "SizingParameter"]
**DesignDays** | [**List&lt;DesignDay&gt;**](DesignDay.md) | A list of DesignDays that represent the criteria for which the HVAC systems will be sized. | [optional] 
**HeatingFactor** | **double** | A number that will be multiplied by the peak heating load for each zone in order to size the heating system. | [optional] [default to 1.25D]
**CoolingFactor** | **double** | A number that will be multiplied by the peak cooling load for each zone in order to size the heating system. | [optional] [default to 1.15D]
**EfficiencyStandard** | **EfficiencyStandards** | Text to specify the efficiency standard, which will automatically set the efficiencies of all HVAC equipment when provided. Note that providing a standard here will cause the OpenStudio translation process to perform an additional sizing calculation with EnergyPlus, which is needed since the default efficiencies of equipment vary depending on their size. THIS WILL SIGNIFICANTLY INCREASE TRANSLATION TIME TO OPENSTUDIO. However, it is often worthwhile when the goal is to match the HVAC specification with a particular standard. | [optional] 
**ClimateZone** | **ClimateZones** | Text indicating the ASHRAE climate zone to be used with the efficiency_standard. When unspecified, the climate zone will be inferred from the design days on this sizing parameter object. | [optional] 
**BuildingType** | **string** | Text for the building type to be used in the efficiency_standard. If the type is not recognized or is None, it will be assumed that the building is a generic NonResidential. The following have specified systems per the standard:  Residential, NonResidential, MidriseApartment, HighriseApartment, LargeOffice, MediumOffice, SmallOffice, Retail, StripMall, PrimarySchool, SecondarySchool, SmallHotel, LargeHotel, Hospital, Outpatient, Warehouse, SuperMarket, FullServiceRestaurant, QuickServiceRestaurant, Laboratory, Courthouse. | [optional] 
**BypassEfficiencySizing** | **bool** | A boolean to indicate whether the efficiency standard should trigger an sizing run that sets the efficiencies of all HVAC equipment in the Model (False) or the standard should only be written into the OSM and the sizing run should be bypassed (True). Bypassing the sizing run is useful when you only want to check that the overall HVAC system architecture is correct and you do not want to wait the extra time that it takes to run the sizing calculation. | [optional] [default to false]

[[Back to Model list]](../README.md#documentation-for-models)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to README]](../README.md)


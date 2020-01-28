
from post_gen_script import get_allof_types
import urllib.request, json


def test_get_allof_types(schema_obj_name, keys_anyof):
    #load schema json, and get all union types
    unitItem = []
    source_json_url = "https://www.ladybug.tools/honeybee-schema/model.json"
    json_url = urllib.request.urlopen(source_json_url)
    data = json.loads(json_url.read())
    for sn, sp in data['components']['schemas'].items():
        props = sp['properties']
        if sn == schema_obj_name:
            get_allof_types(props,unitItem)
    
    c1 =keys_anyof
  
    for types in unitItem:
        source ="AnyOf%s" % ("".join(types))
        assert source in c1


def test_run_all():
    #boundary_condition
    name = "Door"
    keys = ["AnyOfOutdoorsSurface"]
    test_get_allof_types(name, keys)

    #schedule, construciton, material
    name = "ModelEnergyProperties"
    keys = ["AnyOfOpaqueConstructionAbridgedWindowConstructionAbridgedShadeConstruction",
    "AnyOfEnergyMaterialEnergyMaterialNoMassEnergyWindowMaterialGasEnergyWindowMaterialGasCustomEnergyWindowMaterialGasMixtureEnergyWindowMaterialSimpleGlazSysEnergyWindowMaterialBlindEnergyWindowMaterialGlazingEnergyWindowMaterialShade",
    "AnyOfScheduleRulesetAbridgedScheduleFixedIntervalAbridged"]
    test_get_allof_types(name, keys)

    #autosizable 
    name = "Outdoor"
    keys = ["AnyOfstringnumber"]
    test_get_allof_types(name, keys)


test_run_all()



//using HoneybeeSchema.Energy;
//extern alias LBTNewtonSoft; using System;
//using System.Collections.Generic;
//using System.Linq;

//namespace HoneybeeSchema
//{
//	public static class Extension_ToAbridged
//	{
//		public static AirBoundaryConstructionAbridged ToAbridged(this AirBoundaryConstruction obj, out ISchedule schedule)
//		{
//			schedule = obj.AirMixingSchedule as ISchedule;
//			var acabj = new AirBoundaryConstructionAbridged(obj.Identifier, displayName: obj.DisplayName, obj.AirMixingPerArea, schedule?.Identifier);
//			return acabj;
//		}

//		public static OpaqueConstructionAbridged ToAbridged(this OpaqueConstruction obj, out List<IMaterial> materials)
//		{
//			materials = obj.Materials.OfType<IMaterial>().ToList();
//			var ocabj = new OpaqueConstructionAbridged(obj.Identifier, materials.Select(_ => _.Identifier).ToList(), obj.DisplayName);
//			return ocabj;
//		}

//		public static WindowConstructionAbridged ToAbridged(this WindowConstruction obj, out List<IMaterial> materials)
//		{
//			materials = obj.Materials.OfType<IMaterial>().ToList();
//			var wcabj = new WindowConstructionAbridged(obj.Identifier, materials.Select(_ => _.Identifier).ToList(), obj.DisplayName);
//			return wcabj;
//		}

//		public static WindowConstructionShadeAbridged ToAbridged(this WindowConstructionShade obj, out WindowConstructionAbridged windowConstruction, out List<IMaterial> materials, out ISchedule schedule)
//		{
//			var wcc = obj.WindowConstruction;
//			var wccmats = wcc.Materials.OfType<IMaterial>();
//			var shadeM = obj.ShadeMaterial as IMaterial;
//			var sch = obj.Schedule as ISchedule;

//			//Convert to abridged
//			var wccadj = new WindowConstructionAbridged(wcc.Identifier, wccmats.Select(_ => _.Identifier).ToList(), wcc.DisplayName);
//			var wscabj = new WindowConstructionShadeAbridged(obj.Identifier, wccadj, shadeM?.Identifier, obj.DisplayName, obj.ShadeLocation, obj.ControlType, obj.Setpoint, sch?.Identifier);
			
//			windowConstruction = wccadj;
//			materials = wccmats.ToList();
//			materials.Add(shadeM);
//			schedule = sch;
//			return wscabj;

//		}

//		public static ConstructionSetAbridged ToAbridged(this ConstructionSet obj, out List<IConstructionset> constructionSets, out List<IConstruction> constructions, out List<IMaterial> materials, out List<ISchedule> schedules)
//		{
//			constructionSets = new List<IConstructionset>();
//			schedules = new List<ISchedule>();
//			constructions = new List<IConstruction>();
//			materials = new List<IMaterial>();

//			ISchedule acSch = null;
//			var air = obj.AirBoundaryConstruction?.ToAbridged(out acSch);
//			schedules.Add(acSch);
//			constructions.Add(air);

//			var wallCons = new List<IConstruction>();
//			var wallMats = new List<IMaterial>();
//			var wallS = obj.WallSet?.ToAbridged(out wallCons, out wallMats);
//			constructions.AddRange(wallCons);
//			materials.AddRange(wallMats);
//			constructionSets.Add(wallS);

//			var aptCons = new List<IConstruction>();
//            var aptMats = new List<IMaterial>();
//			var aptS = obj.ApertureSet?.ToAbridged(out aptCons, out aptMats);
//			constructions.AddRange(aptCons);
//			materials.AddRange(aptMats);
//			constructionSets.Add(aptS);

//			var doorCons = new List<IConstruction>();
//			var doorMats = new List<IMaterial>();
//			var doorS = obj.DoorSet?.ToAbridged(out doorCons, out doorMats);
//			constructions.AddRange(doorCons);
//			materials.AddRange(doorMats);
//			constructionSets.Add(doorS);

//			var floorCons = new List<IConstruction>();
//			var floorMats = new List<IMaterial>();
//			var floorS = obj.FloorSet?.ToAbridged(out floorCons, out floorMats);
//			constructions.AddRange(floorCons);
//			materials.AddRange(floorMats);
//			constructionSets.Add(floorS);

//			var roofCons = new List<IConstruction>();
//			var roofMats = new List<IMaterial>();
//			var roofS = obj.RoofCeilingSet?.ToAbridged(out roofCons, out roofMats);
//			constructions.AddRange(roofCons);
//			materials.AddRange(roofMats);
//			constructionSets.Add(roofS);

//			var shd = obj.ShadeConstruction;
//			constructions.Add(shd);

//			var adj = new ConstructionSetAbridged(obj.Identifier, obj.DisplayName, wallS, floorS, roofS, aptS, doorS, shd?.Identifier, air?.Identifier);
//			return adj;
//		}

//		public static WallConstructionSetAbridged ToAbridged(this WallConstructionSet obj, out List<IConstruction> constructions, out List<IMaterial> materials)
//		{
//			materials = new List<IMaterial>();
			
//			var ms1 = new List<IMaterial>();
//			var ms2 = new List<IMaterial>();
//			var ms3 = new List<IMaterial>();

//			var ex = obj.ExteriorConstruction?.ToAbridged(out ms1);
//			var inter = obj.InteriorConstruction?.ToAbridged(out ms2);
//			var g = obj.GroundConstruction?.ToAbridged(out ms3);

//			constructions = new List<IConstruction>() { ex, inter, g};

//			materials.AddRange(ms1);
//			materials.AddRange(ms2);
//			materials.AddRange(ms3);

//			var abj = new WallConstructionSetAbridged(inter?.Identifier, ex?.Identifier, g?.Identifier);
//			return abj;
//		}

//        public static ApertureConstructionSetAbridged ToAbridged(this ApertureConstructionSet obj, out List<IConstruction> constructions, out List<IMaterial> materials)
//        {
//            materials = new List<IMaterial>();

//            var ms1 = new List<IMaterial>();
//            var ms2 = new List<IMaterial>();
//            var ms3 = new List<IMaterial>();
//            var ms4 = new List<IMaterial>();

//			var ex = obj.WindowConstruction?.ToAbridged(out ms1);
//            var inter = obj.InteriorConstruction?.ToAbridged(out ms2);
//            var sky = obj.SkylightConstruction?.ToAbridged(out ms3);
//			var op = obj.OperableConstruction?.ToAbridged(out ms4);

//			constructions = new List<IConstruction>() { ex, inter, sky, op };

//            materials.AddRange(ms1);
//            materials.AddRange(ms2);
//            materials.AddRange(ms3);
//			materials.AddRange(ms4);

//			var abj = new ApertureConstructionSetAbridged(inter?.Identifier, ex?.Identifier, sky?.Identifier, op?.Identifier);
//            return abj;
//        }

//		public static DoorConstructionSetAbridged ToAbridged(this DoorConstructionSet obj, out List<IConstruction> constructions, out List<IMaterial> materials)
//		{
//			materials = new List<IMaterial>();

//			var ms1 = new List<IMaterial>();
//			var ms2 = new List<IMaterial>();
//			var ms3 = new List<IMaterial>();
//			var ms4 = new List<IMaterial>();
//			var ms5 = new List<IMaterial>();

//			var ex = obj.ExteriorConstruction?.ToAbridged(out ms1);
//			var exg = obj.ExteriorGlassConstruction?.ToAbridged(out ms3);
//			var inter = obj.InteriorConstruction?.ToAbridged(out ms2);
//			var interg = obj.InteriorGlassConstruction?.ToAbridged(out ms4);
//			var oh = obj.OverheadConstruction?.ToAbridged(out ms5);

//			constructions = new List<IConstruction>() { ex, inter, exg, interg, oh };

//			materials.AddRange(ms1);
//			materials.AddRange(ms2);
//			materials.AddRange(ms3);
//			materials.AddRange(ms4);
//			materials.AddRange(ms5);

//			var abj = new DoorConstructionSetAbridged(inter?.Identifier, ex?.Identifier, oh?.Identifier, exg?.Identifier, interg?.Identifier);
//			return abj;
//		}

//		public static FloorConstructionSetAbridged ToAbridged(this FloorConstructionSet obj, out List<IConstruction> constructions, out List<IMaterial> materials)
//		{
//			materials = new List<IMaterial>();

//			var ms1 = new List<IMaterial>();
//			var ms2 = new List<IMaterial>();
//			var ms3 = new List<IMaterial>();

//			var ex = obj.ExteriorConstruction?.ToAbridged(out ms1);
//			var inter = obj.InteriorConstruction?.ToAbridged(out ms2);
//			var g = obj.GroundConstruction?.ToAbridged(out ms3);

//			constructions = new List<IConstruction>() { ex, inter, g };

//			materials.AddRange(ms1);
//			materials.AddRange(ms2);
//			materials.AddRange(ms3);

//			var abj = new FloorConstructionSetAbridged(inter?.Identifier, ex?.Identifier, g?.Identifier);
//			return abj;
//		}

//		public static RoofCeilingConstructionSetAbridged ToAbridged(this RoofCeilingConstructionSet obj, out List<IConstruction> constructions, out List<IMaterial> materials)
//		{
//			materials = new List<IMaterial>();

//			var ms1 = new List<IMaterial>();
//			var ms2 = new List<IMaterial>();
//			var ms3 = new List<IMaterial>();

//			var ex = obj.ExteriorConstruction?.ToAbridged(out ms1);
//			var inter = obj.InteriorConstruction?.ToAbridged(out ms2);
//			var g = obj.GroundConstruction?.ToAbridged(out ms3);

//			constructions = new List<IConstruction>() { ex, inter, g };

//			materials.AddRange(ms1);
//			materials.AddRange(ms2);
//			materials.AddRange(ms3);

//			var abj = new RoofCeilingConstructionSetAbridged(inter?.Identifier, ex?.Identifier, g?.Identifier);
//			return abj;
//		}

//	}

//}


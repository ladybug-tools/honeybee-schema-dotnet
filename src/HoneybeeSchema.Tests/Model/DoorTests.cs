

using NUnit.Framework;

using System;
using System.Linq;
using System.Collections.Generic;
using HoneybeeSchema;

namespace HoneybeeSchema.Test
{
    /// <summary>
    ///  Class for testing Door
    /// </summary>
    /// <remarks>
    /// This file is automatically generated by OpenAPI Generator (https://openapi-generator.tech).
    /// Please update the test case below to test the model.
    /// </remarks>
    public class DoorTests
    {
        private Door instance;

        /// <summary>
        /// Setup before each test
        /// </summary>
        [SetUp]
        public void Init()
        {
            // TODO uncomment below to create an instance of Door
            var face = new Face3D(
                new List<List<double>>()
                {
                    new List<double>(){0,0,0 },
                    new List<double>(){0.5,0.5,0.5 },
                    new List<double>(){1,0,0 }
                });
            instance = new Door( 
                "mainEntrance",
                face
                );

        }

        /// <summary>
        /// Clean up after each test
        /// </summary>
        [TearDown]
        public void Cleanup()
        {

        }

        /// <summary>
        /// Test an instance of Door
        /// </summary>
        [Test]
        public void DoorInstanceTest()
        {
            // TODO uncomment below to test "IsInstanceOf" Door
            Assert.IsInstanceOf(typeof(Door), instance);
        }

        /// <summary>
        /// Test an instance of Door
        /// </summary>
        [Test]
        public void EqualInstanceTest()
        {
            var p1 = new List<List<double>>() { new List<double>() { 0.11111, 0.22222, 0.333333 } };
            var p2 = new List<List<double>>() { new List<double>() { 0.11110, 0.22222, 0.333333 } };
            var p3 = new List<List<double>>() { new List<double>() { 0.11221, 0.22222, 0.333333 } };

            var arePtsSame = Extension.AllEquals(p1, p2);
            Assert.IsTrue(arePtsSame);

            var arePtsNotSame = Extension.AllEquals(p1, p3);
            Assert.IsFalse(arePtsNotSame);

            var door2 = this.instance.DuplicateDoor();
            var isSame = door2.Equals(instance);
            Assert.IsTrue(isSame);


            var hole = new List<List<List<double>>>();
            var hole2 = new List<List<List<double>>>();
            hole = null;
            var isListSame = Extension.AllEquals(hole, hole2);
            Assert.IsTrue(isListSame);


            instance.Geometry.Holes = null;
            door2.Geometry.Holes = new List<List<List<double>>>();
            Assert.IsTrue(door2.Equals(instance));
            Assert.IsTrue(door2 == instance);

            instance.IndoorShades = new List<Shade>();
            door2.IndoorShades = null;
            Assert.IsTrue(door2.Equals(instance));
            Assert.IsTrue(door2 == instance);

            instance.IndoorShades = new List<Shade>() { new Shade("nn", new Face3D(new List<List<double>>()), new ShadePropertiesAbridged()) };
            Assert.IsFalse(door2.Equals(instance));
            Assert.IsFalse(door2 == instance);

        }

        // only for local tests
        //[Test]
        public void RoomCompare()
        {
            var id = "Room_e6ac360b-aaed-4c3b-a130-36b4c2ac9d13-000d14cc";
            var f = @"C:\Users\mingo\Desktop\New folder\New folder\model_from_revit.hbjson";
            var f2 = @"C:\Users\mingo\Desktop\New folder\New folder\model_updated.hbjson";

            var j1 = System.IO.File.ReadAllText(f);
            var j2 = System.IO.File.ReadAllText(f2);

            var m1 = Model.FromJson(j1);
            var m2 = Model.FromJson(j2);

            var r1 = m1.Rooms.FirstOrDefault(_ => _.Identifier == id);
            var r2 = m2.Rooms.FirstOrDefault(_ => _.Identifier == id);

            
            Assert.IsTrue(Extension.Equals(r1.UserData, r2.UserData));

            Assert.IsTrue(r1.Properties.Equals(r2.Properties));
           
            Assert.IsTrue(Extension.AllEquals(r1.Faces, r2.Faces));
            Assert.IsTrue(Extension.AllEquals(r1.IndoorShades, r2.IndoorShades));
            Assert.IsTrue(Extension.AllEquals(r1.OutdoorShades, r2.OutdoorShades));
            Assert.IsTrue(r1.Equals(r2));

        }

        /// <summary>
        /// Test the property 'Name'
        /// </summary>
        [Test]
        public void NameTest()
        {
            // TODO unit test for the property 'Name'
            Assert.IsTrue(this.instance.Identifier == "mainEntrance");
        }
        /// <summary>
        /// Test the property 'DisplayName'
        /// </summary>
        [Test]
        public void DisplayNameTest()
        {
            // TODO unit test for the property 'DisplayName'
        }
        /// <summary>
        /// Test the property 'Type'
        /// </summary>
        [Test]
        public void TypeTest()
        {
            // TODO unit test for the property 'Type'
        }
        /// <summary>
        /// Test the property 'Geometry'
        /// </summary>
        [Test]
        public void GeometryTest()
        {
            // TODO unit test for the property 'Geometry'
        }
        /// <summary>
        /// Test the property 'BoundaryCondition'
        /// </summary>
        [Test]
        public void BoundaryConditionTest()
        {
            this.instance.BoundaryCondition = new Outdoors(sunExposure: false, viewFactor: 0.5);
            var bcObj = this.instance.BoundaryCondition.Obj as Outdoors;
            Assert.IsTrue(bcObj.SunExposure == false);

        }
        /// <summary>
        /// Test the property 'IsGlass'
        /// </summary>
        [Test]
        public void IsGlassTest()
        {
            // TODO unit test for the property 'IsGlass'
        }
        /// <summary>
        /// Test the property 'Properties'
        /// </summary>
        [Test]
        public void PropertiesTest()
        {
            // TODO unit test for the property 'Properties'
        }

        /// <summary>
        /// Test the ToJson with a default instance
        /// </summary>
        [Test]
        public void ToJsonTest()
        {
            var j = this.instance.ToJson();

            var obj = Door.FromJson(j);

            var bc = obj.BoundaryCondition.Obj as Outdoors;
            Assert.IsTrue(bc.ViewFactor.Obj is Autocalculate);
        }

        /// <summary>
        /// Test the ToJson with a default instance
        /// </summary>
        [Test]
        public void ToJsonViewTypeTest()
        {
            this.instance.BoundaryCondition = new Outdoors(sunExposure: false, viewFactor: 0.5);
            var j = this.instance.ToJson();

            var obj = Door.FromJson(j);

            var bc = obj.BoundaryCondition.Obj as Outdoors;
            Assert.IsTrue((double)bc.ViewFactor.Obj == 0.5);

        }

        [Test]
        public void ValidateTest()
        {
       
            var res = this.instance.Validate();

            this.instance.Identifier = "ateta adfsadf%";
            res = this.instance.Validate();
            Assert.IsTrue(res.FirstOrDefault().MemberNames.Contains("Identifier"));
  
        }
    }

}

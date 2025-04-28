
using NUnit.Framework;

using System;
using System.Linq;
using System.IO;
using System.Collections.Generic;
using HoneybeeSchema;
using System.Reflection;

namespace HoneybeeSchema.Test
{
    public class ModifierSetTests
    {
        private ModifierSet instance;

        [SetUp]
        public void Init()
        {
           
        }

       
        [Test]
        public void ShadeModifierSetTest()
        {
            //var shade = new ShadeModifierSet();
            //shade.InteriorModifier = null;

            // test null anyOf type
            var jsonShade = @"
{
    ""type"": ""ShadeModifierSet"", 
    ""interior_modifier"": null
}
        ";

            var shade2 = ShadeModifierSet.FromJson(jsonShade);
            Assert.IsTrue(shade2.InteriorModifier == null);
        }


    }

}

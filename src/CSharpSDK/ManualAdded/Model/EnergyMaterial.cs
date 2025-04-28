extern alias LBTNewtonSoft; using System;
using System.Collections.Generic;

namespace HoneybeeSchema
{
    public partial class EnergyMaterial
    {
        public double RValue => this.Thickness / this.Conductivity;

        public double UValue => this.Conductivity / this.Thickness;

    }
}

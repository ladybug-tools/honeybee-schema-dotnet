using System;
using System.Collections.Generic;

namespace HoneybeeSchema
{
    public partial class EnergyWindowFrame
    {
        public double RValue => 1 / this.Conductance;

        public double UValue => this.Conductance;

    }
}

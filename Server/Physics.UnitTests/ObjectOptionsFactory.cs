using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Physics.UnitTests
{
    public class ObjectOptions
    {
        public decimal Weight { get; set; }
        public decimal Volume { get; set; }
        public decimal Density { get; set; }
    }
    public class ObjectOptionsFactory
    {
        ObjectOptions _material;
        public ObjectOptionsFactory()
        {
            _material = new ObjectOptions();
        }


        public ObjectOptionsFactory Aluminium()
        {
            this._material.Weight = 0.0544m;
            this._material.Volume = 0.00002m;
            this._material.Density = 2720;
            return this;
        }

        public ObjectOptions Build()
        {
            return this._material;
        }

    }
}

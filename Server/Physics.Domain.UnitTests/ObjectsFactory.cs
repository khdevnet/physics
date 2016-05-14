namespace Physics.Domain.UnitTests
{
    public class ObjectOptions
    {
        public float Weight { get; set; }
        public float Volume { get; set; }
        public float Density { get; set; }
    }

    public class ObjectsFactory
    {
        ObjectOptions _material;

        public ObjectsFactory()
        {
            _material = new ObjectOptions();
        }

        public ObjectsFactory AluminiumObject()
        {
            this._material.Weight = 0.0544f;
            this._material.Volume = 0.00002f;
            this._material.Density = 2720f;
            return this;
        }

        public ObjectsFactory WithInvalidDensity()
        {
            this._material.Density = 0;
            return this;
        }

        public ObjectsFactory WithInvalidVolume()
        {
            this._material.Volume = 0;
            return this;
        }

        public ObjectsFactory WithInvalidWeight()
        {
            this._material.Weight = 0;
            return this;
        }

        public ObjectOptions Build()
        {
            return this._material;
        }
    }
}

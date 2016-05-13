using Physics.Api.Application.Service.Entity;
using System.Collections.Generic;

namespace Physics.Api.Application.Service
{
    public interface IDensityService
    {
        List<Density> GetAll();
        void Save(Density density);
        Density GetById(string id);
        Density GetByWeightAndVolume(decimal weight, decimal volume);
        bool Exists(string id);
        void Delete(string id);
    }
}

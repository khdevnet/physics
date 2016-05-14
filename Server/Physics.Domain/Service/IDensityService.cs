
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Physics.Domain.Service
{
    public interface IDensityService
    {
        Task<List<Density>> GetAllAsync();
        List<Density> GetAll();
        void Save(Density density);
        Task SaveAsync(Density density);
        Density GetById(string id);
        Task<Density> GetByIdAsync(string id);
        Density GetByWeightAndVolume(float weight, float volume);
        Task<Density> GetByWeightAndVolumeAsync(float weight, float volume);
        bool Exists(string id);
        void Delete(string id);
        Task DeleteAsync(string id);
    }
}


using System;
using System.Collections.Generic;
using System.Linq;

using Physics.Domain.Repository;
using System.Threading.Tasks;

namespace Physics.Domain.Service
{
    public class DensityService : IDensityService
    {
        private readonly IDensityRepository _repository;
        private readonly IPhysicsCalculator _physicsCalculator;

        public DensityService(IDensityRepository repository, IPhysicsCalculator physicsCalculator)
        {
            _repository = repository;
            _physicsCalculator = physicsCalculator;
        }

        public List<Density> GetAll()
        {
            return _repository.All<Density>().ToList();
        }

        public Task<List<Density>> GetAllAsync()
        {
            return Task.Run(() => this.GetAll());
        }

        public void Save(Density density)
        {
            if (!Valid(density)) throw new ArgumentException("Density not valid!!");
            bool isItNewDensity = string.IsNullOrWhiteSpace(density.Id);
            if (isItNewDensity) density.Id = GenerateNewId(density.Title);
            _repository.Save(density);
        }

        public Task SaveAsync(Density density)
        {
            return Task.Run(() => this.Save(density));
        }

        string GenerateNewId(string title)
        {
            return title.ToLower().Replace(' ', '-');
        }

        bool Valid(Density density)
        {
            return !string.IsNullOrWhiteSpace(density.Title) && density.Value > 0;
        }

        public Density GetById(string id)
        {
            return _repository.Single<Density>(id);
        }

        public Task<Density> GetByIdAsync(string id)
        {
            return Task.Run(() => this.GetById(id));
        }

        public bool Exists(string id)
        {
            return _repository.Exists<Density>(id);
        }

        public void Delete(string id)
        {
            _repository.Delete<Density>(id);
        }

        public Density GetByWeightAndVolume(float weight, float volume)
        {
            var densityValue = _physicsCalculator.CalculateDensity(weight, volume);
            var density = this.GetAll().SingleOrDefault(x => x.Value == densityValue);
            if (density == null) return new Density() { Value = densityValue };
            return density;
        }

        public Task<Density> GetByWeightAndVolumeAsync(float weight, float volume)
        {
            return Task.Run(() => this.GetByWeightAndVolume(weight, volume));
        }

        public Task DeleteAsync(string id)
        {
            return Task.Run(() => this.Delete(id));
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;

using Physics.Domain.Repository;
using Physics.Domain.PhysicsCalculator;

namespace Physics.Domain.Service
{
    public class DensityService : IDensityService
    {
        private readonly IRepository _repository;
        private readonly IPhysicsCalculator _physicsCalculator;

        public DensityService(IRepository repository, IPhysicsCalculator physicsCalculator)
        {
            _repository = repository;
            _physicsCalculator = physicsCalculator;
        }

        public List<Density> GetAll()
        {
            return _repository.All<Density>().ToList();
        }

        public void Save(Density density)
        {
            if (!valid(density)) throw new ArgumentException("Density not valid!!");
            bool isItNewDensity = string.IsNullOrWhiteSpace(density.Id);
            if (isItNewDensity) density.Id = generateNewId(density.Title);

            _repository.Save<Density>(density);
        }

        string generateNewId(string title)
        {
            return title.ToLower().Replace(' ', '-');
        }
        bool valid(Density density)
        {
            return !string.IsNullOrWhiteSpace(density.Title) && density.Value > 0;
        }

        public Density GetById(string id)
        {
            return _repository.Single<Density>(id);
        }

        public bool Exists(string id)
        {
            return _repository.Exists<Density>(id);
        }

        public void Delete(string id)
        {
            _repository.Delete<Density>(id);
        }

        public Density GetByWeightAndVolume(decimal weight, decimal volume)
        {
            var densityValue = _physicsCalculator.CalculateDensity(weight, volume);
            var density = this.GetAll().SingleOrDefault(x => x.Value == densityValue);
            if (density == null) return new Density() { Value = densityValue };
            return density;
        }
    }
}
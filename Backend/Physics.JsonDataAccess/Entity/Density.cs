using System;
using Physics.Domain.Repository;

namespace Physics.JsonDataAccess.Entity
{

    public class Density : BaseEntity<Density>, IBaseEntity<Density>
    {
        public Density() : base(x => x.Id)
        {

        }
        public string Id { get; set; }
        public string Title { get; set; }
        public float Value { get; set; }
    }
}
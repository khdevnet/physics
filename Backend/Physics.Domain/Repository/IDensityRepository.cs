﻿namespace Physics.Domain.Repository
{
    public interface IDensityRepository: IRepository
    {
        void Save(Density item);
    }
}

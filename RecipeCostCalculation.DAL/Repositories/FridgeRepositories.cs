using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RecipeCostCalculation.DAL.Interfaces;
using RecipeCostCalculation.Domain.Entities;

namespace RecipeCostCalculation.DAL.Repositories
{
    public class FridgeRepositories : IBaseRepositories<FridgeEntity>
    {
        public Task Create(FridgeEntity entity)
        {
            throw new NotImplementedException();
        }

        public Task Delete(FridgeEntity entity)
        {
            throw new NotImplementedException();
        }

        public IQueryable<FridgeEntity> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<FridgeEntity> Update(FridgeEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}

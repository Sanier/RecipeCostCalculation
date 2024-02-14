using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RecipeCostCalculation.DAL.Interfaces;
using RecipeCostCalculation.Domain.Entities;

namespace RecipeCostCalculation.DAL.Repositories
{
    public class RecipeRepositories : IBaseRepositories<RecipeEntity>
    {
        public Task Create(RecipeEntity entity)
        {
            throw new NotImplementedException();
        }

        public Task Delete(RecipeEntity entity)
        {
            throw new NotImplementedException();
        }

        public IQueryable<RecipeEntity> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<RecipeEntity> Update(RecipeEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}

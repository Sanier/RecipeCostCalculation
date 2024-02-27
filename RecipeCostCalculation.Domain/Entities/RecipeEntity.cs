﻿using RecipeCostCalculation.Domain.Models.ProductModels;

namespace RecipeCostCalculation.Domain.Entities
{
    public class RecipeEntity
    {
        public long Id { get; set; }
        public required string Name { get; set; }
        public required string Description { get; set; }
        public required ForRecipeModel ForRecipeModel { get; set; }
    }
}

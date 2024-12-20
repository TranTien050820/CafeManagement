﻿using Cafe_Management.Code;
using Cafe_Management.Core.Entities;
using Cafe_Management.Core.Interfaces;
using Cafe_Management.Infrastructure.Repositories;

namespace Cafe_Management.Application.Services
{
    public class IngredientService
    {
        private readonly IIngredientRepository _ingredientRepository;

        public IngredientService(IIngredientRepository ingredientRepository )
        {
            _ingredientRepository = ingredientRepository;
        }

        public async Task<IEnumerable<Ingredient>> GetAllIngredients()
        {
            return await _ingredientRepository.GetAllIngredients();
        }

        public async Task<Ingredient?> GetIngredientById(int id)
        {
            return await _ingredientRepository.GetIngredientById(id);
        }
        public async Task AddIngredient(Ingredient ingredient)
        {


            await _ingredientRepository.AddIngredient(ingredient);
        }

        public async Task UpdateIngredient(Ingredient ingredient)
        {
            await _ingredientRepository.UpdateIngredient(ingredient);
        }

    }
}

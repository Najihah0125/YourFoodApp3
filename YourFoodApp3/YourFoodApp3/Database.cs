using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace YourFoodApp3
{
    public class Database
    {
        public readonly SQLiteAsyncConnection _database;

        public Database(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<AddedRecipe>();
            _database.CreateTableAsync<PreloadedRecipe>();

         

        }

        //get all added recipes
        public Task<List<AddedRecipe>> GetAddedRecipeAsync()
        {
            return _database.Table<AddedRecipe>().ToListAsync();
        }
        
        //add recipe
        public Task<int> AddRecipeAsync(AddedRecipe recipe)
        {
            return _database.InsertAsync(recipe);
        }

        //get all preloaded recipe
        public Task<List<PreloadedRecipe>> GetPreloadedRecipeAsync()
        {
            return _database.Table<PreloadedRecipe>().ToListAsync();
        }

        //preload table preloadrecipe
        public Task<int> PreloadRecipeAsync(PreloadedRecipe preloadrecipe)
        {
            return _database.InsertAsync(preloadrecipe);
        }

    }
    


}

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

        //get bookmarked recipes
        public Task<List<PreloadedRecipe>> GetBookmarkedRecipeAsync()
        {
            return _database.Table<PreloadedRecipe>().Where(recipe => recipe.Bookmark == "yes").ToListAsync();
        }

        //get specific preloaded recipe
        public Task<List<PreloadedRecipe>> GetSpecificPreloadedRecipeAsync(int recipeid)
        {
            return _database.Table<PreloadedRecipe>().Where(recipe => recipe.Id == recipeid).ToListAsync();
        }

        //update bookmark column in preloaded recipe table
        public async Task UpdateBookmark(int rowId, string newBookmark)
        {
            var row = await _database.Table<PreloadedRecipe>().FirstOrDefaultAsync(data => data.Id == rowId);

            if(row != null)
            {
                row.Bookmark = newBookmark;
                await _database.UpdateAsync(row);
            }
        }

        //delete added recipe
        public Task<int> DeleteRecipe(AddedRecipe addedRecipe)
        {
            return _database.DeleteAsync(addedRecipe);
        }

        //update added recipe
        public Task<int> UpdateAddedRecipe(AddedRecipe addedRecipe)
        {
            return _database.UpdateAsync(addedRecipe);
        }
    }
}

﻿using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace YourFoodApp3
{
    public class AddedRecipe
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string RecipeName { get; set; }
        public string Description { get; set; }
        public string Time { get; set; }
        public string Ingredients { get; set; }
        public string Steps { get; set; }
        public string Image { get; set; }
    }
}

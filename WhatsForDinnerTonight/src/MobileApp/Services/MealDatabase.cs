using SQLite;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WhatsForDinnerTonight;

public class MealDatabase
{
    // private readonly SQLiteAsyncConnection _database;
    private readonly HashSet<Meal> _database;

    public MealDatabase(string dbPath)
    {
        _database = new HashSet<Meal>();
        // _database = new SQLiteAsyncConnection(dbPath);
        // _database.CreateTableAsync<Meal>().Wait();
//         var meals = _database.Table<Meal>().ToListAsync();


//  {
//         // var meals = await GetMealsAsync();
//         if (meals.Count == 0)   
//         {
//             var sampleMeals = new List<Meal>
//             {
//                 new Meal { Name = "Spaghetti Carbonara", Ingredients = "Spaghetti, Eggs, Parmesan Cheese, Pancetta, Pepper", Recipe = "Cook spaghetti. In a bowl, mix eggs and grated Parmesan cheese. Fry pancetta until crispy. Combine spaghetti, egg mixture, and pancetta. Season with pepper and serve." },
//                 new Meal { Name = "Chicken Alfredo", Ingredients = "Fettuccine, Chicken Breast, Heavy Cream, Parmesan Cheese, Butter, Garlic", Recipe = "Cook fettuccine. Sauté garlic in butter. Add chicken and cook until done. Pour in heavy cream and Parmesan cheese, and let it thicken. Combine with fettuccine and serve." },
//                 new Meal { Name = "Beef Tacos", Ingredients = "Ground Beef, Taco Shells, Lettuce, Tomato, Cheese, Taco Seasoning", Recipe = "Cook ground beef with taco seasoning. Assemble tacos with beef, lettuce, tomato, and cheese. Serve with your favorite salsa." }
//             };

//             foreach (var meal in sampleMeals)
//             {
//                 await SaveMealAsync(meal);
//             }
//         }
//     }


    }

    public IEnumerable<Meal> GetMeals()
    {

        // var values =  await _database.Table<Meal>().ToListAsync();
        return _database;
    }

    public Meal? GetMeal(string name)
    {
        return _database.Where(i => i.Name == name).FirstOrDefault();
    }

    public bool SaveMeal(Meal meal)
    {
        return _database.Add(meal);
    }

    // public async Task<int> DeleteMealAsync(Meal meal)
    // {
    //     return await _database.DeleteAsync(meal);
    // }

    // New method to insert sample data
    public void SeedData()
    {
        var meals = GetMeals();
        if (meals.Count() == 0)   
        {
            var sampleMeals = new List<Meal>
            {
                new Meal { Name = "Spaghetti Carbonara", Ingredients = "Spaghetti, Eggs, Parmesan Cheese, Pancetta, Pepper", Recipe = "Cook spaghetti. In a bowl, mix eggs and grated Parmesan cheese. Fry pancetta until crispy. Combine spaghetti, egg mixture, and pancetta. Season with pepper and serve." },
                new Meal { Name = "Chicken Alfredo", Ingredients = "Fettuccine, Chicken Breast, Heavy Cream, Parmesan Cheese, Butter, Garlic", Recipe = "Cook fettuccine. Sauté garlic in butter. Add chicken and cook until done. Pour in heavy cream and Parmesan cheese, and let it thicken. Combine with fettuccine and serve." },
                new Meal { Name = "Beef Tacos", Ingredients = "Ground Beef, Taco Shells, Lettuce, Tomato, Cheese, Taco Seasoning", Recipe = "Cook ground beef with taco seasoning. Assemble tacos with beef, lettuce, tomato, and cheese. Serve with your favorite salsa." }
            };

            foreach (var meal in sampleMeals)
            {
                SaveMeal(meal);
            }
        }
    }
}

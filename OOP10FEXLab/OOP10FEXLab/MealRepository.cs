using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;

namespace OOP10FEXLab
{
    /// <summary>
    /// Retrieves the package meals from the meals notepad file (meals.txt).
    /// Format per line: Id|Category|Name|Price|ImagePath
    /// </summary>
    public class MealRepository
    {
        private readonly string filePath;

        /// <summary>
        /// Uses meals.txt beside the running program.
        /// </summary>
        public MealRepository()
            : this(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "meals.txt"))
        {
        }

        /// <summary>
        /// Uses the given meals file.
        /// </summary>
        public MealRepository(string filePath)
        {
            this.filePath = filePath;
        }

        /// <summary>
        /// Reads every package meal from the file. Creates the file with sample meals if it is missing.
        /// </summary>
        public List<Meal> GetAllMeals()
        {
            if (!File.Exists(filePath))
            {
                File.WriteAllLines(filePath, GetDefaultMealLines());
            }

            List<Meal> meals = new List<Meal>();

            foreach (string line in File.ReadAllLines(filePath))
            {
                if (string.IsNullOrWhiteSpace(line) || line.TrimStart().StartsWith("#"))
                {
                    continue;
                }

                string[] parts = line.Split('|');
                if (parts.Length < 4)
                {
                    continue;
                }

                decimal price;
                if (!decimal.TryParse(parts[3].Trim(), NumberStyles.Number, CultureInfo.InvariantCulture, out price))
                {
                    continue;
                }

                meals.Add(new Meal
                {
                    Id = parts[0].Trim(),
                    Category = parts[1].Trim(),
                    Name = parts[2].Trim(),
                    Price = price,
                    ImagePath = parts.Length > 4 ? parts[4].Trim() : string.Empty
                });
            }

            return meals;
        }

        /// <summary>
        /// Reads only the meals that belong to one category.
        /// </summary>
        public List<Meal> GetMealsByCategory(string category)
        {
            return GetAllMeals().Where(m => m.Category == category).ToList();
        }

        private static string[] GetDefaultMealLines()
        {
            return new[]
            {
                "# Id|Category|Name|Price|ImagePath",
                "C1|Chicken|1pc Fried Chicken with Rice|99.00|images/c1.png",
                "C2|Chicken|2pc Fried Chicken with Rice|185.00|images/c2.png",
                "C3|Chicken|1pc Spicy Chicken with Rice|105.00|images/c3.png",
                "S1|Spaghetti|Sweet Spaghetti|65.00|images/s1.png",
                "S2|Spaghetti|1pc Chicken with Spaghetti|119.00|images/s2.png",
                "S3|Spaghetti|Spaghetti with Burger and Drink|125.00|images/s3.png",
                "B1|Burgers|Classic Burger|45.00|images/b1.png",
                "B2|Burgers|Cheese Burger with Fries and Drink|110.00|images/b2.png",
                "F1|Family Meals|Bucket of 6 Chicken|475.00|images/f1.png",
                "F2|Family Meals|Spaghetti Family Pan|299.00|images/f2.png",
                "D1|Desserts and Drinks|Peach Mango Pie|45.00|images/d1.png",
                "D2|Desserts and Drinks|Iced Tea (Large)|55.00|images/d2.png"
            };
        }
    }
}

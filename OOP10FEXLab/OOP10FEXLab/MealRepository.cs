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
        /// Reads every package meal from the file.
        /// </summary>
        public List<Meal> GetAllMeals()
        {
            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException("meals.txt was not found beside the program.", filePath);
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
    }
}
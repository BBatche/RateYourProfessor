using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RateYourProfessor
{
    public class DataStorage
    {
        protected const string ProfessorsFilePath = "professors.txt";
        private const string RatingsFilePath = "ratings.txt";
        private const string CategoriesFilePath = "categories.txt";

        public List<Professor> GetProfessors()
        {
            if (File.Exists(ProfessorsFilePath))
            {
                string json = File.ReadAllText(ProfessorsFilePath);
                return JsonConvert.DeserializeObject<List<Professor>>(json);
            }
            return new List<Professor>();
        }

        public bool SaveProfessors(List<Professor> professors)
        {
            try
            {
                // Create professors.txt
                CreateEmptyFile(ProfessorsFilePath);

                Console.WriteLine("Files created successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error creating files: {ex.Message}");
            }

            for (int i = 0; i < professors.Count; i++)
            {
                var currentProfessor = professors[i];

                // Check for invalid conditions
                if (currentProfessor.ID <= 0 || currentProfessor.Name == null)
                {
                    return false;
                }

                // Check for duplicate IDs
                for (int j = i + 1; j < professors.Count; j++)
                {
                    if (currentProfessor.ID == professors[j].ID)
                    {
                        Console.WriteLine($"Duplicate ID found: {currentProfessor.ID}");
                        return false;
                    }
                }
            }
            string json = JsonConvert.SerializeObject(professors, Formatting.Indented);
            File.WriteAllText(ProfessorsFilePath, json);
            return true;
        }

        public List<Rating> GetRatings()
        {
            if (File.Exists(RatingsFilePath))
            {
                string json = File.ReadAllText(RatingsFilePath);
                return JsonConvert.DeserializeObject<List<Rating>>(json);
            }
            return new List<Rating>();
        }

        public bool SaveRatings(List<Rating> ratings)
        {
            try
            {
                // Create ratings.txt
                CreateEmptyFile(RatingsFilePath);

                Console.WriteLine("Files created successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error creating files: {ex.Message}");
                return false;
            }

            for (int i = 0; i < ratings.Count; i++)
            {
                var currentRating = ratings[i];

                // Check for invalid conditions
                if (currentRating.ID <= 0 || currentRating.Value < 0 || currentRating.Value > 5)
                {
                    Console.WriteLine("Invalid rating ID or Score.");
                    return false;
                }

                // Check for duplicate IDs
                for (int j = i + 1; j < ratings.Count; j++)
                {
                    if (currentRating.ID == ratings[j].ID)
                    {
                        Console.WriteLine($"Duplicate rating ID found: {currentRating.ID}");
                        return false;
                    }
                }
            }

            string json = JsonConvert.SerializeObject(ratings, Formatting.Indented);
            File.WriteAllText(RatingsFilePath, json);
            return true;
        }

        public List<Categories> GetCategories()
        {
            if (File.Exists(CategoriesFilePath))
            {
                string json = File.ReadAllText(CategoriesFilePath);
                return JsonConvert.DeserializeObject<List<Categories>>(json);
            }
            return new List<Categories>();
        }

        public bool SaveCategories(List<Categories> categories)
        {
            try
            {
                // Create categories.txt
                CreateEmptyFile(CategoriesFilePath);

                Console.WriteLine("Files created successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error creating files: {ex.Message}");
                return false;
            }

            for (int i = 0; i < categories.Count; i++)
            {
                var currentCategory = categories[i];

                // Check for invalid conditions
                if (currentCategory.ID <= 0 || currentCategory.Name == null)
                {
                    Console.WriteLine("Invalid category ID or Name.");
                    return false;
                }

                // Check for duplicate IDs
                for (int j = i + 1; j < categories.Count; j++)
                {
                    if (currentCategory.ID == categories[j].ID)
                    {
                        Console.WriteLine($"Duplicate category ID found: {currentCategory.ID}");
                        return false;
                    }
                }
            }

            string json = JsonConvert.SerializeObject(categories, Formatting.Indented);
            File.WriteAllText(CategoriesFilePath, json);
            return true;
        }

        public void CreateEmptyFile(string filePath)
        {
            if (!File.Exists(filePath))
            {
                File.WriteAllText(filePath, string.Empty);
            }
        }

        public void ClearProfessorsFile()
        {
            File.WriteAllText(ProfessorsFilePath, string.Empty);
        }
        public void ClearCategoriesFile()
        {
            File.WriteAllText(CategoriesFilePath, string.Empty);
        }
        public void ClearRatingsFile()
        {
            File.WriteAllText(RatingsFilePath, string.Empty);
        }

        public void DeleteProfessorsFile()
        {
            File.Delete(ProfessorsFilePath);
        }
        public void DeleteCategoriesFile()
        {
            File.Delete(CategoriesFilePath);
        }
        public void DeleteRatingsFile()
        {
            File.Delete(RatingsFilePath);
        }
    }

    
}


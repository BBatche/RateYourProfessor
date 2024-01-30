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

        public void SaveRatings(List<Rating> ratings)
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
            }
            string json = JsonConvert.SerializeObject(ratings, Formatting.Indented);
            File.WriteAllText(RatingsFilePath, json);
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

        public void SaveCategories(List<Categories> categories)
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
            }
            string json = JsonConvert.SerializeObject(categories, Formatting.Indented);
            File.WriteAllText(CategoriesFilePath, json);
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
    }

    
}


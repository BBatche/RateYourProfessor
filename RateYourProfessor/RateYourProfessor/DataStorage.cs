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
        private const string ProfessorsFilePath = "professors.json";
        private const string RatingsFilePath = "ratings.json";
        private const string CategoriesFilePath = "categories.json";

        public List<Professor> GetProfessors()
        {
            if (File.Exists(ProfessorsFilePath))
            {
                string json = File.ReadAllText(ProfessorsFilePath);
                return JsonConvert.DeserializeObject<List<Professor>>(json);
            }
            return new List<Professor>();
        }

        public void SaveProfessors(List<Professor> professors)
        {
            string json = JsonConvert.SerializeObject(professors, Formatting.Indented);
            File.WriteAllText(ProfessorsFilePath, json);
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
            string json = JsonConvert.SerializeObject(categories, Formatting.Indented);
            File.WriteAllText(CategoriesFilePath, json);
        }
    }
}
}

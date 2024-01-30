using Newtonsoft.Json;
using RateYourProfessor;
using System.Data;
// See https://aka.ms/new-console-template for more information


public class Program
{
        
    static DataStorage dataStorage = new DataStorage();
    public static List<Professor> professors = new List<Professor>();
    public static List<Rating> ratings = new List<Rating>();
    public static List<Categories> categories = new List<Categories>();

    static void Main()
    {
        LoadData();
        bool exit = false;
        while (!exit)
        {
            Console.Clear();
            Console.WriteLine("1. Add Professor");
            Console.WriteLine("2. Add Rating");
            Console.WriteLine("3. Add Category");
            Console.WriteLine("4. Edit Professor");
            Console.WriteLine("5. Edit Rating");
            Console.WriteLine("6. Edit Category");
            Console.WriteLine("7. Delete Professor");
            Console.WriteLine("8. Delete Rating");
            Console.WriteLine("9. Delete Category");
            Console.WriteLine("10. View Professors");
            Console.WriteLine("11. View Ratings");
            Console.WriteLine("12. View Categories");
            Console.WriteLine("0. Exit");


            Console.Write("Enter your choice: ");
            if (int.TryParse(Console.ReadLine(), out int choice))
            {
                switch (choice)
                {
                    case 1:
                        AddProfessor();
                        break;
                    case 2:
                        AddRating();
                        break;
                    case 3:
                        AddCategory();
                        break;
                    case 4:
                        EditProfessor();
                        break;
                    case 5:
                        EditRating();
                        break;
                    case 6:
                        EditCategory();
                        break;
                    case 7:
                        DeleteProfessor();
                        break;
                    case 8:
                        DeleteRating();
                        break;
                    case 9:
                        DeleteCategory();
                        break;
                    case 10:
                        ViewProfessors();
                        break;
                    case 11:
                        ViewRatings();
                        break;
                    case 12:
                        ViewCategories();
                        break;
                    case 0:
                        SaveData();
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a number.");
            }

            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
    }

    public static void AddProfessor()
    {
        Console.Write("Enter Professor ID: ");
        if (int.TryParse(Console.ReadLine(), out int id))
        {
            // Check if the ID is unique
            if (professors.Any(p => p.ID == id))
            {
                Console.WriteLine($"Professor with ID {id} already exists. Please choose a unique ID.");
                return;
            }

            Console.Write("Enter Professor Name: ");
            string name = Console.ReadLine();
            professors.Add(new Professor(id, name));
            Console.WriteLine("Professor added successfully.");
        }
        else
        {
            Console.WriteLine("Invalid input for Professor ID.");
        }
    }

    public static void AddRating()
    {
        Console.Write("Enter Rating ID: ");
        if (int.TryParse(Console.ReadLine(), out int ratingId))
        {
            // Check if the ID is unique
            if (ratings.Any(r => r.ID == ratingId))
            {
                Console.WriteLine($"Rating with ID {ratingId} already exists. Please choose a unique ID.");
                return;
            }

            Console.Write("Enter Professor ID: ");
            if (int.TryParse(Console.ReadLine(), out int professorId))
            {
                Professor professor = professors.FirstOrDefault(p => p.ID == professorId);
                if (professor != null)
                {
                    Console.Write("Enter Category ID: ");
                    if (int.TryParse(Console.ReadLine(), out int categoryId))
                    {
                        
                        Console.Write("Enter Rating Value (1-10): ");
                        if (int.TryParse(Console.ReadLine(), out int value) && value >= 1 && value <= 10)
                        {
                            Rating newRating = new Rating(ratingId, professorId, categoryId, value);
                            ratings.Add(newRating);
                            professor.Ratings.Add(newRating);
                            Console.WriteLine("Rating added successfully.");
                        }
                        else
                        {
                            Console.WriteLine("Invalid input for Rating Value. Please enter a value between 1 and 10.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid input for Category ID.");
                    }
                }
                else
                {
                    Console.WriteLine($"Professor with ID {professorId} not found.");
                }
            }
            else
            {
                Console.WriteLine("Invalid input for Professor ID.");
            }
        }
        else
        {
            Console.WriteLine("Invalid input for Rating ID.");
        }
    }

    public static void AddCategory()
        {
        Console.Write("Enter Category ID: ");
        if (int.TryParse(Console.ReadLine(), out int id))
        {
            // Check if the ID is unique
            if (categories.Any(c => c.ID == id))
            {
                Console.WriteLine($"Category with ID {id} already exists. Please choose a unique ID.");
                return;
            }

            Console.Write("Enter Category Name: ");
            string name = Console.ReadLine();
            Console.Write("Enter Category Description: ");
            string description = Console.ReadLine();
            categories.Add(new Categories(id, name, description));
            Console.WriteLine("Category added successfully.");
        }
        else
        {
            Console.WriteLine("Invalid input for Category ID.");
        }
    }

    public static void EditProfessor()
    {
        Console.Write("Enter Professor ID to edit: ");
        if (int.TryParse(Console.ReadLine(), out int id))
        {
            Professor professor = professors.FirstOrDefault(p => p.ID == id);
            if (professor != null)
            {
                Console.Write("Enter new Professor Name: ");
                string newName = Console.ReadLine();
                professor.Name = newName;
                Console.WriteLine("Professor edited successfully.");
            }
            else
            {
                Console.WriteLine($"Professor with ID {id} not found.");
            }
        }
        else
        {
            Console.WriteLine("Invalid input for Professor ID.");
        }
    }

    public static void EditRating()
    {
        Console.Write("Enter Rating ID to edit: ");
        if (int.TryParse(Console.ReadLine(), out int ratingId))
        {
            Rating rating = ratings.FirstOrDefault(r => r.ID == ratingId);
            if (rating != null)
            {
                Console.Write("Enter new Rating Value: ");
                if (int.TryParse(Console.ReadLine(), out int newValue))
                {
                    rating.Value = newValue;
                    Console.WriteLine("Rating edited successfully.");
                }
                else
                {
                    Console.WriteLine("Invalid input for Rating Value.");
                }
            }
            else
            {
                Console.WriteLine($"Rating with ID {ratingId} not found.");
            }
        }
        else
        {
            Console.WriteLine("Invalid input for Rating ID.");
        }
    }

    public static void EditCategory()
    {
        Console.Write("Enter Category ID to edit: ");
        if (int.TryParse(Console.ReadLine(), out int id))
        {
            Categories category = categories.FirstOrDefault(c => c.ID == id);
            if (category != null)
            {
                Console.Write("Enter new Category Name: ");
                string newName = Console.ReadLine();
                Console.Write("Enter new Category Description: ");
                string newDescription = Console.ReadLine();
                category.Name = newName;
                category.Description = newDescription;
                Console.WriteLine("Category edited successfully.");
            }
            else
            {
                Console.WriteLine($"Category with ID {id} not found.");
            }
        }
        else
        {
            Console.WriteLine("Invalid input for Category ID.");
        }
    }

    public static void DeleteProfessor()
    {
        Console.Write("Enter Professor ID to delete: ");
        if (int.TryParse(Console.ReadLine(), out int id))
        {
            Professor professor = professors.FirstOrDefault(p => p.ID == id);
            if (professor != null)
            {
                professors.Remove(professor);
                Console.WriteLine("Professor deleted successfully.");
            }
            else
            {
                Console.WriteLine($"Professor with ID {id} not found.");
            }
        }
        else
        {
            Console.WriteLine("Invalid input for Professor ID.");
        }
    }

    public static void DeleteRating()
    {
        Console.Write("Enter Rating ID to delete: ");
        if (int.TryParse(Console.ReadLine(), out int id))
        {
            Rating rating = ratings.FirstOrDefault(r => r.ID == id);
            if (rating != null)
            {
                ratings.Remove(rating);
                Console.WriteLine("Rating deleted successfully.");
            }
            else
            {
                Console.WriteLine($"Rating with ID {id} not found.");
            }
        }
        else
        {
            Console.WriteLine("Invalid input for Rating ID.");
        }
    }

    public static void DeleteCategory()
    {
        Console.Write("Enter Category ID to delete: ");
        if (int.TryParse(Console.ReadLine(), out int id))
        {
            Categories category = categories.FirstOrDefault(c => c.ID == id);
            if (category != null)
            {
                categories.Remove(category);
                Console.WriteLine("Category deleted successfully.");
            }
            else
            {
                Console.WriteLine($"Category with ID {id} not found.");
            }
        }
        else
        {
            Console.WriteLine("Invalid input for Category ID.");
        }
    }
    static void ViewProfessors()
    {
        Console.WriteLine("List of Professors:");
        foreach (var professor in professors)
        {
            Console.WriteLine($"ID: {professor.ID}, Name: {professor.Name}");
        }
    }

    static void ViewRatings()
    {
        Console.WriteLine("List of Ratings:");
        foreach (var rating in ratings)
        {
            Console.WriteLine($"ID: {rating.ID}, Professor ID: {rating.ProfessorID}, Category ID: {rating.CategoryID}, Value: {rating.Value}");
        }
    }

    static void ViewCategories()
    {
        Console.WriteLine("List of Categories:");
        foreach (var category in categories)
        {
            Console.WriteLine($"ID: {category.ID}, Name: {category.Name}, Description: {category.Description}");
        }
    }

    static void SaveData()
        {
            dataStorage.SaveProfessors(professors);
            dataStorage.SaveRatings(ratings);
            dataStorage.SaveCategories(categories);
            Console.WriteLine("Data saved successfully.");
        }

    static void LoadData()
    {
        professors = dataStorage.GetProfessors();
        ratings = dataStorage.GetRatings();
        categories = dataStorage.GetCategories();
        Console.WriteLine("Data loaded successfully.");
    }

}





    



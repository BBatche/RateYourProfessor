
using Newtonsoft.Json;
using RateYourProfessor;
using System;

namespace ProfessorTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestAddEmptyProfessor()
        {
            
            DataStorage ds = new DataStorage();
            ds.ClearProfessorsFile();

            Professor p1 = new Professor(0, null);
            List<Professor> pL = new List<Professor> { p1 };
            ds.SaveProfessors(pL);

            
            Assert.IsNull(ds.GetProfessors());
        }

        [TestMethod]
        public void TestAddProfessorToFileThatExists()
        {

            DataStorage ds = new DataStorage();
            ds.ClearProfessorsFile();
            Professor p1 = new Professor(1, "Bilitski");
            List<Professor> pL = new List<Professor> { p1 };

            ds.SaveProfessors(pL);

            List<Professor> test = ds.GetProfessors();

            Assert.AreEqual(pL[0].Name, test[0].Name);

        }

        [TestMethod]
        public void AddDuplicateProfessorToFile()
        {
            DataStorage ds = new DataStorage();
            ds.ClearProfessorsFile();
            Professor p1 = new Professor(1, "Bilitski");
            Professor p2 = new Professor(1, "Bilitski");
            List<Professor> pL = new List<Professor> { p1, p2 };


            Assert.IsFalse(ds.SaveProfessors(pL));

            
        }
        [TestMethod]
        public void SaveAndRetrieveCategories()
        {
            DataStorage ds = new DataStorage();
            ds.ClearCategoriesFile();

            Categories cat1 = new Categories(1, "Math", " ");
            Categories cat2 = new Categories(2, "Physics", " ");
            List<Categories> categoriesList = new List<Categories> { cat1, cat2 };

            ds.SaveCategories(categoriesList);

            List<Categories> retrievedCategories = ds.GetCategories();

            Assert.AreEqual(categoriesList.Count, retrievedCategories.Count);
        }

        [TestMethod]
        public void AddDuplicateCategoryToFile()
        {
            DataStorage ds = new DataStorage();
            ds.ClearCategoriesFile();

            Categories cat1 = new Categories(1, "Math", " ");
            Categories cat2 = new Categories(1, "Physics", " ");
            List<Categories> categoriesList = new List<Categories> { cat1, cat2 };

            Assert.IsFalse(ds.SaveCategories(categoriesList));
        }

        [TestMethod]
        public void SaveAndRetrieveRatings()
        {
            DataStorage ds = new DataStorage();
            ds.ClearRatingsFile();

            Rating rating1 = new Rating(1, 4, 3, 2);
            Rating rating2 = new Rating(2, 3, 4, 3);
            List<Rating> ratingsList = new List<Rating> { rating1, rating2 };

            ds.SaveRatings(ratingsList);

            List<Rating> retrievedRatings = ds.GetRatings();

            Assert.AreEqual(ratingsList.Count, retrievedRatings.Count);
        }

        [TestMethod]
        public void AddDuplicateRatingToFile()
        {
            DataStorage ds = new DataStorage();
            ds.ClearRatingsFile();

            Rating rating1 = new Rating(1, 4, 3, 2);
            Rating rating2 = new Rating(1, 3, 4, 3);
            List<Rating> ratingsList = new List<Rating> { rating1, rating2 };

            Assert.IsFalse(ds.SaveRatings(ratingsList));
        }

        [TestClass]
        
        public class ProgramTests
        {
            private StringWriter consoleOutput;
            private StringReader consoleInput;

            [TestInitialize]
            public void Setup()
            {
                consoleOutput = new StringWriter();
                Console.SetOut(consoleOutput);
            }

            [TestCleanup]
            public void Cleanup()
            {
                consoleOutput.Dispose();
                consoleInput.Dispose();
                Program.professors.Clear();  
                Program.ratings.Clear();    
                Program.categories.Clear(); 
            }

            [TestMethod]
            public void TestAddProfessor_UniqueID()
            {
                
                consoleInput = new StringReader("1\nJohn Doe\n");
                Console.SetIn(consoleInput);

                Program.AddProfessor();
                
                Assert.AreEqual(1, Program.professors.Count);
            }

            [TestMethod]
            public void TestAddProfessor_DuplicateID()
            {
                Program.professors.Add(new Professor(1, "ExistingProfessor"));
                consoleInput = new StringReader("1\nJohn Doe\n");
                Console.SetIn(consoleInput);

                Program.AddProfessor();
                
                Assert.AreEqual(1, Program.professors.Count); 
            }

        }
    }
}

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
        
    }
}
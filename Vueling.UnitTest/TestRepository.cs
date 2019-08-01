using Microsoft.VisualStudio.TestTools.UnitTesting;
using Vueling.Infraestructure.Repositories.Entities;

namespace Vueling.UnitTest
{
    [TestClass]
    public class TestRepository
    {
        private Repository _repository = Repository.Instance();

        [TestMethod]
        public void TestCreate()
        {
            string route = @"C:\Users\dberges\Desktop\MyTest.txt";
            
            _repository.SetRoute(route);

            Assert.AreEqual(true, _repository.Create());
        }

        [TestMethod]
        public void TestWrite()
        {
            string route = @"C:\Users\dberges\Desktop\MyTest.txt";

            _repository.SetRoute(route);

            Assert.AreEqual(true, _repository.Add("jose,tattuine"));

        }

        [TestMethod]
        public void TestRead()
        {
            string route = @"C:\Users\dberges\Desktop\MyTest.txt";

            _repository.SetRoute(route);

            Assert.IsNotNull(_repository.GetAll());

        }

        [TestMethod]
        public void TestSearch()
        {
            string route = @"C:\Users\dberges\Desktop\MyTest.txt";

            _repository.SetRoute(route);
            

            Assert.IsNotNull(_repository.GetById("Yoda", "Dagoba"));

        }

        [TestMethod]
        public void TestUpdate()
        {
            string route = @"C:\Users\dberges\Desktop\MyTest.txt";

            _repository.SetRoute(route);


            Assert.AreEqual(true, _repository.Update("jose", "tattouine", "lucas","planet1"));

        }

        [TestMethod]
        public void TestDeleteLine()
        {
            string route = @"C:\Users\dberges\Desktop\MyTest.txt";

            _repository.SetRoute(route);
            Assert.AreEqual(true, _repository.Delete("jorge", "planet1"));
        }

        [TestMethod]
        public void TestDeleteAll()
        {
            string route = @"C:\Users\dberges\Desktop\MyTest.txt";

            _repository.SetRoute(route);

            Assert.AreEqual(true, _repository.DeleteAll());

        }

    }
}

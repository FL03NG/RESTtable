using Microsoft.VisualStudio.TestTools.UnitTesting;
using RESTtable.Models;
namespace TestProject1
{
    [TestClass]
    public sealed class Test1
    {
        private TableRepoList _repo;

        [TestInitialize]
        public void Setup()
        {
            _repo = new TableRepoList(true); // starter med data
        }
        [TestMethod]
        public void Get_MaxWeight_ShouldReturnCorrectTables()
        {
            var result = _repo.Get(null, 20).ToList();

            Assert.AreEqual(2, result.Count);
            Assert.IsTrue(result.All(t => t.Weight <= 20));
        }
    }
}
    
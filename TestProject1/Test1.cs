using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RESTtable.Controllers;
using RESTtable.Models;
using System.Linq;

namespace TestProject1
{
    [TestClass]
    public class TableControllerTests
    {
        private TableController _controller;
        private TableRepoList _repo; // <-- ændret her

        [TestInitialize]
        public void Setup()
        {
            _repo = new TableRepoList(true);
            _controller = new TableController(_repo);
        }

        [TestMethod]
        public void GetTableById_ExistingId_ShouldReturnOk()
        {
            Table existingTable = _repo.GetAllTables().First();

            ActionResult<Table> result = _controller.GetTableById(existingTable.Id);

            Assert.IsNotNull(result.Result);
            Assert.IsInstanceOfType(result.Result, typeof(OkObjectResult));
        }
    }
}
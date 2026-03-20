using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RESTtable.Models;
using System;

namespace RESTtable.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TableController : ControllerBase
    {
        private readonly ITableRepo _tableRepo;

        public TableController(ITableRepo tableRepo)
        {
            _tableRepo = tableRepo;
        }
        [HttpGet]
        public ActionResult<IEnumerable<Table>> Get([FromQuery] int? minWeight, [FromQuery] int? maxWeight)
        {
            IEnumerable<Table> result = _tableRepo.Get(minWeight, maxWeight);

            if (result == null || !result.Any())
            {
                return NoContent();
            }

            return Ok(result);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<Table> GetTableById(int id)
        {
            Table? table = _tableRepo.GetTableById(id);

            if (table == null)
            {
                return NotFound();
            }

            return NotFound();
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<Table> AddTable([FromBody] Table table)
        {
            if (table == null)
            {
                return BadRequest();
            }

            Table newTable = _tableRepo.AddTable(table);

            return CreatedAtAction(nameof(GetTableById), new { id = newTable.Id }, newTable);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<Table> UpdateTable(int id, [FromBody] Table table)
        {
            if (table == null)
            {
                return BadRequest();
            }

            if (id != table.Id)
            {
                return BadRequest();
            }

            Table? updatedTable = _tableRepo.UpdateTable(table);

            if (updatedTable == null)
            {
                return NotFound();
            }

            return Ok(updatedTable);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<Table> DeleteTable(int id)
        {
            Table? deletedTable = _tableRepo.DeleteTable(id);

            if (deletedTable == null)
            {
                return NotFound();
            }

            return Ok(deletedTable);
        }
    }
}
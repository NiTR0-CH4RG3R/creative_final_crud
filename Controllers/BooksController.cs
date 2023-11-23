using System;
using System.Linq;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;

namespace creative_final_crud.Controllers {
    [ApiController]
    [Route("api/[controller]")]
    public class BooksController : ControllerBase {

        private readonly CfrDatabase _database;

        public BooksController( CfrDatabase database ) {
            _database = database;
        }

        [HttpGet]
        public IActionResult Get() {
            return Ok(
                _database.Book.ToList()
            );
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id) {
            var book = _database.Book.Find(id);
            if (book == null) {
                return NotFound();
            }
            return Ok(book);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Models.Book book) {
            try {
                _database.Book.Add(book);
                _database.SaveChanges();
                return Ok();
            } 
            catch(Exception e) {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Models.Book book) {
            try {
                if (id != book.Id) {
                    return BadRequest();
                }
                if (_database.Book.Find(id) == null) {
                    return NotFound();
                }
                _database.Book.Update(book);
                _database.SaveChanges();
                return Ok();
            }
            catch(Exception e) {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id) {
            try {
                var book = _database.Book.Find(id);
                if (book == null) {
                    return NotFound();
                }
                _database.Book.Remove(book);
                _database.SaveChanges();
                return Ok();
            } 
            catch(Exception e) {
                return BadRequest(e.Message);
            }
        }
    }
}
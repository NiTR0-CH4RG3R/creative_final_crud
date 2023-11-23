using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;

namespace creative_final_crud.Controllers {
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase {

        private readonly CfrDatabase _database;
        public UsersController( CfrDatabase database ) {
            _database = database;
        }

        [HttpGet]
        public IActionResult Get() {
            return Ok(
                _database.User.ToList()
            );
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id) {
            var user = _database.User.Find(id);
            if (user == null) {
                return NotFound();
            }
            return Ok(user);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Models.User user) {
            var _user = _database.User.Find(user.Id);
            if ( _user == null ) {
                return BadRequest();
            }
            return Ok(_user);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Models.User user) {
            if (id != user.Id || _database.User.Find(id) == null) {
                return BadRequest();
            }

            try {
                _database.User.Update(user);
                _database.SaveChanges();
                return Ok();
            }
            catch (Exception e) {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id) {
            return NotFound();
        }
    }
}
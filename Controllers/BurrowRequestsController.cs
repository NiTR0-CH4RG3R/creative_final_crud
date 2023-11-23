using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace creative_final_crud.Controllers {
    [ApiController]
    [Route("api/[controller]")]
    public class BurrowRequestsController : ControllerBase {

        private readonly CfrDatabase _database;

        public BurrowRequestsController( CfrDatabase database ) {
            _database = database;
        }

        [HttpGet]
        public IActionResult Get() {
            var requestDTOs = new List<Models.BurrowRequestDTO>();

            foreach (var request in _database.BurrowRequest.ToList()) {
                requestDTOs.Add(new Models.BurrowRequestDTO {
                    Id = request.Id,
                    UserId = request.UserId,
                    BookId = request.BookId,
                    RequestedDate = request.RequestedDate,
                    ApprovedDate = request.ApprovedDate,
                    IsApproved = request.IsApproved
                });
            }

            return Ok(requestDTOs);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id) {
            var request = _database.BurrowRequest.Find(id);
            if ( request == null ) {
                return NotFound();
            }

            return Ok(new Models.BurrowRequestDTO {
                Id = request.Id,
                UserId = request.UserId,
                BookId = request.BookId,
                RequestedDate = request.RequestedDate,
                ApprovedDate = request.ApprovedDate,
                IsApproved = request.IsApproved
            });
        }

        [HttpPost]
        public IActionResult Post([FromBody] Models.BurrowRequestDTO burrowRequest) {
            try {
                var request = new Models.BurrowRequest {
                    Id = burrowRequest.Id,
                    UserId = burrowRequest.UserId,
                    BookId = burrowRequest.BookId,
                    RequestedDate = burrowRequest.RequestedDate,
                    ApprovedDate = burrowRequest.ApprovedDate,
                    IsApproved = burrowRequest.IsApproved,
                    Book = _database.Book.Find(burrowRequest.BookId),
                    User = _database.User.Find(burrowRequest.UserId)
                };
                _database.BurrowRequest.Add(request);
                _database.SaveChanges();
                return Ok();
            }
            catch (Exception e) {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Models.BurrowRequestDTO burrowRequest) {
            return NotFound();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id) {
            return NotFound();
        }
    }
}
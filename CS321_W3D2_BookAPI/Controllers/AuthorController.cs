using System;
using System.Linq;
using System.Collections.Generic;
using CS321_W3D2_BookAPI.Data;
using CS321_W3D2_BookAPI.Models;
using CS321_W3D2_BookAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace CS321_W3D2_BookAPI.Controllers
{
    public class AuthorController
    {
        [Route("api/[controller]")]
        [ApiController]
        public class AuthorsController : ControllerBase
        {
        private readonly IAuthorService _authorService;

        // Constructor
        public AuthorsController(IAuthorService authorService)
        {
            // TODO: keep a reference to the service so we can use below
            _authorService = authorService;
        }

        // TODO: get all books
        // GET api/books
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_authorService.GetAll());
        }

        // get specific book by id
        // GET api/books/:id
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var author = _authorService.Get(id);
            if (author == null) return NotFound();
            return Ok(author);
        }

        // create a new book
        // POST api/books
        [HttpPost]
        public IActionResult Post([FromBody] Author newAuthor)
        {
            try
            {
                // add the new book
                _authorService.Add(newAuthor);
            }
            catch (System.Exception ex)
            {
                ModelState.AddModelError("AddAuthor", ex.GetBaseException().Message);
                return BadRequest(ModelState);
            }

            // return a 201 Created status. This will also add a "location" header
            // with the URI of the new book. E.g., /api/books/99, if the new is 99
            return CreatedAtAction("Get", new { Id = newAuthor.Id }, newAuthor);
        }

        // TODO: update an existing book
        // PUT api/books/:id
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Author updatedAuthor)
        {
            var author = _authorService.Update(updatedAuthor);
            if (author == null) return NotFound();
            return Ok(author);
        }

        // TODO: delete an existing book
        // DELETE api/books/:id
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var author = _authorService.Get(id);
            if (author == null) return NotFound();
            _authorService.Remove(author);
            return NoContent();
        }
        }
    }
    
}

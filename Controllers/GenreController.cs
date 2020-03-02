using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApi;
using WebApi.DTO;
using WebApi.Entities;
using WebApi.Interfaces;

namespace WebApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class GenreController : ControllerBase
    {
        private readonly IGenreRepo _repository;
        private readonly IMapper _mapper;

        public GenreController(IGenreRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        // GET: Genre
        [HttpGet]
        public ActionResult GetGenreItems()
        {
            var items = _repository.GetAll();
            List<GenreResponse> response = new List<GenreResponse>();
            foreach(var item in items)
            {
                var temp = _mapper.Map<GenreResponse>(item);
                response.Add(temp);
            }
            return Ok(response);
        }

        // GET: Genre/5
        [HttpGet("{id}")]
        public ActionResult GetGenreEntity(int id)
        {
            var genreEntity =  _repository.GetSingle(id);

            if (genreEntity == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<GenreResponse>(genreEntity));
        }

        // PUT: api/Genre/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public IActionResult PutGenreEntity(int id, GenreCreateDto genreEntity)
        {
            if (id != genreEntity.GenreId) return BadRequest();
            
            _repository.Update(id, _mapper.Map<GenreEntity>(genreEntity));

            if(!_repository.Save()) throw new Exception("Failed on save");

            return NoContent();
        }

        // POST: api/Genre
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public  ActionResult<GenreEntity> PostGenreEntity(GenreCreateDto genreEntity)
        {
            GenreEntity toAdd = _mapper.Map<GenreEntity>(genreEntity);
            _repository.Add(toAdd);
            if(!_repository.Save()) throw new Exception("Failed on save");

            return CreatedAtAction(nameof(GetGenreEntity), toAdd);
        }

        // DELETE: api/Genre/5
        [HttpDelete("{id}")]
        public ActionResult<GenreEntity> DeleteGenreEntity(int id)
        {
            var toRemove = _repository.GetSingle(id);
            if (toRemove == null) return NotFound();
            

            _repository.Delete(id);
            if(!_repository.Save()) throw new Exception("Failed on save");

            return toRemove;
        }
        [HttpGet("~/GenreExist")]
        public bool GenreEntityExists(string genre)
        {
            return _repository.isGenreExist(genre);
        }
    }
}

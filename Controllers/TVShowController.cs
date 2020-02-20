using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebApi.DTO;
using WebApi.Entities;
using WebApi.Repositories;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TVShowController : ControllerBase
    {
        private readonly IRepository _repository;
        private readonly IMapper _mapper;
        public TVShowController(IRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("id:int", Name = nameof(GetSingleTVShow))]
        public ActionResult GetSingleTVShow(int id)
        {
            TVShowEntity item = _repository.GetSingle(id);
            if(item == null) return NotFound();
            return Ok(item);
        }

        [HttpGet(Name = nameof(GetAllTVShows))]
        public ActionResult GetAllTVShows()
        {
            List<TVShowEntity> items = _repository.GetAll().ToList();
            return Ok(items);
        }

        [HttpPost(Name = nameof(AddTVShow))]
        public ActionResult AddTVShow([FromBody] TVShowCreateDto tvCreate)
        {
            if (tvCreate == null) return BadRequest();
            

            TVShowEntity toAdd = _mapper.Map<TVShowEntity>(tvCreate);
            _repository.Add(toAdd);

            if (!_repository.Save()) throw new System.Exception("Creating failed on");

            TVShowEntity newItem = _repository.GetSingle(toAdd.Id);

            return CreatedAtRoute(nameof(GetSingleTVShow), newItem);
        }

        [HttpDelete]
        [Route("{id:int}", Name = nameof(RemoveTVShow))]
        public ActionResult RemoveTVShow(int id)
        {
            TVShowEntity item = _repository.GetSingle(id);
            if(item == null) return NotFound();
            _repository.Delete(id);
            if(!_repository.Save()) throw new System.Exception("Deleting failed on save.");
            return NoContent();
        }

        [HttpGet("GetRandomTVShow", Name = nameof(GetRandomTVShow))]
        public ActionResult GetRandomTVShow(string genre)
        {
            TVShowEntity item = _repository.GetRandomTVShowByGenre(genre.ToLower());
            return Ok(item);
        }

    }
}
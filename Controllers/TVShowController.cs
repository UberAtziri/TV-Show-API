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
        private readonly ITVShowRepo _repository;
        private readonly IGenreRepo _genre;
        private readonly IMapper _mapper;
        private readonly ITVShowGenres _tvgenres;
        public TVShowController(ITVShowRepo repository, IMapper mapper, ITVShowGenres tvgenres, IGenreRepo genre)
        {
            _repository = repository;
            _mapper = mapper;
            _tvgenres = tvgenres;
            _genre = genre;
        }

        [HttpGet]
        [Route("id:int", Name = nameof(GetSingleTVShow))]
        public ActionResult GetSingleTVShow(int id)
        {
            TVShowEntity item = _repository.GetSingle(id);
            if (item == null) return NotFound();
            TVShowResponse response = _mapper.Map<TVShowResponse>(item);
            foreach(var temp in item.TVShowGenre)
            {
                response.Genres.Add(temp.Genre.Genre);
            }

            return Ok(response);
        }

        [HttpGet(Name = nameof(GetAllTVShows))]
        public ActionResult GetAllTVShows()
        {
            List<TVShowEntity> items = _repository.GetAll().ToList();
            List<TVShowResponse> responseItems = new List<TVShowResponse>();
            foreach(var item in items)
            {
                var response = _mapper.Map<TVShowResponse>(item);
                foreach(var temp in item.TVShowGenre)
                {
                    response.Genres.Add(temp.Genre.Genre);
                }
                responseItems.Add(response);
            }
            return Ok(responseItems);
        }

        [HttpPost(Name = nameof(AddTVShow))]
        public ActionResult AddTVShow([FromBody] TVShowCreateDto tvCreate)
        {
            if (tvCreate == null) return BadRequest();
            

            TVShowEntity toAdd = _mapper.Map<TVShowEntity>(tvCreate);
            _repository.Add(toAdd);

            if (!_repository.Save()) throw new System.Exception("Creating failed on");

            TVShowEntity newItem = _repository.GetSingle(toAdd.TVShowId);

            return CreatedAtRoute(nameof(GetSingleTVShow), newItem);
        }

        [HttpDelete]
        [Route("{id:int}", Name = nameof(RemoveTVShow))]
        public ActionResult RemoveTVShow(int id)
        {
            TVShowEntity item = _repository.GetSingle(id);
            if (item == null) return NotFound();
            _repository.Delete(id);
            if (!_repository.Save()) throw new System.Exception("Deleting failed on save.");
            return NoContent();
        }

        [HttpGet("GetRandomTVShow", Name = nameof(GetRandomTVShow))]
        public ActionResult GetRandomTVShow(string genre)
        {
            TVShowEntity item = _repository.GetRandomTVShowByGenre(genre.ToLower());
            var response = _mapper.Map<TVShowResponse>(item);
            foreach(var temp in item.TVShowGenre)
            {
                response.Genres.Add(temp.Genre.Genre);
            }
            return Ok(response);
        }

        [HttpPut]
        [Route("{id:int}", Name = nameof(UpdateTVShow))]
        public ActionResult<TVShowEntity> UpdateTVShow(int id, [FromBody] TVShowUpdateDto item)
        {
            if (item == null) return BadRequest();

            var existingItem = _repository.GetSingle(id);
            if (existingItem == null) return NotFound();

            _mapper.Map(item, existingItem);
            _repository.Update(id, existingItem);
            if( !_repository.Save()) throw new System.Exception("Updating failed on save.");
            return Ok(existingItem);
        }
        [HttpGet("~/AddGenre")]
        public ActionResult AddGenre(string Title, string Genre)
        {
            var TVitem = _repository.GetTVShowByTitle(Title);
            var genreItem = _genre.GetGenreEntityByGenre(Genre);
            if(genreItem == null || TVitem == null) throw new System.Exception("Genre or TVShow doesn't exist.");
            var toAdd = new TVShowGenre(){TVShowId = TVitem.TVShowId, GenreId = genreItem.GenreId};
            _tvgenres.Add(toAdd);
            TVitem.TVShowGenre.Add(toAdd);
            if(!_repository.Save()) throw new System.Exception("Failed on save.");
            return Ok(TVitem);
            
        }
    }
}
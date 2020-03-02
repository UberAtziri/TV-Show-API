using System.Security.Cryptography.X509Certificates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApi.Entities;
using WebApi.Repositories;
using AutoMapper;
using WebApi.DTO;

namespace WebApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TVShowGenresController : ControllerBase
    {
        private readonly ITVShowGenres _tvgenres;
        private readonly IMapper _mapper;


        public TVShowGenresController(ITVShowGenres tvgenres, IMapper mapper)
        {
            _tvgenres = tvgenres;
            _mapper = mapper;
        }

        // GET
        [HttpGet]
        public ActionResult Get()
        {
            var items = _tvgenres.GetAll();
            List<TVShowGenreResponse> response = new List<TVShowGenreResponse>();
            foreach(var item in items)
            {
                TVShowGenreResponse temp = new TVShowGenreResponse(){Title = item.TVShow.Title, Genre = item.Genre.Genre };
                response.Add(temp);
            }
            return Ok(response);
        }

        // GET
        [HttpGet("~/GetByTitle")]
        public ActionResult<List<TVShowGenreResponse>> GetByTitle(string title)
        {
            var tVShowGenre = _tvgenres.GetByTVShow(title);
            List<TVShowGenreResponse> response = new List<TVShowGenreResponse>();
            
            foreach(var item in tVShowGenre)
            {
                TVShowGenreResponse temp = new TVShowGenreResponse(){ Title = item.TVShow.Title, Genre = item.Genre.Genre};
                response.Add(temp);
            }

            if (tVShowGenre == null)
            {
                return NotFound();
            }

            return response;
        }

        // GET
        [HttpGet("~/GetByGenre")]
        public ActionResult<List<TVShowGenreResponse>> GetByGenre(string genre)
        {
            var tVShowGenre = _tvgenres.GetByGenre(genre);

            if (tVShowGenre == null)
            {
                return NotFound();
            }

            List<TVShowGenreResponse> response = new List<TVShowGenreResponse>();
            
            foreach(var item in tVShowGenre)
            {
                TVShowGenreResponse temp = new TVShowGenreResponse(){ Title = item.TVShow.Title, Genre = item.Genre.Genre};
                response.Add(temp);
            }
           

            return response;
        }

        // DELETE
        [HttpDelete("~/Delete")]
        public ActionResult<TVShowGenre> DeleteTVShowGenre(string title, string genre)
        {
            _tvgenres.Delete(title, genre);
            if(!_tvgenres.Save()) throw new Exception("Failed on delete.");
            return NoContent();
        }
    }
}
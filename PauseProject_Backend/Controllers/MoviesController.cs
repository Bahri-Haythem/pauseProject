﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PauseProject.DTOs;

namespace PauseProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private void setParamaters(HttpClient client)
        {
           // client.DefaultRequestHeaders.Add("x-rapidapi-host", "rawg-video-games-database.p.rapidapi.com");
            client.DefaultRequestHeaders.Add("api_key", "24b8faff37938fbb8b0d9ef7baec7a09");
            client.BaseAddress = new Uri("https://api.themoviedb.org/3/movie/550?");
        }
        // GET: api/Movies
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            using (var client = new HttpClient())
            {
                try
                {
                    //setParamaters(client);
                    client.BaseAddress = new Uri("https://api.themoviedb.org");
                    var response = await client.GetAsync("/3/movie/550?api_key=24b8faff37938fbb8b0d9ef7baec7a09");
                    response.EnsureSuccessStatusCode();

                    var stringResult = await response.Content.ReadAsStringAsync();
                    var rawBooks = JsonConvert.DeserializeObject<MoviesDTO>(stringResult);

                    return Ok(new
                    {

                    });
                }
                catch (HttpRequestException http)
                {
                    return BadRequest("bad request : " + http.Message);
                }
            }
        }


        // GET: api/Movies/5
        [HttpGet("{id}", Name = "GetMovies")]
        public async Task<IActionResult> Get(int id)
        {
            using (var client = new HttpClient())
            {

                // try
                //  {
                // setParamaters(client);
                client.BaseAddress = new Uri("https://api.themoviedb.org");
               
              

                List<Object> Objects = new List<Object>();
                int i = (id - 1) * 20;
                int j = 0;

                do
                {
                    var response = await client.GetAsync("/3/movie/" + i + "?api_key=24b8faff37938fbb8b0d9ef7baec7a09");
                    Console.Write(response.StatusCode);
                    //
                    if (response.IsSuccessStatusCode)
                    {
                        Console.Write(response.StatusCode);

                        var stringResult = await response.Content.ReadAsStringAsync();

                        var rawMovie = JsonConvert.DeserializeObject<MoviesDTO>(stringResult);
                        //if (rawBook.MusicID != 0)
                        //{
                        i++;
                        j++;
                        if (rawMovie.img != null) 
                        rawMovie.img= "https://image.tmdb.org/t/p/w600_and_h900_bestv2" + rawMovie.img;
                        Objects.Add(new
                        {
                            rawMovie.id,
                            rawMovie.img,
                            rawMovie.release_date,
                            rawMovie.title,


                        });
                        //}
                    }
                    else
                    {
                        i++;
                    }
                } while (j < 20);
               
                return Ok(Objects);
                // }

                // catch (HttpRequestException http)
                // {
                //     return BadRequest("bad request : " + http.Message);
                //}
            }
        }


    


}
}

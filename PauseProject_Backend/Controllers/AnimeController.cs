﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PauseProject.DTOs;

namespace PauseProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnimeController : ControllerBase
    {
        
        // GET: api/Anime
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            using (var client = new HttpClient())
            {
                try
                {
                    //setParamaters(client);
                    client.BaseAddress = new Uri("https://kitsu.io/api/edge/anime/1");
                    var response = await client.GetAsync("");
                    response.EnsureSuccessStatusCode();

                    var stringResult = await response.Content.ReadAsStringAsync();
                    var rawBooks = JsonConvert.DeserializeObject<BooksDTO>(stringResult);

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





        // PUT: api/Anime/5
        [HttpGet("{id}", Name = "GetAnimes")]
        public async Task<IActionResult> Get(int id)
        {
            
                using (var client = new HttpClient())
                {

                    // try
                    //  {
                    // setParamaters(client);
                    client.BaseAddress = new Uri("https://kitsu.io");

                    List<Object> Objects = new List<Object>();
                    int i = (id - 1) * 20;
                    int j = 0;

                    while(j <20)
                    {
                    var handle = new EventWaitHandle(false, EventResetMode.ManualReset);

                    var thread = new Thread(async () =>
                    {

                        try
                        {
                            var response = await client.GetAsync("/api/edge/anime/" + i);
                            //
                            if (response.IsSuccessStatusCode)
                            {
                                Console.Write(response.StatusCode);

                                var stringResult = await response.Content.ReadAsStringAsync();

                                var rawBook = JsonConvert.DeserializeObject<BooksDTO>(stringResult);
                                //if (rawBook.MusicID != 0)
                                //{
                               
                                j++;
                                Objects.Add(new
                                {
                                    rawBook.data,


                                });
                                Console.WriteLine("Thread{0} exits", i);
                                handle.Set();
                                j++;
                                //}
                            }

                            i++;

                        }
                     
                     catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                });
                i++;

                thread.Start();

            }

            Console.WriteLine("Main thread exits");
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

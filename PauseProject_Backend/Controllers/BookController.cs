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
    public class BookController : ControllerBase
    {
        // GET: api/Book
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Book/5
        [HttpGet("{id}", Name = "GetBook")]
        public async Task<IActionResult> Get(int id)
        {
            using (var client = new HttpClient())
            {

                client.BaseAddress = new Uri("https://kitsu.io/api/edge/manga/" + id);
                List<Object> Objects = new List<Object>();




                var response = await client.GetAsync("");
                //
                if (response.IsSuccessStatusCode)
                {
                    Console.Write(response.StatusCode);

                    var stringResult = await response.Content.ReadAsStringAsync();

                    var rawBook = JsonConvert.DeserializeObject<BooksDTO>(stringResult);
                    //if (rawBook.MusicID != 0)
                    //{

                    Objects.Add(new
                    {
                        rawBook.data,


                    });

                }



                return Ok(Objects);

            }
        }

        // GET: api/BookTitle/5
        [HttpGet("title/{id}", Name = "GetBookTitle")]
        public async Task<IActionResult> Get2(int id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://kitsu.io/api/edge/manga/" + id);
                List<Object> Objects = new List<Object>();

                var response = await client.GetAsync("");

                if (response.IsSuccessStatusCode)
                {
                    var stringResult = await response.Content.ReadAsStringAsync();
                    var rawBooks = JsonConvert.DeserializeObject<BookTitleDTO>(stringResult);
                    rawBooks.data.type = "book";
                    Objects.Add(new
                    {
                        rawBooks.data.id,
                        rawBooks.data.attributes.canonicalTitle,
                        rawBooks.data.type
                      

                    });
                }



                    return Ok(Objects);
                }
            }

        }
    }


    // POST: api/Book


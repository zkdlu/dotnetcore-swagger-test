using System;
using System.Collections;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CustomSwagger.Controllers
{
    [ApiController]
    [Route("[controller]")] // [Route("person")]
    public class PersonController : ControllerBase
    {
        private static readonly Person[] People = new[]
        {
            new Person
            {
                Name = "1",
                Age = 10,
                Description = "Hello"
            },
            new Person
            {
                Name = "2",
                Age = 20,
                Description = "World"
            }
        };

        private readonly ILogger<PersonController> _logger;

        public PersonController(ILogger<PersonController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<Person> GetPeople()
        {
            foreach (var person in People)
            {
                yield return person;
            }
        }

        [HttpGet("/person/{id}")]
        public Person GetPerson(int id)
        {
            if (People.Length < id || id < 0)
            {
                return new Person
                {
                    Name = "Empty",
                    Age = 0,
                    Description = "Empty"
                };
            }

            return People[id];
        }
    }
}

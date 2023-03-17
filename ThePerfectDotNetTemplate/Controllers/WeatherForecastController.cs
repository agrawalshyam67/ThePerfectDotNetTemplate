using System.Security.Cryptography;
using Core.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Repository;

namespace ThePerfectDotNetTemplate.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly ThePerfectDotNetTemplateDbContext _dbContext;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, ThePerfectDotNetTemplateDbContext dbContext)
        {
            _logger = logger;
            _dbContext = dbContext;
        }

        [HttpPut]
        [Route("Users/ChangeRoles/{id:long}/{role}")]
        public IEnumerable<UserEntity> ChangeRoles([FromRoute] long id, [FromRoute] string role)
        {
            var user = _dbContext
                .Users
                .FirstOrDefault(user => user.Id == id);
            if (user != null)
            {
                user.UserRoles = Enum.Parse<UserRoles>(role, true);
                _dbContext.Users.Update(user);
            }

            _dbContext.SaveChanges();

            var users = _dbContext.Users.ToList();
            return users;
        }
        
        [HttpGet]
        [Route("Users")]
        public IEnumerable<UserEntity> GetUsers()
        {
            var user = new UserEntity();
            user.FirstName = "Shyam";
            // user.FirstName = Guid.NewGuid().ToString();
            user.UserRoles = UserRoles.Admin|UserRoles.User;
            _dbContext.Users.Add(user);
            _dbContext.SaveChanges();

            var users = _dbContext.Users.ToList();
            return users;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
               return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}
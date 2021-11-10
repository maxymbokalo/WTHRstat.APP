using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using WTHRstat.APP.EntityFramework;
using WTHRstat.APP.Models;
using WTHRstat.APP.ModelsERD;

namespace WTHRstat.APP.Controllers
{
    [ApiController]
    [Route("api/wthrstat")]
    public class WeatherController : Controller
    {
        private WTHRstatDBContext _dbContext;

        public WeatherController(WTHRstatDBContext dbContext)
        {
            _dbContext = dbContext;
        }
        [Route("getemissions")]
        [HttpGet]
        public IActionResult GetEmissions()
        {
            return Ok(_dbContext.Emissions);
        }
        [Route("getsources")]
        [HttpGet]
        public IActionResult GetSources()
        {
            return Ok(_dbContext.Sources);
        }
        [Route("addemission")]
        [HttpPost]
        public IActionResult AddEmission(EmissionERD emission)
        {
            _dbContext.Emissions.Add(emission);
            _dbContext.SaveChanges();
            return Ok();
        }
        [Route("addsource")]
        [HttpPost]
        public IActionResult AddSource(SourceERD source)
        {
            _dbContext.Sources.Add(source);
            _dbContext.SaveChanges();
            return Ok();
        }
        [HttpDelete("deleteemission/{id}")]
        public IActionResult DeleteEmission(int id)
        {
            var emission = _dbContext.Emissions.FirstOrDefault(em => em.Id == id);
            _dbContext.Emissions.Remove(emission);
            _dbContext.SaveChanges();
            return Ok();
        }
        [HttpDelete("deletesource/{id}")]
        public IActionResult DeleteSource(int id)
        {
            var source = _dbContext.Sources.FirstOrDefault(sr => sr.Id == id);
            _dbContext.Sources.Remove(source);
            _dbContext.SaveChanges();
            return Ok();
        }
        [Route("updatesource")]
        [HttpPut]
        public IActionResult UpdateSource(SourceERD source)
        {
            _dbContext.Sources.Update(source);
            _dbContext.SaveChanges();
            return Ok();
        }
        [Route("updateemission")]
        [HttpPut]
        public IActionResult UpdateEmission(EmissionERD emission)
        {
            _dbContext.Emissions.Update(emission);
            _dbContext.SaveChanges();
            return Ok();
        }/*
        [Route("getdailyaqi")]
        [HttpGet]
        public IActionResult GetDailyAqi(string city, DateTime date)
        {
            var dailyAqi = GetAqi(city, date);

            return Ok(new DailyAqiERD {
                SourceName = city,
                Aqi = dailyAqi,
            });
        }
        public IActionResult GetCityAqis(string city)
        {

            return Ok();
        }
        public double GetAqi(string city,DateTime date)
        {
            var sourceCity = _dbContext.Sources.FirstOrDefault(s => s.City == city);
            IEnumerable<EmissionERD> cityEmissions = _dbContext.Emissions.Where(e => e.Source_Id == sourceCity.Id && e.Date.Date == date.Date);
            var dailyAqi = 0;
            foreach (EmissionERD em in cityEmissions)
            {
                dailyAqi += em.Concentration;
            }
            return dailyAqi;
        }
        */
    }
}

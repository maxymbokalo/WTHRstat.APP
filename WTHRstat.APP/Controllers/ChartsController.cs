using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WTHRstat.APP.EntityFramework;
using WTHRstat.APP.ModelsERD;

namespace WTHRstat.APP.Controllers
{
    [ApiController]
    [Route("api/charts")]
    public class ChartsController : Controller
    {
        private WTHRstatDBContext _dbContext;

        public ChartsController(WTHRstatDBContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IActionResult Index()
        {
            return View();
        }
        [Route("getcharts")]
        [HttpGet]
        public IActionResult getSourceEmissions(SearchSource search)
        {
            var emissions = _dbContext.Emissions.Where(em =>
            em.Source_Id == search.SourceId && em.Date.Date >= search.StartDate.Date && em.Date.Date <= search.EndDate.Date);

            return Ok(emissions);
        }
    }
}

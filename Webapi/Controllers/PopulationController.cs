using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DAL.Interface;
using DAL.Data;
using Models.Model;
using Microsoft.AspNetCore.Components.Authorization;
using System.Reflection.Metadata.Ecma335;

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Webapi.Controllers

{
    [Route("api/[concroller]")]
    [ApiController]
    public class PopulationController : ControllerBase
    {
        private readonly IPopulation _dbstorePopulation;
       
        public PopulationController(IPopulation dbstorePopulation)
        {
            _dbstorePopulation = dbstorePopulation; 
        }

        [HttpPost]
        [Route("/api/addPopulation/{cityName}")]
        public async Task<ActionResult<bool>> Add(string cityName)
        {
            var res = _dbstorePopulation.AddCity(cityName);
            return Ok(res);

        }

        [HttpDelete]
        [Route("/api/deletePopulation/{id}")]
        public async Task<ActionResult<bool>> delete(int id)
        {
            var res = _dbstorePopulation.DeletePopulation(id);
           
            return Ok(res);

        }

        [HttpGet]
        [Route("/api/getallPopulation/{skip}")]
        public async Task<IActionResult> GetAllPopulation(int skip)
        {
            var populations = await _dbstorePopulation.Getallpopulations(skip);

            if (populations == null || !populations.Any())
            {
                return NoContent(); 
            }

            return Ok(populations); 
        }

        [HttpGet]
        [Route("/api/getPopulationByPart/{name}/{skip}")]
        public async Task<IActionResult> getPopulationByPart(string name, int skip)
        {
            var populations = await _dbstorePopulation.GetPopulationByPartOfName(name,skip);

            if (populations == null )
            {
                return NoContent(); // מחזיר קוד 204 No Content אם אין פריטים
            }

            return Ok(populations);
        }
        [HttpGet]
        [Route("/api/getSortInDescendingOrder/{skip}/")]
        public async Task<IActionResult> SortInDescendingOrder(int skip)
        {
            var populations = await _dbstorePopulation.SortInDescendingOrder(skip);

            if (populations == null)
            {
                return NoContent(); // מחזיר קוד 204 No Content אם אין פריטים
            }

            return Ok(populations);
        }

        [HttpGet]
        [Route("/api/getSort/{skip}")]
        public async Task<IActionResult> SortInAscendingOrder(int skip)
        {
            var populations = await _dbstorePopulation.SortInAscendingOrder(skip);

            if (populations == null)
            {
                return NoContent(); 
            }

            return Ok(populations);
        }


        [HttpPut]
        [Route("/api/ChangePopulation/{src}/{destination}/undefined/undefined")]
        public async Task<ActionResult<bool>> ChangePopulation(int src ,string destination)
        {
            await _dbstorePopulation.EditPopulation(src,destination);
            return Ok();
        }



    }
}

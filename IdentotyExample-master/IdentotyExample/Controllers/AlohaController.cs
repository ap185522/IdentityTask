using IdentotyExample.Models.ModelMenu;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Data;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using static IdentotyExample.Enums.Enums;


namespace IdentotyExample.Controllers
{
    public class AlohaController : Controller
    {
        private readonly AlohaAPIClient _client;

        public AlohaController(AlohaAPIClient client)
        {
            _client = client;
        }

        [HttpGet]
        [Route("GetNearbySitesBySearchTerm")]
        public async Task<ActionResult> GetNearbySitesBySearchTerm(string searchTerm, bool getNearbySitesForFirstGeocodeResult = true, bool includeAllSites = false, int offset = 0, int limit = 5)
        {
            var result = await _client.GetNearbySitesBySearchTerm(searchTerm, getNearbySitesForFirstGeocodeResult, includeAllSites, offset, limit);
            return Ok(result);
        }


        [HttpGet]
        [Route("GetNearbySitesByLatitudeAndLongitude")]
        public async Task<ActionResult> GetNearbySitesByLatitudeAndLongitude(double latitude, double longitude, string orderMode = "Pickup", int offset = 0, int limit = 5, bool includeAllSites = false, string companyCode = "DLEC001")
        {
            var response = await _client.GetNearbySitesByLatitudeAndLongitude(latitude, longitude, orderMode, offset, limit,includeAllSites,companyCode);
            return Ok(response);
        }

        [HttpGet]
        [Route("GetMenu")]
        public async Task<ActionResult> GetMenu(int siteId, DateTime promiseTime = new DateTime(), bool includeInvisible = false, string orderMode = "Delivery")
        {
            var response = await _client.GetMenu(siteId, promiseTime, includeInvisible, orderMode);    
            return Ok(response);
        }


        [HttpGet]
        [Route("GetTimes")]
        public async Task<ActionResult> GetTimes(int siteId, bool noCache = false, string orderMode = "Delivery")
        {
            var response=await _client.GetTimes(siteId, noCache, orderMode);
            return Ok(response);
        }

        [HttpPut]
        [Route("PutOrder")]
        public async Task<ActionResult> PutOrder([FromBody] Order order, int siteId, bool verbose = false)
        {
            var response = await _client.PutOrder(order, siteId, verbose);
            return Ok(response);
        }

        public IActionResult Index()
        {
            return View();
        }

    }
}

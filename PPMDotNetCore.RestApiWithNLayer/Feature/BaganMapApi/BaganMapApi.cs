
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Threading.Tasks;


namespace PPMDotNetCore.RestApiWithNLayer.Feature.BankingManagementSystem
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaganMapApi : ControllerBase
    {
        private async Task<BaganMap> GetData()
        {
            string jsonstr = await System.IO.File.ReadAllTextAsync("BaganMap.json");
            var model = JsonConvert.DeserializeObject<BaganMap>(jsonstr);
            return model;
        }

        [HttpGet("baganInfo")]
        public async Task<IActionResult> BanganInfo()
        {
            var model = await GetData();
            return Ok(model.Tbl_BaganMapInfoData);
        }
        [HttpGet("{pagodaName}")]
        public async Task<IActionResult> PagodaName(string pagodaName)
        {
            var model = await GetData();
            return Ok(model.Tbl_BaganMapInfoData.FirstOrDefault(x => x.PagodaEngName == pagodaName));
        }
    }





    public class BaganMap
    {
        public Tbl_Baganmapinfodata[] Tbl_BaganMapInfoData { get; set; }
        public Tbl_Baganmapinfodetaildata[] Tbl_BaganMapInfoDetailData { get; set; }
        public Tbl_Travelroutelistdata[] Tbl_TravelRouteListData { get; set; }
    }

    public class Tbl_Baganmapinfodata
    {
        public string Id { get; set; }
        public string PagodaMmName { get; set; }
        public string PagodaEngName { get; set; }
        public float Latitude { get; set; }
        public float Longitude { get; set; }
    }

    public class Tbl_Baganmapinfodetaildata
    {
        public string Id { get; set; }
        public string Description { get; set; }
    }

    public class Tbl_Travelroutelistdata
    {
        public string TravelRouteId { get; set; }
        public string TravelRouteName { get; set; }
        public string TravelRouteDescription { get; set; }
        public string[] PagodaList { get; set; }
    }



}

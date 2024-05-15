using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace PPMDotNetCore.RestApiWithNLayer.Feature.MyanmarProverb
{
    [Route("api/[controller]")]
    [ApiController]
    public class MyanmarProverbController : ControllerBase
    {
        private async Task<MyanmarProverb> GetDataFromApi()
        {
            HttpClient _client = new HttpClient();
            var response = await _client.GetAsync("https://raw.githubusercontent.com/sannlynnhtun-coding/Myanmar-Proverbs/main/MyanmarProverbs.json");
            if (response.IsSuccessStatusCode)
            {
                string jsonStr = await response.Content.ReadAsStringAsync();
                var model = JsonConvert.DeserializeObject<MyanmarProverb>(jsonStr);
                return model!;
            }
            return null;
        }
        [HttpGet]
        public async Task<IActionResult> GetDataAsync()
        {
            var model = await GetDataFromApi();
            return Ok(model.Tbl_MMProverbs);
        }
        [HttpGet("{titleName}")]
        public async Task<IActionResult> GetApiData(string titleName)
        {
            var modle = await GetDataFromApi();
            var item = modle.Tbl_MMProverbsTitle.FirstOrDefault(x => x.TitleName == titleName);
            if (item is null) return NotFound("Please put any title name");
            var titleId = item.TitleId;
            var result = modle.Tbl_MMProverbs.Where(x => x.TitleId == titleId);
            List<Tbl_MmproverbsHead> lst = result.Select(x => new Tbl_MmproverbsHead
            {
                ProverbId = x.ProverbId,
                ProverbName = x.ProverbName,
                TitleId = x.TitleId
            }).ToList();
            return Ok(lst);
        }
        [HttpGet("{titleId}/{proverbId}")]
        public async Task<IActionResult> Get(int titleId, int proverbId)
        {
            var modle = await GetDataFromApi();
            var result = modle.Tbl_MMProverbs.FirstOrDefault(x => x.TitleId == titleId && x.ProverbId == proverbId);
            return Ok(result);
        }
    }

    public class MyanmarProverb
    {
        public Tbl_Mmproverbstitle[] Tbl_MMProverbsTitle { get; set; }
        public Tbl_Mmproverbs[] Tbl_MMProverbs { get; set; }

    }

    public class Tbl_Mmproverbstitle
    {
        public int TitleId { get; set; }
        public string TitleName { get; set; }
    }

    public class Tbl_Mmproverbs
    {
        public int TitleId { get; set; }
        public int ProverbId { get; set; }
        public string ProverbName { get; set; }
        public string ProverbDesp { get; set; }
    }
    public class Tbl_MmproverbsHead
    {
        public int TitleId { get; set; }
        public int ProverbId { get; set; }
        public string ProverbName { get; set; }
    }

}

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace PPMDotNetCore.LatHtaikBayDinApi.Controllers.MyanmarProverb
{
    [Route("api/[controller]")]
    [ApiController]
    public class MyanmarProverbController : ControllerBase
    {
        private async Task<MyanmarProverb> GetDataAsync()
        {
            string jsonStr = await System.IO.File.ReadAllTextAsync("data.json");
            var model = JsonConvert.DeserializeObject<MyanmarProverb>(jsonStr);
            return model!;
        }

        [HttpGet]
        public async Task<IActionResult> ProverbTitle()
        {
            var model = await GetDataAsync();
            return Ok(model.Tbl_MMProverbsTitle);
        }
        [HttpGet("{titleId}/{proverbId}")]
        public async Task<IActionResult>ProverdDetail(int titleId,string proverbId)
        {
            var model = await GetDataAsync();
            var item = model.Tbl_MMProverbs.Where(x => x.TitleId == titleId);
            List<MyanmarProverbHead> lst = item.Select(x => new MyanmarProverbHead
            {
                ProverbId = x.ProverbId,
                ProverbName = x.ProverbName,
                TitleId = x.TitleId
            }).ToList();
            return Ok(lst);
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
    public class MyanmarProverbHead
    {
        public int TitleId { get; set; }
        public int ProverbId { get; set; }
        public string ProverbName { get; set; }
    }
}



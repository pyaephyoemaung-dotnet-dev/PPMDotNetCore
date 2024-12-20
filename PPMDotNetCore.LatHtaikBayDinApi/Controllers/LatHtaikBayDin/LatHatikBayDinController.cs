using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace PPMDotNetCore.LatHtaikBayDinApi.Controllers.LatHtaikBayDin
{
    [Route("api/[controller]")]
    [ApiController]
    public class LatHatikBayDinController : ControllerBase
    {
        private async Task<LatHatikBayDin> GetDataAsync()
        {
            string json = await System.IO.File.ReadAllTextAsync("LatHatikBayDin.json");
            var model = JsonConvert.DeserializeObject<LatHatikBayDin>(json);
            return model!;
        }
        [HttpGet]
        public async Task<IActionResult> QuestionsAsync()
        {
            var model = await GetDataAsync();
            return Ok(model.questions);
        }
        [HttpGet]
        public async Task<IActionResult> NumberList()
        {
            var model = await GetDataAsync();
            return Ok(model.numberList);
        }
        [HttpGet("{questionsNo}/{no}")]
        public async Task<IActionResult>Answer(int questionsNo,int no)
        {
            var model = await GetDataAsync();
            return Ok(model.answers.FirstOrDefault(x => x.questionNo == questionsNo && x.answerNo == no));
        }
    }
}

public class LatHatikBayDin
{
    public Question[] questions { get; set; }
    public Answer[] answers { get; set; }
    public string[] numberList { get; set; }
}

public class Question
{
    public int questionNo { get; set; }
    public string questionName { get; set; }
}

public class Answer
{
    public int questionNo { get; set; }
    public int answerNo { get; set; }
    public string answerResult { get; set; }
}

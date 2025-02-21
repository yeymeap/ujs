using Microsoft.AspNetCore.Mvc;
[Route("[controller]")]
public class ContentController : Controller
{
    [HttpGet]
    [Route("[action]")]
    public string ParIntro()
    {
        return "Lorem Ipsum";
    }

    [HttpGet]
    [Route("[action]")]
    public string ParFirst()
    {
        return "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Maecenas purus enim, tincidunt ac auctor in, vehicula sit amet neque. Quisque quis risus porta libero egestas posuere at in nunc.Donec ornare placerat mauris, ac";
    }

    [HttpGet]
    [Route("[action]")]
    public string CurrentTime()
    {
        return DateTime.Now.ToString("o");
    }

}
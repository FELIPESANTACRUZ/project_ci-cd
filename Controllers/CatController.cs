using System.Net;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;


namespace CICD_Project.Controllers;

[ApiController]
[Route("[controller]")]
public class CatController : ControllerBase
{
    public static string URLBase = "HDUJAHJD";

    private readonly ILogger<CatController> _logger;
    private readonly IConfiguration Configuration;

    public CatController(ILogger<CatController> logger, IConfiguration configuration){
        _logger = logger;
        Configuration = configuration;
    }

    [HttpGet]
    public IActionResult Get(bool image){
        var random = new Random();
        var url = URLBase+random.Next(1,10)+".jpg";
        if(image)
        {
            using (var webClient = new WebClient()){
                byte[] imageBytes = webClient.DownloadData(url);
                return File(imageBytes, "image/jpg");
            }
        }
        else {
            return Ok(url);
        }
    }
}

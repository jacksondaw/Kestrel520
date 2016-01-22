using System;
using Kestrel520.Models;
using Microsoft.AspNet.Mvc;
using Microsoft.Extensions.Logging;

namespace Kestrel520.Controllers
{
    public class Home : Controller
    {
        private readonly ILogger _logger;

        public Home(ILogger<Home> logger)
        {
            _logger = logger;
        }

        [HttpGet("/")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost("/")]
        public IActionResult Post(FileDescription fileDescription)
        {
            if (fileDescription == null) return HttpBadRequest("No file description provided");

            if (fileDescription.File.Length <= 0) return HttpBadRequest();

            try
            {
                fileDescription.ContentType = fileDescription.File.ContentType;
                fileDescription.CreatedTimestamp = DateTime.Now;


                return Ok(fileDescription);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);


                return HttpBadRequest($"Failed to process file upload. {ex.Message}");
            }
        }
    }
}
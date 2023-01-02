using Microsoft.AspNetCore.Mvc;
using WebApplication1.Services.InteerFaces;
using WebApplication1.Services;
using WebApplication1.ViewModels;

namespace WebApplication1.Controllers
{
    public class MoovieController : Controller
    {
        private readonly ImoovieService _moovieService;
        private readonly MoovieInfoService _moovieInfoService;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public MoovieController(ImoovieService moovieService, MoovieInfoService moovieInfoService, IWebHostEnvironment webHostEnvironment)
        {
            _moovieService = moovieService;
            _moovieInfoService = moovieInfoService;
            _webHostEnvironment = webHostEnvironment;
        }

        public IActionResult Index()
        {
            var data = _moovieService.GetMoovieList();
            return View(data);
        }
        [HttpGet]
        public IActionResult Add()
        {
          ViewBag.countries=_moovieInfoService.GetCountries();
            ViewBag.actors = _moovieInfoService.GetActors();
            ViewBag.Categories = _moovieInfoService.GetCategories();
            return View();
        }
        [HttpPost]
        public IActionResult Add(MoovieAddEdit model, IFormFile PosterImage)
        {
            if (PosterImage != null)
            {
                string fileName = Guid.NewGuid() + System.IO.Path.GetExtension(PosterImage.FileName);
                string path = $"{_webHostEnvironment.WebRootPath}/images/moovies/{fileName}";
                model.PosterImageFileName = fileName;
                using var fileStream = new FileStream(path, FileMode.Create);
                PosterImage.CopyTo(fileStream);
            }
            int moovieId = _moovieService.Add(model);
            return RedirectToAction("Index");
        }
    }
}

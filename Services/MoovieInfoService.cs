using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.Data;
using WebApplication1.Data;
using WebApplication1.Services.InteerFaces;
using WebApplication1.ViewModels;

namespace WebApplication1.Services
{
    public class MoovieInfoService : IMoovieInfo
    {
        private readonly DataContext _moovieDbContext;
        public MoovieInfoService(DataContext moovieDbContext)
        {
            _moovieDbContext = moovieDbContext;
        }

        public List<DropDownViewModel> GetActors()
        {
            var actors = _moovieDbContext.Actors.OrderBy(a => a.LastName).
                Select(a => new DropDownViewModel
                {
                    Value=a.Id,
                    Text=a.FirstName,
                }).ToList();
            return actors;
        }

        public List<DropDownViewModel> GetCategories()
        {
            var categories = _moovieDbContext.Categories.
                Select(a => new DropDownViewModel
                {
                    Text = a.Name,
                    Value = a.Id
                }).ToList();
            return categories;
        }

        public List<DropDownViewModel> GetCountries()
        {
            var countries = _moovieDbContext.Countries.Select(c => new DropDownViewModel
            {
                Text = c.Name,
                Value = c.Id

            }).ToList();
            return countries;
        }
        
    }
}

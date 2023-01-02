using WebApplication1.Data;
using WebApplication1.Data.Entitis;
using WebApplication1.Services.InteerFaces;
using WebApplication1.ViewModels;

namespace WebApplication1.Services
{
    public class MoovieService : ImoovieService
    {
        private readonly DataContext _moovieDbContext;
        public MoovieService(DataContext moovieDbContext)
        {
            _moovieDbContext = moovieDbContext;
        }

        public int Add(MoovieAddEdit model)
        {
            var moovieCategories = model.CategoryIds.Select(c => new MoovieCategory
            {
                CategoryId = c,

            }).ToList();
            Moovie moovie = new()
            {
                Date = model.Date,
                Description = model.Description,
                CountryId = model.CountryId,
                Name = model.Name,
                PosterImageFileName = model.PosterImageFileName
            };
            _moovieDbContext.Moovies.Add(moovie);
            moovie.Categories = new List<MoovieCategory>();
            moovieCategories.ForEach(mc => moovie.Categories.Add(mc));
            _moovieDbContext.SaveChanges();
            var moovieActors = model.ActorIds.Select(a => new MoovieActor
            {
                MoovieId = model.Id,
                ActorId = a,

            });
            _moovieDbContext.MoovieActors.AddRange(moovieActors);
            _moovieDbContext.SaveChanges();
            return moovie.Id;
        }

        public List<MoovieListView> GetMoovieList()
        {
       var list=_moovieDbContext.Moovies.Select(m=>new MoovieListView
       {
           Id = m.Id,
           Date = m.Date,
           ImageFile = m.PosterImageFileName,
           Name = m.Name,
           ActorCount = m.Actors.Count(),
           Categories = String.Join(",", m.Categories.Select(c => c.Category.Name))
       }).ToList();
            return list;    
        }
    }
}

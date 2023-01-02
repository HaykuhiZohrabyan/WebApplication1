using WebApplication1.Data;
using WebApplication1.Data.Entitis;
using WebApplication1.Services.InteerFaces;
using WebApplication1.ViewModels;

namespace WebApplication1.Services
{
    public class ActorService:IActorService
    {
        private readonly DataContext _moovieDbContext;
        public ActorService(DataContext moovieDbContext)
        {
            _moovieDbContext = moovieDbContext;
        }

        public int Add(ActorAddEditVM model)
        {
            var entity = new Actor
            {
                DOB = model.DOB,
                Biography = model.Biography,
                FirstName = model.FirstName,
                ImageFileName = model.ImageFileName,
                LastName = model.LastName,

            };
            _moovieDbContext.Actors.Add(entity);
            _moovieDbContext.SaveChanges();
            return entity.Id;
        }
    }
}

   
using WebApplication1.ViewModels;

namespace WebApplication1.Services.InteerFaces
{
    public interface IMoovieInfo
    {
        public List<DropDownViewModel> GetCountries();
        public List<DropDownViewModel> GetCategories();
        public List<DropDownViewModel> GetActors();
    }
}

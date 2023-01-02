using WebApplication1.ViewModels;

namespace WebApplication1.Services.InteerFaces
{
    public interface ImoovieService
    {
        public int Add(MoovieAddEdit model);
        public List<MoovieListView> GetMoovieList();
    }
}

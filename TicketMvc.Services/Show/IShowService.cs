using System.Collections.Generic;
using TicketMvc.Models.Show;

namespace TicketMvc.Services
{
    public interface IShowService
    {
        ShowCreate CreateShow(ShowCreate showCreate);
        IEnumerable<ShowCreate> GetAllShows();
        ShowCreate GetShowById(int id);
        void UpdateShow(int id, ShowCreate showUpdate);
        void DeleteShow(int id);
    }
}

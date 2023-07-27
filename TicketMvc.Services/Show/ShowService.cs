using TicketMvc.Models.Show;

namespace TicketMvc.Services
{
    public class ShowService : IShowService
    {
        private List<ShowCreate> _shows = new List<ShowCreate>();
        private int _nextId = 1;

        public ShowCreate CreateShow(ShowCreate showCreate)
        {
            var newShow = new ShowCreate
            {
                ShowTitle = showCreate.ShowTitle,
                Description = showCreate.Description,
            };

            newShow.Id = _nextId++;
            _shows.Add(newShow);

            return newShow;
        }

        public IEnumerable<ShowCreate> GetAllShows()
        {
            return _shows;
        }

        public ShowCreate GetShowById(int id)
        {
            return _shows.Find(show => show.Id == id);
        }

        public void UpdateShow(int id, ShowCreate showUpdate)
        {
            var existingShow = _shows.Find(show => show.Id == id);

            if (existingShow != null)
            {
                existingShow.ShowTitle = showUpdate.ShowTitle;
                existingShow.Description = showUpdate.Description;
                // You can update the ShowDate here if required.
            }
        }

        public void DeleteShow(int id)
        {
            _shows.RemoveAll(show => show.Id == id);
        }
    }
}

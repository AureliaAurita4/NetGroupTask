using NetGroupHomeTask.Models;

namespace NetGroupHomeTask.Interfaces
{
    public interface IEventRepository
    {
        IEnumerable<Event> GetAllEvents();
        Event GetEvent(int id);
        void AddEvent(Event someEvent);
        void RegisterToEvent(int id);
    }
}

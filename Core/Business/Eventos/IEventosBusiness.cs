using Core.Models.Eventos;
using System.Linq;

namespace Core.Business.Eventos
{
    public interface IEventosBusiness
    {
        IQueryable<Data.Entities.Evento> GetEventos();
        IQueryable<Data.Entities.Evento> GetEventoAtivo();
        Data.Entities.Evento GetEventoById(int id);
        void PostEvento(PostEventoModel model);
        void DeleteEvento(int id);
        void ToggleEventoStatus(int id);
    }
}

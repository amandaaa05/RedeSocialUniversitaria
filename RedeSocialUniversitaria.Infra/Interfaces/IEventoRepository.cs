using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RedeSocialUniversitaria.Domain;

namespace RedeSocialUniversitaria.Infra.Interfaces
{
    public interface IEventoRepository
    {
        Task<Evento> GetByIdAsync(int id);
        Task<IEnumerable<Evento>> GetAllAsync();
        Task AddAsync(Evento evento);
        Task<bool> SubscribeUserAsync(int eventId, int userId);
        Task SaveAsync();
    }
}

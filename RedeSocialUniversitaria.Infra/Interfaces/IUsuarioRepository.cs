using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RedeSocialUniversitaria.Domain;

namespace RedeSocialUniversitaria.Infra.Interfaces
{
    public interface IUsuarioRepository
    {
        Task<Usuario> GetByIdAsync(int id);
        Task<IEnumerable<Usuario>> GetAllAsync();
        Task AddAsync(Usuario usuario);
        Task<bool> FollowUserAsync(int userId, int followUserId);
        Task SaveAsync();
    }
}

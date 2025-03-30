using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RedeSocialUniversitaria.Domain;

namespace RedeSocialUniversitaria.Infra.Interfaces
{
    public interface IPostagemRepository
    {
        Task<Postagem> GetByIdAsync(int id);
        Task<IEnumerable<Postagem>> GetAllAsync();
        Task AddAsync(Postagem postagem);
        Task AddLikeAsync(int postagemId);
        Task AddCommentAsync(int postagemId, Comentario comentario);
        Task SaveAsync();
    }
}

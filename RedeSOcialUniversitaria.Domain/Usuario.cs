namespace RedeSocialUniversitaria.Domain
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Curso { get; set; }
        public ICollection<Usuario> Seguidores { get; set; } = new List<Usuario>();
        public ICollection<Postagem> Postagens { get; set; } = new List<Postagem>();
    }
}

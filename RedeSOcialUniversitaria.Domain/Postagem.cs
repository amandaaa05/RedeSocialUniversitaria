﻿namespace RedeSocialUniversitaria.Domain
{
    public class Postagem
    {
        public int Id { get; set; }
        public int UsuarioId { get; set; }
        public Usuario Autor { get; set; }
        public string Conteudo { get; set; }
        public DateTime Data { get; set; }
        public int Curtidas { get; set; }
        public ICollection<Comentario> Comentarios { get; set; } = new List<Comentario>();
       
    }
}

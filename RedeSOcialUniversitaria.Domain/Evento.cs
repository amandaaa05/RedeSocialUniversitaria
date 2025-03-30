namespace RedeSocialUniversitaria.Domain
{
    public class Evento
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Local { get; set; }
        public string Descricao { get; set; }
        public DateTime Data { get; set; }
        public bool ExigeInscricao { get; set; }
        public ICollection<Usuario> Inscritos { get; set; } = new List<Usuario>();
    }
}

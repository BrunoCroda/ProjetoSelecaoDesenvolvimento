namespace ProjetoSelecaoDesenvolvimento.Models
{
    public class Filme
    {
        public int id { get; set; }
        public string titulo { get; set; }
        public int mesLancamento { get; set; }
        public int anoLancamento { get; set; }
        public int generoId { get; set; }
    }
}

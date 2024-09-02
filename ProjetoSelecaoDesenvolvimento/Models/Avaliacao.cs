namespace ProjetoSelecaoDesenvolvimento.Models
{
    public class Avaliacao
    {
        public int id { get; set; }
        public int filmeId { get; set; }
        public int usuarioId { get; set; }
        public int avaliacao {  get; set; }
        public string comentario {  get; set; }  
    }
}

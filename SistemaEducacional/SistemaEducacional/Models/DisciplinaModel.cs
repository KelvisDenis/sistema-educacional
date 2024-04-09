namespace SistemaEducacional.Models
{
    public class DisciplinaModel
    {
        public int Id { get; set; }
        public string? Nome { get; set; }
        public DateTime? DataCriacao { get; set; }
        public DisciplinaModel() { }

        public DisciplinaModel(int id, string? nome, DateTime? dataCriacao)
        {
            Id = id;
            Nome = nome;
            DataCriacao = dataCriacao;
        }
        public bool CheckDate(DateTime date)
        {
            var check = (date < DateTime.Now);
            return check;
        }
    }
}

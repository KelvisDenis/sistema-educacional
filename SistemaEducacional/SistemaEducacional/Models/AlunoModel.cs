namespace SistemaEducacional.Models
{
    public class AlunoModel
    {
        public int Id { get; set; }
        public string? Nome { get; set; }
        public string? Cpf { get; set; }
        public DateTime? DataNascimento { get; set; }
        public int? IdTurma { get; private set; }
        public int? IdNota { get; private set; }
        public string? Email { get; private set; }
        public string? SenhaTemporaria { get; private set; }

        public ICollection<NotasModel> Notas { get; set; }  


        public AlunoModel() { }

        public AlunoModel(int id, string? nome, string? cpf,string? email, string? senha,
            DateTime? dataNascimento, int? idTurma)
        {
            Id = id;
            Nome = nome;
            Cpf = cpf;
            DataNascimento = dataNascimento;
            IdTurma = idTurma;
            Email = email;
            SenhaTemporaria = senha;
        }

        public bool CheckDate(DateTime date)
        {
            var check = (date < DateTime.Now);
            return check;
        }
    }
}

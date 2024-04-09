using Microsoft.AspNetCore.Components.Forms;

namespace SistemaEducacional.Models
{
    public class DirecaoModel
    {
        public int Id { get; set; }
        public string? Nome { get; set; }
        public string? Cpf { get; set; }
        public DateTime? DataNascimento { get; set; }
        public string? Email { get; set; }
        public string? Senha { get; set; }

        public DirecaoModel()
        {
        }

        public DirecaoModel(int id, string? nome,
            string? cpf, DateTime? dataNascimento, string? email, string? senha)
        {
            Id = id;
            Nome = nome;
            Cpf = cpf;
            DataNascimento = dataNascimento;
            Email = email;
            Senha = senha;
        }

        public bool CheckSenha(string? senha)
        {
            var result = (Senha == senha);
            return result;
        }
         
        public bool CheckDateValid(DateTime date)
        {
            var check = (date < DateTime.Now);
            return check;
        }

    }
}

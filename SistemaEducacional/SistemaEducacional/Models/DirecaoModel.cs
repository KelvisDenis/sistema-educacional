using Microsoft.AspNetCore.Components.Forms;
using System.ComponentModel.DataAnnotations;

namespace SistemaEducacional.Models
{
    /// <summary>
    /// classe representa a entidade direção no banco de dados 
    /// </summary>
    public class DirecaoModel
    {
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        public string? Nome { get; set; }
        [Required]
        [StringLength(11)]
        public string? Cpf { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime? DataNascimento { get; set; }
        public string? Email { get; set; }
        public string? Senha { get; set; }

        /// <summary>
        /// Construtores
        /// </summary>
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

        /// <summary>
        /// metodo checkSenha, verifica se a senha é a mesma que a da entidade 
        /// </summary>
        /// <param name="senha"></param>
        /// <returns></returns>
        public bool CheckSenha(string? senha)
        {
            var result = (Senha == senha);
            return result;
        }

        /// <summary>
        /// varifica se a data, para ser menor que a do presente momento
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public bool CheckDateValid(DateTime date)
        {
            var check = (date < DateTime.Now);
            return check;
        }

    }
}

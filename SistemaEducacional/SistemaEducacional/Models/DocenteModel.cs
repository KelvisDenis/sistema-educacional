using System.ComponentModel.DataAnnotations;

namespace SistemaEducacional.Models
{
    /// <summary>
    /// representa a entidade Docente no banco de dados 
    /// </summary>
    public class DocenteModel
    {
        public int Id { get; set; }
        [Required]
        [StringLength(100)]  
        public string? Nome { get; set; }
        [StringLength(11)]
        [Required]
        public string? Cpf { get; set; }
        [Required]
        [DataType(DataType.Date)]

        public DateTime? DataNascimento { get; set; }
        public int? IdTurma { get; private set; }
        public string? Email { get; private set; }
        public string? SenhaTemporaria { get; private set; }

        /// <summary>
        /// construtores
        /// </summary>
        public DocenteModel() { }

        public DocenteModel(int id, string? nome, string? email, string? senha,
            string? cpf, DateTime? dataNascimento, int? idTurma)
        {
            Id = id;
            Nome = nome;
            Cpf = cpf;
            DataNascimento = dataNascimento;
            IdTurma = idTurma;
            Email = email;
            SenhaTemporaria = senha;
        }
        /// <summary>
        /// metodo para checar se a data não é maior que a atual 
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public bool CheckDate(DateTime date)
        {
            var check = (date < DateTime.Now);
            return check;
        }
    }
}

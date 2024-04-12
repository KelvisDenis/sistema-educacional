using System.ComponentModel.DataAnnotations;

namespace SistemaEducacional.Models
{
    /// <summary>
    /// representa a entidade Disciplina no banco de dados
    /// </summary>
    public class DisciplinaModel
    {
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        public string? Nome { get; set; }
        [Required]
        [DataType(DataType.Date)]

        public DateTime? DataCriacao { get; set; }

        /// <summary>
        /// construtores
        /// </summary>
        public DisciplinaModel() { }

        public DisciplinaModel(int id, string? nome, DateTime? dataCriacao)
        {
            Id = id;
            Nome = nome;
            DataCriacao = dataCriacao;
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

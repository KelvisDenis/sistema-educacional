using System.ComponentModel.DataAnnotations;

namespace SistemaEducacional.Models
{
    /// <summary>
    /// representa a entidade nota no banco de dados
    /// </summary>
    public class NotasModel
    {
        public int Id { get; set; }
        public double? Nota { get; set; }
        public int? IdAluno { get; set; }
        public  string? Tipo { get; set; }
        public int? IdDisciplina { get; set; }

        /// <summary>
        /// construtores
        /// </summary>
        public NotasModel() { }
        public NotasModel(int id,int? idAluo, double? nota, string? tipo, int? idDisciplina)
        {
            Id = id;
            Nota = nota;
            IdDisciplina = idDisciplina;
            IdAluno = idAluo;
            Tipo = tipo;
        }
    }
}

namespace SistemaEducacional.Models
{
    /// <summary>
    /// representa a entidade Turma no banco de dados 
    /// </summary>
    public class TurmaModel
    {
        public int Id { get; set; }
        public string? NomeTurma { get; set; }
        public string? AnoTurma { get; set; }
        public DateTime? DataCriacao { get; set; }
        public List<DocenteModel>? Docentes { get; set; }
        public List<AlunoModel>? Alunos { get; set; }

        /// <summary>
        /// construtores
        /// </summary>
        public TurmaModel() { }
        public TurmaModel(int id, string? nomeTurma, string? anoTurma, DateTime? dataCriacao)
        {
            Id = id;
            NomeTurma = nomeTurma;
            AnoTurma = anoTurma;
            DataCriacao = dataCriacao;
        }
        /// <summary>
        /// metodo para checar se a data não é maior que a atual 
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

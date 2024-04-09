namespace SistemaEducacional.Models
{
    public class TurmaModel
    {
        public int Id { get; set; }
        public string? NomeTurma { get; set; }
        public string? AnoTurma { get; set; }
        public DateTime? DataCriacao { get; set; }
        public List<DocenteModel>? Docentes { get; set; }
        public List<AlunoModel>? Alunos { get; set; }

        public TurmaModel() { }
        public TurmaModel(int id, string? nomeTurma, string? anoTurma, DateTime? dataCriacao)
        {
            Id = id;
            NomeTurma = nomeTurma;
            AnoTurma = anoTurma;
            DataCriacao = dataCriacao;
        }
        public bool CheckDateValid(DateTime date)
        {
            var check = (date < DateTime.Now);
            return check;
        }
        public void AddDocente(DocenteModel docente)
        {
            Docentes.Add(docente);
        }
        public void AddAluno(AlunoModel aluno)
        {
            Alunos.Add(aluno);
        }
    }
}

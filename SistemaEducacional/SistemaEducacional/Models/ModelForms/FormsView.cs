namespace SistemaEducacional.Models.ModelForms
{
    /// <summary>
    /// classe contem  todas as models
    /// Serve para usar mais de uma model em uma view
    /// </summary>
    public class FormsView
    {
        public TurmaModel? TurmaModel { get; set; }
        public DocenteModel? DocenteModel { get; set; }
        public List<DisciplinaModel>? DisciplinaModel { get; set;}
        public DirecaoModel? DirecaoModel { get; set; }
        public CheckModel? CheckModel { get; set; }
        public AlunoModel? AlunoModel { get; set; }
        public List<NotasModel>? NotasModels { get; set; }
        public BoletimModel? BoletimModels { get; set; } = new BoletimModel();
    }
}

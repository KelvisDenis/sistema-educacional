namespace SistemaEducacional.Models.ModelForms
{
    /// <summary>
    /// classe representa a entidade boletim 
    /// </summary>
    public class BoletimModel
    {

        public int Id { get; set; }
        public List<DisciplinaModel>? Discplinas { get; set; } = new List<DisciplinaModel>();
        public List<NotasModel>? Notas { get; set; } = new List<NotasModel>();

    }
}

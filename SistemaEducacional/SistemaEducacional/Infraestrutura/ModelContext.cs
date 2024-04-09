using Microsoft.EntityFrameworkCore;
using SistemaEducacional.Models;

namespace SistemaEducacional.Infraestrutura
{
    public class ModelContext : DbContext
    {
        public ModelContext(DbContextOptions<ModelContext> options): base(options)
        {
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
        }

        public DbSet<AlunoModel> AlunoModels { get; set; }
        public DbSet<DirecaoModel> DirecaoModels { get; set; }
        public DbSet<DisciplinaModel> DisciplinaModels { get; set; }
        public DbSet<DocenteModel> DocenteModels { get; set; }
        public DbSet<TurmaModel> TurmaModels { get; set; }

    }
}

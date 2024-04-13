using Microsoft.EntityFrameworkCore;
using SistemaEducacional.Models;

namespace SistemaEducacional.Infraestrutura
{
    /// <summary>
    /// Classe para conectar com o banco de dados
    /// </summary>
    public class ModelContext : DbContext
    {
        /// <summary>
        /// Construtor
        /// </summary>
        /// <param name="options"></param>
        public ModelContext(DbContextOptions<ModelContext> options): base(options)
        {
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
        }
        /// <summary>
        /// As Entidades do banco
        /// </summary>
        public DbSet<AlunoModel> AlunoModels { get; set; }
        public DbSet<DirecaoModel> DirecaoModels { get; set; }
        public DbSet<DisciplinaModel> DisciplinaModels { get; set; }
        public DbSet<DocenteModel> DocenteModels { get; set; }
        public DbSet<TurmaModel> TurmaModels { get; set; }
        public DbSet<NotasModel> NotasModels { get; set; }

    }
}

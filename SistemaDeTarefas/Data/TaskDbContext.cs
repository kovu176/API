using Microsoft.EntityFrameworkCore;
using SistemaDeTarefas.Models;

namespace SistemaDeTarefas.Data
{
    public class TaskDbContext : DbContext
    {
        public TaskDbContext (DbContextOptions<TaskDbContext> options) : base (options)
        {

        }

        public DbSet<UsuarioModel> Usuarios { get; set; }
        public DbSet<TarefaModel> Tarefas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }


    }
}

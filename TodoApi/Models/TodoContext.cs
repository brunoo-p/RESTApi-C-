using Microsoft.EntityFrameworkCore;


namespace TodoApi.Models

{
    public class TodoContext : DbContext
    {
        public DbSet<UsuarioModel> usuarioModel { get; set; }
        public DbSet<Cadastro> cadastros { get; set; }   
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //public TodoContext() : base()
        {
            optionsBuilder.UseSqlServer(@"Server=(localhost)\mssqllocalhost;Database=Api; Integrated Security=True");
        }
    }
}
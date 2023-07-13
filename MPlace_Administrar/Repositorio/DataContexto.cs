using Microsoft.EntityFrameworkCore;
using MPlace_Administrar.Repositorio.Entidades;

namespace MPlace_Administrar.Repositorio
{
    public class DataContexto : DbContext
    {
        public DataContexto(DbContextOptions<DataContexto> option) : base(option) {}
        public DbSet<TipoPersonaViewModel> TipoPersona { get; set; }
    }
}

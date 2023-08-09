using CrudASP.Models;
using Microsoft.EntityFrameworkCore;

namespace CrudASP.Datos
{
    public class ApplicationDbContext : DbContext// debe heredar de esta clase las propiedades
    {
        // crear el constructor de la clase
        public ApplicationDbContext(DbContextOptions <ApplicationDbContext> options) : base(options)
        {

        }
        // Aca van los modelos
        // para poder poner aca los DbSet primero se tiene que crear el modelo
        public DbSet<Contacto> Contactos { get; set; }
    }
}

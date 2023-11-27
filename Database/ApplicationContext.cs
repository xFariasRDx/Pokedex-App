using Database.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Database
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) { } //Dependency Injection 

        public DbSet<Pokemon> pokemons { get; set; }
        public DbSet<Regiones> regiones { get; set; }
        public DbSet<Tipos> tipos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Fluent API

            #region "Tables"

            modelBuilder.Entity<Pokemon>().
                ToTable("Pokemons");

            modelBuilder.Entity<Regiones>().
                ToTable("Regions");

            modelBuilder.Entity<Tipos>().
                ToTable("Types");

            #endregion

            #region "Primary Keys"

            modelBuilder.Entity<Pokemon>().
                HasKey(pokemon => pokemon.Id);

            modelBuilder.Entity<Regiones>().
                HasKey(regiones => regiones.Id);

            modelBuilder.Entity<Tipos>().
                HasKey(tipos => tipos.Id);

            #endregion

            #region "RelationShips"

            modelBuilder.Entity<Regiones>().HasMany<Pokemon>(regiones => regiones.pokemones).WithOne(pokemons => pokemons.regiones).HasForeignKey(pokemon => pokemon.RegionId);
            modelBuilder.Entity<Tipos>().HasMany<Pokemon>(tipos => tipos.pokemones1).WithOne(pokemons => pokemons.tipo1).HasForeignKey(pokemons => pokemons.TipoId1);
            modelBuilder.Entity<Tipos>().HasMany<Pokemon>(tipos => tipos.pokemones2).WithOne(pokemons => pokemons.tipo2).HasForeignKey(pokemons => pokemons.TipoId2);

            #endregion

            #region "Property Configuration"

            #region "Pokemones"

            modelBuilder.Entity<Pokemon>()
            .Property(pokemon => pokemon.Name)
            .IsRequired()
            .HasMaxLength(50);

            modelBuilder.Entity<Pokemon>()
                .Property(Pokemon => Pokemon.TipoId1)
                .IsRequired();

            #endregion

            #region "Regiones"

            modelBuilder.Entity<Regiones>().Property(regiones => regiones.Name).IsRequired();

            #endregion

            #region "Tipos"

            modelBuilder.Entity<Tipos>().Property(tipos => tipos.Tipo);

            #endregion

            #endregion

        }

    }

}


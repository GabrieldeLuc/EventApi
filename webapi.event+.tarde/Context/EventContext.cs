﻿using Microsoft.EntityFrameworkCore;
using webapi.event_.tarde.Domains;
using webapi.event_.tarde.Repositories;

namespace webapi.event_.tarde.Context
{
    public class EventContext : DbContext
    {
        public DbSet<TipoUsuario> TipoUsuario { get; set; }
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<TipoEvento> TipoEvento { get; set; }
        public DbSet<Evento> Evento { get; set; }
        public DbSet<ComentarioEvento> ComentarioEvento { get; set; }
        public DbSet<Instituicao> Instituicao { get; set; }
        public DbSet<PresencaEvento> PresencaEvento { get; set; }

    

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=NOTE02-S14; Database=event+_tarde; User Id=sa; Pwd=Senai@134; TrustServerCertificate=True;");
            base.OnConfiguring(optionsBuilder);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using agenda_api.Entities;
using Microsoft.EntityFrameworkCore;

namespace agenda_api.Context
{
    public class AgendaContext : DbContext
    {
        public AgendaContext(DbContextOptions<AgendaContext> options) : base(options)
		{

		}

		public DbSet<Contato> Contatos { get; set; }
    }
}
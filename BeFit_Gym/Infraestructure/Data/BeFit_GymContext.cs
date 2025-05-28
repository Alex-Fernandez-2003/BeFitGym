using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BeFit_Gym.Core.Entities;

namespace BeFit_Gym.Infraestructure.Data
{
    public class BeFit_GymContext : DbContext
    {
        public BeFit_GymContext(DbContextOptions<BeFit_GymContext> options)
            : base(options)
        {
        }

        public DbSet<Usuario> Usuario { get; set; } = default!;
        public DbSet<Asistencia> Asistencia { get; set; } = default!;
        public DbSet<Cliente> Cliente { get; set; } = default!;
        public DbSet<ClienteMembresia> ClienteMembresia { get; set; } = default!;
        public DbSet<Membresia> Membresia { get; set; } = default!;


    }
}

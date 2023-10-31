 using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransferPortal.Domain.Entities;

namespace TransferPortal.Persistence.Data
{
    public class TransferPortalDbContext : DbContext
    {
        public TransferPortalDbContext(DbContextOptions<TransferPortalDbContext> options): base(options)
        {
            
        }
        public DbSet<Teacher> Teachers { get; set; }
    }
}

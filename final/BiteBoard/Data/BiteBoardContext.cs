using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BiteBoard.Models;

namespace BiteBoard.Data
{
    public class BiteBoardContext : DbContext
    {
        public BiteBoardContext (DbContextOptions<BiteBoardContext> options)
            : base(options)
        {
        }

        public DbSet<BiteBoard.Models.movie> movie { get; set; } = default!;
    }
}

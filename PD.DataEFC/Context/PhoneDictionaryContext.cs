using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PD.DataCore.Models;

namespace PD.DataEFC.Context
{
    public class PhoneDictionaryContext : DbContext
    {
        public DbSet<PhoneDictionaryModel> DictionaryRecords { get; set; }

        public PhoneDictionaryContext(DbContextOptions<PhoneDictionaryContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PD.DataCore.Models;

namespace PD.DataEF.Context
{
    public class PhoneDictionaryContext : DbContext
    {
        public PhoneDictionaryContext(string nameOrConnectionString) : base(nameOrConnectionString)
        {
        }

        public DbSet<PhoneDictionaryModel> DictionaryRecords { get; set; }
    }
}

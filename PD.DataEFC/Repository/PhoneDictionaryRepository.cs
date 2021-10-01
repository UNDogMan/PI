using Microsoft.EntityFrameworkCore;
using PD.DataCore.Models;
using PD.DataEFC.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PD.DataEFC.Repository
{
    public class PhoneDictionaryRepository : DataCore.Interfaces.IPhoneDictionary
    {
        private PhoneDictionaryContext _context;

        public PhoneDictionaryRepository(PhoneDictionaryContext context)
        {
            _context = context;
        }

        public async Task AddRecord(PhoneDictionaryModel record)
        {
            record.ID = Guid.NewGuid();
            _context.DictionaryRecords.Add(record);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteRecord(Guid id)
        {
            _context.DictionaryRecords.Remove(_context.DictionaryRecords.First(x => x.ID == id));
            await _context.SaveChangesAsync();
        }

        public async Task<PhoneDictionaryModel> GetRecordById(Guid Id)
        {
            return await _context.DictionaryRecords.FindAsync(Id);
        }

        public async Task<IEnumerable<PhoneDictionaryModel>> GetRecords()
        {
            return await _context.DictionaryRecords.ToListAsync();
        }

        public async Task UpdateRecord(PhoneDictionaryModel record)
        {
            _context.DictionaryRecords.Remove(_context.DictionaryRecords.First(x => x.ID == record.ID));
            _context.DictionaryRecords.Add(record);
            await _context.SaveChangesAsync();
        }
    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PD.DataCore.Interfaces;
using PD.DataCore.Models;
using PD.DataEF.Context;

namespace PD.DataEF.Repository
{
    public class EFPhoneDictionaryRepository : IPhoneDictionary
    {
        private PhoneDictionaryContext _context;

        public EFPhoneDictionaryRepository(string nameOrConnectionString)
        {
            _context = new PhoneDictionaryContext(nameOrConnectionString);
        }

        public async Task AddRecord(PhoneDictionaryModel record)
        {
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
            return await _context.DictionaryRecords.FindAsync(System.Threading.CancellationToken.None, Id);
        }

        public async Task<IEnumerable<PhoneDictionaryModel>> GetRecords()
        {
            return _context.DictionaryRecords.AsEnumerable();
        }

        public async Task UpdateRecord(PhoneDictionaryModel record)
        {
            _context.DictionaryRecords.Remove(_context.DictionaryRecords.First(x => x.ID == record.ID));
            _context.DictionaryRecords.Add(record);
            await _context.SaveChangesAsync();
        }
    }
}
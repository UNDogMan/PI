using PD.DataCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PD.DataCore.Interfaces
{
    public interface IPhoneDictionary
    {
        Task<IEnumerable<PhoneDictionaryModel>> GetRecords();
        Task<PhoneDictionaryModel> GetRecordById(Guid Id);
        Task AddRecord(PhoneDictionaryModel record);
        Task UpdateRecord(PhoneDictionaryModel record);
        Task DeleteRecord(Guid id);
    }
}

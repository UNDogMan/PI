using PD.DataCore.Interfaces;
using PD.DataCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Threading.Tasks;

namespace PD.WCF
{
    public class PDService : IPDService
    {
        private readonly IPhoneDictionary _dictionary;

        public PDService()
        {
            if (AppSettings.UseDB)
            {
                _dictionary = new DataEF.Repository.EFPhoneDictionaryRepository("defaul");
            }
            else
            {
                _dictionary = new DataJson.Repository.JsonPhoneRepository();
            }
        }

        public List<PhoneDictionaryModel> GetAllSync()
        {
            return _dictionary.GetRecords().Result.ToList();
        }

        public async Task<List<PhoneDictionaryModel>> GetAll()
        {
            return (await _dictionary.GetRecords()).ToList();
        }

        public async Task<PhoneDictionaryModel> Get(Guid id)
        {
            return await _dictionary.GetRecordById(id);
        }

        public async Task Add(PhoneDictionaryModel value)
        {
            await _dictionary.AddRecord(value);
        }

        public async Task Update(PhoneDictionaryModel value)
        {
            await _dictionary.UpdateRecord(value);
        }

        public async Task Delete(Guid id)
        {
            await _dictionary.DeleteRecord(id);
        }
    }
}

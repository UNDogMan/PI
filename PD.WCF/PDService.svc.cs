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

        public List<PhoneDictionaryModel> GetAll()
        {
            return _dictionary.GetRecords().Result.ToList();
        }

        public PhoneDictionaryModel Get(Guid id)
        {
            return _dictionary.GetRecordById(id).Result;
        }

        public void Add(PhoneDictionaryModel value)
        {
            _dictionary.AddRecord(value).Wait();
        }

        public void Update(PhoneDictionaryModel value)
        {
            _dictionary.UpdateRecord(value).Wait();
        }

        public void Delete(Guid id)
        {
            _dictionary.DeleteRecord(id).Wait();
        }
    }
}

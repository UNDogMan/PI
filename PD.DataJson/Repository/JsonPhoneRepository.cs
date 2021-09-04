using Newtonsoft.Json;
using PD.DataCore.Interfaces;
using PD.DataCore.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PD.DataJson.Repository
{
    public class JsonPhoneRepository : IPhoneDictionary
    {
        private string FilePath { get => Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Dict.json"); }
        private ICollection<PhoneDictionaryModel> _records;

        public JsonPhoneRepository()
        {
            if (File.Exists(FilePath))
            {
                _records = JsonConvert.DeserializeObject<ICollection<PhoneDictionaryModel>>(File.ReadAllText(FilePath));
            }
            else
            {
                _records = new List<PhoneDictionaryModel>();
                _records.Add(new PhoneDictionaryModel
                {
                    ID = Guid.NewGuid(),
                    Surname = "test",
                    PhoneNum = "+375 33 1122345"
                });
                SaveData();
            }
        }

        public Task AddRecord(PhoneDictionaryModel record)
        {
            return Task.Run(() =>
            {
                record.ID = Guid.NewGuid();
                _records.Add(record);
                SaveData();
            });
        }

        public Task DeleteRecord(Guid id)
        {
            return Task.Run(() =>
            {
                _records.Remove(_records.First(x => x.ID == id));
                SaveData();
            });
        }

        public Task<PhoneDictionaryModel> GetRecordById(Guid Id)
        {
            return Task.Run(() =>
            {
                return _records.FirstOrDefault(x => x.ID == Id);
            });
        }

        public Task<IEnumerable<PhoneDictionaryModel>> GetRecords()
        {
            return Task.Run(() =>
            {
                return _records.AsEnumerable();
            });
        }

        public Task UpdateRecord(PhoneDictionaryModel record)
        {
            return Task.Run(() =>
            {
                _records.Remove(_records.First(x => x.ID == record.ID));
                _records.Add(record);
                SaveData();
            });
        }

        private void SaveData()
        {
            File.WriteAllText(FilePath, JsonConvert.SerializeObject(_records));
        }
    }
}

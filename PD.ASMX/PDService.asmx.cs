using PD.DataCore.Interfaces;
using PD.DataCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Services;

namespace PD.ASMX
{
    /// <summary>
    /// Сводное описание для WebService1
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Чтобы разрешить вызывать веб-службу из скрипта с помощью ASP.NET AJAX, раскомментируйте следующую строку. 
    // [System.Web.Script.Services.ScriptService]
    public class PDService : System.Web.Services.WebService
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

        [WebMethod]
        public string HelloWorld()
        {
            return "Привет всем!";
        }

        [WebMethod]
        public List<PhoneDictionaryModel> GetAllSync()
        {
            return _dictionary.GetRecords().Result.ToList();
        }

        [WebMethod]
        public async Task<List<PhoneDictionaryModel>> GetAll()
        {
            return (await _dictionary.GetRecords()).ToList();
        }

        [WebMethod]
        public async Task<PhoneDictionaryModel> Get(Guid id)
        {
            return await _dictionary.GetRecordById(id);
        }

        [WebMethod]
        public async Task Post(PhoneDictionaryModel value)
        {
            await _dictionary.AddRecord(value);
        }

        [WebMethod]
        public async Task Put(PhoneDictionaryModel value)
        {
            await _dictionary.UpdateRecord(value);
        }

        [WebMethod]
        public async Task Delete(Guid id)
        {
            await _dictionary.DeleteRecord(id);
        }
    }
}

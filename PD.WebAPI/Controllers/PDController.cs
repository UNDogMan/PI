using PD.DataCore.Interfaces;
using PD.DataCore.Models;
using PD.WebAPI.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace PD.WebAPI.Controllers
{
    public class PDController : ApiController
    {
        private readonly IPhoneDictionary _dictionary;

        public PDController()
        {
            if (AppSettings.UseDB) {
                _dictionary = new DataEF.Repository.EFPhoneDictionaryRepository("defaul");
            }
            else
            {
                _dictionary = new DataJson.Repository.JsonPhoneRepository();
            }
            
        }

        // GET api/PD
        public async Task<IEnumerable<PhoneDictionaryModel>> Get()
        {
            return await _dictionary.GetRecords();
        }

        // GET api/PD/5
        public async Task<PhoneDictionaryModel> Get(Guid id)
        {
            return await _dictionary.GetRecordById(id);
        }

        // POST api/PD
        public async Task Post([FromBody] PhoneDictionaryModel value)
        {
            await _dictionary.AddRecord(value);
        }

        // PUT api/PD/5
        public async Task Put(Guid id, [FromBody] PhoneDictionaryModel value)
        {
            await _dictionary.UpdateRecord(value);
        }

        // DELETE api/PD/5
        public async Task Delete(Guid id)
        {
            await _dictionary.DeleteRecord(id);
        }
    }
}

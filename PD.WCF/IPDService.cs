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
    // ПРИМЕЧАНИЕ. Команду "Переименовать" в меню "Рефакторинг" можно использовать для одновременного изменения имени интерфейса "IService1" в коде и файле конфигурации.
    [ServiceContract]
    public interface IPDService
    {
        [OperationContract]
        List<PhoneDictionaryModel> GetAllSync();

        [OperationContract]
        Task<List<PhoneDictionaryModel>> GetAll();

        [OperationContract]
        Task<PhoneDictionaryModel> Get(Guid id);

        [OperationContract]
        Task Add(PhoneDictionaryModel value);

        [OperationContract]
        Task Update(PhoneDictionaryModel value);

        [OperationContract]
        Task Delete(Guid id);

    }
}

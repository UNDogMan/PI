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
        List<PhoneDictionaryModel> GetAll();

        [OperationContract]
        PhoneDictionaryModel Get(Guid id);

        [OperationContract]
        void Add(PhoneDictionaryModel value);

        [OperationContract]
        void Update(PhoneDictionaryModel value);

        [OperationContract]
        void Delete(Guid id);

    }
}

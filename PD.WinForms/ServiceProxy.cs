using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PD.DataCore.Models;
using PD.WinForms.PDServiceReferenceASMX;
using PD.WinForms.PDServiceReferenceWCF;

namespace PD.WinForms
{
    public enum Services
    {
        ASMX = 1,
        WCF = 2
    }

    public static class ModelExt
    {
        public static DataCore.Models.PhoneDictionaryModel ASMXModelToGeneral(this PDServiceReferenceASMX.PhoneDictionaryModel model)
        {
            return new DataCore.Models.PhoneDictionaryModel
            {
                ID = model.ID,
                Surname = model.Surname,
                PhoneNum = model.PhoneNum,
            };
        }

        public static PDServiceReferenceASMX.PhoneDictionaryModel GeneralModelToASMX(this DataCore.Models.PhoneDictionaryModel model)
        {
            return new PDServiceReferenceASMX.PhoneDictionaryModel
            {
                ID = model.ID,
                Surname = model.Surname,
                PhoneNum = model.PhoneNum,
            };
        }
    }

    public class ServiceProxy
    {
        private Services service = Services.ASMX;
        private PDServiceClient wcfClient = null;
        private PDServiceSoapClient asmxClient = null;

        public ServiceProxy()
        {
            wcfClient = new PDServiceClient();
            asmxClient = new PDServiceSoapClient();
        }

        public ServiceProxy UseASMX()
        {
            service = Services.ASMX;
            return this;
        }

        public ServiceProxy UseWCF()
        {
            service = Services.WCF;
            return this;
        }

        public IEnumerable<DataCore.Models.PhoneDictionaryModel> GetAll()
        {
            switch (service)
            {
                case Services.ASMX:
                    var respASMX = asmxClient.GetAll().Select(x => x.ASMXModelToGeneral());
                    return respASMX;

                case Services.WCF:
                    var respWCF = wcfClient.GetAll();
                    return respWCF;
            }

            return null;
        }

        public void Add(DataCore.Models.PhoneDictionaryModel model)
        {
            switch (service)
            {
                case Services.ASMX:
                    asmxClient.Post(model.GeneralModelToASMX());
                    break;

                case Services.WCF:
                    wcfClient.Add(model);
                    break;
            }
        }

        public void Update(DataCore.Models.PhoneDictionaryModel model)
        {
            switch (service)
            {
                case Services.ASMX:
                    asmxClient.Put(model.GeneralModelToASMX());
                    break;

                case Services.WCF:
                    wcfClient.Update(model);
                    break;
            }
        }

        public void Delete(DataCore.Models.PhoneDictionaryModel model)
        {
            switch (service)
            {
                case Services.ASMX:
                    asmxClient.Delete(model.ID);
                    break;

                case Services.WCF:
                    wcfClient.Delete(model.ID);
                    break;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PD.DataCore.Models
{
    [DataContract]
    public class PhoneDictionaryModel
    {
        [DataMember]
        public Guid ID { get; set; }

        [DataMember]
        [Required]
        public string Surname { get; set; }


        [DataMember]
        [Required]
        public string PhoneNum { get; set; }

        public override bool Equals(object obj)
        {
            return obj is PhoneDictionaryModel model &&
                   ID.Equals(model.ID);
        }

        public override int GetHashCode()
        {
            int hashCode = 979670022;
            hashCode = hashCode * -1521134295 + ID.GetHashCode();
            return hashCode;
        }

        public override string ToString()
        {
            return $"{Surname} - {PhoneNum}";
        }
    }
}

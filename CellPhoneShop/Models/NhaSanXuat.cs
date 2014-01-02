using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace CellPhoneShop
{
    [DataContract]
    public class NhaSanXuat
    {
        [DataMember(Name = "MaNSX")]
        public int MaNSX { get; set; }

        [DataMember(Name = "Ten")]
        public string Ten { get; set; }

        [DataMember(Name = "Logo")]
        public string Logo { get; set; }
    }
}
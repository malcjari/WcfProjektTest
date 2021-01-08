using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WcfProjektTest
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    {

        [OperationContract]
        List<CaseData> getAllCases();

        [OperationContract]
        void addCase(CaseData iCase);

        [OperationContract]
        void deleteCase(int id);

        [OperationContract]
        void editCase(int id, int category, string description, bool isActive);

        [OperationContract]
        bool logIn(string username, string password);
    }


    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    [DataContract]
    public class CaseData
    {
        [DataMember]
        public int id { get; set; }

        [DataMember]
        public DateTime date { get; set; }

        [DataMember]
        public string lat { get; set; }

        [DataMember]
        public string lng { get; set; }

        [DataMember]
        public string description { get; set; }

        [DataMember]
        public bool isActive { get; set; }

        [DataMember]
        public string contact_phone { get; set; }

        [DataMember]
        public string contact_email { get; set; }

        [DataMember]
        public int category { get; set; }

    }


}

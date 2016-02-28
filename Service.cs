using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Web;

namespace WcfService1
{

    public class Service : IService
    {
        public string EchoWithGet(string s)
        {
            return "You said" + s;
        }

        public string EchoWithPost(string s)
        {
            return "you said" + s;
        }
    }

    public interface IService
    {
        [OperationContract]
        [WebGet]
        string EchoWithGet(string s);

        [OperationContract]
        [WebInvoke]
        string EchoWithPost(string s);

    }
}


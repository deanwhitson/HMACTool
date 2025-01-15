using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace HMACClient
{
    public class HMACDelegatingHandler : DelegatingHandler
    {
        string APPId = System.Configuration.ConfigurationManager.AppSettings["APPId"];
        string APIKey = System.Configuration.ConfigurationManager.AppSettings["APIKey"];

    }
}

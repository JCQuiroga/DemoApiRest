using System;
using System.IO;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace DemoApiRest.Extensiones
{
    public class Loghandler:DelegatingHandler
    {
        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancelationToken)
        {
            using (var d = File.AppendText(@"c:\log\logapi.txt"))
            {
                d.WriteLine("{o:d} Request ->{1}",DateTime.Now,request);
            }
            return base.SendAsync(request, cancelationToken);
        }
    }
}
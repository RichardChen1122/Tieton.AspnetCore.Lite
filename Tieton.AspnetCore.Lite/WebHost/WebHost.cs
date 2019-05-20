using System;
using System.Collections.Generic;
using System.Text;

namespace Tieton.AspnetCore.Lite.WebHost
{
    public class WebHost:IWebHost
    {
        private IServer _server;
        public WebHost(IServer server, RequestDelegate rd)
        {

        }

        public void Run()
        {
            throw new NotImplementedException();
        }
    }
}

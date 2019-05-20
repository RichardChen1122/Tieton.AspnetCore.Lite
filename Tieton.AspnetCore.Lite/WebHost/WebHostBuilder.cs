using System;
using System.Collections.Generic;
using System.Text;
using Tieton.AspnetCore.Lite.Application;

namespace Tieton.AspnetCore.Lite.WebHost
{
    public class WebHostBuilder : IWebHostBuilder
    {
        private IServer _server;
        private readonly List<Action<IApplicationBuilder>> _configures;

        public WebHostBuilder()
        {
            _configures = new List<Action<IApplicationBuilder>>();
        }

        public IWebHost Build()
        {
            IApplicationBuilder app = new ApplicationBuilder();
            foreach(var config in _configures)
            {
                config(app);
            }

            return new WebHost(_server, app.Build());
        }

        public IWebHostBuilder Configure(Action<IApplicationBuilder> configure)
        {
            _configures.Add(configure);
            return this;
        }

        public IWebHostBuilder UseServer(IServer server)
        {
            this._server = server;
            return this;
        }
    }
}

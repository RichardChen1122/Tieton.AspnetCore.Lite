using System;
using System.Collections.Generic;
using System.Text;
using Tieton.AspnetCore.Lite.Application;

namespace Tieton.AspnetCore.Lite.WebHost
{
    public interface IWebHostBuilder
    {
        IWebHostBuilder UseHttpListenser();
        IWebHostBuilder Configure(Action<IApplicationBuilder> configure);
        IWebHost Build();
    }
}

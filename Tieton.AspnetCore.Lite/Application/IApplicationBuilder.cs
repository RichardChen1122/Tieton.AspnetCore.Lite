using System;
using System.Collections.Generic;
using System.Text;

namespace Tieton.AspnetCore.Lite.Application
{
    public interface IApplicationBuilder
    {
        RequestDelegate Build();
        IApplicationBuilder Use(Func<RequestDelegate, RequestDelegate> middleWare);
    }
}

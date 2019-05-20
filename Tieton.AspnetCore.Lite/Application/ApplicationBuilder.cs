using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Tieton.AspnetCore.Lite.Context;

namespace Tieton.AspnetCore.Lite.Application
{
    public class ApplicationBuilder : IApplicationBuilder
    {
        List<Func<RequestDelegate, RequestDelegate>> _middleWares = new List<Func<RequestDelegate, RequestDelegate>>();

        public RequestDelegate Build()
        {
            _middleWares.Reverse();
            return TempMethod;
        }

        public IApplicationBuilder Use(Func<RequestDelegate, RequestDelegate> middleWare)
        {
            _middleWares.Add(middleWare);
            return this;
        }

        private Task TempMethod(HttpContext context)
        {
            RequestDelegate next = TempMethod2;

            foreach(var middle in _middleWares)
            {
                next = middle(next);
            }

            return next(context);
        }

        private Task TempMethod2(HttpContext context)
        {
            context.Response.StatusCode = 404;
            return Task.CompletedTask;
        }
    }

}

using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Text;
using Tieton.AspnetCore.Lite.Context;

namespace Tieton.AspnetCore.Lite.Context
{
    public class HttpContext
    {
        /// <summary>
        /// Http请求对象
        /// </summary>
        public HttpRequest Request { get; }

        /// <summary>
        /// Http响应对象
        /// </summary>
        public HttpResponse Response { get; }

        public HttpContext(IFeatureCollection features)
        {
            Request = new HttpRequest(features);
            Response = new HttpResponse(features);
        }
    }

    public class HttpRequest
    {
        private readonly IHttpRequestFeature _feature;
        public Uri Url => _feature.Url;
        public NameValueCollection Headers => _feature.Headers;
        public Stream Body => _feature.Body;
        public HttpRequest(IFeatureCollection features)
        {
            _feature = features.Get<IHttpRequestFeature>();
                }
    }

    public class HttpResponse
    {
        private readonly IHttpResponseFeature _feature;
        public HttpResponse(IFeatureCollection features) => _feature = features.Get<IHttpResponseFeature>();
        public NameValueCollection Headers => _feature.Headers;
        public Stream Body => _feature.Body;
        public int StatusCode { get => _feature.StatusCode; set => _feature.StatusCode = value; }
    }
}

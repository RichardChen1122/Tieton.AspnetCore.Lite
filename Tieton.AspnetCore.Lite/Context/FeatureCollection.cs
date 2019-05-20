using System;
using System.Collections.Generic;
using System.Text;

namespace Tieton.AspnetCore.Lite.Context
{
    public class FeatureCollection:Dictionary<Type,object>, IFeatureCollection
    {
    }

    public static class FeatureExtensions
    {
        public static T Get<T>(this IFeatureCollection features)
        {
            return features.TryGetValue(typeof(T), out object value) ? (T)value : default(T);
        }

        public static IFeatureCollection Set<T>(this IFeatureCollection features, T feature)
        {
            features[typeof(T)] = feature;
            return features;
        }
    }
}

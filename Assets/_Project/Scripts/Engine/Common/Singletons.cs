using System;
using System.Collections.Generic;

namespace _Project.Scripts.Engine.Common
{
    public static class Singletons
    {
        public static readonly Dictionary<Type, string> TypeNameMap = new Dictionary<Type, string>
        {
            {typeof(CameraController), "MainCamera"},
        };
    }
}
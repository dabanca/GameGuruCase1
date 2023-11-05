using System;
using System.Collections.Generic;
using _Project.Scripts.Engine.Camera;
using _Project.Scripts.Engine.Loaders;

namespace _Project.Scripts.Engine.Common
{
    public static class Singletons
    {
        public static readonly Dictionary<Type, string> TypeNameMap = new Dictionary<Type, string>
        {
            {typeof(CameraController), "MainCamera"},
            {typeof(MonoViewLoader), "MonoViewLoader"},
        };
    }
}

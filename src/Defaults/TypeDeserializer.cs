using System;
using System.Reflection;

namespace Fmacias.TplQueue.Defaults
{
    public static class TypeDeserializer
    {
        public static bool TryResolveType(string serializedType, out Type type, AppDomain? appDomain = null)
        {
            if (string.IsNullOrWhiteSpace(serializedType))
            {
                type = null!;
                return false;
            }

            appDomain = appDomain ?? AppDomain.CurrentDomain;
            type = Type.GetType(serializedType, throwOnError: false);

            if (type != null)
            {
                return true;
            }

            foreach (Assembly assembly in appDomain.GetAssemblies())
            {
                type = assembly.GetType(serializedType, throwOnError: false);

                if (type != null)
                {
                    return true;
                }
            }
            return false;
        }
    }
}

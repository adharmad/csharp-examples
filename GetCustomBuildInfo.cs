using System;
using System.Reflection;
using System.Globalization;

namespace csharp_examples
{
    class GetCustomBuildInfo
    {
        public static void CustomBuildInfo()
        {
            const string BuildVersionMetadataPrefix = "+build";

            Assembly assembly = Assembly.GetExecutingAssembly();
            var attribute = assembly.GetCustomAttribute<AssemblyInformationalVersionAttribute>();
            if (attribute?.InformationalVersion != null)
            {
                var value = attribute.InformationalVersion;
                var index = value.IndexOf(BuildVersionMetadataPrefix);
                if (index > 0)
                {
                    value = value.Substring(index + BuildVersionMetadataPrefix.Length);
                    if (DateTime.TryParseExact(value, "yyyyMMddHHmmss", CultureInfo.InvariantCulture, DateTimeStyles.None, out var result))
                    {
                        Console.WriteLine(result.ToString());
                    }
                }
            }
        }
    }
}

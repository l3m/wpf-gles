using System;
using System.IO;
using System.Reflection;

namespace WpfGles
{
    public static class LoadEmbedded
    {
        public static Assembly FromAssembly(string asm_name)
        {
            var p = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory,
                    asm_name);
            AssemblyName name = AssemblyName.GetAssemblyName(p);
            var asm = Assembly.Load(name);
            return asm;            
        }

        public static String TextFile(string resource_name)
        {
            var asm = Assembly.GetExecutingAssembly();
            return TextFile(asm, resource_name);
        }

        // see http://stackoverflow.com/questions/3314140/how-to-read-embedded-resource-text-file
        public static String TextFile(Assembly asm, string resource_name)
        {
            using (Stream stream = asm.GetManifestResourceStream(resource_name))
            {
                if (stream == null)
                    throw new FileNotFoundException(string.Format("No embedded resource with name '{0}'", resource_name));

                using (var reader = new StreamReader(stream))
                {
                    string result = reader.ReadToEnd();
                    return result;
                }
            }
        }

        public static byte[] File(Assembly asm, string resource_name)
        {
            using (Stream stream = asm.GetManifestResourceStream(resource_name))
            {
                if (stream == null)
                    throw new FileNotFoundException(string.Format("No embedded resource with name '{0}'", resource_name));

                int size = (int) stream.Length;
                var bytes = new byte[size];
                stream.Read(bytes, 0, size);
                return bytes;
            }
        }
    }
}

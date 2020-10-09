namespace LoadEncrypt
{
    using System;
    using System.IO;
    using System.IO.Compression;
    using System.Reflection;
    using System.Security.Cryptography;
    using System.Security.Permissions;
    using System.Text;
    using EnsoulSharp.SDK;
    using RebornAIOV2.Properties;

    internal class Program
    {
        private static void Main(string[] args)
        {
            GameEvent.OnGameLoad += OnGameLoad;
        }

        [PermissionSet(SecurityAction.Assert, Unrestricted = true)]
        private static void OnGameLoad()
        {
            try
            {
                byte[] bytes = File.ReadAllBytes("C://Reborn.v2");
                Array.Reverse(bytes, 0, bytes.Length);
                byte[] bytesG = Reborn(bytes);
                System.Threading.Thread.GetDomain().Load(bytesG).EntryPoint.Invoke("", null);


            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
        public static byte[] Reborn(byte[] RebornX)

        {
            using (GZipStream stream = new GZipStream(new MemoryStream(RebornX), CompressionMode.Decompress))
            {
                const int size = 4096;
                byte[] Buffer = new byte[size];
                { }
                using (MemoryStream memoryStream = new MemoryStream())
                {
                    int count;
                    do
                    {
                        count = stream.Read(Buffer, 0, size);

                        if (count > 0)
                        {
                            memoryStream.Write(Buffer, 0, count);
                        }

                    } while (count > 0);

                    return memoryStream.ToArray();
                }
            }
        }
}
}
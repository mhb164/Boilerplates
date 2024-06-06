using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boilerplates
{
    internal class Aid
    {
        public static void ConfigureAppStart()
        {
            System.Globalization.CultureInfo.DefaultThreadCurrentCulture = System.Globalization.CultureInfo.InvariantCulture;

            System.Threading.ThreadPool.SetMaxThreads(32767, 16184);
            System.Threading.ThreadPool.SetMinThreads(2048, 2048);

            System.Net.ServicePointManager.DefaultConnectionLimit = 8092;
        }

        public static byte[] Zip(byte[] bytes)
        {
            using (var msi = new MemoryStream(bytes))
            using (var mso = new MemoryStream())
            {
                using (var gs = new System.IO.Compression.GZipStream(mso, System.IO.Compression.CompressionMode.Compress))
                {
                    msi.CopyTo(gs);
                }

                return mso.ToArray();
            }

        }

        public static byte[] Unzip(byte[] bytes)
        {
            using (var msi = new MemoryStream(bytes))
            using (var mso = new MemoryStream())
            {
                using (var gs = new System.IO.Compression.GZipStream(msi, System.IO.Compression.CompressionMode.Decompress))
                    gs.CopyTo(mso);

                return mso.ToArray();
            }
        }
    }
}

using ICSharpCode.SharpZipLib.Zip;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace VS4Net
{
    class DownoadManager
    {
        private static DownoadManager instance;
        public static DownoadManager Instance
        {
            get
            {
                if (instance == null)
                    instance = new DownoadManager();
                return instance;
            }
        }
        public bool Running { get; private set; }
        private List<string> List { get; }
        private const string TARGET_ROOT_DIR = @"D:\Program Files (x86)\Reference Assemblies\Microsoft\Framework\.NETFramework";
        private DownoadManager()
        {
            Running = false;
            List = new List<string>();
        }
        public void Add(string link)
        {
            List.Add(link);
        }
        public async Task Start()
        {
            if (List != null && List.Count > 0)
            {
                Running = true;
                var files = new List<string>();
                foreach (var item in List)
                {
                    var version = await NugetManager.Instance.GetVersion(item);
                    var filePath = await NugetManager.Instance.Download(item, version);
                    if (!string.IsNullOrEmpty(filePath))
                        files.Add(filePath);
                }
                UnZip(files);
            }
        }
        private void UnZip(List<string> files)
        {
            foreach (var file in files)
            {
                using (ZipInputStream s = new ZipInputStream(File.OpenRead(file)))
                {
                    ZipEntry theEntry;
                    while ((theEntry = s.GetNextEntry()) != null)
                    {
                        string directoryName = Path.GetDirectoryName(theEntry.Name),
                            sourceDir = directoryName.Replace("build\\.NETFramework", ""),
                            fileName = theEntry.Name.Replace("build/.NETFramework", "");
                        if (directoryName.StartsWith("build\\.NETFramework\\v4"))
                        {
                            if (directoryName.Length > 0)
                                Directory.CreateDirectory($"{TARGET_ROOT_DIR}\\{sourceDir}");
                            if (fileName != string.Empty)
                            {
                                using (var streamWriter = File.Create($"{TARGET_ROOT_DIR}\\{fileName}"))
                                {
                                    int size = 2048;
                                    byte[] data = new byte[2048];
                                    while (true)
                                    {
                                        size = s.Read(data, 0, data.Length);
                                        if (size > 0)
                                            streamWriter.Write(data, 0, size);
                                        else
                                            break;
                                    }
                                }
                            }
                        }
                    }
                }
                Thread.Sleep(200);
                File.Delete(file);
            }
        }
        public void About()
        {
            Running = false;
        }
    }
}
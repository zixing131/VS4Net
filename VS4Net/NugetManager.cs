using NuGet.Common;
using NuGet.Protocol;
using NuGet.Protocol.Core.Types;
using NuGet.Versioning;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace VS4Net
{
    class NugetManager
    {
        private static NugetManager instance;
        public static NugetManager Instance
        {
            get
            {
                if (instance == null)
                    instance = new NugetManager();
                return instance;
            }
        }
        private const string NUGET_URL = "https://api.nuget.org/v3/index.json";
        private NugetManager() { }
        public async Task<string> GetVersion(string packageName)
        {
            try
            {
                var logger = NullLogger.Instance;
                var cache = new SourceCacheContext();
                var repository = Repository.Factory.GetCoreV3(NUGET_URL);
                var resource = await repository.GetResourceAsync<FindPackageByIdResource>();
                var versions = await resource.GetAllVersionsAsync(packageName, cache, logger, CancellationToken.None);
                return versions.LastOrDefault()?.ToString();
            }
            catch { }
            return string.Empty;
        }
        public async Task<string> Download(string packageName, string packageVer)
        {
            try
            {
                var logger = NullLogger.Instance;
                var cache = new SourceCacheContext();
                var repository = Repository.Factory.GetCoreV3(NUGET_URL);
                var resource = await repository.GetResourceAsync<FindPackageByIdResource>();
                var packageVersion = new NuGetVersion(packageVer);
                using MemoryStream packageStream = new MemoryStream();
                await resource.CopyNupkgToStreamAsync(packageName, packageVersion, packageStream, cache, logger, CancellationToken.None);
                FileInfo fileInfo = new FileInfo($"{packageName}{packageVersion}.nupkg");
                if (fileInfo.Exists)
                    fileInfo.Delete();
                using (var fs = fileInfo.Create())
                {
                    var bytes = packageStream.ToArray();
                    fs.Write(bytes, 0, bytes.Length);
                }
                return fileInfo.FullName;
            }
            catch { }
            return string.Empty;
        }
    }
}
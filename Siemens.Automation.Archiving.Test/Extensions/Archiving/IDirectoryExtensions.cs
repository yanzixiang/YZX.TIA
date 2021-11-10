using Siemens.Automation.Archiving;

using YZX.Tia.Proxies.Archiving;

namespace YZX.Tia.Extensions.Archiving
{
  public static class IDirectoryExtensions
  {
    public static ZipExtractorProxy ToZipExtractorProxy(IDirectory directory)
    {
      return new ZipExtractorProxy(directory);
    }
  }
}

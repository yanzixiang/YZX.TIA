using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Siemens.Automation.Archiving;
using Siemens.Automation.Archiving.Private;

namespace YZX.Tia.Proxies.Archiving
{
  public class ZipExtractorProxy
  {
    ZipExtractor extractor;

    public ZipExtractorProxy(IDirectory directory)
    {
      extractor = directory as ZipExtractor;
    }

    public Dictionary<string, object> GetFileInfos()
    {
      var infos = extractor.GetFileInfos();
      var infodic = new Dictionary<string, object>();
      foreach(var info in infos)
      {
        infodic[info.Key] = info.Value;
      }
      return infodic;
    }

    public IFile GetFile(object fileInfo)
    {
      ZipArchivedFileInfo info = fileInfo as ZipArchivedFileInfo;
      return extractor.GetFile(info); 
    }

    public IEnumerable<IFile> GetFiles()
    {
      return extractor.GetFiles();
    }

    public string GetPasswordString()
    {
      return extractor.GetPasswordString();
    }

  }
}

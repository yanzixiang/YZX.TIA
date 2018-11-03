using System; 
using System.Linq;
using System.Text;
using System.Xml.Linq;
using System.IO;
using System.Collections.Generic;

using Siemens.Automation.OMSPlus.Managed;
using Siemens.Automation.DomainServices.DirectoryMappingService;
using Siemens.Automation.DomainServices.DirectoryMappingService.Internal;

namespace YZX.Tia.Extensions
{
  public static class RemoteFileAccessExtensions
  {
    public static List<string> GetFileNames(this RemoteFileAccess remoteFileAccess, string path="")
    {
      List<string> peList = new List<string>();
      uint handle = 0U;
      remoteFileAccess.OpenDir(FormatPath(path), ref handle);
      Value entries = null;
      remoteFileAccess.ReadDir(handle, ref entries, 100U, RemoteFileAccess.DirEntryFilter.FindFilesOnly);
      if (entries != null)
      {
        for (uint key = 0U; key < entries.ElementCount; ++key)
        {
          Value obj = new Value();
          entries.GetValue(key, ref obj);
          string str = string.Empty;
          obj.GetValue(ref str);
          if (!str.Equals(".") && !str.Equals("..") && !peList.Contains(str))
            peList.Add(str);
          obj.Dispose();
        }
        entries.Dispose();
      }
      remoteFileAccess.CloseDir(handle);
      return peList;
    }

    internal static IConfigFile ReadConfigFile(this RemoteFileAccess remoteFileAccess,
      IMetaService m_metaService,
      string configFileName)
    {
      IConfigFile configFile = null;
      uint handle = 0U;
      string path = configFileName;
      remoteFileAccess.OpenFile(path, RemoteFileAccess.FileAccessMode.ReadAccess, ref handle);
      Siemens.Automation.OMSPlus.Managed.FileInfo info = new Siemens.Automation.OMSPlus.Managed.FileInfo();
      remoteFileAccess.GetFileInfo(configFileName, ref info);
      uint bytes_to_read = (uint)info.size;
      byte[] buffer = new byte[(int)bytes_to_read];
      uint read = 0U;
      remoteFileAccess.ReadFile(handle, ref buffer, bytes_to_read, RemoteFileAccess.CurrentPosition, ref read);
      byte[] bytes = new byte[(int)read];
      for (uint index = 0U; index < read; ++index)
        bytes[(int)index] = buffer[(int)index];
      string @string = new UTF8Encoding().GetString(bytes);
      remoteFileAccess.CloseFile(handle);
      XDocument innerDocument = m_metaService.ParseConfigFile(@string);
      if (innerDocument != null)
      {
        string fileName = Path.GetFileName(configFileName);
        ConfigFileParameters configFileParameters = GetConfigFileParameters(innerDocument, fileName);
        if (configFileParameters != null)
          configFile = new ConfigFile(configFileParameters);
      }
      return configFile;
    }

    private static ConfigFileParameters GetConfigFileParameters(XDocument innerDocument, string fileName)
    {
      if (innerDocument == null)
        return null;
      string unformattedPath;
      string type;
      try
      {
        unformattedPath = Enumerable.First(Enumerable.Where(innerDocument.Descendants(), x => x.Name.LocalName == Constants.DirectoryPath)).Value;
        type = Enumerable.First(Enumerable.Where(innerDocument.Descendants(), x => x.Name.LocalName == Constants.Type)).Value;
      }
      catch (InvalidOperationException ex)
      {
        return null;
      }
      return new ConfigFileParameters(fileName, FormatPath(unformattedPath), type, false);
    }

    public static string FormatPath(string unformattedPath)
    {
      return unformattedPath.Replace("\\", "/");
    }
  }
}

using System;
using System.IO;
using System.Collections.Generic;

using Siemens.Automation.Utilities.PackagingService;
using Siemens.Automation.Archiving;
using Siemens.Automation.Archiving.Private;
using Siemens.Automation.Utilities.IO;

using Common;
using Reflection;
using Extensions;

namespace YZX.Tia.Proxies
{
  public class PackagingImplementationBaseProxy
  {
    public PackagingImplementationBase PackagingImplementationBase;

    public PackagingImplementationBaseProxy(string path)
    {
      PackagingImplementationBase = new PackagingImplementationBase(path, null, null);
    }

    public string PackageFilePath
    {
      get
      {
        return PackagingImplementationBase.PackageFilePath;
      }
    }

    public string PackageFileDirectory
    {
      get
      {
        return FileSystem.PathGetDirectoryName(PackageFilePath);
      }
    }

    public IDirectory Package
    {
      get
      {
        return Reflector.GetInstanceFieldByName(PackagingImplementationBase, "m_Package",
          ReflectionWays.SystemReflection)
          as IDirectory;
      }
    }

    public bool Disposed
    {
      get
      {
        return (bool)Reflector.GetInstanceFieldByName(PackagingImplementationBase, "m_Disposed",
          ReflectionWays.SystemReflection);
      }
    }

    public Dictionary<string, object> GetFilesWithPositions()
    {
      if (Disposed)
        throw new InvalidOperationException("MetaPackageReader is closed");
      IDictionary<string, ZipArchivedFileInfo> fileInfos = ((ZipExtractor)Package).GetFileInfos();
      Dictionary<string, object> filepositions = new Dictionary<string, object>();
      foreach(string key in fileInfos.Keys)
      {
        filepositions[key] = fileInfos[key];
      }
      return filepositions;
    }

    IDictionary<string, ZipArchivedFileInfo> GetFilesWithFileInfo()
    {
      if (Disposed)
        throw new InvalidOperationException("MetaPackageReader is closed");
      IDictionary<string, ZipArchivedFileInfo> fileInfos = ((ZipExtractor)Package).GetFileInfos();
      return fileInfos;
    }

    public IList<string> GetFiles()
    {
      return PackagingImplementationBase.GetFiles();
    }

    public UtilityStream OpenStreamReferencePackageWithPosition(string entryName, object ZipArchivedFileInfo)
    {
      return PackagingImplementationBase.OpenStreamReferencePackageWithPosition(entryName, (ZipArchivedFileInfo)ZipArchivedFileInfo);
    }

    public void Unpack()
    {
      IDictionary <string, ZipArchivedFileInfo>  fileinfos = GetFilesWithFileInfo();
      IList<string> files = GetFiles();
      foreach(string f in files)
      {
        Console.WriteLine(f);
        ZipArchivedFileInfo fileinfo = fileinfos[f];
        UtilityStream us = OpenStreamReferencePackageWithPosition(f, fileinfo);
        us.WriteToFile(Path.Combine(PackageFileDirectory,f));
      }
    }
  }
}

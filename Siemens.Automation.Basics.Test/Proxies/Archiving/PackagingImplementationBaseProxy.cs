using System;
using System.IO;
using System.Collections.Generic;

using Siemens.Automation.Basics.PackagingService;
using Siemens.Automation.Utilities.PackagingService;
using Siemens.Automation.Archiving;
using Siemens.Automation.Utilities.IO;

using Siemens.Simatic.Hmi.Utah.Common.Base.Reflection;

namespace YZX.Tia.Proxies.Archiving
{
  public class PackagingImplementationBaseProxy: IDisposable
  {
    public PackagingImplementationBase PackagingImplementationBase;

    public PackagingImplementationBaseProxy(string path,bool ForWriting= false)
    {

      var parameter = new PackagingParameterBase();
      if (ForWriting)
      {
        parameter.ForWriting = true;
        PackagingImplementationBase = new PackagingImplementationBase(path, parameter, null);
      }
      else
      {
        PackagingImplementationBase = new PackagingImplementationBase(path, parameter, null);
      }
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
        return Path.GetDirectoryName(PackageFilePath);
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

    private ZipExtractorProxy zipExtractor;
    public ZipExtractorProxy ZipExtractor
    {
      get
      {
        if(zipExtractor == null)
        {
          zipExtractor = new ZipExtractorProxy(Package);
        }
        return zipExtractor;
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

    IDictionary<string, object> GetFilesWithFileInfo()
    {
      if (Disposed)
        throw new InvalidOperationException("MetaPackageReader is closed");
      var fileInfos = ZipExtractor.GetFileInfos();
      return fileInfos;
    }

    public IList<string> GetFiles()
    {
      return PackagingImplementationBase.GetFiles();
    }

    public UtilityStream OpenStreamReferencePackageWithPosition(string entryName, object FileInfo)
    {
      return Reflector.RunInstanceMethodByName(PackagingImplementationBase,
        "OpenStreamReferencePackageWithPosition",
        ReflectionWays.SystemReflection,
        entryName,FileInfo
        ) as UtilityStream;
    }

    public void Unpack(string SaveDirectory = "")
    {
      var  fileinfos = GetFilesWithFileInfo();
      var filesNames = GetFiles();
      var files = ZipExtractor.GetFiles();
      foreach(var f in filesNames)
      {
        Console.WriteLine(f);
        var fileinfo = fileinfos[f];
        var us = OpenStreamReferencePackageWithPosition(f, fileinfo);
        string path;
        if (SaveDirectory == "")
        {
          path = Path.Combine(PackageFileDirectory, f);
        }
        else
        {
          path = Path.Combine(SaveDirectory, f);
        }
        StreamWriter sw = new StreamWriter(path);
        us.CopyTo(sw.BaseStream);
        sw.Flush();
        sw.Close();
      }
    }

    public void AddFile(string filename, Stream stream)
    {
      PackagingImplementationBase.AddFile(filename, stream);
    }

    public void Save(string newFilePath)
    {
      var StreamBasedArchiveInfo = CreateArchiveInfo();
      StreamWriter sw = new StreamWriter(newFilePath);
      var us = StreamBasedArchiveInfo.Stream;
      us.Seek(0,SeekOrigin.Begin);
      us.CopyTo(sw.BaseStream);
      sw.Flush();
      sw.Close();
    }

    public StreamBasedArchiveInfo CreateArchiveInfo()
    {
      var ArchiveInfo = Reflector.RunInstanceMethodByName(PackagingImplementationBase,
        "CreateArchiveInfo",
        ReflectionWays.SystemReflection
        ) as ArchiveInfo;
      return ArchiveInfo as StreamBasedArchiveInfo;
    }

    #region IDisposable Support
    private bool disposedValue = false; // 要检测冗余调用

    protected virtual void Dispose(bool disposing)
    {
      if (!disposedValue)
      {
        if (disposing)
        {
          // TODO: 释放托管状态(托管对象)。
        }

        // TODO: 释放未托管的资源(未托管的对象)并在以下内容中替代终结器。
        // TODO: 将大型字段设置为 null。

        disposedValue = true;
      }
    }

    // TODO: 仅当以上 Dispose(bool disposing) 拥有用于释放未托管资源的代码时才替代终结器。
    // ~PackagingImplementationBaseProxy()
    // {
    //   // 请勿更改此代码。将清理代码放入以上 Dispose(bool disposing) 中。
    //   Dispose(false);
    // }

    // 添加此代码以正确实现可处置模式。
    public void Dispose()
    {
      ((IDisposable)PackagingImplementationBase).Dispose();
      // 请勿更改此代码。将清理代码放入以上 Dispose(bool disposing) 中。
      Dispose(true);
      // TODO: 如果在以上内容中替代了终结器，则取消注释以下行。
      // GC.SuppressFinalize(this);
    }
    #endregion
  }
}

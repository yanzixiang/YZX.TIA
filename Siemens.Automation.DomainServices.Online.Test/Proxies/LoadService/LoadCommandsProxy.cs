using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

using Siemens.Automation.Basics;
using Siemens.Automation.ObjectFrame;
using Siemens.Automation.DomainServices;
using Siemens.Automation.DomainServices.LoadService;
using Siemens.Simatic.Hmi.Utah.Common.Base.Reflection;

using YZX.Tia.Proxies.LoadService.Download;

namespace YZX.Tia.Proxies.LoadService.Upload
{
  public class LoadCommandsProxy
  {
    LoadCommands LoadCommands;

    public ILoad Load
    {
      get
      {
        return LoadCommands as ILoad;
      }
    }

    public IDlc Dlc
    {
      get
      {
        return LoadCommands as IDlc;
      }
    }

    public ICompileLoadAttributes CompileLoadAttributes
    {
      get
      {
        return LoadCommands as ICompileLoadAttributes;
      }
    }

    public LoadCommandsProxy(ILoadCommandExtension loadCommand)
    {
      LoadCommands = loadCommand as LoadCommands;
    }

    public IOnlineService OnlineService
    {
      get
      {
        return Reflector.GetInstancePropertyByName(LoadCommands, "OnlineService", 
          ReflectionWays.SystemReflection) as IOnlineService;
      }
    }

    public DownloadServiceProxy DownloadServiceProxy
    {
      get
      {
        DownloadService downloadService = Reflector.GetInstancePropertyByName(LoadCommands,
          "DownloadSerice", ReflectionWays.SystemReflection) as DownloadService;
        return new DownloadServiceProxy(downloadService);
      }
    }

    public DownloadCommandServiceProxy DownloadCommandServiceProxy
    {
      get
      {
        DownloadCommandService downloadCommandService = Reflector.GetInstancePropertyByName(LoadCommands,
          "DownloadCommandService", ReflectionWays.SystemReflection) as DownloadCommandService;
        return new DownloadCommandServiceProxy(downloadCommandService);
      }
    }

    public MainUploadServiceProxy MainUploadServiceProxy
    {
      get
      {
        MainUploadService mainUploadService = Reflector.GetInstancePropertyByName(LoadCommands,
          "MainUploadService", ReflectionWays.SystemReflection) as MainUploadService;
        return new MainUploadServiceProxy(mainUploadService);
      }
    }

    public UploadServiceProxy UploadServiceProxy
    {
      get
      {
        UploadService uploadervice = Reflector.GetInstancePropertyByName(LoadCommands,
          "UploadService", ReflectionWays.SystemReflection) as UploadService;
        return new UploadServiceProxy(uploadervice);
      }
    }

    public UploadCommandServiceProxy UploadCommandServiceProxy
    {
      get
      {
        UploadCommandService uploadCommandService = Reflector.GetInstancePropertyByName(LoadCommands,
          "UploadCommandService", ReflectionWays.SystemReflection) as UploadCommandService;
        return new UploadCommandServiceProxy(uploadCommandService);
      }
    }

    public LoadState LoadState
    {
      get
      {
        return Load.LoadState;
      }
    }

    public IWorkingContext WorkingContext
    {
      get
      {
        return Dlc.WorkingContext;
      }
    }

    public event DownloadEventHandler DownloadStarted
    {
      add
      {
        LoadCommands.DownloadStarted += value;
      }
      remove
      {
        LoadCommands.DownloadStarted -= value;
      }
    }

    public event DownloadEventHandler DownloadFinished
    {
      add
      {
        LoadCommands.DownloadFinished += value;
      }
      remove
      {
        LoadCommands.DownloadFinished -= value;
      }
    }
    
    public MemoryStream GetBinaryDataStream(ICoreObject backupFile)
    {
      return Reflector.RunInstanceMethodByName(LoadCommands, "GetBinaryDataStream", 
        ReflectionWays.SystemReflection,
        backupFile)
        as MemoryStream;
    }


  }
}

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
using Siemens.Automation.DomainServices.CompileService;

using Siemens.Simatic.Hmi.Utah.Common.Base.Reflection;

using YZX.Tia.Proxies.LoadService.Download;

namespace YZX.Tia.Proxies.LoadService.Upload
{
  public class CompileCommandsProxy
  {
    CompileCommands CompileCommands;

    public ILoad Load
    {
      get
      {
        return CompileCommands as ILoad;
      }
    }

    public IDlc Dlc
    {
      get
      {
        return CompileCommands as IDlc;
      }
    }

    public ICompileLoadAttributes CompileLoadAttributes
    {
      get
      {
        return CompileCommands as ICompileLoadAttributes;
      }
    }

    public CompileCommandsProxy(ICompileCommandExtension compileCommands)
    {
      CompileCommands = compileCommands as CompileCommands;
    }

    public IOnlineService OnlineService
    {
      get
      {
        return Reflector.GetInstancePropertyByName(CompileCommands, "OnlineService", 
          ReflectionWays.SystemReflection) as IOnlineService;
      }
    }

    public DownloadServiceProxy DownloadServiceProxy
    {
      get
      {
        DownloadService downloadService = Reflector.GetInstancePropertyByName(CompileCommands,
          "DownloadSerice", ReflectionWays.SystemReflection) as DownloadService;
        return new DownloadServiceProxy(downloadService);
      }
    }

    public DownloadCommandServiceProxy DownloadCommandServiceProxy
    {
      get
      {
        DownloadCommandService downloadCommandService = Reflector.GetInstancePropertyByName(CompileCommands,
          "DownloadCommandService", ReflectionWays.SystemReflection) as DownloadCommandService;
        return new DownloadCommandServiceProxy(downloadCommandService);
      }
    }

    public MainUploadServiceProxy MainUploadServiceProxy
    {
      get
      {
        MainUploadService mainUploadService = Reflector.GetInstancePropertyByName(CompileCommands,
          "MainUploadService", ReflectionWays.SystemReflection) as MainUploadService;
        return new MainUploadServiceProxy(mainUploadService);
      }
    }

    public UploadServiceProxy UploadServiceProxy
    {
      get
      {
        UploadService uploadervice = Reflector.GetInstancePropertyByName(CompileCommands,
          "UploadService", ReflectionWays.SystemReflection) as UploadService;
        return new UploadServiceProxy(uploadervice);
      }
    }

    public UploadCommandServiceProxy UploadCommandServiceProxy
    {
      get
      {
        UploadCommandService uploadCommandService = Reflector.GetInstancePropertyByName(CompileCommands,
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

  }
}

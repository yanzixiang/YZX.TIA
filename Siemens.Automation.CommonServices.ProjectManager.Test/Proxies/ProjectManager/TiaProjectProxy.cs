using System;

using Siemens.Automation.Basics;
using Siemens.Automation.ObjectFrame;
using Siemens.Automation.ProjectManager;
using Siemens.Automation.FrameApplication;
using Siemens.Automation.ProjectManager.Impl.Tia;

#if Tia
using Siemens.Simatic.PlcLanguages.BlockLogic;
using Siemens.Simatic.PlcLanguages.VatService;
using Siemens.Simatic.PlcLanguages.BlockLogic.PLDebug;
#endif

using Siemens.Simatic.Hmi.Utah.Common.Base.Reflection;

using YZX.Tia.Dlc;
using YZX.Tia.Proxies.BlockLogic;

namespace YZX.Tia.Proxies.ProjectManager
{
  public partial class TiaProjectProxy
  {
    TiaProject tp;

    ITiaProject TiaProject
    {
      get
      {
        return tp as ITiaProject;
      }
    }
    ITiaProjectInternal TiaProjectInternal
    {
      get
      {
        return tp as ITiaProjectInternal;
      }
    }

    public TiaProjectProxy(object o)
    {
      tp = o as TiaProject;
    }

    public IWorkingContext WorkingContext
    {
      get
      {
        return TiaProject.WorkingContext;
      }
    }

    public IWorkingContext ProjectWorkingContext
    {
      get
      {
        ICoreContext projectContext = WorkingContext.GetCoreContext();
        return ((IDlc)projectContext).WorkingContext;
      }
    }

    

    public void UnlockStarterFile()
    {
      TiaProjectInternal.UnlockStarterFile();
    }

    public string DirectoryPath
    {
      get
      {
        return (string)Reflector.GetInstancePropertyByName(tp,
          "DirectoryPath",
          ReflectionWays.SystemReflection);
      }
    }

    public string StarterFilePath
    {
      get
      {
        return (string)Reflector.GetInstancePropertyByName(tp,
          "StarterFilePath",
          ReflectionWays.SystemReflection);
      }
    }

    public event EventHandler MainWorkingContextIsClosing
    {
      add
      {
        tp.MainWorkingContextIsClosing += value;
      }
      remove
      {
        tp.MainWorkingContextIsClosing -= value;
      }
    }

    public event EventHandler IsModifiedChanged
    {
      add
      {
        tp.IsModifiedChanged += value;
      }
      remove
      {
        tp.IsModifiedChanged -= value;
      }
    }

#if Tia
    public QueryBasedControllerTargetLookupProxy QueryBasedControllerTargetLookup
    {
      get
      {
        var coreContext = WorkingContext.GetCoreContext();
        var QueryBasedControllerTargetLookupProxy = 
          new QueryBasedControllerTargetLookupProxy(coreContext);
        return QueryBasedControllerTargetLookupProxy;
      }
    }

    public ICoreObject FindCPU(string name)
    {
      return QueryBasedControllerTargetLookup.FindControllerTargetByName(name);
    }

    public ILibraryVersionService LibraryVersionService
    {
      get
      {
        return ProjectWorkingContext.DlcManager.Load("Siemens.Simatic.PlcLanguages.BlockLogic.LibraryVersionService") as ILibraryVersionService;
      }
    }
#endif

    public void Close(bool Silent = true)
    {
      var cpp = new CloseProjectParams();
      cpp.Silent = Silent;
      TiaProject.Close(cpp);
    }

    public TiaProjectState State {
      get
      {
        return TiaProject.State;
      }
    }
  }
}

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

using Reflection;

using YZX.Tia.Extensions;

namespace YZX.Tia.Proxies
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

    private IWorkingContext projectViewWorkingContext;
    public IWorkingContext ProjectViewWorkingContext
    {
      get
      {
        if (projectViewWorkingContext == null)
        {
          //projectViewWorkingContext = new WorkingContext(true,
          //  WorkingContextEnvironment.Project,
          //  "YZX"
          //  );

          projectViewWorkingContext = new WorkingContext(TiaStarter.m_ViewApplicationContext, 
            WorkingContextEnvironment.Project);

          //projectViewWorkingContext = TiaStarter.UIContextHolder.ProjectUIContext;
          projectViewWorkingContext.SiblingInBusinessLogicContext = ProjectWorkingContext;
        }
        return projectViewWorkingContext;
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

    public TiaProjectState TiaProjectState
    {
      get
      {
        return (TiaProjectState)Reflector.GetInstancePropertyByName(tp, 
          "TiaProjectState", 
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
        ICoreContext coreContext = WorkingContext.GetCoreContext();
        QueryBasedControllerTargetLookupProxy QueryBasedControllerTargetLookupProxy = 
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
  }
}

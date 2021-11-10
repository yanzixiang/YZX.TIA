using System;

using Siemens.Automation.Basics;

namespace YZX.Tia.Proxies.Dlc
{
  public class DlcObserverProxy : IDlcObserver
  {

    public event EventHandler<DlcAttachedEventArgs> DlcAttachedEvent;
    public void DlcAttached(IWorkingContext workingContext, 
      IDlcMetaInfo dlcMetaInfo, IDlc dlc)
    {
      DlcAttachedEvent?.Invoke(this,
        new DlcAttachedEventArgs(workingContext,dlcMetaInfo,dlc));
    }

    public event EventHandler<DlcEventArgs> DlcDetachedEvent;
    public void DlcDetached(IDlc dlc)
    {
      DlcDetachedEvent?.Invoke(this, new DlcEventArgs(dlc));
    }

    public event EventHandler<DlcInstanceClonedEventArgs> DlcInstanceClonedEvent;
    public void DlcInstanceCloned(IWorkingContext workingContext, 
      IDlcMetaInfo dlcMetaInfo, IDlc dlcForCloning, IDlc clonedDlc)
    {
      DlcInstanceClonedEvent?.Invoke(this, 
        new DlcInstanceClonedEventArgs(workingContext, dlcMetaInfo, dlcForCloning, clonedDlc));
    }

    public event EventHandler<DlcInstanceCreatedEventArgs> DlcInstanceCreatedEvent;
    public void DlcInstanceCreated(IDlcMetaInfo dlcMetaInfo, IDlc dlc)
    {
      DlcInstanceCreatedEvent?.Invoke(this, 
        new DlcInstanceCreatedEventArgs(dlcMetaInfo, dlc));
    }

    public event EventHandler<DlcEventArgs> DlcPostAttachedEvent;
    public void DlcPostAttached(IDlc dlc)
    {
      DlcPostAttachedEvent?.Invoke(this, new DlcEventArgs(dlc));
    }

    public event EventHandler<DlcEventArgs> DlcPredetachedEvent;
    public void DlcPredetached(IDlc dlc)
    {
      DlcPredetachedEvent?.Invoke(this, new DlcEventArgs(dlc));
    }

    public event EventHandler<WorkingContextEventArgs> WorkingContextClosedEvent;
    public void WorkingContextClosed(IWorkingContext workingContext)
    {
      WorkingContextClosedEvent?.Invoke(this, new WorkingContextEventArgs(workingContext));
    }

    public event EventHandler<WorkingContextEventArgs> WorkingContextCreatedEvent;
    public void WorkingContextCreated(IWorkingContext workingContext)
    {
      WorkingContextCreatedEvent?.Invoke(this, new WorkingContextEventArgs(workingContext));
    }

    public event EventHandler<ChildWorkingContextEventArgs> ChildWorkingContextCreatedEvent;
    public void WorkingContextCreated(IWorkingContext parentWorkingContext, 
      IWorkingContext newWorkingContext)
    {
      ChildWorkingContextCreatedEvent?.Invoke(this, 
        new ChildWorkingContextEventArgs(parentWorkingContext, newWorkingContext));
    }
  }

  public class ChildWorkingContextEventArgs
  {
    public IWorkingContext parentWorkingContext;
    public IWorkingContext newWorkingContext;

    public ChildWorkingContextEventArgs(IWorkingContext parentWorkingContext, IWorkingContext newWorkingContext)
    {
      this.parentWorkingContext = parentWorkingContext;
      this.newWorkingContext = newWorkingContext;
    }
  }

  public class WorkingContextEventArgs
  {
    public IWorkingContext workingContext;

    public WorkingContextEventArgs(IWorkingContext workingContext)
    {
      this.workingContext = workingContext;
    }
  }

  public class DlcInstanceClonedEventArgs
  {
    public IWorkingContext workingContext;
    public IDlcMetaInfo dlcMetaInfo;
    public IDlc dlcForCloning;
    public IDlc clonedDlc;

    public DlcInstanceClonedEventArgs(IWorkingContext workingContext,
      IDlcMetaInfo dlcMetaInfo, IDlc dlcForCloning, IDlc clonedDlc)
    {
      this.workingContext = workingContext;
      this.dlcMetaInfo = dlcMetaInfo;
      this.dlcForCloning = dlcForCloning;
      this.clonedDlc = clonedDlc;
    }
  }

  public class DlcInstanceCreatedEventArgs:DlcEventArgs
  {
    public IDlcMetaInfo dlcMetaInfo;

    public DlcInstanceCreatedEventArgs(IDlcMetaInfo dlcMetaInfo, IDlc dlc):base(dlc)
    {
      this.dlcMetaInfo = dlcMetaInfo;
    }
  }

  public class DlcEventArgs
  {
    public IDlc dlc;

    public DlcEventArgs(IDlc dlc)
    {
      this.dlc = dlc;
    }
  }

  public class DlcAttachedEventArgs:DlcEventArgs
  {
    public IWorkingContext workingContext;
    public IDlcMetaInfo dlcMetaInfo;

    public DlcAttachedEventArgs(IWorkingContext workingContext, IDlcMetaInfo dlcMetaInfo, IDlc dlc):base(dlc)
    {
      this.workingContext = workingContext;
      this.dlcMetaInfo = dlcMetaInfo;
    }
  }
}

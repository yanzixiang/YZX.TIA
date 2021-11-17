using System;
using System.Windows.Forms;
using Microsoft.Win32;
using System.Threading;

using Siemens.Automation.Basics;
using Siemens.Automation.ObjectFrame;
using Siemens.Automation.Basics.Synchronizer;
using Siemens.Automation.FrameApplication;
using Siemens.Automation.FrameApplication.Bootstrapper;
using Siemens.Automation.FrameApplication.ShortcutManager;
using Siemens.Automation.Basics.SynchronizationContext;
using Siemens.Automation.CommonServices.ApplicationLifeCycle.PowerManagement;

using YZX.Tia.Dlc;

namespace YZX.Tia
{
  public partial class TiaStarter
  {
    private IWindowManagerInternal m_WindowManager;
    private IApplicationFrame m_MainApplicationFrame;

    private void StartFileStorageServer()
    {
      ICoreFrame m_CoreFrame = m_ViewApplicationContext.DlcManager.Load("Siemens.Automation.ObjectFrame.CoreFrame") 
        as ICoreFrame;
      m_CoreFrame.TryStartServer();
    }

    public static Form m_MainApplicationForm;

    public string AppId = "TiaTest";
    public string username = "YZX";

    private void CreateStartupPreloadedContext()
    {
      AutoResetEvent autoResetEvent = new AutoResetEvent(false);
      new Thread(new ParameterizedThreadStart(this.CreateStartupPreloadedContextThread)).Start(autoResetEvent);
      autoResetEvent.WaitOne();
    }

    private void CreateStartupPreloadedContextThread(object autoResetEvent)
    {
      try
      {
        WorkingContext workingContext = new WorkingContext(false, 
          WorkingContextEnvironment.Application, 
          AppId, 
          username)
        {
          Scope = "DlcStartupPreload"
        };
        ((EventWaitHandle)autoResetEvent).Set();
        ((IDlcAutoloader)workingContext.DlcManager).AutoloadByScope();
      }
      finally
      {
        ((EventWaitHandle)autoResetEvent).Set();
      }
    }

    public void StartUpHibernateThread()
    {
      using (AutoResetEvent autoResetEvent = new AutoResetEvent(false))
      {
        new Thread(new ParameterizedThreadStart(StartUpHibernateThread))
        {
          IsBackground = true,
          Name = "PowerManagementThread",
          Priority = ThreadPriority.Normal
        }.Start(autoResetEvent);
        autoResetEvent.WaitOne();
      }
    }
    private static void StartUpHibernateThread(object o)
    {
      HibernateServiceFactory.CreateAndInit((AutoResetEvent)o);
    }

    public void StartUpPowerManagementThread()
    {
      using (AutoResetEvent autoResetEvent = new AutoResetEvent(false))
      {
        new Thread(new ParameterizedThreadStart(StartUpHibernateThread))
        {
          IsBackground = true,
          Name = "PowerManagementThread",
          Priority = ThreadPriority.Normal
        }.Start(autoResetEvent);
        autoResetEvent.WaitOne();
      }
    }

    public static void ForceEarlyCreationOfBroadcastEventWindow()
    {
      SystemEvents.InvokeOnEventsThread((Action)(() => { }));
    }

    private bool StartShouldBeInterrupted()
    {
      return false;
    }

    private static TiaStarter instance;
    public static TiaStarter Instance
    {
      get
      {
        return instance;
      }
    }

    public TiaStarter(bool showView=false)
    {
      this.CreateWorkingContextHierarchy();
      if (showView)
      {
        //WindowManager.InitializationCompleted += WindowManager_InitializationCompleted;
      }
      this.CreateStartupPreloadedContext();
      instance = this;
    }

    private void WindowManager_InitializationCompleted(object sender, EventArgs e)
    {
      //m_ViewApplicationContext.DlcManager.Load("Siemens.Automation.Portal.ComServer.Application", true);
      //this.m_WindowManager.InitializationCompleted -= new EventHandler(this.WindowManager_InitializationCompleted);
      bool flag = false;
      //if (this.InitializationCompletedCallback != null)
      //  flag = this.InitializationCompletedCallback();
      if (flag)
      {
        m_MainApplicationForm.Close();
      }
      else
      {
        this.StartFileStorageServer();
        string startupCompletedCallback = "";
        if (string.IsNullOrEmpty(startupCompletedCallback))
        {
          startupCompletedCallback = "Siemens.Automation.FrameApplication.Bootstrapper.DefaultStartupCompletedCallbackDlc";
        }
        new StartupCompletedCallbackDlcCommandLineHandler(m_ViewApplicationContext, startupCompletedCallback).Start(null);
      }

      //m_MainApplicationForm.Hide();
    }

    public void CreateForm()
    {
      //this.WindowManager.InitializationCompleted += new EventHandler(this.WindowManager_InitializationCompleted);
      //this.m_MainApplicationFrame = this.WindowManager.CreateMainApplication() as IApplicationFrame;
      if (this.m_MainApplicationFrame == null)
        throw new FrameApplicationException("Calling IWindowManager.CreateMainApplication was not successful: It has returned null.");
      m_MainApplicationForm = (Form)this.m_MainApplicationFrame.FrameControl;
      if (m_MainApplicationForm == null)
        throw new FrameApplicationException("The FrameControl of the ApplicationFrame must be of type 'System.Windows.Forms.Form'.");
      m_MainApplicationForm.FormClosed += new FormClosedEventHandler(this.MainApplicationForm_FormClosed);
    }

    public void Run(Form f = null)
    {
      Console.WriteLine("AppLoader.Run", "Bootstrapper enters IStarter.Run method.");
      if (this.StartShouldBeInterrupted())
        return;
      ForceEarlyCreationOfBroadcastEventWindow();
      Application.EnableVisualStyles();
      //this.CreateStartupPreloadedContext();

      m_ViewApplicationContext.GetRequiredDlc<IShortcutManager>("Siemens.Automation.FrameApplication.ShortcutManager");
      m_ViewApplicationContext.DlcManager.Load("Siemens.Automation.FrameApplication.Services.RegisterServices");
      m_ViewApplicationContext.SiblingInBusinessLogicContext.AutoLoadDlcs();
      m_ViewApplicationContext.AutoLoadDlcs();

      if (f == null)
      {
        CreateForm();
      }
      else
      {
        m_MainApplicationForm = f;
      }

      SynchronizationContext current = SynchronizationContext.Current;
      try
      {
        SynchronizationContext.SetSynchronizationContext(new NonPumpingSynchronizationContext(current));
        ISynchronizer sychronizer = Synchronizer;
        if (sychronizer != null)
        {
          Console.WriteLine("AppLoader.Run", "Bootstrapper starts running ThreadSynchronizer.");
          sychronizer.Run(m_MainApplicationForm);
          Console.WriteLine("AppLoader.Run", "Bootstrapper finished running ThreadSynchronizer.");
        }
        else
        {
          Application.Run(m_MainApplicationForm);
        }
      }
      finally
      {
        SynchronizationContext.SetSynchronizationContext(current);
      }
    }
    private void MainApplicationForm_FormClosed(object sender, FormClosedEventArgs e)
    {
      m_MainApplicationForm.FormClosed -= new FormClosedEventHandler(this.MainApplicationForm_FormClosed);
      this.Uninitialize();
    }

    public void Uninitialize()
    {
      lock (this)
      {
        if (m_ViewApplicationContext != null)
          m_ViewApplicationContext.Close();
        m_MainApplicationForm = null;
        this.m_WindowManager = null;
      }
    }
  }
}

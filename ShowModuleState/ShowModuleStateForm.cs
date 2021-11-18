using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;
using Console = Colorful.Console;

using Siemens.Automation.Basics;
using Siemens.Automation.FrameApplication;
using Siemens.Automation.ObjectFrame;

using Siemens.Automation.CommonTrace.TraceIntegrationDotNet;

using YZX.Tia;
using YZX.Tia.Proxies;
using YZX.Tia.Proxies.Dlc;
using YZX.Tia.Proxies.FrameApplication;

using YZX.Tia.Extensions.FrameApplication;
using YZX.Tia.Extensions.ProjectManager;
using YZX.Tia.Proxies.ProjectManager;
using YZX.Tia.Extensions.Diagnostic;
using YZX.Tia.Dlc;

namespace ShowModuleState
{
  public partial class ShowModuleStateForm : Form
  {
    public ShowModuleStateForm()
    {
      address = "Sps7;Rack=0;Slot=2;RSA=TCP_192.168.8.111_SM_255.255.255.0_SubnetId_4C-AA-00-00-00-01;ResourceId=1;";
      //address = "Sps7;Rack=0;Slot=2;RSA=TCP_192.168.1.111_SM_255.255.255.0_SubnetId_8F-21-00-00-00-02;ResourceId=1;";
      address = "OMS;TSelector=SIMATIC-ROOT-ES;RSA=TCP_192.168.1.34_SM_255.255.255.0_SubnetId_11-5F-00-00-00-01;ResourceId=6;";

      path = @"E:\gitt\VPLC\1500VPLCTIA\1500VPLCTIA.ap14";

      boardName = "PLCSIM";

      TiaStarter.SetForm(this);

      InitializeComponent();

      Load += Form1_Load;
      SizeChanged += Form1_SizeChanged;

      //AfterSychronizer();
    }

    private void Form1_SizeChanged(object sender, EventArgs e)
    {
    }

    TiaProjectProxy projectProxy;
    PrimaryProjectManagerProxy PrimaryProjectManagerProxy;
    PrimaryProjectUiWorkingContextManagerProxy PrimaryProjectUiWorkingContextManagerProxy;

    public void OpenProject()
    {
      Console.WriteLine("OpenProject");
      PrimaryProjectUiWorkingContextManagerProxy = TiaStarter.m_ViewApplicationContext.GetPrimaryProjectUiWorkingContextManagerProxy();

      PrimaryProjectManagerProxy =
        PrimaryProjectUiWorkingContextManagerProxy.PrimaryProjectManager;

      PrimaryProjectManagerProxy.ProjectOpened += PrimaryProjectManagerProxy_ProjectOpened;



      var proxy = TiaStarter.m_BusinessLogicApplicationContext.GetTiaProjectManagerProxy();
      object project = null;
      //proxy.OpenProjectReadWrite(path, out project);
      try
      {
        PrimaryProjectManagerProxy.OpenProjectReadWrite(path, out project);
      }catch(Exception ex)
      {
        Console.WriteLine(ex);
      }
    }

    private void PrimaryProjectManagerProxy_ProjectOpened(object sender, EventArgs e)
    {
      projectProxy = PrimaryProjectManagerProxy.PrimaryProject;

      var project_WorkingContext_Proxy = new WorkingContextProxy(projectProxy.WorkingContext);

      var project_WorkingContext_PlatformServiceContainer = project_WorkingContext_Proxy.PlatformServiceContainer;
      if (project_WorkingContext_PlatformServiceContainer != null)
      {
        project_WorkingContext_PlatformServiceContainer.ConstructServiceEvent += Project_WorkingContext_PlatformServiceContainer_ConstructServiceEvent;
        project_WorkingContext_PlatformServiceContainer.ServiceLoadedEvent += Project_WorkingContext_PlatformServiceContainer_ServiceLoadedEvent;
        project_WorkingContext_PlatformServiceContainer.ServiceAddedEvent += Project_WorkingContext_PlatformServiceContainer_ServiceAddedEvent;
        project_WorkingContext_PlatformServiceContainer.ServiceRemovedEvent += Project_WorkingContext_PlatformServiceContainer_ServiceRemovedEvent;
      }

      projectProxy.WorkingContext.AutoLoadDlcs();

      ShowModuleState();

    }

    private void Project_WorkingContext_PlatformServiceContainer_ServiceRemovedEvent(
      object sender, 
      ServiceChangedEventArgs e)
    {
      Console.WriteLine(string.Format("ServiceRemoved {0}",e.ServiceType.Name));
    }

    private void Project_WorkingContext_PlatformServiceContainer_ServiceAddedEvent(
      object sender, 
      ServiceChangedEventArgs e)
    {
      Console.WriteLine(string.Format("ServiceAdded {0}",e.ServiceType.Name));
    }

    private void Project_WorkingContext_PlatformServiceContainer_ServiceLoadedEvent(
      object sender, 
      ServiceChangedEventArgs e)
    {
      Console.WriteLine(string.Format("ServiceLoaded {0}",e.ServiceType.Name));
    }

    private void Project_WorkingContext_PlatformServiceContainer_ConstructServiceEvent(
      object sender, 
      ConstructServiceEventArgs e)
    {
      Console.WriteLine(string.Format("ConstructService {0}",e.ServiceCreatorType.Name));
    }

    Control ModuleState;
    public void ShowModuleState()
    {
      if (projectProxy != null)
      {
        cpu = projectProxy.FindCPU("VPLC1");
        ModuleState = cpu.ShowModuleState();

        Controls.Add(ModuleState);

        var metainfos1 = TiaStarter.m_ViewApplicationContext.GetGlobalSingletonCache_MetaInfo();
        var metainfos2 = TiaStarter.m_ViewApplicationContext.GetSingletonCache_MetaInfo();
        var metainfos3 = TiaStarter.m_ViewApplicationContext.GetNonSingletonCache_MetaInfo();

        var metainfos4 = TiaStarter.m_BusinessLogicApplicationContext.GetGlobalSingletonCache_MetaInfo();
        var metainfos5 = TiaStarter.m_BusinessLogicApplicationContext.GetSingletonCache_MetaInfo();
        var metainfos6 = TiaStarter.m_BusinessLogicApplicationContext.GetNonSingletonCache_MetaInfo();

        Console.WriteLine("O");
      }
    }

    string address;
    string path;

    string boardName = "Intel(R) Dual Band Wireless-AC 7265";
    int boardNumber = 1;
    int configIndex = 1;

    public void BeforeStartSynchronizer()
    {
      OpenProject();
    }

    private void Form1_Load(object sender, EventArgs e)
    {
      Console.WriteLine("Form1_Load");
      TestTraceManager();

      BeforeStartSynchronizer();


      Resize += Form1_Resize;
    }

    public void TestTraceManager()
    {
      var trace = TraceManagerExtensions.GetTrace("Siemens.Automation.TraceIntegrationDotNet", 
        "Siemens.Automation.CommonTrace.TraceIntegrationDotNet.TraceManager");
      trace.DebugMessageSent += Trace_DebugMessageSent;
      trace.InformationMessageSent += Trace_InformationMessageSent;
      trace.WarningMessageSent += Trace_WarningMessageSent;
      trace.ErrorMessageSent += Trace_ErrorMessageSent;
    }

    private void Trace_ErrorMessageSent(object sender, TraceEventArgs e)
    {
      try
      {
        Console.WriteLine(string.Format("{0} Error", e.ClassName), Color.Red);
        Console.WriteLine(e, Color.Red);
      }catch(Exception ex)
      {

      }
    }

    private void Trace_WarningMessageSent(object sender, TraceEventArgs e)
    {
      try
      {
        Console.WriteLine(string.Format("{0} Warning", e.ClassName), Color.Yellow);
        Console.WriteLine(e, Color.Yellow);
      }catch(Exception ex)
      {

      }
    }

    private void Trace_InformationMessageSent(object sender, TraceEventArgs e)
    {
      try
      {
        Console.WriteLine(string.Format("{0} Information", e.ClassName), Color.Green);
        Console.WriteLine(e, Color.Green);
        if (e.MethodName == "#### DlcManager #####: DlcCreated")
        {
          Console.WriteLine(e, Color.Gold);
        }
      }catch(Exception ex) { }
    }

    private void Trace_DebugMessageSent(object sender, TraceEventArgs e)
    {
      try
      {
        Console.WriteLine(string.Format("{0} Debug",e.ClassName));
        Console.WriteLine(e);
      }catch(Exception ex)
      {

      }
    }

    private void Form1_Resize(object sender, EventArgs e)
    {
    }

    static ICoreObject cpu;
  }
}

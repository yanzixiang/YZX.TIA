using System;
using System.Collections;
using System.Threading;
using System.ComponentModel;
using System.Collections.Generic;
using System.Windows.Forms;

using Siemens.Automation.Basics;
using Siemens.Automation.ObjectFrame;
using Siemens.Automation.CommonServices;
using Siemens.Automation.DomainServices;
using Siemens.Automation.DomainServices.OnlineService;
using Siemens.Automation.DomainServices.ConnectionService;
using Siemens.Automation.DomainServices.ConnectionService.Private;
using Siemens.Automation.DomainServices.DomainGrid;
using Siemens.Automation.CommonServices.AccessControl;
using Siemens.Automation.FrameApplication;
using Siemens.Simatic.PlcLanguages.PLInterface.PLDebug;
using Siemens.Simatic.Lang.Model.Idents;
using Siemens.Simatic.PlcLanguages.BlockLogic.PLDebug;
using Siemens.Automation.OnlineAccess.OnlineInterface;
using Siemens.Automation.OnlineAccess;
using Siemens.Simatic.PlcLanguages.BlockEditorFrame;
using Siemens.Simatic.PlcLanguages.BlockEditorFrame.Editor.Logic;
using Siemens.Simatic.PlcLanguages.BlockEditorFrame.Services.Starter;
using Siemens.Simatic.PlcLanguages.BlockEditorFrame.Editor.View;
using Siemens.Simatic.PlcLanguages.BlockEditorFrame.Services.Online;

using Reflection;

using YZXLogicEngine;
using YZX.Tia;
using YZX.Tia.Extensions;
using YZX.Tia.Proxies;
using YZX.Tia.Proxies.Graph;
using YZX.Tia.Forms;
using YZX.Tia.Proxies.Ladder;

namespace VatViewer
{
  public partial class Form1 : TiaForm
  {
    public Form1()
    {
      address = "Sps7;Rack=0;Slot=2;RSA=TCP_192.168.8.111_SM_255.255.255.0_SubnetId_4C-AA-00-00-00-01;ResourceId=1;";
      //address = "Sps7;Rack=0;Slot=2;RSA=TCP_192.168.1.111_SM_255.255.255.0_SubnetId_8F-21-00-00-00-02;ResourceId=1;";
      address = "OMS;TSelector=SIMATIC-ROOT-ES;RSA=TCP_192.168.1.34_SM_255.255.255.0_SubnetId_11-5F-00-00-00-01;ResourceId=6;";

      path = @"S:\216321\216321江森HTA\216321-315\216321-315.ap14";
      path = @"S:\216889\216889-1500-1113\216889-1500-1113.ap14";

      boardName = "PLCSIM";

      TiaStarter.SetForm(this);

      

      InitializeComponent();

      Load += Form1_Load;
      SizeChanged += Form1_SizeChanged;

      //AfterSychronizer();
    }

    private void Form1_SizeChanged(object sender, EventArgs e)
    {
      gbec.Size = Size;
    }

    TiaProjectProxy projectProxy;
    PrimaryProjectManagerProxy PrimaryProjectManagerProxy;
    PrimaryProjectUiWorkingContextManagerProxy PrimaryProjectUiWorkingContextManagerProxy;
    IUIContextHolder UIContextHolder;
    IWorkingContext ProjectUIContext;

    public void OpenProject()
    {
      PrimaryProjectUiWorkingContextManagerProxy = TiaStarter.m_ViewApplicationContext.GetPrimaryProjectUiWorkingContextManagerProxy();

      PrimaryProjectManagerProxy =
        PrimaryProjectUiWorkingContextManagerProxy.PrimaryProjectManager;

      PrimaryProjectManagerProxy.ProjectOpened += PrimaryProjectManagerProxy_ProjectOpened;



      var proxy = Program.app.TiaProjectManagerProxy;
      object project = null;
      //proxy.OpenProjectReadWrite(path, out project);
      PrimaryProjectManagerProxy.OpenProjectReadWrite(path, out project);
    }

    private void PrimaryProjectManagerProxy_ProjectOpened(object sender, EventArgs e)
    {
      UIContextHolder = PrimaryProjectUiWorkingContextManagerProxy.IUIContextHolder;
      ProjectUIContext = UIContextHolder.ProjectUIContext;

      projectProxy = PrimaryProjectManagerProxy.PrimaryProject;
      projectProxy.WorkingContext.AutoLoadDlcs();

      LoadVatTable();

      TestGetLadderEditor();

    }

    private void TestGetLadderEditor()
    {
      this.gbec = Program.app.GetBlockEditor(graph);
      GraphBlockEditorControlProxy pLBlockEditorControlElementProxy =
        new GraphBlockEditorControlProxy(this.gbec);
      OnlineManagerBase plOnlineManager = pLBlockEditorControlElementProxy.GraphBlockEditorLogic.OnlineManager;
      plOnlineManager.GoOnline();
      plOnlineManager.StartProgramStatus();

      List<IUIControl> children = pLBlockEditorControlElementProxy.GetChildUIControls();
      Controls.Add(this.gbec);
    }

    public void LoadVatTable()
    {
      cpu = projectProxy.FindCPU("216889CPU");
      graph = projectProxy.BlockServiceProxy.FindBlockByAddress(cpu, BlockType.FB, 2010)[0];
    }

    ICoreObject graph;
    string address;
    string path;
    
    string boardName = "Intel(R) Dual Band Wireless-AC 7265";
    int boardNumber = 1;
    int configIndex = 1;

    DebugDevice dd;
    DebugDeviceProxy ddp;
    ConnectionServiceProvider ssp;
    ThreadSynchronizerProxy tsp;

    public void BeforeStartSynchronizer()
    {
      OpenProject();
      LoadVatTable();
    }

    private void Form1_Load(object sender, EventArgs e)
    {
      Console.WriteLine("Form1_Load");

      BeforeStartSynchronizer();

      OpenIronPythonConsole();

      Resize += Form1_Resize;
    }

    private void Form1_Resize(object sender, EventArgs e)
    {
      this.gbec.Size = this.Size;
    }

    public void OpenIronPythonConsole()
    {
      IronPythonConsoleForm IPCF = new IronPythonConsoleForm();
      //VarTableViewModifyExtension VTVME = ConfigVTVME();
      //IPCF.PCV.SetVariable("VTVME", VTVME);
      IPCF.PCV.SetVariable("app", Program.app);
      IPCF.PCV.SetVariable("gbec", this.gbec);
      IPCF.InitFile = "IronPython/VAT.py";

      IPCF.Show();
      IPCF.FormClosed += IPCF_FormClosed;
    }

    private void IPCF_FormClosed(object sender, FormClosedEventArgs e)
    {
      IronPythonConsoleForm ipcf = sender as IronPythonConsoleForm;
      ipcf.Dispose();
    }

    static ICoreObject cpu;
  }
}

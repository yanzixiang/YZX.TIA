using System;
using System.Drawing;
using System.Threading;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Windows.Threading;

using Siemens.Automation.Basics;
using Siemens.Automation.ObjectFrame;
using Siemens.Automation.DomainServices;
using Siemens.Automation.FrameApplication;
using Siemens.Automation.UI.Controls.WindowlessFramework;

using Siemens.Simatic.Lang.Model.Idents;
using Siemens.Simatic.PlcLanguages.BlockEditorFrame.Services.Starter;
using Siemens.Simatic.PlcLanguages.PLInterface.PLDebug;
using Siemens.Simatic.PlcLanguages.BlockLogic.PLDebug;
using Siemens.Simatic.PlcLanguages.BlockEditorFrame;
using Siemens.Simatic.PlcLanguages.BlockEditorFrame.Editor.Logic;
using Siemens.Simatic.PlcLanguages.BlockEditorFrame.Services.Online;
using Siemens.Simatic.PlcLanguages.BlockEditorFrame.Editor.View;
using Siemens.Simatic.PlcLanguages.FLGraphicEditor;
using Siemens.Simatic.PlcLanguages.BlockEditorFrame.Controls.TagComments;

using Siemens.Simatic.PlcLanguages.FLGraphicEditor.View;


using Reflection;


using YZX.Tia;
using YZX.Tia.Extensions;
using YZX.Tia.Extensions.Ladder;
using YZX.Tia.Proxies;
using YZX.Tia.Proxies.Ladder;
using YZX.Tia.Forms;
using YZX.Tia.Proxies.Graph;

namespace VatViewer
{
  public partial class Form1 : TiaForm
  {
    string path;
    public Form1()
    {
      path = @"S:\216889\216889-1500-1113\216889-1500-1113.ap14";


      TiaStarter.SetForm(this);

      Thread = Thread.CurrentThread;

      InitializeComponent();

      Load += Form1_Load;
      SizeChanged += Form1_SizeChanged;

      //AfterSychronizer();
    }

    private void Form1_SizeChanged(object sender, EventArgs e)
    {
      if(gbec != null)
      {
        gbec.Size = new Size(Size.Width - 20, Size.Height - 40);
      }

      if(ModuleState != null)
      {
        ModuleState.Size = new Size(Size.Width - 20, Size.Height - 40);
      }
    }

    TiaProjectProxy projectProxy;

    public void OpenProject()
    {


      Program.app.PrimaryProjectManagerProxy.ProjectOpened += PrimaryProjectManagerProxy_ProjectOpened;



      var proxy = Program.app.TiaProjectManagerProxy;
      object project = null;
      //proxy.OpenProjectReadWrite(path, out project);
      Program.app.PrimaryProjectManagerProxy.OpenProjectReadWrite(path, out project);
    }

    private void PrimaryProjectManagerProxy_ProjectOpened(object sender, EventArgs e)
    {

      projectProxy = Program.app.PrimaryProjectManagerProxy.PrimaryProject;
      projectProxy.WorkingContext.AutoLoadDlcs();

      LoadOB1();

      //TestDiagBufferDialog();

      //OpenGraph();
      OpenLadder();
    }

    private void OpenLadder()
    {
      this.gbec = Program.app.GetBlockEditor(pl) ;
      pLBlockEditorControlElementProxy =
        new PLBlockEditorControlElementProxy(this.gbec);
      OnlineManagerBase plOnlineManager = pLBlockEditorControlElementProxy.PLBlockEditorLogic.OnlineManager;
      plOnlineManager.GoOnline();
      plOnlineManager.StartProgramStatus();
      Controls.Add(this.gbec);

      this.gbec.DisablePLBlockInput();

    }

    private void OpenGraph()
    {
      this.gbec = Program.app.GetBlockEditor(graph);
      GraphBlockEditorControlProxy pLBlockEditorControlElementProxy =
        new GraphBlockEditorControlProxy(this.gbec);

      //pLBlockEditorControlElementProxy.BasicDrawSettings.StepBackground = Brushes.DarkBlue;
      //Font stepNameFont = new Font("Consolas", pLBlockEditorControlElementProxy.BasicDrawSettings.StepNameFont.Size);
      //pLBlockEditorControlElementProxy.BasicDrawSettings.StepNameFont = stepNameFont;

      OnlineManagerBase plOnlineManager = pLBlockEditorControlElementProxy.GraphBlockEditorLogic.OnlineManager;
      plOnlineManager.GoOnline();
      plOnlineManager.StartProgramStatus();


      List<IUIControl> children = pLBlockEditorControlElementProxy.GetChildUIControls();
      Controls.Add(this.gbec);
      var cs = this.gbec.Controls;
      this.gbec.DisableGraphBlockInput();
    }

    Control ModuleState;
    public void TestDiagBufferDialog()
    {
      ModuleState =  Program.app.ShowModuleState(cpu);
      Controls.Add(ModuleState);
    }

    PLBlockEditorControlElementProxy pLBlockEditorControlElementProxy;

    public void LoadOB1()
    {
      cpu = projectProxy.FindCPU("216889CPU");
      pl = projectProxy.BlockServiceProxy.FindBlockByAddress(cpu, BlockType.FC, 2012)[0];
      graph = projectProxy.BlockServiceProxy.FindBlockByAddress(cpu, BlockType.FB, 2010)[0];
    }

    ICoreObject pl;
    ICoreObject graph;
    public void BeforeStartSynchronizer()
    {
      OpenProject();
    }

    private void Form1_Load(object sender, EventArgs e)
    {
      Console.WriteLine("Form1_Load");
      //TestWindowManager();

      BeforeStartSynchronizer();

      
    }

    Thread Thread;
    Dispatcher Dispatcher;



    static ICoreObject cpu;

    private void WorkingContext_ServiceAddedEvent(object sender, ServiceChangedEventArgs e)
    {
      Console.WriteLine("GBEC WorkingContext_ServiceAddedEvent {0} {1}", e.ServiceType, e.ServiceCreatorType);
    }
  }
}

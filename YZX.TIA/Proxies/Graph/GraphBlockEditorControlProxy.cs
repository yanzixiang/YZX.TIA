using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Siemens.Simatic.PlcLanguages.GraphEditor.Frame;
using Siemens.Simatic.PlcLanguages.BlockEditorFrame.Editor.View;
using Siemens.Simatic.PlcLanguages.BlockEditorFrame.Editor.Logic;
using Siemens.Simatic.PlcLanguages.BlockEditorFrame;

namespace YZX.Tia.Proxies.Graph
{
  public class GraphBlockEditorControlProxy
  {
    internal GraphBlockEditorControl GraphBlockEditorControl;
    public GraphBlockEditorControlProxy(BlockEditorControlBase element)
    {
      GraphBlockEditorControl = element as GraphBlockEditorControl;
    }

    public BlockEditorLogicBase GraphBlockEditorLogic
    {
      get
      {
        return GraphBlockEditorControl.GraphBlockEditorLogic;
      }
    }

    public GraphBlockEditorLogicProxy GraphBlockEditorLogicProxy
    {
      get
      {
        return new GraphBlockEditorLogicProxy(GraphBlockEditorLogic);
      }
    }

    public MainControlContainerProxy MainControlContainer
    {
      get
      {
        return new MainControlContainerProxy(GraphBlockEditorControl.MainControlContainer);
      }
    }

    public NavigationViewControlProxy NavigationViewControl
    {
      get
      {
        return new NavigationViewControlProxy(GraphBlockEditorControl.NavigationViewControl);
      }
    }

    public GraphModelProxy ModelProxy
    {
      get
      {
        return new GraphModelProxy(GraphBlockEditorControl.Model);
      }
    }

    public GraphDrawSettingsProxy BasicDrawSettings
    {
      get
      {
        var settings = GraphBlockEditorControl.BasicDrawSettings;
        var proxy = new GraphDrawSettingsProxy(settings);
        return proxy;
      }
    }

    public List<IUIControl> GetChildUIControls()
    {
      return GraphBlockEditorControl.GetChildUIControls();
    }

    public void ShowAlarmMainCtrl(bool focus, bool speedySplitterHandling = false)
    {
      GraphBlockEditorControl.ShowAlarmMainCtrl(focus, speedySplitterHandling);
    }

    public void ShowSingleStepMainCtrl(bool focus, bool speedySplitterHandling = false)
    {
      GraphBlockEditorControl.ShowSingleStepMainCtrl(focus, speedySplitterHandling);
    }

    public void DisableGraphBlockInput()
    {

    }
  }
}

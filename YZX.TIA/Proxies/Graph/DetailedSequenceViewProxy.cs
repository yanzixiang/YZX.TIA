using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;

using Siemens.Automation.UI.Controls.WindowlessFramework;
using Siemens.Automation.CommonServices.TextEditor;
using Siemens.Automation.CommonServices.TextEditor.View;
using Siemens.Simatic.PlcLanguages.PLInterface.PLDebug;
using Siemens.Simatic.PlcLanguages.FLGraphicEditor;
using Siemens.Simatic.PlcLanguages.GraphEditor;
using Siemens.Simatic.PlcLanguages.GraphEditor.View;
using Siemens.Simatic.PlcLanguages.BlockEditorFrame;
using Siemens.Simatic.PlcLanguages.GraphEditor.View.Overlays;
using Siemens.Simatic.PlcLanguages.GraphEditor.ActionList.View;
using Siemens.Simatic.PlcLanguages.GraphEditor.View.Selection;

using Reflection;

namespace YZX.Tia.Proxies.Graph
{
  public class DetailedSequenceViewProxy:AbstractGraphViewProxy
  {
    internal DetailedSequenceView view;

    internal DetailedSequenceViewProxy(DetailedSequenceView view)
      :base(view)
    {
      this.view = view;
    }

    public SequenceUIElementProxy SequenceUIElement
    {
      get
      {
        return new SequenceUIElementProxy(view.SequenceUIElement);
      }
    }

    public HostElement HostElement
    {
      get
      {
        return Reflector.GetInstancePropertyByName(view, "HostElement", 
          ReflectionWays.SystemReflection) as HostElement;
      }
    }

    public void TrackStep(int stepNumber, bool firstCallOfTrackActiveStep)
    {
      view.TrackStep(stepNumber, firstCallOfTrackActiveStep);
    }

    public List<IDebugBlock> GetVisibleSubControls()
    {
      return Reflector.RunInstanceMethodByName(view, "GetVisibleSubControls",
        ReflectionWays.SystemReflection) as List<IDebugBlock>;
    }

    public void DisableGraphBlockInput()
    {
      view.SelectionManager.DelayedSelectionChanged += SelectionManager_DelayedSelectionChanged;
    }

    private void SelectionManager_DelayedSelectionChanged(object sender, EventArgs e)
    {
      DefaultSelectionManager manager = sender as DefaultSelectionManager;
      var selectedItems = manager.SelectedItems;
      if(selectedItems.Count > 0)
      {
        foreach(var item in selectedItems)
        {

        }
      }
      DisableGraphBlockInputInternal();
    }

    public void DisableGraphBlockInputInternal()
    {
      SequenceUIElement.SequenceUIElement.BackColor = Color.Yellow;
      UIElementCollection children = HostElement.ChildUIElements;

      List<OverlayBaseProxy> seqOverlayList = GetSequenceOverlay();
      foreach (var overlay in seqOverlayList)
      {
        var steps = overlay.GetSteps();
        foreach (var step in steps)
        {

          ActionListControl actions = step.GetActionListControl();
          if (actions != null)
          {
            actions.BackColor = Color.Red;
            actions.Enabled = false;
            CmdDispatcher CmdDispatcher = actions.CmdDispatcher;
            CmdDispatcher.MainCmdContainer.ClearCmdHandler();
            var ActionListOverlays = actions.ActionListOverlays;
            actions.ContextMenuProvider = null;


            EditOverlay edit = actions.EditOverlay;
            edit.BackColor = Color.Blue;
          }

        }

        var transitions = overlay.GetTransitions();

        foreach(var transition in transitions)
        {
          GraphFLGraphicEditor editor = transition.GetGraphFLGraphicEditor();
          if(editor != null)
          {
            editor.Enabled = false;
            editor.BackColor = Color.Yellow;
          }

        }
      }

      List<IDebugBlock> blocks = GetVisibleSubControls();


      foreach (var child in view.Controls)
      {

      }
    }

    public List<OverlayBaseProxy> GetSequenceOverlay()
    {

      List<OverlayBaseProxy> list = new List<OverlayBaseProxy>();
      if(OverlayManager == null)
      {
        return list;
      }



      foreach (var overlay in OverlayManager.OverlayList)
      {
        if (overlay.OverlayType == GraphEditorDefinitions.OverlayType.Sequence)
        {

          var proxy = new OverlayBaseProxy(overlay);

          list.Add(proxy);
        }
      }
      return list;
    }

  }
}
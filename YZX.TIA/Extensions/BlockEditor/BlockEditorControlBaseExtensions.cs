using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;

using Siemens.Simatic.PlcLanguages.BlockEditorFrame;
using Siemens.Simatic.PlcLanguages.BlockEditorFrame.Editor.View;
using Siemens.Simatic.PlcLanguages.BlockEditorFrame.Controls.TagComments;
using Siemens.Simatic.PlcLanguages.FLGraphicEditor;
using Siemens.Simatic.PlcLanguages.FLGraphicEditor.View;

using YZX.Tia.Extensions;
using YZX.Tia.Proxies.Ladder;
using YZX.Tia.Proxies.Graph;

namespace YZX.Tia.Extensions.Ladder
{
  public static class BlockEditorControlBaseExtensions
  {
    public static void DisablePLBlockInput(this BlockEditorControlBase ladder)
    {
      PLBlockEditorControlElementProxy pLBlockEditorControlElementProxy =
          new PLBlockEditorControlElementProxy(ladder);

      List<NetworkElementProxy> networks = pLBlockEditorControlElementProxy.GetNetworks();

      foreach (NetworkElementProxy network in networks)
      {
        List<IUIControl> networkChildren = network.LanguagePaletteBaseElement.GetChildUIControls();
        CommandTextBoxElement Title = network.CommandTextBoxElement;
        Title.BackColor = Color.Red;

        CollapsableTextBoxElement CommentElement = network.CommentElement;
        CommentElement.BackColor = Color.Yellow;


        TagCommentElement NetworkTagCommentElement = network.NetworkTagCommentElement;
        NetworkTagCommentElement.BackColor = Color.Blue;

        SimaticFLGraphicEditor SimaticFLGraphicEditor = network.SimaticFLGraphicEditor;
        SimaticFLGraphicEditor.BackColor = Color.Gold;

        SimaticFLGraphicEditor.Enabled = false;


        FLGViewAccessibleObjectProxy FLGViewAccessibleObjectProxy = FLGViewExtensions.GetCorrectAccessibilityObject(SimaticFLGraphicEditor);

        GraphicManager manager = SimaticFLGraphicEditor.GetGraphicManager();

        List<GraphicObjectProxy> list = manager.ToGraphicObjectProxyList();
        foreach (GraphicObjectProxy proxy in list)
        {
          if (proxy.SupportEdit)
          {
            IFLGEditBoxHandler handler = proxy.EditBoxHandler;

            AccessibleObject AccessibleObject = FLGViewAccessibleObjectProxy.GetAccessibleChildObject(proxy);
          }
        }
      }

      pLBlockEditorControlElementProxy.FavouritsToolBar.Visible = false;
      pLBlockEditorControlElementProxy.BlockHeaderPalette.Visible = false;
    }

    public static void DisableGraphBlockInput(this BlockEditorControlBase graph)
    {
      GraphBlockEditorControlProxy proxy = new GraphBlockEditorControlProxy(graph);

      MainControlContainerProxy mainControlContainerProxy = proxy.MainControlContainer;
      GraphBlockEditorControlProxy GraphBlockEditorControlProxy = mainControlContainerProxy.GraphBlockEditorControl;
      List<DetailedSequenceViewProxy> seqList = mainControlContainerProxy.GetDetailedSequenceView();
      foreach (var seqProxy in seqList)
      {
        seqProxy.DisableGraphBlockInput();
      }
    }
  }
}
using System;
using System.Collections.Generic;

using Siemens.Automation.UI.Controls.WindowlessFramework;

using Siemens.Simatic.PlcLanguages.BlockEditorFrame.Editor.View;
using Siemens.Simatic.PlcLanguages.BlockEditorFrame.Editor.Logic;

using Siemens.Simatic.PlcLanguages.NetworkEditorFrame.Editor.View;
using Siemens.Simatic.PlcLanguages.NetworkEditorFrame.Editor.Logic;
using Siemens.Simatic.PlcLanguages.BlockEditorFrame.Taskcards.Instruction;

namespace YZX.Tia.Proxies.NetworkEditorFrame
{
  public class PLBlockEditorControlElementProxy
  {
    internal PLBlockEditorControlElement PLBlockEditorControlElement;
    public PLBlockEditorControlElementProxy(BlockEditorControlBase element)
    {
      PLBlockEditorControlElement = element as PLBlockEditorControlElement;
    }

    public BlockEditorLogicBase PLBlockEditorLogic
    {
      get
      {
        return PLBlockEditorControlElement.PLBlockEditorLogic;
      }
    }

    public PLBlockEditorLogicProxy PLBlockEditorLogicProxy
    {
      get
      {
        return new PLBlockEditorLogicProxy(PLBlockEditorLogic);
      }
    }

    public FavouritesControl FavouritsToolBar
    {
      get
      {
        return PLBlockEditorControlElement.FavouritsToolBar;
      }
    }

    public BlockHeaderPaletteElement BlockHeaderPalette
    {
      get
      {
        return PLBlockEditorControlElement.BlockHeaderPalette as BlockHeaderPaletteElement;
      }
    }

    public List<NetworkElementProxy> GetNetworks()
    {
      UIElementCollection networks = PLBlockEditorControlElement.NetworksContainer.GetNetworks();
      List<NetworkElementProxy> proxies = new List<NetworkElementProxy>();
      foreach(UIElement network in networks)
      {
        if(network is NetworkElement)
        {
          NetworkElement ne = network as NetworkElement;
          NetworkElementProxy proxy = new NetworkElementProxy(ne);
          proxies.Add(proxy);
        }
      }
      return proxies;
    }
  }
}

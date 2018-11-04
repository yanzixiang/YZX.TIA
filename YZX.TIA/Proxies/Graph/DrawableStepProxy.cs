
using Siemens.Automation.UI.Controls.WindowlessFramework;

using Siemens.Simatic.PlcLanguages.GraphEditor.View.DrawableElements;
using Siemens.Simatic.PlcLanguages.GraphEditor.ActionList.View;
using Siemens.Simatic.PlcLanguages.BlockEditorFrame.Editor.View;
using Siemens.Simatic.PlcLanguages.BlockEditorFrame;

namespace YZX.Tia.Proxies.Graph
{
  public class DrawableStepProxy:DrawableBoxElementProxy
  {
    internal DrawableStep step;

    internal DrawableStepProxy(DrawableStep step)
      :base(step)
    {
      this.step = step;
    }


    public ActionListControl GetActionListControl()
    {
      if(step.ElementList.Count > 0)
      {
        DrawableLangModTogglerDSV dsv = step.ElementList[2] as DrawableLangModTogglerDSV;
        if (dsv.ElementList.Count > 0)
        {
          UIElementWrapperForUIContainer container = dsv.ElementList[0] as UIElementWrapperForUIContainer;
          UIElementWrapperForPalettes palettes = container.ElementList[0] as UIElementWrapperForPalettes;
          UIElementWrapperForPalettesProxy palettesProxy = new UIElementWrapperForPalettesProxy(palettes);
          LanguagePaletteBaseElement palette = palettesProxy.Palette;
          UIControlWindowlessWrapper wrapper = palette.ChildControls[1] as UIControlWindowlessWrapper;
          ActionListControl alc = wrapper.ChildControls[0] as ActionListControl;
          return alc;
        }
      }
      return null;
    }
  }
}
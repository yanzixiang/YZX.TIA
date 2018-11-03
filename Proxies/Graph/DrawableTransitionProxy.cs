using Siemens.Simatic.PlcLanguages.BlockEditorFrame;
using Siemens.Simatic.PlcLanguages.BlockEditorFrame.Editor.View;
using Siemens.Simatic.PlcLanguages.FLGraphicEditor;
using Siemens.Simatic.PlcLanguages.GraphEditor.ActionList.View;
using Siemens.Simatic.PlcLanguages.GraphEditor.View.DrawableElements;

namespace YZX.Tia.Proxies.Graph
{
  public class DrawableTransitionProxy:DrawableBoxElementProxy
  {
    internal DrawableTransition Transition;

    internal DrawableTransitionProxy(DrawableTransition transition):
      base(transition)
    {
      this.Transition = transition;
    }

    public GraphFLGraphicEditor GetGraphFLGraphicEditor()
    {
      if (Transition.ElementList.Count > 0)
      {
        DrawableLangModTogglerDSV dsv = Transition.ElementList[2] as DrawableLangModTogglerDSV;
        if (dsv.ElementList.Count > 0)
        {
          UIElementWrapperForUIContainer container = dsv.ElementList[0] as UIElementWrapperForUIContainer;
          UIElementWrapperForPalettes palettes = container.ElementList[0] as UIElementWrapperForPalettes;
          UIElementWrapperForPalettesProxy palettesProxy = new UIElementWrapperForPalettesProxy(palettes);
          LanguagePaletteBaseElement palette = palettesProxy.Palette;
          UIControlWindowlessWrapper wrapper = palette.ChildControls[1] as UIControlWindowlessWrapper;
          GraphFLGraphicEditor editor = wrapper.ChildControls[0] as GraphFLGraphicEditor;
          return editor;
        }
      }
      return null;
    }
  }
}
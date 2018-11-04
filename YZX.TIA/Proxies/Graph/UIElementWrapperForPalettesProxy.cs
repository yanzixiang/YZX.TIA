using Siemens.Simatic.PlcLanguages.GraphEditor.View.DrawableElements;
using Siemens.Simatic.PlcLanguages.GraphEditor.View.UIElements;
using Siemens.Simatic.PlcLanguages.BlockEditorFrame.Editor.View;

using Reflection;

namespace YZX.Tia.Proxies.Graph
{
  public class UIElementWrapperForPalettesProxy:SelectableUIElementWrapperProxy
  {
    internal UIElementWrapperForPalettes palettes;

    internal UIElementWrapperForPalettesProxy(UIElementWrapperForPalettes palettes)
      :base(palettes)
    {
      this.palettes = palettes;
    }

    internal LanguagePaletteBaseElement Palette
    {
      get
      {
        return Reflector.GetInstancePropertyByName(palettes, "Palette", 
          ReflectionWays.SystemReflection) as LanguagePaletteBaseElement;
      }
    }
  }
}
using Siemens.Simatic.PlcLanguages.FLGraphicEditor.View;
using Siemens.Simatic.PlcLanguages.FLGraphicEditor.View.Accessibility;

using YZX.Tia.Proxies.Ladder;

namespace YZX.Tia.Extensions
{
  public static class FLGViewExtensions
  {
    public static GraphicManager GetGraphicManager(this FLGView flgView)
    {
      return flgView.GraphicManager;
    }

    public static FLGViewAccessibleObjectProxy GetCorrectAccessibilityObject(this FLGView flgView)
    {
      IFLGAccessibleObject IFLGAccessibleObject = flgView.GetCorrectAccessibilityObject();
      return new FLGViewAccessibleObjectProxy(IFLGAccessibleObject);
    }
  }
}

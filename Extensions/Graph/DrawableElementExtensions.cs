using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Siemens.Simatic.PlcLanguages.GraphEditor.View.DrawableElements;
using Siemens.Simatic.PlcLanguages.GraphEditor.View.DrawableElements.DrawableLanguageModules;

using YZX.Tia.Proxies;
using YZX.Tia.Proxies.Graph;

namespace YZX.Tia.Extensions.Graph
{
  public static class DrawableElementExtensions
  {
    internal static DrawableElementProxy ToProxy(this DrawableElement element)
    {
      if(element is DrawableStep)
      {
        DrawableStep step = element as DrawableStep;
        return new DrawableStepProxy(step);
      }

      if(element is DrawableLangModTogglerDSV)
      {
        DrawableLangModTogglerDSV dsv = element as DrawableLangModTogglerDSV;
        return new DrawableLangModTogglerDSVProxy(dsv);
      }

      if(element is ActionListDrawLangMod)
      {
        ActionListDrawLangMod mod = element as ActionListDrawLangMod;
        return new DrawableElementProxy(mod);
      }

      if(element is UIElementWrapperForUIContainer)
      {
        UIElementWrapperForUIContainer container = element as UIElementWrapperForUIContainer;
        return new UIElementWrapperForUIContainerProxy(container);
      }

      if(element is DrawableTransition)
      {
        DrawableTransition transition = element as DrawableTransition;
        return new DrawableTransitionProxy(transition);
      }

      return new DrawableElementProxy(element);
    }
  }
}

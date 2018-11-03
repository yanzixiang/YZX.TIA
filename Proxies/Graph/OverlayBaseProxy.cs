using System.Collections.Generic;

using Siemens.Simatic.PlcLanguages.GraphEditor.View.Overlays;
using Siemens.Simatic.PlcLanguages.GraphEditor.View.DrawableElements;

namespace YZX.Tia.Proxies.Graph
{
  public class OverlayBaseProxy
  {
    internal OverlayBase overlay;

    internal OverlayBaseProxy(OverlayBase overlay)
    {
      this.overlay = overlay;
    }

    
    public List<DrawableTransitionProxy> GetTransitions()
    {
      List<DrawableTransitionProxy> list = new List<DrawableTransitionProxy>();
      foreach (var element in overlay.ElementList)
      {
        if (element is DrawableTransition)
        {
          DrawableTransition step = element as DrawableTransition;
          DrawableTransitionProxy proxy = new DrawableTransitionProxy(step);
          list.Add(proxy);
        }
      }
      return list;
    }

    public List<DrawableStepProxy> GetSteps()
    {
      List<DrawableStepProxy> list = new List<DrawableStepProxy>();
      foreach(var element in overlay.ElementList)
      {
        if(element is DrawableStep)
        {
          DrawableStep step = element as DrawableStep;
          DrawableStepProxy proxy = new DrawableStepProxy(step);
          list.Add(proxy);
        }
      }
      return list;
    }
  }
}
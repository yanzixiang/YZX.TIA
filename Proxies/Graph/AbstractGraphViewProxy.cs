using System;

using Siemens.Automation.UI.Controls;
using Siemens.Simatic.PlcLanguages.GraphEditor;
using Siemens.Simatic.PlcLanguages.GraphEditor.View;
using Siemens.Simatic.PlcLanguages.GraphEditor.View.Overlays;

using Reflection;

namespace YZX.Tia.Proxies.Graph
{
  public class AbstractGraphViewProxy
  {
    internal AbstractGraphView currentView;

    public AbstractGraphViewProxy(UserControl currentView)
    {
      this.currentView = currentView as AbstractGraphView;

    }

    internal OverlayManagerBase OverlayManager
    {
      get
      {
        return currentView.OverlayManager;
      }
    }

    public GraphDrawSettingsProxy DrawSettingsProxy
    {
      get
      {
        var settings = Reflector.GetInstanceFieldByName(currentView, "m_DrawSettings",
          ReflectionWays.SystemReflection) as GraphDrawSettings;
        return new GraphDrawSettingsProxy(settings);
      }
    }
  }
}

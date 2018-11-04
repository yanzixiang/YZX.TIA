using System.Collections.Generic;

using Siemens.Automation.FrameApplication.ViewManager;

using Reflection;

namespace YZX.Tia.Proxies.FrameApplication
{
  public class ViewMetaReaderProxy
  {
    private static ViewMetaReaderProxy s_This;

    public static ViewMetaReaderProxy Singleton
    {
      get
      {

        if(s_This == null)
        {
          s_This = new ViewMetaReaderProxy(ViewMetaReader.Singleton);
        }

        return s_This;
      }
    }

    ViewMetaReader ViewMetaReader;
    internal ViewMetaReaderProxy(ViewMetaReader reader)
    {
      ViewMetaReader = reader;
    }

    public ViewServiceDataProxy this[string viewID]
    {
      get
      {
        ViewServiceData vd = ViewMetaReader[viewID];
        ViewServiceDataProxy proxy = new ViewServiceDataProxy(vd);
        return proxy;
      }
    }

    public Dictionary<string, ViewServiceDataProxy> ViewDictionary
    {
      get
      {
        Dictionary<string, ViewServiceData> vd = Reflector.GetInstanceFieldByName(ViewMetaReader,
          "m_ViewDictionary",
          ReflectionWays.SystemReflection) as Dictionary<string, ViewServiceData>;
        Dictionary<string, ViewServiceDataProxy> vdp = new Dictionary<string, ViewServiceDataProxy>();
        foreach(string key in vd.Keys)
        {
          ViewServiceData data = vd[key];
          ViewServiceDataProxy proxy = new ViewServiceDataProxy(data);
          vdp[key] = proxy;
        }
        return vdp;
      }
    }
  }
}

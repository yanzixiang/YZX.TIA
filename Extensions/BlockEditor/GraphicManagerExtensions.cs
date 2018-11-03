using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Siemens.Simatic.PlcLanguages.FLGraphicEditor.View;
using Siemens.Simatic.PlcLanguages.FLGraphicEditor.View.UserInteraction;
using Siemens.Simatic.PlcLanguages.FLGraphicEditor.View.Selection;

using YZX.Tia.Proxies.Ladder;

namespace YZX.Tia.Extensions.Ladder
{
  public static class GraphicManagerExtensions
  {
    public static void SetNullInteractor(this GraphicManager manager)
    {
      DefaultUserInteractor oldInteractor = manager.UserInteractor;
      NullUserInteractor newInteractor = new NullUserInteractor(oldInteractor);
      manager.SetUserInteractor(newInteractor);
    }

    public static void SetNullSelectionManager(this GraphicManager manager)
    {
      DefaultSelectionManager oldManager = manager.SelectionManager as DefaultSelectionManager;
      NullSelectionManager newManager = new NullSelectionManager(manager.FLGView,manager);
      manager.SetSelectionManager(newManager);
    }

    public static List<GraphicObjectProxy> ToGraphicObjectProxyList(this GraphicManager manager)
    {
      List<GraphicObjectProxy> list = new List<GraphicObjectProxy>();

      foreach(var go in manager)
      {
        GraphicObjectProxy proxy = new GraphicObjectProxy(go);
        list.Add(proxy);
      }

      return list;
    }
  }
}

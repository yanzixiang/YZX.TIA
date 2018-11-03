using Siemens.Automation.Basics;
using Siemens.Automation.ObjectFrame;
using Siemens.Automation.DomainServices.OnlineService;
using Siemens.Automation.FrameApplication;
using Siemens.Simatic.HwConfiguration.Basics.Basics;
using Siemens.Simatic.HwConfiguration.Diagnostic.Services.Common;

using YZX.Tia.Proxies.OnlineService;

namespace YZX.Tia.Extensions
{
  partial class ICoreObjectExtensions
  {
    public static object GetNodeDetails(this ICoreObject node)
    {
      return LifelistNodeDetailsFactory.GetNodeDetails(node);
    }

    public static ICoreObject GetOnlineDeviceNode(this ICoreObject lifelistNode)
    {
      var detail = lifelistNode.GetNodeDetails();
      LifelistNodeDetailsProxy detailsProxy = new LifelistNodeDetailsProxy(detail);
      var onlineDevice = detailsProxy.OnlineDeviceNode;
      return onlineDevice;
    }

    public static IWorkingContext GetUIWorkingContext(this ICoreObject lifelistNode)
    {
      OnlineObjectService OnlineObjectService = lifelistNode.GetOnlineObjectService();
      IConfigBase onlineProject = OnlineObjectService.CreateOnlineProject();
      var PersistenceWorkingContext = onlineProject.CoreObject.GetWorkingContext();

      var applicationWorkingContext = TiaStarter.m_ViewApplicationContext;
      UIContextCreator creator = new UIContextCreator(PersistenceWorkingContext, applicationWorkingContext);
      IWorkingContext context = creator.PersistenceUIContext;
      return context;
    }
  }
}

using System;

using Siemens.Automation.DomainServices;
using Siemens.Automation.DomainServices.ConnectionService.Private;
using Siemens.Automation.ObjectFrame;
using Siemens.Automation.OnlineAccess.OnlineInterface;

using YZX.Tia.Proxies.OnlineService;
using YZX.Tia.Proxies.OnlineInterface;

using YZX.Tia.Extensions.ObjectFrame;

namespace YZX.Tia.Extensions.OnlineService
{
  public partial class ILifelistServiceExtensions
  {
    public static int GetClientSession(
      this ILifelistService LifelistService,
      string address,
      string configName,
      string accessibleName,
      out ICoreObject AccessibleNode,
      ConnectionOpenedEventHandler connectionOpenedEventHandler = null
    )
    {

      ICoreObjectCollection boardConfigurations = ((IOnlineConfiguration)LifelistService.GetIConnectionService()).GetUsableConfigurations("OMS");
      ICoreObject boardConfiguration = LifelistService.GetBoardConfigurationByName(configName);


      ICoreObjectCollection accessibleNodes = LifelistService.GetAccessibleNodes(boardConfiguration, true);
      var names = accessibleNodes.GetNames();

      if (names.Contains(accessibleName))
      {

        AccessibleNode = accessibleNodes.GetCoreObjectByName(accessibleName);
        Type t = AccessibleNode.GetType();
        var onlineObject = LifelistService.GetOnlineNode(AccessibleNode);

        var connection = onlineObject.GetConnectionServiceProvider();
        var ConnectionServiceProviderProxy = new ConnectionServiceProviderProxy(connection);
        ConnectionServiceProviderProxy.ConnectionOpened += connectionOpenedEventHandler;

        IOamAddress oamAddress;
        int createResult = OamObjectCreatorProxy.CreateAddress(address, out oamAddress);

        TargetConnectionInfo TargetConnectionInfo =
          new TargetConnectionInfo(boardConfiguration, null, null, oamAddress);

        connection.SetTargetConnectionPath(onlineObject, TargetConnectionInfo);
        IConnection omsc = connection.ConnectToOnline(onlineObject, "OMS",
          OnlineConnectionModes.UseTargetConnectionInfo,
          TargetConnectionInfo);
        return 0;
      }
      AccessibleNode = null;
      return -1;
    }
  }
}

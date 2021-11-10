using System.Net;

using Siemens.Automation.DomainServices;
using Siemens.Automation.ObjectFrame;
using Siemens.Automation.ObjectFrame.BusinessLogic;
using Siemens.Automation.OnlineAccess.OnlineInterface;

using Siemens.Simatic.PlcLanguages.BlockLogic;
using Siemens.Simatic.HwConfiguration.Diagnostic.Common;

namespace YZX.Tia.Extensions.ObjectFrame
{
  partial class ICoreObjectExtensions
  {
    public static IBlock GetBlock(this ICoreObject coreObject)
    {
      IBlock block = IecplUtilities.GetBusinessLogicBlock(coreObject) as IBlock;
      return block;
    }
    public static ICodeBlock GetCodeBlock(this ICoreObject coreObject)
    {
      return (ICodeBlock)((IBusinessLogicConnector)coreObject).GetBusinessLogic("PlcLanguages.BlockLogic.BlockService");
    }

#if TIAV13
#else
    private static void SetIpAddress(this ICoreObject onlineCore,
      DiagServiceProvider DiagServiceProvider,
      int addressType, 
      byte[] ipAddress, 
      byte[] subnetMask, 
      byte[] router){
      IEthernetDiscoverNode ethernetDiscoverNode = DiagServiceProvider.PELifelistService.GetOamNode(onlineCore.GetParent().GetParent()) as IEthernetDiscoverNode;
      if (ethernetDiscoverNode == null)
        return;
      IPAddress ipAddress1 = new IPAddress(ethernetDiscoverNode.IpStationParams.LocalIpParam.InternetProtocolAddress.GetAddressBytes());
      IPAddress ipAddress2 = new IPAddress(ethernetDiscoverNode.IpStationParams.LocalIpParam.LocalIpv4SubnetMask.GetAddressBytes());
      IPAddress ipAddress3 = new IPAddress(ethernetDiscoverNode.IpStationParams.LocalIpParam.LocalDefaultRouter.GetAddressBytes());
      if (ethernetDiscoverNode.Configuration.ProtocolType != OamProtocolType.Ethernet && ethernetDiscoverNode.Configuration.ProtocolType != OamProtocolType.InternetProtocol && ethernetDiscoverNode.Configuration.ProtocolType != OamProtocolType.Auto)
        throw new OnlineException(4, 240);
      if (ipAddress == null)
        throw new OnlineException(7, 240);
      IPAddress ipAddress4 = new IPAddress(ipAddress);
      ethernetDiscoverNode.IpStationParams.LocalIpParam.InternetProtocolAddress = ipAddress4;
      if (subnetMask != null)
        ethernetDiscoverNode.IpStationParams.LocalIpParam.LocalIpv4SubnetMask = new IPAddress(subnetMask);
      if (router != null)
      {
        if (1 == addressType)
        {
          IPAddress ipAddress5 = new IPAddress(router);
          ethernetDiscoverNode.IpStationParams.LocalIpParam.LocalDefaultRouter = ipAddress5;
        }
        else
          ethernetDiscoverNode.IpStationParams.LocalIpParam.LocalDefaultRouter = ipAddress4;
      }
      ethernetDiscoverNode.IpStationParams.LocalIpParam.IpActive = 1;
      ethernetDiscoverNode.IpStationParams.PermanentStorage = true;
      int errorCode = ethernetDiscoverNode.IpStationParams.Write();
      if (errorCode != 0)
      {
        int serviceId = DiagServiceProvider.OnlineSessionDlc.OnlineAccess.ErrorHandler.ServiceId;
        ethernetDiscoverNode.IpStationParams.LocalIpParam.InternetProtocolAddress = ipAddress1;
        ethernetDiscoverNode.IpStationParams.LocalIpParam.LocalIpv4SubnetMask = ipAddress2;
        ethernetDiscoverNode.IpStationParams.LocalIpParam.LocalDefaultRouter = ipAddress3;
        ethernetDiscoverNode.IpStationParams.Write();
        throw new OnlineException(errorCode, serviceId, string.Empty);
      }
    }
#endif
    
  }
}

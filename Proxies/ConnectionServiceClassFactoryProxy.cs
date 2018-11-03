using Siemens.Automation.DomainServices.ConnectionService;

namespace YZX.Tia.Proxies
{
  public class ConnectionServiceClassFactoryProxy
  {
    ConnectionServiceClassFactory ConnectionServiceClassFactory;
    internal ConnectionServiceClassFactoryProxy(IConnectionServiceClassFactory factory)
    {
      ConnectionServiceClassFactory = factory as ConnectionServiceClassFactory;
    }
  }
}

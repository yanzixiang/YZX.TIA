using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Siemens.Automation.OnlineAccess.OnlineInterface;
using Siemens.Automation.DomainServices.UI.OnlineCommon;
using Siemens.Automation.DomainServices.UI.OnlineCommon.DataBinding;

using Reflection;

using YZX.Tia.Converter;

namespace YZX.Tia.Proxies.OnlineService
{
  public class OnlineCommonLifeListFacadeProxy
  {
    internal OnlineCommonLifeListFacade OnlineCommonLifeListFacade;

    internal OnlineCommonLifeListFacadeProxy(OnlineCommonLifeListFacade facade)
    {
      OnlineCommonLifeListFacade = facade;
    }

    public List<OnlineCommonNodeProxy> UserAddressesLifelistNodes
    {
      get
      {
        var nodes = Reflector.GetInstancePropertyByName(OnlineCommonLifeListFacade,
          "UserAddressesLifelistNodes", ReflectionWays.SystemReflection)
          as List<OnlineCommonNode>;

        return nodes.ConvertAll(new Converter<OnlineCommonNode, OnlineCommonNodeProxy>(
          OnlineServiceConverters.OnlineCommonNodeProxy));
      }
    }

    public OnlineCommonHelperProxy Helper
    {
      get
      {
        return new OnlineCommonHelperProxy(OnlineCommonLifeListFacade.Helper);
      }
    }

    public OamProtocolType ProtocolType
    {
      get
      {
        return OnlineCommonLifeListFacade.ProtocolType;
      }
    }

    public OnlineCommonNodeProxy SelectedNode
    {
      get
      {
        var node = Reflector.GetInstancePropertyByName(OnlineCommonLifeListFacade,
          "SelectedNode", ReflectionWays.SystemReflection)
          as OnlineCommonNode;
        return new OnlineCommonNodeProxy(node);
      }
      set
      {
        Reflector.SetInstancePropertyByName(OnlineCommonLifeListFacade,
          "SelectedNode", value.OnlineCommonNode,
          ReflectionWays.SystemReflection);
      }
    }

    public SortedList<string, string> PresentMacToIPAddresses
    {
      get
      {
        return OnlineCommonLifeListFacade.PresentMacToIPAddresses;
      }
    }
  }
}

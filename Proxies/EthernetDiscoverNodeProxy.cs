using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Siemens.Automation.OnlineAccess;
using Siemens.Automation.OnlineAccess.OnlineInterface;

namespace YZX.Tia.Proxies
{
  public class EthernetDiscoverNodeProxy:OamNodeProxy
  {
    EthernetDiscoverNode EthernetDiscoverNode;

    public EthernetDiscoverNodeProxy(INode node) : base(node)
    {
      EthernetDiscoverNode = node as EthernetDiscoverNode;
    }

  }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Siemens.Automation.OnlineAccess;
using Siemens.Automation.OnlineAccess.OnlineInterface;

namespace YZX.Tia.Proxies
{
  public class OamNodeProxy:OamNodeBaseProxy
  {
    OamNode OamNode;

    public OamNodeProxy(INode node):base(node)
    {
      OamNode = node as OamNode;
    }

    internal List<OamSharedConnectionServer> SharedServers { get; }

    public List<INode> Parent
    {
      get
      {
        OamNodeCollection nodes = OamNode.Parent as OamNodeCollection;
        List<INode> nodeList = new List<INode>(nodes.Count);
        
        foreach(OamNode node in nodes)
        {
          nodeList.Add(node);
        }

        return nodeList;
      }
    }
  }
}

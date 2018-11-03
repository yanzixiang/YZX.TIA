using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Siemens.Simatic.PlcLanguages.GraphEditor.Model;
using Siemens.Simatic.PlcLanguages.GraphEditor.Model.GraphElements;

using Reflection;

namespace YZX.Tia.Proxies.Graph
{
  public class GraphModelProxy
  {
    internal GraphModel model;

    public GraphModelProxy(Component model)
    {
      this.model = model as GraphModel;
    }

    public DebugManagerProxy DebugManagerProxy
    {
      get
      {
        return new DebugManagerProxy(model.DebugManager);
      }
    }

    public bool ReadOnly
    {
      get
      {
        return model.ReadOnly;
      }
      set
      {
        Reflector.SetInstancePropertyByName(model, "ReadOnly", value, 
          ReflectionWays.SystemReflection);
      }
    }

    public int GetMaximumActiveStepCount()
    {
      return model.GetMaximumActiveStepCount();
    }

    public List<SequenceProxy> SequenceProxies
    {
      get
      {
        List<SequenceProxy> list = new List<SequenceProxy>();
        foreach (Sequence seq in model.Sequences)
        {
          SequenceProxy proxy = new SequenceProxy(seq);
          list.Add(proxy);
        }
        return list;
      }
    }


  }
}

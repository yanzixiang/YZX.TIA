using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Siemens.Simatic.PlcLanguages.GraphBlockLogic;

namespace YZX.Tia.Proxies.GraphBlockLogic
{
  public class GraphActionProxy
  {
    internal GraphAction GraphActions;

    internal GraphActionProxy(GraphAction actions)
    {
      GraphActions = actions;
    }

    public bool IsOnAction
    {
      get
      {
        return GraphActions.IsOnAction;
      }
    }

    public bool IsOffAction
    {
      get
      {
        return GraphActions.IsOffAction;
      }
    }

    public bool IsOffAllAction
    {
      get
      {
        return GraphActions.IsOffAllAction;
      }
    }

    public bool IsEmptyAction
    {
      get
      {
        return GraphActions.IsEmptyAction;
      }
    }

    public int Id
    {
      get
      {
        return GraphActions.Id;
      }
      set
      {
        GraphActions.Id = value;
      }
    }
  }
}

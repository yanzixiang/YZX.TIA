using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Siemens.Simatic.PlcLanguages.GraphBlockLogic;

using YZX.Tia.Converter;

namespace YZX.Tia.Proxies.GraphBlockLogic
{
  public class GraphStepProxy
  {
    internal GraphStep GraphStep;

    internal GraphStepProxy(GraphStep step)
    {
      GraphStep = step;
    }

    public GraphActionsProxy StepActions
    {
      get
      {
        return new GraphActionsProxy(GraphStep.StepActions);
      }
    }

    public int Id
    {
      get
      {
        return GraphStep.Id;
      }
      set
      {
        GraphStep.Id = value;
      }
    }

    public int Number
    {
      get
      {
        return GraphStep.Number;
      }
      set
      {
        GraphStep.Number = value;
      }
    }

    public string Name
    {
      get
      {
        return GraphStep.Name;
      }
      set
      {
        GraphStep.Name = value;
      }
    }

    public GraphSequenceProxy Parent
    {
      get
      {
        return new GraphSequenceProxy(GraphStep.Parent) ;
      }
    }


    public List<GraphActionProxy> OnActions
    {
      get
      {
        return GraphStep.OnActions.ConvertAll(new Converter<GraphAction, GraphActionProxy>(
          GraphBlockLogicConverters.GraphActionProxy));
      }
    }

    public List<GraphActionProxy> OffActions
    {
      get
      {
        return GraphStep.OffActions.ConvertAll(new Converter<GraphAction, GraphActionProxy>(
          GraphBlockLogicConverters.GraphActionProxy));
      }
    }

    public List<GraphActionProxy> OffAllActions
    {
      get
      {
        return GraphStep.OffAllActions.ConvertAll(new Converter<GraphAction, GraphActionProxy>(
          GraphBlockLogicConverters.GraphActionProxy));
      }
    }

    public GraphConnectionProxy InConnection
    {
      get
      {
        return new GraphConnectionProxy(GraphStep.InConnection);
      }
      set
      {
        GraphStep.InConnection = value.GraphConnection;
      }
    }

    public GraphConnectionProxy OutConnection
    {
      get
      {
        return new GraphConnectionProxy(GraphStep.OutConnection);
      }
      set
      {
        GraphStep.OutConnection = value.GraphConnection;
      }
    }


  }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Siemens.Simatic.PlcLanguages.GraphBlockLogic;

using YZX.Tia.Converter;

namespace YZX.Tia.Proxies.GraphBlockLogic
{
  public class GraphModelProxy
  {
    internal GraphModel GraphModel;

    internal GraphModelProxy(GraphModel model)
    {
      GraphModel = model;
    }

    public List<GraphActionsProxy> Actions
    {
      get
      {
        return GraphModel.Actions.ConvertAll(new Converter<GraphActions, GraphActionsProxy>(
          GraphBlockLogicConverters.GraphActionsProxy));
      }
    }

    public List<GraphStepProxy> InitialSteps
    {
      get
      {
        return GraphModel.InitialSteps.ConvertAll(new Converter<GraphStep, GraphStepProxy>(
         GraphBlockLogicConverters.GraphStepProxy));
      }
    }

    public List<GraphSequenceProxy> Sequences
    {
      get
      {
        return GraphModel.Sequences.ConvertAll(new Converter<GraphSequence, GraphSequenceProxy>(
         GraphBlockLogicConverters.GraphSequenceProxy));
      }
    }

    public List<GraphActionProxy> OnActions
    {
      get
      {
        return GraphModel.OnActions.ConvertAll(new Converter<GraphAction, GraphActionProxy>(
          GraphBlockLogicConverters.GraphActionProxy));
      }
    }

    public List<GraphActionProxy> OffActions
    {
      get
      {
        return GraphModel.OffActions.ConvertAll(new Converter<GraphAction, GraphActionProxy>(
          GraphBlockLogicConverters.GraphActionProxy));
      }
    }

    #region Step
    public GraphStepProxy FindStepByNumber(int number)
    {
      GraphStep step = GraphModel.FindStepByNumber(number);
      GraphStepProxy proxy = new GraphStepProxy(step);
      return proxy;
    }

    public GraphStepProxy FindStepByName(string name)
    {
      GraphStep step = GraphModel.FindStepByName(name);
      GraphStepProxy proxy = new GraphStepProxy(step);
      return proxy;
    }

    public GraphStepProxy GetStep(int id)
    {
      GraphStep step = GraphModel.GetStep(id);
      GraphStepProxy proxy = new GraphStepProxy(step);
      return proxy;
    }
    #endregion Step

    #region Transition
    public GraphTransitionProxy FindTransitionByNumber(int number)
    {
      GraphTransition transition = GraphModel.FindTransitionByNumber(number);
      GraphTransitionProxy proxy = new GraphTransitionProxy(transition);
      return proxy;
    }

    internal GraphTransitionProxy FindTransitionByName(string name)
    {
      GraphTransition transition = GraphModel.FindTransitionByName(name);
      GraphTransitionProxy proxy = new GraphTransitionProxy(transition);
      return proxy;
    }

    public GraphTransitionProxy GetTransition(int id)
    {
      GraphTransition transition = GraphModel.GetTransition(id);
      GraphTransitionProxy proxy = new GraphTransitionProxy(transition);
      return proxy;
    }
    #endregion Transition




  }
}

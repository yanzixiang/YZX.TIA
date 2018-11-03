using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Siemens.Simatic.PlcLanguages.GraphBlockLogic;

using YZX.Tia.Converter;

namespace YZX.Tia.Proxies.GraphBlockLogic
{
  public class GraphSequenceProxy
  {
    GraphSequence GraphSequence;

    internal GraphSequenceProxy(GraphSequence sequence)
    {
      GraphSequence = sequence;
    }

    public string Title
    {
      get
      {
        return GraphSequence.Title;
      }
      set
      {
        GraphSequence.Title = value;
      }
    }

    public string Comment
    {
      get
      {
        return GraphSequence.Comment;
      }
      set
      {
        GraphSequence.Comment = value;
      }
    }


    public List<GraphTransitionProxy> Transitions
    {
      get
      {
        return GraphSequence.Transitions.ConvertAll(new Converter<GraphTransition, GraphTransitionProxy>(
  GraphBlockLogicConverters.GraphTransitionProxy));
      }
    }

    public List<GraphStepProxy> Steps
    {
      get
      {
        return GraphSequence.Steps.ConvertAll(new Converter<GraphStep, GraphStepProxy>(
  GraphBlockLogicConverters.GraphStepProxy));
      }
    }

    public List<GraphBranchProxy> Branches
    {
      get
      {
        return GraphSequence.Branches.ConvertAll(new Converter<GraphBranch, GraphBranchProxy>(
  GraphBlockLogicConverters.GraphBranchProxy));
      }
    }

    public List<GraphActionProxy> OnActions
    {
      get
      {
        return GraphSequence.OnActions.ConvertAll(new Converter<GraphAction, GraphActionProxy>(
          GraphBlockLogicConverters.GraphActionProxy));
      }
    }

    public List<GraphActionProxy> OffActions
    {
      get
      {
        return GraphSequence.OffActions.ConvertAll(new Converter<GraphAction, GraphActionProxy>(
          GraphBlockLogicConverters.GraphActionProxy));
      }
    }

    public List<GraphActionProxy> OffAllActions
    {
      get
      {
        return GraphSequence.OffAllActions.ConvertAll(new Converter<GraphAction, GraphActionProxy>(
          GraphBlockLogicConverters.GraphActionProxy));
      }
    }

    public List<GraphSequencePartProxy> SequenceParts
    {
      get
      {
        return GraphSequence.SequenceParts.ConvertAll(new Converter<GraphSequencePart, GraphSequencePartProxy>(
          GraphBlockLogicConverters.GraphSequencePartProxy));
      }
    }


    public List<GraphSequencePartProxy> RelevantSequenceParts
    {
      get
      {
        return GraphSequence.RelevantSequenceParts.ConvertAll(new Converter<GraphSequencePart, GraphSequencePartProxy>(
          GraphBlockLogicConverters.GraphSequencePartProxy));   
      }
    }

    public List<GraphConnectionProxy> Connections
    {
      get
      {
        return GraphSequence.Connections.ConvertAll(new Converter<GraphConnection, GraphConnectionProxy>(
          GraphBlockLogicConverters.GraphConnectionProxy));
      }
    }

    public GraphStepProxy FindStepByNumber(int number)
    {
      GraphStep step = GraphSequence.FindStepByNumber(number);
      return new GraphStepProxy(step);
    }

    public GraphTransitionProxy FindTransitionByNumber(int number)
    {
      GraphTransition transition = GraphSequence.FindTransitionByNumber(number);
      return new GraphTransitionProxy(transition);
    }

    public GraphBranchProxy FindBranchByNumber(int number)
    {
      GraphBranch branch = GraphSequence.FindBranchByNumber(number);
      return new GraphBranchProxy(branch);
    }




  }
}

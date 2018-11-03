using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Siemens.Simatic.PlcLanguages.GraphBlockLogic;

using YZX.Tia.Proxies;
using YZX.Tia.Proxies.GraphBlockLogic;

namespace YZX.Tia.Converter
{
  public static class GraphBlockLogicConverters
  {
    internal static GraphActionProxy GraphActionProxy(GraphAction action)
    {
      return new GraphActionProxy(action);
    }
    internal static GraphActionsProxy GraphActionsProxy(GraphActions actions)
    {
      return new GraphActionsProxy(actions);
    }

    internal static GraphSequenceProxy GraphSequenceProxy(GraphSequence sequence)
    {
      return new GraphSequenceProxy(sequence);
    }

    internal static GraphStepProxy GraphStepProxy(GraphStep step)
    {
      return new GraphStepProxy(step);
    }

    internal static GraphJumpProxy GraphJumpProxy(GraphJump jump)
    {
      return new GraphJumpProxy(jump);
    }

    internal static GraphTransitionProxy GraphTransitionProxy(GraphTransition transition)
    {
      return new GraphTransitionProxy(transition);
    }

    internal static GraphBranchProxy GraphBranchProxy(GraphBranch branch)
    {
      return new GraphBranchProxy(branch);
    }

    internal static GraphSequencePartProxy GraphSequencePartProxy(GraphSequencePart part)
    {
      return new GraphSequencePartProxy(part);
    }

    internal static GraphConnectionProxy GraphConnectionProxy(GraphConnection connection)
    {
      return new GraphConnectionProxy(connection);
    }
  }
}

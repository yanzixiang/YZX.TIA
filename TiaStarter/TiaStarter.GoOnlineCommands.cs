using System.Collections;
using System.Collections.Generic;

using Siemens.Automation.DomainServices.UI.GoOnline;
using Siemens.Automation.Basics;
using Siemens.Automation.CommonServices;

namespace YZX.Tia
{
  partial class TiaStarter
  {
    GoOnlineCommands m_GoOnlineCommands = null;
    public GoOnlineCommands GoOnlineCommands
    {
      get
      {
        if(m_GoOnlineCommands == null)
        {
          m_GoOnlineCommands = new GoOnlineCommands();
          IDlc dlc_GoOnlineCommands = m_GoOnlineCommands as IDlc;
          dlc_GoOnlineCommands.Attach(m_BusinessLogicApplicationContext);
        }
        return m_GoOnlineCommands;
      }
    }

    public CommandResult GoOnlineCommands_Excute(ICommand command)
    {
      ICommandTarget ict = GoOnlineCommands as ICommandTarget;
      return ict.Execute(command);
    }
  }
}

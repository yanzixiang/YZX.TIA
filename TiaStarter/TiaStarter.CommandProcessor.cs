using Siemens.Automation.Basics;
using Siemens.Automation.CommonServices;
using Siemens.Automation.ObjectFrame;
using Siemens.Automation.DomainServices.UI.GoOnline;

namespace YZX.Tia
{
  partial class TiaStarter
  {
    public ICommandProcessor CommandProcessor
    {
      get
      {
        return m_BusinessLogicApplicationContext.DlcManager.Load("Siemens.Automation.CommonServices.CommandProcessor") as ICommandProcessor;
      }
    }

    public ICommand CreateCommand(string id)
    {
      ICommand command = CommandProcessor.CreateCommand(id);
      //command.WorkingContext = m_BusinessLogicApplicationContext;
      command.WorkingContext = projectViewWorkingContext;
      return command;
    }

    #region ExtendedGoOnline
    public CommandResult ExtendedGoOnline(ICoreObject cpu)
    {
      GoOnlineCommands GoOnlineCommands = new GoOnlineCommands();
      IDlc dlc_GoOnlineCommands = GoOnlineCommands as IDlc;
      dlc_GoOnlineCommands.Attach(PersistenceWorkingContext);
      ICommandTarget ict_GoOnlineCommands = GoOnlineCommands as ICommandTarget;
      ICommand command = CommandProcessor.CreateCommand("Application.ExtendedGoOnline", new object[1]
      {
        cpu
      }, new NameObjectCollection());

      command.WorkingContext = projectWorkingContext;

      return ict_GoOnlineCommands.Execute(command);
    }

    #endregion
  }
}

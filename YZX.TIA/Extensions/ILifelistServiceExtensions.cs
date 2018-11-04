using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Siemens.Automation.DomainServices;
using Siemens.Automation.ObjectFrame;
using Siemens.Automation.DomainServices.OnlineService;
using Siemens.Automation.OnlineAccess.OnlineInterface;
using Siemens.Automation.DomainServices.ConnectionService;
using Siemens.Automation.DomainModel;

namespace YZX.Tia.Extensions
{
  public static class ILifelistServiceExtensions
  {
    public static ICoreObject GetLocalInterfaceCardByBoardConfiguration(this ILifelistService lifelist,
      IOamConfiguration physicalConfiguration)
    {
      ICoreObjectCollection localInterfaceCards = lifelist.GetLocalInterfaceCards(true);
      ICoreObject coreBoard = LifelistNavigator.FindCoreBoard(localInterfaceCards, physicalConfiguration.Board);
      return coreBoard;
    }

    public static IConnectionService GetIConnectionService(this ILifelistService lifelist)
    {
      LifelistServiceProvider lsp = lifelist as LifelistServiceProvider;
      if (lsp != null)
      {
        return lsp.ConnectionService;
      }
      else
      {
        return null;
      }
    }
    
    public static ConnectionServiceProvider GetOnlineServiceProvider(this ILifelistService lifelist)
    {
      IConnectionService connectionService = lifelist.GetIConnectionService();
      ConnectionServiceProvider csp = connectionService.ToConnectionServiceProvider();
      return csp;
    }

    public static ICoreObject GetInterfaceCardByName(this ILifelistService lifelist,
      string InterfaceCardName,
      bool forceScan=true)
    {
      ICoreObjectCollection interfaces = lifelist.GetLocalInterfaceCards(forceScan);
      foreach(ICoreObject card in interfaces){
        string name = card.GetObjectName();
        if (name == InterfaceCardName)
        {
          return card;
        }
      }
      return null;
    }

    public static ICoreObject GetBoardConfigurationByName(this ILifelistService lifelist,
      string ConfigurationName,
      bool forceScan = true)
    {
      ICoreObjectCollection boards = lifelist.GetLocalInterfaceCards(forceScan);
      foreach (ICoreObject localBoard in boards)
      {
        ICoreObjectCollection configurations = lifelist.GetAllBoardConfigurations(localBoard);
        foreach (ICoreObject config in configurations)
        {
          IOamIdentification attributes = CoreObjectExtension.GetAttributes<IOamIdentification>(config);
          if (attributes != null && attributes.OamName == ConfigurationName)
          {
            return config;
          }
        }
      }
      return null;
    }

    public static ICoreObject GetBoardConfigurationByName(this ILifelistService lifelist,
      ICoreObject localBoard, 
      string ConfigurationName)
    {
      ICoreObjectCollection configurations = lifelist.GetAllBoardConfigurations(localBoard);
      foreach(ICoreObject config in configurations)
      {
        IOamIdentification attributes = CoreObjectExtension.GetAttributes<IOamIdentification>(config);
        if (attributes != null && attributes.OamName == ConfigurationName)
        {
          return config;
        }
      }
      return null;
    }

  }
}

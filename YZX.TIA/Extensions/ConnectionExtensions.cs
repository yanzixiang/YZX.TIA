using System;
using System.Collections.Generic;

using Siemens.Automation.OnlineAccess;
using Siemens.Automation.OnlineAccess.OnlineInterface;
using Siemens.Automation.ObjectFrame;
using Siemens.Automation.DomainServices.ConnectionService.Private;
using Siemens.Automation.DomainServices;

namespace YZX.Tia.Extensions
{
  public static class ConnectionExtensions
  {
    public static IOamConfiguration GetConfigurationByName(
      string  configName
    )
    {
      IOnlineSession onlineSession = OnlineSession.GetOnlineSession();

      List<IOamLocalBoard> Boards = onlineSession.Boards;
      foreach(var board in Boards)
      {
        OamConfigurationScanner OCS = new OamConfigurationScanner();
        OCS.Board = board;
        IEnumerable<IOamConfiguration> configs = OCS.Scan();
        List<IOamConfiguration> configList = new List<IOamConfiguration>(configs);
        foreach (var config in configList)
        {
          if (config.Name == configName)
          {
            return config;
          }
        }
      }
      return null;
    }
    public static IOamConfiguration GetConfigurationByIndex(
      string boardName,
      int boardNumber,
      int configIndex
      )
    {
      IOnlineSession onlineSession = OnlineSession.GetOnlineSession();
      List<IOamLocalBoard> boards = onlineSession.Boards;

      IOamLocalBoard board = onlineSession.GetBoard(boardName, boardNumber);
      OamConfigurationScanner OCS = new OamConfigurationScanner();
      OCS.Board = board;
      IEnumerable<IOamConfiguration> configs = OCS.Scan();
      List<IOamConfiguration> configList = new List<IOamConfiguration>(configs);
      IOamConfiguration config = configList[configIndex];
      return config;
    }

    public static INode CreateNode(IOamConfiguration ioc,string addressString)
    {
      OamConfigurationBase ocb = ioc as OamConfigurationBase;
      IOamAddress address;
      int createResult = OamObjectCreator.CreateAddress(addressString,out address);
      INode node = ocb.CreateNode(address);
      return node;
    }

    public static Tuple<IConnection, IConnection> CreateConnectionFromAddress(
      IOamConfiguration config,
      OamConnectionType connectionType,
      string addressString
      )
    {
      IOamAddress address;
      int createResult = OamObjectCreator.CreateAddress(addressString, out address);
      OamNodeBase node = OamObjectCreator.CreateNode(config, address);

      IConnection connectionMaster = OamObjectCreator.CreateConnection(
        connectionType,
        node,
        true,
        OamConnection.OamConnectionRole.SharedMaster);

      IConnection connectionProxy = OamObjectCreator.CreateConnection(
        connectionType,
        node,
        true,
        OamConnection.OamConnectionRole.SharedProxy);

      Tuple<IConnection, IConnection> result =
        new Tuple<IConnection, IConnection>(connectionMaster, connectionProxy);
      return result;
    }

    public static Tuple<IConnection,IConnection> CreateConnectionFromAddress(
      string boardName,
      int boardNumber,
      int configIndex,
      OamConnectionType connectionType,
      string addressString
      )
    {
      IOamConfiguration config = GetConfigurationByIndex(boardName, boardNumber, configIndex);
      IOamAddress address;
      int createResult = OamObjectCreator.CreateAddress(addressString,out address);
      OamNodeBase node = OamObjectCreator.CreateNode(config, address);

      IConnection connectionMaster = OamObjectCreator.CreateConnection(
        connectionType,
        node,
        true,
        OamConnection.OamConnectionRole.SharedMaster);

      IConnection connectionProxy = OamObjectCreator.CreateConnection(
        connectionType,
        node,
        true,
        OamConnection.OamConnectionRole.SharedProxy);

      Tuple<IConnection, IConnection> result = 
        new Tuple<IConnection, IConnection>(connectionMaster,connectionProxy);
      return result;
    }
  }
}

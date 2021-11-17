using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Siemens.Automation.OnlineAccess;
using Siemens.Automation.OnlineAccess.OnlineInterface;
using Siemens.Automation.OMSPlus.Managed;
using Siemens.Simatic.Hmi.Utah.Common.Base.Reflection;


using YZX.Tia.Proxies;
using YZX.Tia.Extensions.OnlineInterface;

namespace YZX.Tia.Extensions.OnlineService
{
  public static class OnlineSessionExtensions
  {

    /// <summary>
    /// 切换仿真状态
    /// from OamPlcSimCtl
    /// </summary>
    /// <param name="simulated"></param>
    public static void SwitchBoardsToSimulationState(this OnlineSession session,bool simulated)
    {
      List<IOamLocalBoard> boards = session.Boards;
      foreach (IOamLocalBoard oamLocalBoard1 in boards)
      {
        OamLocalBoardBase oamLocalBoardBase = oamLocalBoard1 as OamLocalBoardBase;
        if (oamLocalBoardBase != null)
        {
          OamLocalBoard oamLocalBoard2 = oamLocalBoard1 as OamLocalBoard;
          if (oamLocalBoard2 != null)
          {
            bool isPlcSimulation = oamLocalBoard2.IsPlcSimulation();
            oamLocalBoardBase.ChangeSimulated(simulated, isPlcSimulation);
          }
          else
          {
            oamLocalBoardBase.ChangeSimulated(simulated, false);
          }
        }
      }
    }

    public static ClientSessions GetClientSessions(this OnlineSession session)
    {
      return session.SessionContainer;
    }

    public static OamPlcSimCtlProxy GetPlcSimController(this OnlineSession session)
    {
      OamPlcSimCtl simCtl = session.PlcSimController as OamPlcSimCtl;
      return new OamPlcSimCtlProxy(simCtl);
    }

    public static List<OamLocalBoardBaseProxy> GetBoardProxies(this OnlineSession session)
    {
      IList<IOamLocalBoard> boards = session.Boards;
      List<OamLocalBoardBaseProxy> boardproxies = new List<OamLocalBoardBaseProxy>();

      foreach (IOamLocalBoard board in boards)
      {
        if (board.IsOamComBoard())
        {
          OamComBoardProxy proxy = new OamComBoardProxy(board);
          boardproxies.Add(proxy);
        }
        if (board.IsOamCustomBoard())
        {

        }
        if (board.IsOamLocalBoard())
        {
          OamLocalBoardProxy proxy = new OamLocalBoardProxy(board);
          boardproxies.Add(proxy);
        }
      }

      return boardproxies;
    }

    public static OamDeviceWatcherProxy GetOamDeviceWatcherProxy(this OnlineSession session)
    {
      OamDeviceWatcher watcher = Reflector.GetInstanceFieldByName(session,
        "OamDeviceWatcher",
        ReflectionWays.SystemReflection)
        as OamDeviceWatcher;
      OamDeviceWatcherProxy proxy = new OamDeviceWatcherProxy(watcher);
      return proxy;
    }

    public static OamEthernetConnectionsWatcherProxy GetOamEthernetConnectionsWatcherProxy(this OnlineSession session)
    {
      OamEthernetConnectionsWatcher watcher = Reflector.GetInstanceFieldByName(session,
        "m_Ethwatch",
        ReflectionWays.SystemReflection)
        as OamEthernetConnectionsWatcher;
      OamEthernetConnectionsWatcherProxy proxy = new OamEthernetConnectionsWatcherProxy(watcher);
      return proxy;
    }
  }
}

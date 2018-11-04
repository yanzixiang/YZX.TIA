using JetBrains.Annotations;

using Siemens.Automation.OnlineAccess;
using Siemens.Automation.OnlineAccess.OnlineInterface;
using Siemens.Automation.OnlineAccess.S7SDDnet;
using Siemens.Automation.OnlineAccess.S7DosWrapper;

using Reflection;

namespace YZX.Tia.Proxies
{
  public class OamPlcSimCtlProxy
  {
    OamPlcSimCtl SimCtl;
    public OamPlcSimCtlProxy([NotNull] IOamPlcSimCtl simCtl)
    {
      SimCtl = simCtl as OamPlcSimCtl;
    }

    public S7Simulation S7Simulation
    {
      get
      {
        return Reflector.GetInstanceFieldByName(SimCtl, 
          "m_PlcsimCtl", 
          ReflectionWays.SystemReflection)
          as S7Simulation;
      }
    }

    public S7DWSimulation S7DWSimulation
    {
      get
      {
        return Reflector.GetInstanceFieldByName(S7Simulation, 
          "m_S7DWSimulation",
          ReflectionWays.SystemReflection)
          as S7DWSimulation;
      }
    }

    public int RequestId
    {
      get
      {
        return (int)Reflector.GetInstanceFieldByName(SimCtl, 
          "m_RequestId",
          ReflectionWays.SystemReflection);
      }
    }

    public static int GetNextReferenceCount()
    {
      return (int)Reflector.RunStaticMethodByName(typeof(OamPlcSimCtl),
        "GetNextReferenceCount", 
        ReflectionWays.SystemReflection);
    }

    public int ReferenceCount
    {
      get
      {
        return (int)Reflector.GetInstanceFieldByName(SimCtl, 
          "s_referenceCount",
          ReflectionWays.SystemReflection);
      }
    }


    public bool PlcRedirection
    {
      get
      {
        return SimCtl.PlcRedirection;
      }
    }

    public event OamChangeDelegate<object, IOamClientInfoEventArgs> PlcRedirectionChanged
    {
      add {
        SimCtl.PlcRedirectionChanged += value;
      }
      remove {
        SimCtl.PlcRedirectionChanged -= value;
      }
    }

    public int StartSimulationRedirection()
    {
      return SimCtl.StartSimulationRedirection();
    }

    public int StopSimulationRedirection()
    {
      return SimCtl.StopSimulationRedirection();
    }

    public void Dispose()
    {
      SimCtl.Dispose();
    }
  }
}

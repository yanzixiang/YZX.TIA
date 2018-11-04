using Siemens.Simatic.HwConfiguration.Diagnostic.Viewer;

using Reflection;

namespace YZX.Tia.Extensions
{
  public static class CycleTimeDialogExtensions
  {

    public static void InitializeUI(this CycleTimeDialog CycleTimeDialog)
    {
      Reflector.RunInstanceMethodByName(CycleTimeDialog,
        "InitializeUI", ReflectionWays.SystemReflection);
    }

    public static void SetEnabledState(this CycleTimeDialog CycleTimeDialog,
      bool enabled=true)
    {
      Reflector.RunInstanceMethodByName(CycleTimeDialog,
        "SetEnabledState", ReflectionWays.SystemReflection,enabled);
    }

    public static void DisplayCycleTime(this CycleTimeDialog CycleTimeDialog)
    {
      Reflector.RunInstanceMethodByName(CycleTimeDialog,
        "DisplayCycleTime", ReflectionWays.SystemReflection);
    }


    public static void SetCycleTimeProj(this CycleTimeDialog CycleTimeDialog,
      int Proj)
    {
      Reflector.SetInstanceFieldByName(CycleTimeDialog,
        "m_CycleTimeProj", ReflectionWays.SystemReflection);
    }

    public static void SetCycleTimeProjMin(this CycleTimeDialog CycleTimeDialog,
      float ProjMin)
    {
      Reflector.SetInstanceFieldByName(CycleTimeDialog,
        "m_CycleTimeProjMin", ProjMin,ReflectionWays.SystemReflection);
    }

    public static void SetCycleTimeOnlineMin(this CycleTimeDialog CycleTimeDialog,
      float OnlineMin)
    {
      Reflector.SetInstanceFieldByName(CycleTimeDialog,
        "m_CycleTimeOnlineMin", OnlineMin,ReflectionWays.SystemReflection);
    }

    public static void SetCycleTimeOnlineAkt(this CycleTimeDialog CycleTimeDialog,
      float OnlineAkt)
    {
      Reflector.SetInstanceFieldByName(CycleTimeDialog,
        "m_CycleTimeOnlineAkt",OnlineAkt, ReflectionWays.SystemReflection);
    }

    public static void SetCycleTimeOnlineMax(this CycleTimeDialog CycleTimeDialog,
      float OnlineMax)
    {
      Reflector.SetInstanceFieldByName(CycleTimeDialog,
        "m_CycleTimeOnlineMax", OnlineMax,ReflectionWays.SystemReflection);
    }
  }
}

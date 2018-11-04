using Microsoft.Scripting.Runtime;

using Siemens.Automation.OnlineAccess;
using Siemens.Automation.OnlineAccess.OnlineInterface;

namespace YZX.Tia.Extensions
{
  public static class IOamLocalBoardExtensions
  {
    public static bool IsOamLocalBoard([NotNull] this IOamLocalBoard board)
    {
      OamLocalBoard oamLocalBoard = board as OamLocalBoard;
      return oamLocalBoard != null;
    }

    public static bool IsOamComBoard([NotNull] this IOamLocalBoard board)
    {
      OamComBoard oamComBoard = board as OamComBoard;
      return oamComBoard != null;
    }

    public static bool IsOamCustomBoard([NotNull] this IOamLocalBoard board)
    {
      OamCustomBoard oamCustomBoard = board as OamCustomBoard;
      return oamCustomBoard != null;
    }
  }
}

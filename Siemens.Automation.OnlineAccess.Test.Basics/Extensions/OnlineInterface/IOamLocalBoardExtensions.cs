using Siemens.Automation.OnlineAccess;
using Siemens.Automation.OnlineAccess.OnlineInterface;

namespace YZX.Tia.Extensions.OnlineInterface
{
  public static class IOamLocalBoardExtensions
  {
    public static bool IsOamLocalBoard(this IOamLocalBoard board)
    {
      OamLocalBoard oamLocalBoard = board as OamLocalBoard;
      return oamLocalBoard != null;
    }

    public static bool IsOamComBoard(this IOamLocalBoard board)
    {
      OamComBoard oamComBoard = board as OamComBoard;
      return oamComBoard != null;
    }

    public static bool IsOamCustomBoard(this IOamLocalBoard board)
    {
      OamCustomBoard oamCustomBoard = board as OamCustomBoard;
      return oamCustomBoard != null;
    }
  }
}

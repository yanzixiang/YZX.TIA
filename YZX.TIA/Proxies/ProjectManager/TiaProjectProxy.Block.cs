using System.Collections.Generic;

using Siemens.Automation.ObjectFrame;

using Siemens.Simatic.PlcLanguages.BlockLogic;
using Siemens.Simatic.Lang.Model.Idents;

namespace YZX.Tia.Proxies
{
  partial class TiaProjectProxy
  {
    public BlockServiceProxy BlockServiceProxy
    {
      get
      {
        IBlockService bs =
          ProjectWorkingContext.DlcManager.Load("PlcLanguages.BlockLogic.BlockService") as IBlockService;
        return new BlockServiceProxy(bs);
      }
    }

    public ICoreObject[] FindBlockByAddress(ICoreObject parent, BlockType type, int number)
    {
      return BlockServiceProxy.FindBlockByAddress(parent, type, number);
    }
  }
}

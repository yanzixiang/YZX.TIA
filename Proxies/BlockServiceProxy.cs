using System.Collections;
using System.Collections.Generic;

using Siemens.Automation.ObjectFrame;
using Siemens.Simatic.Lang.Model.Idents;
using Siemens.Simatic.PlcLanguages.BlockLogic;
using Siemens.Simatic.Lang.Model.Blocks;

namespace YZX.Tia.Proxies
{
  public class BlockServiceProxy
  {
    IBlockService BlockService;

    public BlockServiceProxy(IBlockService bs)
    {
      BlockService = bs;
    }

    public ICoreObject FindBlockByName(ICoreObject parent, BlockType type, string name)
    {
      return BlockService.FindBlockByName(parent, type, name);
    }

    public ICoreObject[] FindBlockByAddress(ICoreObject parent, BlockType type, int number)
    {
      return BlockService.FindBlockByAddress(parent, type, number);
    }

    public ICoreObject[] FindBlockByAddress(ICoreObject parent, string absoluteName)
    {
      return BlockService.FindBlockByAddress(parent, absoluteName);
    }

    public ICoreObject[] FindBlockByRID(ICoreObject parent, uint rid)
    {
      return BlockService.FindBlockByRID(parent, rid);
    }
    public string GetViewPath(ICoreObject leafObject)
    {
      return BlockService.GetViewPath(leafObject);
    }
    public List<ICoreObject> GetBlocksByTypeAndLanguage(ICoreObject parent, BlockType type, ProgrammingLanguage language)
    {
      List<ICoreObject> blockList = new List<ICoreObject>();
      IList blocks = BlockService.GetBlocksByTypeAndLanguage(parent, type, language);

      for (int i = 0; i < blocks.Count; i++)
      {
        blockList.Add(blocks[i] as ICoreObject);
      }
      return blockList;
    }

    public List<ICoreObject> GetBlocksByTypeAndSubtype(ICoreObject parent, BlockType type, string subtype)
    {
      List<ICoreObject> blockList = new List<ICoreObject>();
      IList blocks = BlockService.GetBlocksByTypeAndSubtype(parent, type, subtype);

      for (int i = 0; i < blocks.Count; i++)
      {
        blockList.Add(blocks[i] as ICoreObject);
      }
      return blockList;
    }
  }
}

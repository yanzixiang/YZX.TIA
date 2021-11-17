using System.Collections.Generic;
using System.Linq;

using Siemens.Automation.DomainModel;
using Siemens.Automation.ObjectFrame;
using Siemens.Automation.OMSPlus.Managed;

using Siemens.Simatic.PlcLanguages.BlockLogic;
using Siemens.Simatic.Lang.Model.Blocks;
using Siemens.Simatic.Lang.Model.Idents;
using Siemens.Simatic.PlcLanguages.PLInterface;

using Siemens.Simatic.PlcLanguages.BlockLogic.Online.Plus;
using Siemens.Simatic.PlcLanguages.BlockLogic.Online.OnlineReader;

using YZX.Tia.Proxies;

namespace YZX.Tia.Extensions
{
  public static class ClientSessionExtensions
  {
    public static string GetSerialNumberRemote(this ClientSession clientSession)
    {
      return OmsPlusBlockUtilities.GetSerialNumberRemote(clientSession, "");
    }

    public static int GetOperatingState(this ClientSession clientSession)
    {
      return OmsPlusBlockUtilities.GetOperatingState(clientSession);
    }

    public static OnlinePlusReadThroughCacheProxy GetBlockAccess(this ClientSession clientSession, ICoreObject target)
    {
      OnlinePlusReadThroughCache cache = new OnlinePlusReadThroughCache(target, clientSession);
      OnlinePlusReadThroughCacheProxy proxy = new OnlinePlusReadThroughCacheProxy(cache);
      return proxy;
    }

    public static Object CreateASRoot(this ClientSession clientSession)
    {
      Object @object = new Object();
      Composition composition = new Composition();
      Error childObject = clientSession.ProxyObjectRoot.CreateChildObject(new Rid(2478U), ref @object, composition, new ObjectPlacement()
      {
        NewPosition = PlacementHint.PlacementAddDontCare
      }, new Rid(1U));
      composition.Dispose();
      if (childObject.Succeeded || clientSession.ProxyObjectRoot.GetObjectFromID(1U, ref @object).Succeeded)
        return @object;
      return null;
    }

    public static void TestStart(this ClientSession clientSession)
    {
      Rid rid = new Rid(52U);
      Value obj = new Value(3);
      Aid aid = new Aid(2167U);
      int requestID = 0;
      Error error = clientSession.SetVariableRemote(rid, aid, obj, 1, ref requestID);
    }

    public static void TestStop(this ClientSession clientSession)
    {
      Rid rid = new Rid(52U);
      Value obj = new Value(1);
      Aid aid = new Aid(2167U);
      int requestID = 0;
      Error error = clientSession.SetVariableRemote(rid, aid, obj, 1, ref requestID);
    }

    public static OnlineProtectionLevel EffectiveProtectionFromPlcOrHashSet(this ClientSession session)
    {
      OnlineProtectionLevel onlineProtectionLevel = OnlineProtectionLevel.Unknown;
      Value obj = new Value();
      int requestID = -1;
      Error variableRemote = session.GetVariableRemote(session.ServerSessionRID, new Aid(1842U), ref obj, ref requestID);
      if (variableRemote.Succeeded)
      {
        uint num = 1000U;
        variableRemote = obj.GetValue(ref num);
        if (variableRemote.Succeeded)
        {
          switch (num)
          {
            case 0U:
              onlineProtectionLevel = OnlineProtectionLevel.NoProtection;
              break;
            case 1U:
              onlineProtectionLevel = OnlineProtectionLevel.ProtectFailSafeAccess;
              break;
            case 2U:
              onlineProtectionLevel = OnlineProtectionLevel.ProtectWrite;
              break;
            case 3U:
              onlineProtectionLevel = OnlineProtectionLevel.ProtectReadWrite;
              break;
            case 4U:
              onlineProtectionLevel = OnlineProtectionLevel.ProtectIdentificationAccess;
              break;
            case 5U:
              onlineProtectionLevel = OnlineProtectionLevel.NoProtection;
              break;
          }
        }
        if (obj != null)
          obj.Dispose();
      }
      return onlineProtectionLevel;
    }

    public static uint GetProtectionLevelOnline(this ClientSession session)
    {
      uint m_OnlineProtectionLevel = 0;
      Rid rid = new Rid(50U);
      Aid aid = new Aid(3451U);
      Value obj = new Value();
      int requestID = -1;
      if (session.GetVariableRemote(rid, aid, ref obj, ref requestID).Succeeded)
        obj.GetValue(ref m_OnlineProtectionLevel);

      return m_OnlineProtectionLevel;
    }

    public static ulong GetMMCFreeSpaceRemote(this ClientSession session)
    {
      ulong num1 = 0UL;
      ulong num2 = 0UL;
      uint num3 = 0U;
      int requestID = -1;
      AnyVariableValue[] anyValueList = new AnyVariableValue[2]
      {
        new AnyVariableValue()
        {
          ObjectRID = new Rid(201U),
          AddressList = new uint[1]
          {
            399U
          }
        },
        new AnyVariableValue()
        {
          ObjectRID = new Rid(51U),
          AddressList = new uint[1]
          {
            2117U
          }
        }
      };
      if (session.GetVariablesRemote(anyValueList, ref requestID).Succeeded)
      {
        anyValueList[0].VariableValue.GetValue(ref num2);
        anyValueList[1].VariableValue.GetValue(ref num3);
        num1 = ((int)num3 & -1073741824) != -1073741824 ? num2 - (num3 & 1073741823U) * (((int)num3 & int.MinValue) != 0 ? 4096UL : (((int)num3 & 1073741824) != 0 ? 512UL : 1UL)) : 0UL;
      }
      anyValueList[0].VariableValue.Dispose();
      anyValueList[1].VariableValue.Dispose();
      return num1;
    }

    public static Error WriteValuesRemote(this ClientSession session,
      AnyVariableValue[] anyValueArray)
    {
      Error error = new Error();
      foreach (AnyVariableValue anyVariableValue in anyValueArray)
      {
        Blob blob = null;
        error = anyVariableValue.VariableValue.GetValue(ref blob);
        using (blob)
        {
          if (error.Failed)
            return error;
          error = session.SetBlobRemote(anyVariableValue.ObjectRID.RID, anyVariableValue.AddressList, blob);
          if (error.Failed)
            return error;
        }
      }
      return error;
    }

    public static bool ReadPlusDbValuesRemote(this ClientSession session, 
      ICoreObject onlineTarget, ICoreObject blockDb, out OnlineBinary binaryToRead, uint dbValuesAid)
    {
      if (onlineTarget == null || blockDb == null)
        throw new BlockLogicException("onlineTarget, blockDb is null");
      if (!IecplUtilities.IsPlusPLC(blockDb) || !onlineTarget.GetObjectType().IsTypeOf(OnlineControllerTargetData.FullName))
        throw new BlockLogicException("Target is no Plus- or Online target");
      IGeneralBlockSourceData generalBlockSourceData = blockDb.GetAttributeSet(typeof(IGeneralBlockSourceData), false) as IGeneralBlockSourceData;
      if (generalBlockSourceData == null || generalBlockSourceData.BlockType != BlockType.DB)
        throw new BlockLogicException("block is no data block!");
      if ((int)dbValuesAid != 2550 && (int)dbValuesAid != 2548)
        throw new System.NotSupportedException("Only ValueActual_Aid and ValueInitial_Aid are supported");
      uint blockRid = RidService.GetRidService(onlineTarget, true).GetBlockRid(blockDb);
      Error error = new Error();
      ulong ticks = 0UL;
      Dictionary<uint, byte[]> dictionary = new Dictionary<uint, byte[]>()
      {
        {
          3U,
          new byte[0]
        },
        {
          4U,
          new byte[0]
        },
        {
          5U,
          new byte[0]
        }
      };
      binaryToRead = new OnlineBinary(dictionary[4U], dictionary[5U], dictionary[3U], new System.DateTime());
      try
      {
        int requestID = -1;
        Value obj1 = new Value();
        Value obj2 = null;
        foreach (uint index in Enumerable.ToList(dictionary.Keys))
        {
          Blob blob = new Blob();
          Error blobRemote = session.GetBlobRemote(blockRid, new uint[2]
          {
            dbValuesAid,
            index
          }, ref blob);
          using (blob)
          {
            if (blobRemote.Failed)
            {
              return false;
            }
            byte[] data = new byte[0];
            blob.GetData(ref data);
            dictionary[index] = data;
          }
        }
        Error variableSubrangeRemote = session.GetVariableSubrangeRemote(new Rid(blockRid), new uint[2]
        {
          dbValuesAid,
          6U
        }, ref obj2, ref requestID);
        using (obj2)
        {
          if (variableSubrangeRemote.Failed)
          {
            return false;
          }
          obj2.GetValue(ref ticks);
        }
        binaryToRead = new OnlineBinary(dictionary[4U], dictionary[5U], dictionary[3U], DateTimeExtensions.ConvertPLCToESTime(ticks));
      }
      finally
      {
      }
      return true;
    }

    public static bool ReadPlusMcDbValuesRemote(this ClientSession session, 
      ICoreObject onlineTarget, 
      ICoreObject blockDb, 
      out OnlineBinary binaryToRead, 
      uint dbValuesAid)
    {
      if (onlineTarget == null || blockDb == null)
        throw new BlockLogicException("onlineTarget, blockDb is null");
      if (!IecplUtilities.IsPlusPLC(blockDb) || !onlineTarget.GetObjectType().IsTypeOf(OnlineControllerTargetData.FullName))
        throw new BlockLogicException("Target is no Plus- or Online target");
      IGeneralBlockSourceData generalBlockSourceData = blockDb.GetAttributeSet(typeof(IGeneralBlockSourceData), false) as IGeneralBlockSourceData;
      if (generalBlockSourceData == null || generalBlockSourceData.BlockType != BlockType.DB)
        throw new BlockLogicException("block is no data block!");
      if ((int)dbValuesAid != 2550 && (int)dbValuesAid != 2548)
        throw new System.NotSupportedException("Only ValueActual_Aid and ValueInitial_Aid are supported");
      uint blockRid = RidService.GetRidService(onlineTarget, true).GetBlockRid(blockDb);
      Error error = new Error();
      ulong ticks = 0UL;
      Dictionary<uint, byte[]> dictionary = new Dictionary<uint, byte[]>()
      {
        {
          3U,
          new byte[0]
        },
        {
          4U,
          new byte[0]
        },
        {
          5U,
          new byte[0]
        }
      };
      binaryToRead = new OnlineBinary(dictionary[4U], dictionary[5U], dictionary[3U], new System.DateTime());
      try
      {
        int requestID = -1;
        Value obj1 = new Value();
        Value obj2 = null;
        Error variableRemote = session.GetVariableRemote(new Rid(blockRid), new Aid(dbValuesAid), ref obj1, ref requestID);
        using (obj1)
        {
          if (variableRemote.Failed)
          {
            return false;
          }
          foreach (uint key in Enumerable.ToList(dictionary.Keys))
          {
            Error errorState = obj1.GetValue(key, ref obj2);
            using (obj2)
            {
              if (errorState.Failed)
              {
                return false;
              }
              byte[] numArray = new byte[0];
              obj2.GetValue(ref numArray);
              dictionary[key] = numArray;
            }
          }
          Error errorState1 = obj1.GetValue(6U, ref obj2);
          using (obj2)
          {
            if (errorState1.Failed)
            {
              return false;
            }
            obj2.GetValue(ref ticks);
          }
          binaryToRead = new OnlineBinary(dictionary[4U], dictionary[5U], dictionary[3U], DateTimeExtensions.ConvertPLCToESTime(ticks));
        }
      }
      finally
      {
      }
      return true;
    }

    public static string GetAOM_Version(this ClientSession session)
    {
      Value obj1 = new Value();
      int requestID = -1;
      if (session.GetVariableRemote(new Rid(1U), new Aid(2460U), ref obj1, ref requestID).Failed)
      {
        obj1.Dispose();
        return string.Empty;
      }
      string str = null;
      if (obj1.GetValue(ref str).Failed)
      {
        obj1.Dispose();
        return string.Empty;
      }
      obj1.Dispose();
      return str;
    }
  }
}

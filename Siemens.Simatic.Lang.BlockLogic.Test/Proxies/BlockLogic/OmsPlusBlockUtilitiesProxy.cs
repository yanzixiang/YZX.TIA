using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;

using Siemens.Automation.OMSPlus.Managed;
using Siemens.Simatic.Lang.Model.Idents;


using Siemens.Simatic.PlcLanguages.BlockLogic.Online.Plus;

namespace Siemens.Simatic.Lang.BlockLogic.Test.Proxies.BlockLogic
{
  public static class OmsPlusBlockUtilitiesProxy
  {
    public static T GetAttribute<T>(this Siemens.Automation.OMSPlus.Managed.Object currentObject,
      GlobalAID id,
      Value reusedValueStorage = null)
    {
      return OmsPlusBlockUtilities.GetAttribute<T>(currentObject, id, reusedValueStorage);
    }

    public static Siemens.Automation.OMSPlus.Managed.Error SetAttribute(
      ref Siemens.Automation.OMSPlus.Managed.Object omsObject,
      int iAID, object iValue)
    {
      return OmsPlusBlockUtilities.SetAttribute(ref omsObject, iAID, iValue);
    }

    public static uint GetBlockTypeObjectRID(BlockType blockType)
    {
      return OmsPlusBlockUtilities.GetBlockTypeObjectRID(blockType);
    }

    public static BlockType GetBlockTypeFromClassRid(uint classRid)
    {
      return OmsPlusBlockUtilities.GetBlockTypeFromClassRid(classRid);
    }

    public static BlockType GetClassRIDBlockType(uint classRID)
    {
      return OmsPlusBlockUtilities.GetClassRIDBlockType(classRID);
    }

    public static uint[] GetRelationIDs(uint classRID)
    {
      return OmsPlusBlockUtilities.GetRelationIDs(classRID);
    }

    public static Siemens.Automation.OMSPlus.Managed.Error GetAsSwEvent(
      ClientSession clientSession,
      Siemens.Automation.OMSPlus.Managed.Object asObject,
      uint[] aids,
      ref Siemens.Automation.OMSPlus.Managed.Object asSwEvent)
    {
      return OmsPlusBlockUtilities.GetAsSwEvent(clientSession, asObject, aids, ref asSwEvent);
    }

    public static Rid GetDBConfiguredTypeRid(Siemens.Automation.OMSPlus.Managed.Object block)
    {
      return OmsPlusBlockUtilities.GetDBConfiguredTypeRid(block);
    }
  }
}

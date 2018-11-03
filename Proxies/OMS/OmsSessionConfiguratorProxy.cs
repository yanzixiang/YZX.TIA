using System;

using Siemens.Automation.ObjectFrame;
using Siemens.Automation.DomainServices;
using Siemens.Automation.OMSPlus.Managed;

using Reflection;

namespace YZX.Tia.Proxies
{
  public static class OmsSessionConfiguratorProxy
  {
    public static IOmsModelLoader OmsLoadHelper
    {
      get
      {
        return OmsSessionConfigurator.OmsLoadHelper;
      }
    }

    public static string DefaultLocationPaom
    {
      get
      {
        Type t = typeof(OmsSessionConfigurator);
        return (string)Reflector.GetStaticPropertyByName(t,
          "DefaultLocationPaom", 
          ReflectionWays.SystemReflection);
      }
    }

    public static string DefaultLocationPaim
    {
      get
      {
        Type t = typeof(OmsSessionConfigurator);
        return (string)Reflector.GetStaticPropertyByName(t,
          "DefaultLocationPaim",
          ReflectionWays.SystemReflection);
      }
    }

    public static IASModelDescription ResolveASModelLocation(ICoreObject target)
    {
      return OmsSessionConfigurator.ResolveASModelLocation(target);
    }

    public static IASModelDescription ResolveASModelLocation(ICoreObject cardReaderSlot, 
      uint paomVersionID, 
      string paomVersionIdString)
    {
      return OmsSessionConfigurator.ResolveASModelLocation(cardReaderSlot, paomVersionID, paomVersionIdString);
    }

    public static void ResolvePublicKey(ICoreObject target, out PublicKeyInfo publicKeyInfo)
    {
      OmsSessionConfigurator.ResolvePublicKey(target, out publicKeyInfo);
    }

    public static void ResolvePublicKey(ICoreObject cardReaderSlot, 
      uint paomVersionID, 
      string paomVersionIdString, 
      out PublicKeyInfo publicKeyInfo)
    {
      OmsSessionConfigurator.ResolvePublicKey(cardReaderSlot, 
        paomVersionID, paomVersionIdString, out publicKeyInfo);
    }

    public static int LoadSpecificAsModel(ClientSession omsSession, ICoreObject target)
    {
      return OmsSessionConfigurator.LoadSpecificAsModel(omsSession, target);
    }

    public static int LoadSpecificPublicKey(ClientSession omsSession, ICoreObject target)
    {
      return OmsSessionConfigurator.LoadSpecificPublicKey(omsSession, target);
    }
  }
}

using System;
using System.Collections.Generic;

using Siemens.Automation.Basics;

using Siemens.Simatic.Hmi.Utah.Common.Base.Reflection;

namespace YZX.Tia.Dlc
{
  public static partial class IWorkingContextExtensions
  {
    internal static IDlcCache GetGlobalSingletonCache(this IWorkingContext workingContext)
    {
      var manager = workingContext.DlcManager.GetDlcLifetimeManager();
      var cache = Reflector.GetInstanceFieldByName(manager, "m_GlobalSingletonCache") as IDlcCache;
      return cache;
    }

    internal static IDlcCache GetSingletonCache(this IWorkingContext workingContext)
    {
      var manager = workingContext.DlcManager.GetDlcLifetimeManager();
      var cache = Reflector.GetInstanceFieldByName(manager, "m_SingletonCache") as IDlcCache;
      return cache;
    }

    internal static IDlcCache GetNonSingletonCache(this IWorkingContext workingContext)
    {
      var manager = workingContext.DlcManager.GetDlcLifetimeManager();
      var cache = Reflector.GetInstanceFieldByName(manager, "m_NonSingletonCache") as IDlcCache;
      return cache;
    }

    public static List<IDlcMetaInfo> GetGlobalSingletonCache_MetaInfo(this IWorkingContext workingContext)
    {
      var metainfos = new List<IDlcMetaInfo>();
      var cache = workingContext.GetGlobalSingletonCache();
      var dlcs = cache.Dlcs;
      foreach(var dlc in dlcs)
      {
        var meta = cache.FindDlcMetaInfo(dlc);
        metainfos.Add(meta);
      }
      return metainfos;
    }

    public static List<IDlcMetaInfo> GetSingletonCache_MetaInfo(this IWorkingContext workingContext)
    {
      var metainfos = new List<IDlcMetaInfo>();
      var cache = workingContext.GetSingletonCache();
      var dlcs = cache.Dlcs;
      foreach (var dlc in dlcs)
      {
        var meta = cache.FindDlcMetaInfo(dlc);
        metainfos.Add(meta);
      }
      return metainfos;
    }

    public static List<IDlcMetaInfo> GetNonSingletonCache_MetaInfo(this IWorkingContext workingContext)
    {
      var metainfos = new List<IDlcMetaInfo>();
      var cache = workingContext.GetNonSingletonCache();
      var dlcs = cache.Dlcs;
      foreach (var dlc in dlcs)
      {
        var meta = cache.FindDlcMetaInfo(dlc);
        metainfos.Add(meta);
      }
      return metainfos;
    }
  }
}

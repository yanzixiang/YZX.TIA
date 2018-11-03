using System.Collections.Generic;

using Siemens.Simatic.HwConfiguration.Application.ViewDescription;
using Siemens.Simatic.HwConfiguration.Application.UserInterface.Basics.Common.ImageCache;

using Reflection;

namespace YZX.Tia.Extensions
{
  public static class OnlineImageCacheExtensions
  {
    public static Dictionary<string, IHwcnImage> GetImages (OnlineImageCache cache)
    {
      return Reflector.GetInstanceFieldByName(cache,
        "m_Images",
        ReflectionWays.SystemReflection) as Dictionary<string, IHwcnImage>;
    }
  }
}

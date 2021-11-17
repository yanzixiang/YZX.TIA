using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Siemens.Simatic.PlcLanguages.Online;
using Siemens.Simatic.PlcLanguages.BlockLogic;
using Siemens.Simatic.PlcLanguages.BlockEditorFrame.Services.Online;
using Siemens.Simatic.Hmi.Utah.Common.Base.Reflection;

namespace YZX.Tia.Extensions
{
  public static class ICodeBlockExtensions
  {
    public static IOfflineOnlineStatus GetOnlineStatusByExplicitExplore(this ICodeBlock codeBlock)
    {
      return Reflector.RunStaticMethodByName(typeof(OnlineManagerBase),
        "GetOnlineStatusByExplicitExplore",
        ReflectionWays.SystemReflection,
        codeBlock) as IOfflineOnlineStatus;
    }
  }
}

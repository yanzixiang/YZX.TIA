using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Siemens.Automation.Archiving;
using Siemens.Automation.Archiving.Private;

using Siemens.Simatic.Hmi.Utah.Common.Base.Reflection;

namespace YZX.Tia.Proxies.Archiving
{
  public class ZipCreatorProxy
  {
    internal ZipCreator ZipCreator;

    public ZipCreatorProxy(IWriteableDirectory directory)
    {
      ZipCreator = directory as ZipCreator;
    }

    public void CloseCurrentFile()
    {
      ZipCreator.CloseCurrentFile();
    }

    public void CloseArchive()
    {
      Reflector.RunInstanceMethodByName(ZipCreator,
        "CloseArchive",
        ReflectionWays.SystemReflection);
    }
  }
}

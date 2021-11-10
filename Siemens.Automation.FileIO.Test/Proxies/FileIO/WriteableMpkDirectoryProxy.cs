using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Siemens.Automation.FileIO;
using Siemens.Automation.FileIO.Private;
using Siemens.Automation.FileIO.Private.MetaPackage;

using Siemens.Simatic.Hmi.Utah.Common.Base.Reflection;

namespace YZX.Tia.Proxies.FileIO
{
  public class WriteableMpkDirectoryProxy
  {
    WriteableMpkDirectory WriteableMpkDirectory;

    public WriteableMpkDirectoryProxy(IWriteableDirectory directory)
    {
      WriteableMpkDirectory = directory as WriteableMpkDirectory;
    }

    public MetaPackageImplementationProxy GetMetaPackageImplementationProxy()
    {
      var IMetaPackageAccess = Reflector.GetInstanceFieldByName(
        WriteableMpkDirectory,
        "m_MetaPackage",
        ReflectionWays.SystemReflection)
        as IMetaPackageAccess;
      var MetaPackageImplementation = IMetaPackageAccess as MetaPackageImplementation;
      var proxy = new MetaPackageImplementationProxy(IMetaPackageAccess);
      return proxy;
    }
  }
}

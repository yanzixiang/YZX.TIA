using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Siemens.Automation.Archiving;
using Siemens.Automation.FileIO.Private;
using Siemens.Automation.FileIO.Private.MetaPackage;

using Siemens.Simatic.Hmi.Utah.Common.Base.Reflection;

namespace YZX.Tia.Proxies.FileIO
{
  public class MetaPackageImplementationProxy
  {
    IMetaPackageAccess IMetaPackageAccess;
    MetaPackageImplementation MetaPackageImplementation;

    internal MetaPackageImplementationProxy(IMetaPackageAccess metaPackageAccess)
    {
      IMetaPackageAccess = metaPackageAccess;
      MetaPackageImplementation = metaPackageAccess as MetaPackageImplementation;
    }

    public void Add(string fileName, Stream stream)
    {
      IMetaPackageAccess.Add(fileName, stream);
    }

    public IDirectory Package
    {
      get
      {
        var package = Reflector.GetInstanceFieldByName(
        IMetaPackageAccess,
        "m_Package",
        ReflectionWays.SystemReflection)
        as IDirectory;
        return package;
      }
    }
  }
}

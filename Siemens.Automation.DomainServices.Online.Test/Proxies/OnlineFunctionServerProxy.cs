using System.Collections;

using Siemens.Automation.ObjectFrame;
using Siemens.Simatic.HwConfiguration.Diagnostic.Services;
using Siemens.Simatic.HwConfiguration.Diagnostic.OnlineFunctions.DataSetServices.Server;
using Siemens.Simatic.HwConfiguration.Diagnostic.OnlineFunctions.Services;
using Siemens.Simatic.HwConfiguration.Diagnostic.OnlineFunctions.Server;

using Siemens.Simatic.Hmi.Utah.Common.Base.Reflection;

namespace YZX.Tia.Proxies
{
  public class OnlineFunctionServerProxy
  {
    public OnlineFunctionServer OnlineFunctionServer;
    public OnlineFunctionServerProxy(OnlineFunctionServer ofs)
    {
      OnlineFunctionServer = ofs;
    }

    public IOnlineObjectService DiagOnlObjService
    {
      get
      {
        return Reflector.GetInstancePropertyByName(OnlineFunctionServer,
          "DiagOnlObjService",
          ReflectionWays.SystemReflection) as IOnlineObjectService;
      }
    }

    public IDataSetService DataSetService
    {
      get
      {
        return OnlineFunctionServer as IDataSetService;
      }
    }

    public IOfctHighLevelDataSetAccess HighLevelDataSetAccess
    {
      get
      {
        return DataSetService.HighLevelDataSetAccess;
      }
    }

    public IOfctClientLevelDataSetAccess ClientLevelDataSetAccess
    {
      get
      {
        return DataSetService.ClientLevelDataSetAccess;
      }
    }

    public IEnumerable GetFunctionProviderAcfs(ICoreObject onlineTarget)
    {
      return Reflector.RunInstanceMethodByName(OnlineFunctionServer,
        "GetFunctionProviderAcfs", 
        ReflectionWays.SystemReflection,
        onlineTarget) as IEnumerable;
    }

  }
}

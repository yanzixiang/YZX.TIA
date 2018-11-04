using System.ComponentModel;

using Siemens.Automation.Basics;
using Siemens.Automation.DomainServices;
using Siemens.Automation.DomainServices.ConnectionService;
using Siemens.Automation.ObjectFrame;
using Siemens.Automation.ObjectFrame.BusinessLogic;

using Siemens.Automation.CommonServices;
using Siemens.Automation.DomainServices.FolderService;
using Siemens.Automation.ObjectFrame.NameService;
using Siemens.Automation.DomainModel;
using Siemens.Simatic.SystemDiagnosis.Sdal.SdalPE;
using Siemens.Simatic.HwConfiguration.Diagnostic.Services.Common.Lifelist;
using Siemens.Simatic.PlcLanguages.BlockLogic;
using Siemens.Simatic.PlcLanguages.PLInterface.PLDebug;
using Siemens.Simatic.PlcLanguages.VatService;
using Siemens.Simatic.PlcLanguages.Utilities;
using Siemens.Simatic.PlcLanguages.TisPlusServer;
using Siemens.Simatic.HwConfiguration.Application;
using Siemens.Simatic.HwConfiguration.Diagnostic;
using Siemens.Simatic.HwConfiguration.Diagnostic.Services.Common;
using Siemens.Simatic.HwConfiguration.Diagnostic.Common;
using Siemens.Simatic.PLCMessaging;
using Siemens.Simatic.SystemDiagnosis.Comm.AlarmService;
using Siemens.Simatic.PlcLanguages.BlockLogic.Online.Plus.Upload;
using Siemens.Automation.DomainServices.OnlineService;
using Siemens.Simatic.HwConfiguration.Diagnostic.Services.Common.OnlineHostService;
using Siemens.Simatic.PlcLanguages.VatService.FolderSnapIn;
using Siemens.Automation.DomainServices.TagService;

#if TIA
using Siemens.Simatic.PlcLanguages.VatService.Businesslogic;
#endif

using Reflection;

namespace YZX.Tia.Extensions
{
  public static partial class ICoreObjectExtensions
  {
#if TIA
    public static IVarTable ToIVarTable(this ICoreObject ico)
    {
      IBusinessLogicConnector iblc = ico as IBusinessLogicConnector;
      IBusinessLogicObject iblo = iblc.GetBusinessLogic("PlcLanguages.VatService");
      IVarTable ivt = iblo as IVarTable;
      return ivt;
    }

    internal static VarTable ToVarTable(this IVarTable ivt)
    {
      return ivt as VarTable;
    }

    public static ISynchronizeInvoke GetSynchronizer(this ICoreObject coreObject)
    {
      return DlcIdExtensions.LoadByDlcId(((IDlc)coreObject.Context).WorkingContext.DlcManager,
        DlcIds.Platform.Basics.SynchronizerService);
    }

    public static IFolderService GetFolderService(this ICoreObject coreObject)
    {
      return DlcIdExtensions.LoadByDlcId(((IDlc)coreObject.Context).WorkingContext.DlcManager,
        DlcIds.Platform.DomainServices.FolderService);
    }



    public static ICommandProcessor GetCommandProcessor(this ICoreObject coreObject)
    {
      return DlcIdExtensions.LoadByDlcId(((IDlc)coreObject.Context).WorkingContext.DlcManager, 
        DlcIds.Platform.CommonServices.CommandProcessor);
    }

    public static INameService GetNameService(this ICoreObject coreObject)
    {
      return DlcIdExtensions.LoadByDlcId(((IDlc)coreObject.Context).WorkingContext.DlcManager,
        DlcIds.Platform.ObjectFrame.NameService);
    }

    public static IRangeCheck GetRangeCheck(this ICoreObject coreObject)
    {
      return DlcIdExtensions.LoadByDlcId(((IDlc)coreObject.Context).WorkingContext.DlcManager,
        DlcIds.Iecpl.BlockLogic.RangeCheck);
    }

    public static IBulkService GetBulkService(this ICoreObject coreObject)
    {
      return DlcIdExtensions.LoadByDlcId(((IDlc)coreObject.Context).WorkingContext.DlcManager,
        DlcIds.Platform.Basics.BulkService);
    }
#endif
    public static ConnectionServiceProvider GetConnectionServiceProvider(this ICoreObject coreObject)
    {
      ConnectionServiceProvider connectionService = null;
      if (!coreObject.IsDeleted || !coreObject.IsDeleting)
      {
        IConnectionService ics = ((IDlc)coreObject.Context).WorkingContext.DlcManager.Load("Siemens.Automation.DomainServices.ConnectionService") 
          as IConnectionService;
        ConnectionServiceProxy csp = ics as ConnectionServiceProxy;
        connectionService = Reflector.GetInstancePropertyByName(csp, "RealConnectionService", ReflectionWays.SystemReflection) as ConnectionServiceProvider;
      }
      return connectionService;
    }

    public static IElementaryDataTypeService GetDataTypeService(this ICoreObject coreObject)
    {
      IDlc idlc = (IDlc)coreObject.Context;
      IDlcManager idlcManager = idlc.WorkingContext.DlcManager;
      IElementaryDataTypeService datatype = idlcManager.Load("Siemens.Automation.DomainServices.ElementaryDataTypeService") 
        as IElementaryDataTypeService;
      return datatype;
    }

    public static AccessManagerPE GetAccessManagerPE(this ICoreObject coreObject)
    {
      IDlc idlc = (IDlc)coreObject.Context;
      IDlcManager idlcManager = idlc.WorkingContext.DlcManager;
      AccessManagerPE datatype = idlcManager.Load("Siemens.Simatic.SystemDiagnosis.Sdal.SdalPE.AccessManagerPE")
        as AccessManagerPE;
      return datatype;
    }

    public static OmsLifelistExtension GetOmsLifelistExtension(this ICoreObject coreObject)
    {
      IDlc idlc = (IDlc)coreObject.Context;
      IDlcManager idlcManager = idlc.WorkingContext.DlcManager;
      OmsLifelistExtension datatype = idlcManager.Load("Siemens.Simatic.HwConfiguration.Diagnostic.OmsLifelistExtension")
        as OmsLifelistExtension;
      return datatype;
    }

    public static SdalFacade GetSdalFacade(this ICoreObject coreObject)
    {
      IDlc idlc = (IDlc)coreObject.Context;
      IDlcManager idlcManager = idlc.WorkingContext.DlcManager;
      SdalFacade SdalFacade = idlcManager.Load("Siemens.Simatic.SystemDiagnosis.Sdal.SdalPE.SdalFacade")
        as SdalFacade;
      return SdalFacade;
    }



    public static string GetBoardConfigurationName(this ICoreObject boardConfiguration)
    {
      IOamIdentification attributes = CoreObjectExtension.GetAttributes<IOamIdentification>(boardConfiguration);
      if(attributes != null)
      {
        return attributes.OamName;
      }
      else
      {
        return null;
      }
    }

    public static IWorkingContext GetWorkingContext(this ICoreObject coreObject)
    {
      IDlc idlc = (IDlc)coreObject.Context;
      return idlc.WorkingContext;
    }

    public static IDebugService GetDebugService(this ICoreObject coreObject)
    {
      IDlc idlc = (IDlc)coreObject.Context;
      IDlcManager idlcManager = idlc.WorkingContext.DlcManager;
      IDebugService IDebugService = idlcManager.Load("PlcLanguages.BlockLogic.DebugService")
        as IDebugService;
      return IDebugService;
    }

    public static IBlockService GetBlockService(this ICoreObject coreObject)
    {
      IDlc idlc = (IDlc)coreObject.Context;
      IDlcManager idlcManager = idlc.WorkingContext.DlcManager;
      IBlockService IBlockService = idlcManager.Load("PlcLanguages.BlockLogic.BlockService")
        as IBlockService;
      return IBlockService;
    }

    public static IOnlineService GetOnlineService(this ICoreObject coreObject)
    {
      IDlc idlc = (IDlc)coreObject.Context;
      IDlcManager idlcManager = idlc.WorkingContext.DlcManager;
      IOnlineService IOnlineService = idlcManager.Load("Siemens.Automation.DomainServices.OnlineService")
        as IOnlineService;
      return IOnlineService;
    }

    public static IOnlineBlockService GetOnlineBlockService(this ICoreObject coreObject)
    {
      IDlc idlc = (IDlc)coreObject.Context;
      IDlcManager idlcManager = idlc.WorkingContext.DlcManager;
      IOnlineBlockService IOnlineBlockService = idlcManager.Load("PlcLanguages.BlockLogic.OnlineBlockService")
        as IOnlineBlockService;
      return IOnlineBlockService;
    }

    public static ITagService GetTagService(this ICoreObject coreObject)
    {
      return DlcIdExtensions.LoadByDlcId(((IDlc)coreObject.Context).WorkingContext.DlcManager,
        DlcIds.Platform.DomainServices.TagService);
    }

    public static Server GetTisPlusServer(this ICoreObject coreObject)
    {

        IDlc idlc = (IDlc)coreObject.Context;
        IDlcManager idlcManager = idlc.WorkingContext.DlcManager;
        Server server = idlcManager.Load("Siemens.Simatic.PlcLanguages.TisPlusServer") as Server;
        return server;
    }

    public static TopologyDetection GetTopologyDetection(this ICoreObject coreObject)
    {

      IDlc idlc = (IDlc)coreObject.Context;
      IDlcManager idlcManager = idlc.WorkingContext.DlcManager;
      TopologyDetection TopologyDetection = idlcManager.Load("Siemens.Simatic.HwConfiguration.Application.TopologyDetection") 
        as TopologyDetection;
      return TopologyDetection;
    }

    public static OnlineObjectService GetOnlineObjectService(this ICoreObject coreObject)
    {

      IDlc idlc = (IDlc)coreObject.Context;
      IDlcManager idlcManager = idlc.WorkingContext.DlcManager;
      OnlineObjectService OnlineObjectService = idlcManager.Load(DiagDlcIds.OnlineObjectService)
        as OnlineObjectService;
      return OnlineObjectService;
    }

    public static OperatingModeObserverService GetOperatingModeObserverService(this ICoreObject coreObject)
    {
      IDlc idlc = (IDlc)coreObject.Context;
      IDlcManager idlcManager = idlc.WorkingContext.DlcManager;
      OperatingModeObserverService OperatingModeObserverService = idlcManager.Load(DiagDlcIds.OperatingModeObserverService)
        as OperatingModeObserverService;
      return OperatingModeObserverService;
    }

    public static PLCMsgConnector GetPLCMsgConnector(this ICoreObject coreObject)
    {
      IDlc idlc = (IDlc)coreObject.Context;
      IDlcManager idlcManager = idlc.WorkingContext.DlcManager;
      PLCMsgConnector PLCMsgConnector = idlcManager.Load("Siemens.Simatic.PLCMessaging.PLCMsgConnector")
        as PLCMsgConnector;
      return PLCMsgConnector;
    }

    public static InnovationAlarmService GetInnovationAlarmService(this ICoreObject coreObject)
    {
      IDlc idlc = (IDlc)coreObject.Context;
      IDlcManager idlcManager = idlc.WorkingContext.DlcManager;
      InnovationAlarmService InnovationAlarmService = idlcManager.Load("Siemens.Simatic.SystemDiagnosis.Comm.AlarmService.InnovationAlarmService")
        as InnovationAlarmService;
      return InnovationAlarmService;
    }

    public static IUpload GetPlusBlockConsistencyService(this ICoreObject coreObject)
    {
      IDlc idlc = (IDlc)coreObject.Context;
      IDlcManager idlcManager = idlc.WorkingContext.DlcManager;
      PlusBlockConsistencyService PlusBlockConsistencyService = idlcManager.Load("BlockLogic.PlusBlockConsistencyService")
        as PlusBlockConsistencyService;
      return PlusBlockConsistencyService;

    }

    public static LifelistProxyFactory GetLifelistProxyFactory(this ICoreObject coreObject)
    {
      IDlc idlc = (IDlc)coreObject.Context;
      IDlcManager idlcManager = idlc.WorkingContext.DlcManager;
      LifelistProxyFactory LifelistProxyFactory = idlcManager.Load("Siemens.Automation.DomainServices.LifelistProxyFactory")
        as LifelistProxyFactory;
      return LifelistProxyFactory;
    }

    public static OnlineHostService GetOnlineHostService(this ICoreObject coreObject)
    {
      IDlc idlc = (IDlc)coreObject.Context;
      IDlcManager idlcManager = idlc.WorkingContext.DlcManager;
      OnlineHostService OnlineHostService = idlcManager.Load("Siemens.Simatic.HwConfiguration.Diagnostic.OnlineHostService")
        as OnlineHostService;
      return OnlineHostService;
    }

    public static NavigationService GetNavigationService(this ICoreObject coreObject)
    {
      IDlc idlc = (IDlc)coreObject.Context;
      IDlcManager idlcManager = idlc.WorkingContext.DlcManager;
      NavigationService NavigationService = idlcManager.Load("Siemens.Simatic.HwConfiguration.Diagnostic.NavigationService")
        as NavigationService;
      return NavigationService;
    }
  }
}

﻿using System.Collections.Generic;

using Siemens.Automation.Basics;
using Siemens.Automation.ObjectFrame;
using Siemens.Simatic.HwConfiguration.Basics.SystemData;
using Siemens.Simatic.HwConfiguration.Connections.Block.Base;

namespace YZX.Tia.Extensions.ObjectFrame
{
  public static partial class ICoreObjectExtensions
  {
    public static WorkingContext FindWorkingContext(this ICoreObject ico)
    {
      List<ICoreObject> icoL = new List<ICoreObject>() { ico };
      return WorkingContext.FindWorkingContextForGivenObjects(icoL) as WorkingContext;
    }

    public static ConnService GetConnService(this ICoreObject coreObject)
    {
      IDlc idlc = (IDlc)coreObject.Context;
      IDlcManager idlcManager = idlc.WorkingContext.DlcManager;
      ConnService ConnService = idlcManager.Load("Siemens.Simatic.HwConfiguration.Connections.Block.Base.ConnectionService")
        as ConnService;
      return ConnService;
    }

    public static SystemDataBlockFactory GetSystemDataBlockFactory(this ICoreObject coreObject)
    {
      IDlc idlc = (IDlc)coreObject.Context;
      IDlcManager idlcManager = idlc.WorkingContext.DlcManager;
      SystemDataBlockFactory SystemDataBlockFactory = idlcManager.Load("Siemens.Simatic.HwConfiguration.Basics.SystemData.SystemDataBlockFactory")
        as SystemDataBlockFactory;
      return SystemDataBlockFactory;
    }

    public static S7PlusDataUpload GetS7PlusDataUpload(this ICoreObject coreObject)
    {
      IDlc idlc = (IDlc)coreObject.Context;
      IDlcManager idlcManager = idlc.WorkingContext.DlcManager;
      S7PlusDataUpload S7PlusDataUpload = idlcManager.Load("Siemens.Simatic.HwConfiguration.Basics.SystemData.S7PlusDataUpload")
        as S7PlusDataUpload;
      return S7PlusDataUpload;
    }
  }
}

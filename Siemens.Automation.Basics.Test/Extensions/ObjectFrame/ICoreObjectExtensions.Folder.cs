using System.ComponentModel;

using Siemens.Automation.Basics;
using Siemens.Automation.ObjectFrame;
using Siemens.Automation.DomainServices.TagService;
using Siemens.Simatic.PlcLanguages.VatService.FolderSnapIn;

namespace YZX.Tia.Extensions.ObjectFrame
{
  public static partial class ICoreObjectExtensions
  {
    public static VatFolderSnapInFactory GetStandardFolderBLObjectFactory(this ICoreObject coreObject)
    {
      IDlc idlc = (IDlc)coreObject.Context;
      IDlcManager idlcManager = idlc.WorkingContext.DlcManager;
      VatFolderSnapInFactory VatFolderSnapInFactory = idlcManager.Load("Siemens.Automation.DomainServices.FolderService.StandardFolderBLObjectFactory")
        as VatFolderSnapInFactory;
      return VatFolderSnapInFactory;
    }

    public static VatFolderSnapInFactory GetVatFolderSnapInFactory(this ICoreObject coreObject)
    {
      IDlc idlc = (IDlc)coreObject.Context;
      IDlcManager idlcManager = idlc.WorkingContext.DlcManager;
      VatFolderSnapInFactory VatFolderSnapInFactory = idlcManager.Load("PlcLanguages.VatService.FolderSnapIn.VatFolderSnapInFactory")
        as VatFolderSnapInFactory;
      return VatFolderSnapInFactory;
    }

    public static ControllerTagsFolderBLObjectFactory GetControllerTagsFolderBLObjectFactory(this ICoreObject coreObject)
    {
      IDlc idlc = (IDlc)coreObject.Context;
      IDlcManager idlcManager = idlc.WorkingContext.DlcManager;
      ControllerTagsFolderBLObjectFactory ControllerTagsFolderBLObjectFactory = idlcManager.Load("Siemens.Automation.DomainServices.TagService.ControllerTagsFolderBL")
        as ControllerTagsFolderBLObjectFactory;
      return ControllerTagsFolderBLObjectFactory;
    }
  }
}

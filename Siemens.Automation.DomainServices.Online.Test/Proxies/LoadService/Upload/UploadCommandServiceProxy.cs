using Siemens.Automation.DomainServices.LoadService;

namespace YZX.Tia.Proxies.LoadService.Upload
{
  public class UploadCommandServiceProxy
  {
    UploadCommandService UploadCommandService;

    public UploadCommandServiceProxy(object ucs)
    {
      UploadCommandService = ucs as UploadCommandService;
    }
  }
}
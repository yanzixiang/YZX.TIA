using Siemens.Automation.Basics;
using Siemens.Automation.DomainServices.LoadService;

namespace YZX.Tia.Proxies.LoadService.Upload
{
  public class UploadServiceProxy
  {
    UploadService UploadService;

    public UploadServiceProxy(object us)
    {
      UploadService = us as UploadService;
    }
    public UploadServiceProxy(IWorkingContext workingContext)
    {
      UploadService = new UploadService(workingContext);
    }


  }
}

using Siemens.Automation.ProjectManager;
using Siemens.Automation.ProjectManager.Impl.Tia;

namespace YZX.Tia.Proxies
{
  public class TiaProjectManagerProxy
  {
    public object TiaProjectManagerObject
    {
      get
      {
        return TiaProjectManager;
      }
    }
    ITiaProjectManager TiaProjectManager;

    internal TiaProjectManagerProxy(TiaProjectManager tpm)
    {
      TiaProjectManager = tpm;
    }

    public bool OpenProjectReadWrite(string path, out object projectO,bool silent=false)
    {
      OpenProjectParams parameters = new OpenProjectParams(path);
      parameters.Access = TiaProjectAccess.ReadWrite;
      parameters.Silent = silent;
      //parameters.OpenCallback = new UpgradeCurrentOpenCallback(new OpenProjectCommandData.CachingOpenFeedbackHandler());
      ITiaProject project;
      bool returnB = TiaProjectManager.OpenProject(parameters, out project);
      if(project != null)
      {
        projectO = new TiaProjectProxy(project);
      }
      else
      {
        projectO = null;
      }
      return returnB;
    }


  }
}

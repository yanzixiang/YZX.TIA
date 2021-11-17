using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Siemens.Automation.Basics.Browsing;
using Siemens.Automation.FrameApplication;
using Siemens.Automation.FrameApplication.Navigation.Project.Main;

namespace YZX.Tia.Proxies.FrameApplication
{
  public class ProjectNavigationViewProxy
  {
    internal ProjectNavigationView ProjectNavigationView;

    

    internal ProjectNavigationViewProxy(ProjectNavigationView view)
    {
      ProjectNavigationView = view;
    }

    public IBrowsableCollection RootObjects
    {
      get
      {
        return ProjectNavigationView.RootObjects;
      }
    }

    #region NavigationTreeView
    internal INavigationTreeView NavigationTreeView
    {
      get
      {
        return ProjectNavigationView as INavigationTreeView;
      }
    }
    public bool IsViewVisible
    {
      get
      {
        return NavigationTreeView.IsViewVisible;
      }
    }

    public void ChangeViewScopes(string[] viewScopes)
    {
      NavigationTreeView.ChangeViewScopes(viewScopes);
    }

    public string ShowBrowsableInView(IBrowsable browsable)
    {
      var result = NavigationTreeView.ShowBrowsableInView(browsable);
      return result.ToString();
    }

    public string ShowParentOfBrowsableInView(IBrowsable browsable, out IBrowsable[] path)
    {
      var result = NavigationTreeView.ShowParentOfBrowsableInView(browsable, out path);
      return result.ToString();
    }

    public bool ContainsBrowsable(IBrowsable browsable)
    {
      return NavigationTreeView.ContainsBrowsable(browsable);
    }
    #endregion

    public string[] GetGenericBrowserScopes()
    {
      return ProjectNavigationView.GetGenericBrowserScopes();
    }



  }
}

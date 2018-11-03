using Siemens.Automation.FrameApplication;
using Siemens.Automation.FrameApplication.ViewManager;

namespace YZX.Tia.Proxies.FrameApplication
{
  public class EditorFrameGroupProxy:FrameGroupBaseProxy
  {
    EditorFrameGroup EditorFrameGroup;
    public EditorFrameGroupProxy(IEditorFrameGroup group):base(group)
    {
      EditorFrameGroup = group as EditorFrameGroup;
    }


  }
}

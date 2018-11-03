using Siemens.Automation.Basics;
using Siemens.Automation.FrameApplication.WindowManager;

namespace YZX.Tia.Proxies.FrameApplication
{
  public class DialogFrameMetaProxy:HierarchyFrameMetaProxy
  {
    DialogFrameMeta DialogFrameMeta;
    internal DialogFrameMetaProxy(DialogFrameMeta meta) : base(meta)
    {
      DialogFrameMeta = meta;
    }

    public bool IsModal
    {
      get
      {
        return DialogFrameMeta.IsModal;
      }
    }

    public MultiLanguageString CheckBoxTitle
    {
      get
      {
        return DialogFrameMeta.CheckBoxTitle;
      }
    }

    public int HelpId
    {
      get
      {
        return DialogFrameMeta.HelpId;
      }
    }

    public string HelpFile
    {
      get
      {
        return DialogFrameMeta.HelpFile;
      }
    }
  }
}

using System.Collections.Generic;

using Siemens.Simatic.PlcLanguages.NetworkEditorFrame.Editor.View;
using Siemens.Simatic.PlcLanguages.BlockEditorFrame.Editor.View;
using Siemens.Simatic.PlcLanguages.BlockEditorFrame;
using Siemens.Simatic.PlcLanguages.FLGraphicEditor;
using Siemens.Simatic.PlcLanguages.BlockEditorFrame.Controls.TagComments;

namespace YZX.Tia.Proxies.NetworkEditorFrame
{
  public class NetworkElementProxy : LanguagePaletteElementProxy
  {
    internal NetworkElement ne;
    public LanguagePaletteBaseElement LanguagePaletteBaseElement
    {
      get
      {
        return ne;
      }
    }

    internal NetworkElementProxy(NetworkElement ne)
    {
      this.ne = ne;
      children = LanguagePaletteBaseElement.GetChildUIControls();
    }

    private List<IUIControl> children;

    public CommandTextBoxElement CommandTextBoxElement
    {
      get
      {
        return children[0] as CommandTextBoxElement;
      }
    }

    internal LanguageUIElementContainer LanguageUIElementContainer
    {
      get
      {
        UIControlWindowlessWrapper wrapper = children[1] as UIControlWindowlessWrapper;
        return wrapper.Instance as LanguageUIElementContainer;
      }
    }

    public CollapsableTextBoxElement CommentElement
    {
      get
      {
        return LanguageUIElementContainer.ChildControls[0] as CollapsableTextBoxElement;
      }
    }

    public TagCommentElement NetworkTagCommentElement
    {
      get
      {
        return LanguageUIElementContainer.ChildControls[1] as TagCommentElement;
      }
    }
    public SimaticFLGraphicEditor SimaticFLGraphicEditor
    {
      get
      {
        return LanguageUIElementContainer.ChildControls[2] as SimaticFLGraphicEditor;
      }
    }
  }
}

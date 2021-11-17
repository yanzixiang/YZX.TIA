using System.Windows.Forms;

using Siemens.Automation.ObjectFrame;

using Siemens.Simatic.PlcLanguages.BlockEditorFrame.Editor.View;
using Siemens.Simatic.PlcLanguages.BlockEditorFrame.Services.Starter;
using Siemens.Simatic.PlcLanguages.BlockEditorFrame.Editor.Logic;

using YZX.Tia.Extensions.NetworkEditorFrame;

namespace YZX.Tia
{
  partial class TiaStarter
  {
    public BlockEditorControlBase GetBlockEditor(ICoreObject pl)
    {

      UIContextHolder = PrimaryProjectUiWorkingContextManagerProxy.IUIContextHolder;
      ProjectUIContext = UIContextHolder.ProjectUIContext;
      IEditorStarter starter = ProjectUIContext.GetEditorStarterFacadeDlc();

      OpenEditorContext openEditorContext = new OpenEditorContext(pl, ProjectUIContext);

      OpenEditorResult result = starter.OpenEditor(openEditorContext);

      if (result.HasEditor)
      {
        var ieditor = result.Editor;
        var editor = ieditor as Editor;
        var IEditorViewFrameProvider = editor as IEditorViewFrameProvider;
        var control = IEditorViewFrameProvider.MainViewFrame.View.Control;
        return control as BlockEditorControlBase;
      }
      else
      {
        return null;
      }
    }
  }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Siemens.Automation.ObjectFrame;

using Siemens.Simatic.PlcLanguages.BlockEditorFrame.Editor.View;
using Siemens.Simatic.PlcLanguages.BlockEditorFrame.Services.Starter;
using Siemens.Simatic.PlcLanguages.BlockEditorFrame.Editor.Logic;


using YZX.Tia.Proxies;
using YZX.Tia.Extensions;

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
        IEditor ieditor = result.Editor;
        Editor editor = ieditor as Editor;
        IEditorViewFrameProvider IEditorViewFrameProvider = editor;
        Control control = IEditorViewFrameProvider.MainViewFrame.View.Control;
        return control as BlockEditorControlBase;
      }
      else
      {
        return null;
      }
    }
  }
}

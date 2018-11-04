using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Siemens.Automation.UI.Controls.Utils;

using Siemens.Simatic.PlcLanguages.FLGraphicEditor.View;
using Siemens.Simatic.PlcLanguages.FLGraphicEditor.View.UserInteraction;
using Siemens.Simatic.PlcLanguages.FLGraphicEditor.View.Selection;
using Siemens.Simatic.PlcLanguages.FLGraphicEditor.Logic;

namespace YZX.Tia.Proxies.Ladder
{
  internal class NullUserInteractor: DefaultUserInteractor
  {
    private DefaultUserInteractor oldManager;

    public NullUserInteractor(DefaultUserInteractor oldManager)
      :base(oldManager.FLGView,oldManager.Navigator,oldManager.SelectionManager)
    {
      this.oldManager = oldManager;
    }

    protected override DragImage CreateAndSetDragImage(IGraphicObject graphicObject, 
      List<Element> data, 
      IDataObject dataObject)
    {
      return null;
    }

    protected override void HandleHover(IGraphicObject graphicObject) { }
    protected override void HandleSelection(IGraphicObject graphicObject) { }
    protected override void OnViewLostFocus(object sender, EventArgs e) { }
    protected override void OnEditBoxLostFocus(object sender, EventArgs e) { }
    protected override void OnViewMouseDoubleClick(object sender, MouseEventArgs e) {
    }
    protected override void OnViewMouseDown(object sender, MouseEventArgs e) { }
    protected override void OnViewMouseUp(object sender, MouseEventArgs e) { }
    protected override void OnViewMouseMove(object sender, MouseEventArgs e) { }
    protected override void OnViewMouseLeave(object sender, EventArgs e) { }
    protected override void OnViewKeyDown(object sender, KeyEventArgs e) {
      FLGComboBox.Hide();
      FLGEditBox.Hide();
    }
    protected override void OnViewKeyPress(object sender, KeyPressEventArgs e) {
      FLGComboBox.Hide();
      FLGEditBox.Hide();
    }
    protected override void OnEditBoxKeyDown(object sender, KeyEventArgs e) {
      FLGComboBox.Hide();
      FLGEditBox.Hide();
    }
    protected override void OnViewDragEnter(object sender, DragEventArgs e) { }
    protected override void OnViewDragOver(object sender, DragEventArgs e) { }
    protected override void OnViewDragDrop(object sender, DragEventArgs dragEventArgs) { }
    protected override void OnViewDragLeave(object sender, EventArgs e) { }

    public new IFLGEditField EditObject(IGraphicObject objectToEdit, 
      EditObjectActivationMode activationMode)
    {
      return null;
    }

    public new void BeginAction(IUserAction action)
    {
    }

    public new void EndAction(IUserAction action, bool bCommit)
    {
    }

    internal new IFLGTextBox FLGEditBox
    {
      get
      {
        return null;
      }
    }
    public new bool IsEditing
    {
      get
      {
        return false;
      }
    }

  }
}

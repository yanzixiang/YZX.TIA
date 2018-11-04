using System;

using Siemens.Automation.UI.Controls;
using Siemens.Automation.FrameApplication;
using Siemens.Automation.Basics;
using Siemens.Automation.FrameApplication.StatusBar;

namespace YZX.Tia.Forms
{
  public class TiaForm: Form
  {
    public TiaForm()
    {
      //Load += TiaForm_Load;
    }

    StatusBarControl StatusBarControl;
    private void TiaForm_Load(object sender, EventArgs e)
    {
      StatusBarControl = new StatusBarControl(TiaStarter.m_ViewApplicationContext);
      Controls.Add(StatusBarControl);
      SizeChanged += TiaForm_SizeChanged;
    }

    private void TiaForm_SizeChanged(object sender, EventArgs e)
    {
      StatusBarControl.Width = Width;
      StatusBarControl.Height = 50;
    }

    protected override void Dispose(bool disposing)
    {
      try
      {
        base.Dispose(disposing);
      }catch(Exception ex)
      {
        Console.WriteLine(ex.ToString());
      }
    }


  }
}

namespace YZX.Tia.Forms
{
  partial class TiaIronPythonConsoleForm
  {
    private void InitializeComponent()
    {
      this.PCVHost = new System.Windows.Forms.Integration.ElementHost();
      this.PCV = new PythonConsoleControl.IronPythonConsoleControl();
      this.SuspendLayout();
      // 
      // PCVHost
      // 
      this.PCVHost.Dock = System.Windows.Forms.DockStyle.Fill;
      this.PCVHost.Location = new System.Drawing.Point(0, 0);
      this.PCVHost.Name = "PCVHost";
      this.PCVHost.Size = new System.Drawing.Size(284, 261);
      this.PCVHost.TabIndex = 0;
      this.PCVHost.Text = "PCVHost";
      this.PCVHost.Child = this.PCV;
      // 
      // PythonConsoleForm
      // 
      this.ClientSize = new System.Drawing.Size(284, 261);
      this.Controls.Add(this.PCVHost);
      this.Name = "PythonConsoleForm";
      this.ResumeLayout(false);

    }

    public System.Windows.Forms.Integration.ElementHost PCVHost;
    public PythonConsoleControl.IronPythonConsoleControl PCV;
  }
}
using System;
using System.Windows.Forms;

using YZX.Tia;

namespace VatViewer
{
  static class Program
  {
    /// <summary>
    /// 应用程序的主入口点。
    /// </summary>
    [STAThread]
    static int Main()
    {
      Application.EnableVisualStyles();
      Application.SetCompatibleTextRenderingDefault(false);
      

      app = new TiaStarter();

      //Application.Run(new Form1());

      app.StartUpPowerManagementThread();
      app.Run(new Form1());


      return 0;
    }

    public static TiaStarter app=null;
  }
}

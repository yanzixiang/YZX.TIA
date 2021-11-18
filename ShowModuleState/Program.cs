using System;
using System.Windows.Forms;

using YZX.Tia;

namespace ShowModuleState
{
  static class Program
  {
    [STAThread]
    static int Main()
    {
      Application.EnableVisualStyles();
      Application.SetCompatibleTextRenderingDefault(false);
      var currentDomain = AppDomain.CurrentDomain;
      currentDomain.AssemblyLoad += CurrentDomain_AssemblyLoad;
      


      app = new TiaStarter();

      app.StartUpPowerManagementThread();
      app.Run(new ShowModuleStateForm());


      return 0;
    }

    private static void CurrentDomain_AssemblyLoad(
      object sender,
      AssemblyLoadEventArgs args)
    {
      var s_dir = @"D:\Program Files\Siemens\Automation\Portal V14\Bin";
      var d_dir = @"E:\Github\yanzixiang\Published\YZX.TIA\ShowModuleState\ShowModuleStateV14\Bin";

      if (args.LoadedAssembly.GlobalAssemblyCache)
      {
      }
      else
      {
        var filename = System.IO.Path.GetFileName(args.LoadedAssembly.CodeBase);
        string s_path, d_path;
        if (filename.EndsWith("resources.DLL")) {
          s_path = System.IO.Path.Combine(s_dir, "en",filename);
          d_path = System.IO.Path.Combine(d_dir, "en",filename);
        } else
        {
          s_path = System.IO.Path.Combine(s_dir, filename);
          d_path = System.IO.Path.Combine(d_dir, filename);
        }
        
        if (System.IO.File.Exists(s_path))
        {
          if (!System.IO.File.Exists(d_path))
          {
            System.IO.File.Copy(s_path, d_path);
          }
        }
        else
        {
          Console.WriteLine(string.Format("{0} Not exists", s_path));
        }
      }
    }

    public static TiaStarter app = null;
  }
}

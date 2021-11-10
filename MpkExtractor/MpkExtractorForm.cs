using System;
using System.IO;
using System.Windows.Forms;
using System.Collections.Generic;


using Siemens.Automation.FileIO;

using YZX.Tia.Proxies.Archiving;
using YZX.Tia.Proxies.FileIO;

namespace MpkExtractor
{
  public partial class MpkExtractorForm : Form
  {
    public MpkExtractorForm()
    {
      InitializeComponent();
      InitNlogViewer();

      Load += Form1_Load;
    }

    #region NlogViewer
    NlogViewer.NlogViewer nlogViewer;
    NLog.Logger log;
    private void InitNlogViewer()
    {
      nlogViewer = new NlogViewer.NlogViewer();
      nlogViewer.MessageWidth = 400;
      LogHost.Child = nlogViewer;

     log = NLog.LogManager.GetLogger("YZX");
    }
    #endregion

    private void Form1_Load(object sender, EventArgs e)
    {
      log.Info(string.Format("加载Dlc成功"));
      log.Info(string.Format("程序加载成功"));
    }

    PackagingImplementationBaseProxy proxy;
    IList<string> FileNames;
    string FilePath;


    IFileService FileService = 
      FileServiceFacade.FileService;

    #region 按钮
    private void OpenProjectButton_Click(object sender, EventArgs e)
    {
      using (var openFileDialog = new OpenFileDialog())
      {
        openFileDialog.InitialDirectory = "c:\\";
        openFileDialog.Filter = "TIA 配置文件包(*.mpk)|*.mpk";
        openFileDialog.FilterIndex = 2;
        openFileDialog.RestoreDirectory = true;
        if (openFileDialog.ShowDialog() == DialogResult.OK)
        {
          FilePath = openFileDialog.FileName;
          proxy = new PackagingImplementationBaseProxy(FilePath);

          if(FileNames != null)
          {
            FileNames = null;
          }

          FileNames = proxy.GetFiles();
          foreach(var file in FileNames)
          {
            log.Info(file);
          }
          log.Info(string.Format("{0}打开完成", FilePath));
        }
      }
    }

    private void ExportButton_Click(object sender, EventArgs e)
    {
      var folderBrowserDialog1 = new FolderBrowserDialog();
      folderBrowserDialog1.SelectedPath = Path.GetDirectoryName(FilePath);
      folderBrowserDialog1.ShowNewFolderButton = true;

      var result = folderBrowserDialog1.ShowDialog();
      if (result == DialogResult.OK)
      {
        var SaveDirectory = folderBrowserDialog1.SelectedPath;

        proxy.Unpack(SaveDirectory);

        log.Info(string.Format("{0}导出完成",FilePath));
      }
    }

    private void CloseMpk()
    {
      proxy.Dispose();
      proxy = null;
      if (FileNames != null)
      {
        FileNames = null;
      }
      log.Info(string.Format("{0}关闭完成", FilePath));
    }

    private void CloseProjectButton_Click(object sender, EventArgs e)
    {
      CloseMpk();
    }

    private void ExitButton_Click(object sender, EventArgs e)
    {
      try
      {
        log.Info(string.Format("开始关闭程序"));
      }catch(Exception ex)
      {
      }
      finally
      {
        Close();
        Application.Exit();
      }
    }

    private void AddFileButton_Click(object sender, EventArgs e)
    {
      if(proxy == null)
      {
        log.Info(string.Format("未打开Mpk"));
        return;
      }

      using (var openFileDialog = new OpenFileDialog())
      {
        openFileDialog.InitialDirectory = "c:\\";
        openFileDialog.Filter = "TIA 配置文件(*.xml)|*.xml";
        openFileDialog.FilterIndex = 2;
        openFileDialog.RestoreDirectory = true;
        if (openFileDialog.ShowDialog() == DialogResult.OK)
        {
          FilePath = openFileDialog.FileName;
          var FileName = Path.GetFileName(FilePath);
          
          var package = FileService.CreatePackageForWrite(VirtualFileSystem.Installation, "YZX", "AL02.mpk");
          //package => WriteableMpkDirectory
          var packageProxy = new WriteableMpkDirectoryProxy(package);
          var MetaPackageProxy = packageProxy.GetMetaPackageImplementationProxy();


          MetaPackageProxy.Add(FileName, File.Open(FilePath, FileMode.Open));

          var arch = MetaPackageProxy.Package;
          var writer = arch as Siemens.Automation.Archiving.IWriteableDirectory;
          var zipProxy = new ZipCreatorProxy(writer);
          zipProxy.CloseCurrentFile();


          log.Info(string.Format("添加{0}完成", FilePath));
        }
      }
    }

    private void SaveMpkButton_Click(object sender, EventArgs e)
    {
      if (proxy == null)
      {
        log.Info(string.Format("未打开Mpk"));
        return;
      }

      using (var openFileDialog = new SaveFileDialog())
      {
        openFileDialog.InitialDirectory = "c:\\";
        openFileDialog.Filter = "TIA 配置文件包(*.mpk)|*.mpk";
        openFileDialog.FilterIndex = 2;
        openFileDialog.RestoreDirectory = true;
        if (openFileDialog.ShowDialog() == DialogResult.OK)
        {
          FilePath = openFileDialog.FileName;

          proxy.Save(FilePath);

          FileNames = proxy.GetFiles();
          foreach (var file in FileNames)
          {
            log.Info(file);
          }
          log.Info(string.Format("{0}保存完成", FilePath));
        }
      }
    }


    #endregion

    
  }
}

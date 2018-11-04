# -*- coding: utf-8 -*-
import clr
from System import *
from System.IO import *
from System.Collections.Generic import *
from System.Diagnostics import *

NetHome = "C:\\Program Files (x86)\\Reference Assemblies\\Microsoft\Framework\\.NETFramework\\v4.0\\"

TiaHome = "D:\\Program Files\\Siemens\\Automation\\Portal V14\\Bin\\"
TiaHome32 = "D:\\Program Files\\Siemens\\Automation\\Portal V14\\Win32\\Bin\\"
Debugger.Launch()

clr.AddReferenceToFileAndPath(TiaHome32 + "siemens.automation.utilities.dll")
clr.AddReferenceToFileAndPath(TiaHome + "YZX.Tia.dll")
from YZX.Tia.Proxies import *
from YZX.Tia.Extensions import *

mpks = {}

BasePath = "D:\\Program Files\\Siemens\\Automation\\Portal V14\\Meta\\" 
BasePath = "D:\Program Files\Siemens\Automation\Portal V14\Data\IECPL"
BasePath = "D:\Program Files\Siemens\Automation\Portal V14\Data\IPI"
BasePath = "D:\Program Files\Siemens\Automation\Portal V14\Data\Hwcn"

def EnumerateFiles():
  print Directory
  files = Directory.EnumerateFiles(BasePath,"*.mpk",SearchOption.AllDirectories)
  
  for f in files:
    print f
    pib = PackagingImplementationBaseProxy(f)
    pib.Unpack()
    fi = FileInfo(f)
    try:
      fi.Delete()
    except:
      print "删除" + f + "失败"

def RunOneTime():
  EnumerateFiles()
RunOneTime()
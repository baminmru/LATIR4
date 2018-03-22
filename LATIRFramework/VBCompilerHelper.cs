using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using System.IO;

namespace LATIR2Framework
{
    public class VBCompilerHelper
    {

        public static void CompileProject(string IDEPath, string ProjectPath, bool IsDebug)
        {
            string compileStr = string.Empty;
            compileStr += "\"" + IDEPath + " \"";
            compileStr += " \"" + ProjectPath + "\" /t:Rebuild";


            //if (IsDebug)
            //{
            //    compileStr += " /p:Configuration=\"Debug|Any CPU\"";
            //}
            //else
            //{
            //    compileStr += " /p:Configuration=\"Debug|Any CPU\"";
            //}
            string CMDName = ProjectPath.Substring(0, ProjectPath.LastIndexOf(".")) + "_Compile.cmd";
            if (File.Exists(CMDName))
            {
                File.Delete(CMDName);
            }
            FileStream st = File.Create(CMDName);
            StreamWriter sw = new StreamWriter(st, Encoding.GetEncoding(866));
            sw.WriteLine(compileStr);
            // sw.WriteLine("pause");
            sw.Close();
            st.Close();
            try
            {
                Process pr = Process.Start("\"" + CMDName + "\"");
                DateTime now = DateTime.Now;
                while (!pr.HasExited)
                {
                    TimeSpan ts = DateTime.Now - now;
                    if (ts.Minutes > 5)
                    {
                        pr.Kill();
                        break;
                    }
                }
            }
            finally 
            {
                try
                {
                    //File.Delete(CMDName);
                }
                catch { }
            }
        }

    }
}

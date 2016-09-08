using System;
using System.Collections.Generic;
using System.Text;

namespace LATIR2Framework
{
    public class StringHelper
    {

        public static string MakeParamComment(string name, string ParamType, ref string comment) 
        {
		    string s = string.Empty;
		    s = "<param name=\"" + name + "\"> Тип параметра:" + ParamType + ". " + comment + "</param>";
            return s;
        }
	
	
	    public static string MakeRetvalComment(string value, ref string comment) 
        {
		    string s = string.Empty; 
		    s = "<retval name=\"" + value + "\">" + comment + "</retval>";
		    return s;
	    }

        public static string MakeComment(string summary)
        {
            return MakeComment(summary, string.Empty);
        }

        public static string MakeComment(string summary, string value)
        {
            return MakeComment(summary, value, string.Empty);
        }

        public static string MakeComment(string summary, string value, string returns)
        {
            return MakeComment(summary, value, returns, string.Empty);
        }

        public static string MakeComment(string summary, string value, string returns, string remarks)
        {
            return MakeComment(summary, value, returns, remarks, string.Empty);
        }

        public static string MakeComment(string summary, string value, string returns, string remarks, string ParamSection)
        {
            string rem = string.Empty;
            return MakeComment(summary, value, returns, remarks, ParamSection, ref rem );
        }

        public static string MakeComment(string summary, string value, string returns, string remarks, string ParamSection, ref string RetvalsSection)
        {
            string s = string.Empty;
            string[] a;
            s = Environment.NewLine;
            s = s + Environment.NewLine + "''' <summary>";
            s = s + Environment.NewLine + "'''" + LATIR2Framework.StringHelper.NoLF(summary);
            s = s + Environment.NewLine + "''' </summary>";
            //if (LATIR2Framework.StringHelper.NoLF(remarks).Trim() != String.Empty)
            //{
            //    s = s + Environment.NewLine + "''' <value>";
            //    s = s + Environment.NewLine + "'''" + LATIR2Framework.StringHelper.NoLF(value);
            //    s = s + Environment.NewLine + "''' </value>";
            //}
            string[] del = { Environment.NewLine };
            if (ParamSection != string.Empty)
            {
                a = ParamSection.Split(del, StringSplitOptions.None);
                for (int i = a.GetLowerBound(0); i < a.GetUpperBound(0); i++)
                {
                    s = s + Environment.NewLine + "''' <param> " + LATIR2Framework.StringHelper.NoLF(a[i]) +"</param>";
                }
            }
            if (LATIR2Framework.StringHelper.NoLF(returns).Trim() != string.Empty)
            {
                s = s + Environment.NewLine + "''' <returns>";
                s = s + Environment.NewLine + "'''" + LATIR2Framework.StringHelper.NoLF(returns);
                s = s + Environment.NewLine + "''' </returns>";
            }
            if (LATIR2Framework.StringHelper.NoLF(RetvalsSection).Trim() != string.Empty)
            {
                s = s + Environment.NewLine + "''' <returns>";
                a = RetvalsSection.Split(del, StringSplitOptions.None);
                for (int i = a.GetLowerBound(0); i < a.GetUpperBound(0); i++)
                {
                    s = s + Environment.NewLine + "'''" + LATIR2Framework.StringHelper.NoLF(a[i]);
                }
                s = s + Environment.NewLine + "''' </returns>";
            }
            //if (LATIR2Framework.StringHelper.NoLF(remarks).Trim() == string.Empty)
            //{
                s = s + Environment.NewLine + "''' <remarks>";
                s = s + Environment.NewLine + "'''" + LATIR2Framework.StringHelper.NoLF(value);
                s = s + Environment.NewLine + "''' </remarks>";
            //}else{
            //    s = s + Environment.NewLine + "''' <remarks>";
            //    s = s + Environment.NewLine + "'''" + LATIR2Framework.StringHelper.NoLF(remarks);
            //    s = s + Environment.NewLine + "''' </remarks>";
            //}

            
            return  s;
        }


        public static string GetScript2(MTZMetaModel.MTZMetaModel.FIELDVALIDATOR_col scol, string tid)
        {
            try
            {
                Guid ID = new Guid(tid);
                for (int i = 1; i <= scol.Count; i++)
                {
                    if (scol.Item(i).Target.ID.Equals(ID))
                    {
                        return scol.Item(i).Code;
                    }
                }
            }
            catch { }
            return string.Empty;
        }

        public static string NoLF(string s )
        {
            string result = string.Empty;
            result = s.Replace(Environment.NewLine, " ");
            result = result.Replace(char.ConvertFromUtf32(9), " ");
            result = result.Replace(char.ConvertFromUtf32(10), " ");
            result = result.Replace(char.ConvertFromUtf32(13), " ");
            result = result.Replace("<", "(");
            result = result.Replace(">", ")");
            result = result.Replace("\"", " ");
            
            return result;
        }

        // Util function
	    public string CommentSplit(string Prefix, string  c) 
        {
		    string outS  = string.Empty;
            char[] sep = Environment.NewLine.ToCharArray();
            string[] ss = c.Split(sep);
            for (int i = ss.GetLowerBound(0); i <= ss.GetUpperBound(0); i++ )
            {
                outS += Prefix + ss[i];
            }
    		return outS;
        }
	
        public static void SetExt(ref LATIRGenerator.Response o, string name, ref string  ext)
        {
            o.ModuleName = name;
            o.Project().Modules[name].File = name + "." + ext;
        }
    }
}

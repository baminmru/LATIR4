using System;
using System.Collections.Generic;
using System.Text;

namespace LATIR2Framework
{
    public class FieldTypesHelper
    {

        public static int GetFieldSize(MTZMetaModel.MTZMetaModel.FIELD fld, string tid)
        {
            int gfs = 0;
            //' On Error GoTo bye
            try
            {
                string TypeID = string.Empty;
                Guid ID = new Guid(tid);
                MTZMetaModel.MTZMetaModel.FIELDTYPE ft = (MTZMetaModel.MTZMetaModel.FIELDTYPE)fld.FieldType;
                if (ft == null) return 0;
                for (int i = 1; i <= ft.FIELDTYPEMAP.Count; i++)
                {
                    if (ft.FIELDTYPEMAP.Item(i).Target.ID.Equals(ID))
                    {
                        if (ft.TypeStyle == MTZMetaModel.MTZMetaModel.enumTypeStyle.TypeStyle_Skalyrniy_tip)
                        {
                            gfs = int.Parse(ft.FIELDTYPEMAP.Item(i).FixedSize.ToString()) ;
                        }
                        break;
                    }
                }
                if (gfs == 0) gfs = int.Parse(fld.DataSize.ToString());
            }
            catch { }

            return gfs;
        }

        public static string MapFieldTypeToPhysicalType(MTZMetaModel.MTZMetaModel.Application MetaModel, Guid TypeID, string tid, bool SpecialForEnum)
        {
            Guid tidID = new Guid(tid);
            return MapFieldTypeToPhysicalType(MetaModel, TypeID.ToString(), tidID, SpecialForEnum);
        }

        public static string MapFieldTypeToPhysicalType(MTZMetaModel.MTZMetaModel.Application m, string TypeID, Guid tidID, bool SpecialForEnum)
        {
            string result = string.Empty; // "String";
            try
            {
                MTZMetaModel.MTZMetaModel.FIELDTYPE FieldType = null;
                FieldType = m.FIELDTYPE.Item(TypeID);
                if (FieldType == null)
                {
                    return result;
                }
                for (int i = 1; i <= FieldType.FIELDTYPEMAP.Count; i++)
                {
                    MTZMetaModel.MTZMetaModel.FIELDTYPEMAP FIELDTYPEMAP = FieldType.FIELDTYPEMAP.Item(i);
                    if (FIELDTYPEMAP.Target.ID.Equals(tidID))
                    {
                        if (SpecialForEnum && FieldType.TypeStyle == MTZMetaModel.MTZMetaModel.enumTypeStyle.TypeStyle_Perecislenie)
                        {
                            result = "enum" + MakeValidName(FieldType.Name);
                        }
                        else
                        {
                            result = FieldType.FIELDTYPEMAP.Item(i).StoageType;
                        }
                        break;
                    }
                }
            }
            catch
            {
            }
            return result;
        }

        public static string MakeValidName(string name)
        {
            string s = string.Empty;
            string outS = string.Empty;
            string changes = string.Empty;
            string[] arr = new string[] { "_", "PLS", "MNS", "LAPS", "WAV", "APS", "DAPS", "SLASH", "BSLASH", "FENCE", "STAR", "DDOT", "DOT", "COMA", "LS", "GT", "QMARK", "BCLS", "BOPN", "WOPN", "WCLS", "IMARK", "AT", "SHARP", "DOLL", "PCNT", "ROOF", "AND", "OPN", "CLS", "EQ", "XX", "XX", "XX", "XX" };
            string transfr = string.Empty;
            string transto = string.Empty;
            string begs = "_1234567890";

            transfr = "éöóêåíãøùçõúôûâàïðîëäæýÿ÷ñìèòüáþ¸ÉÖÓÊÅÍÃØÙÇÕÚÔÛÂÀÏÐÎËÄÆÝß×ÑÌÈÒÜÁÞ¨";
            transto = "ycukengsszh_fivaproldgeycsmit_buyYCUKENGSSZH_FIVAPROLDGEYCSMIT_BUE";
            changes = " +-`~'\"/\\|*:.,<>?][{}!@#$%^&()=";
            s = name;
            int changeIt;
            for (int i = 0; i < transfr.Length; i++)
            {
                s = s.Replace(transfr.Substring(i, 1), transto.Substring(i, 1));
            }

            for (int i = 0; i < s.Length; i++)
            {
                changeIt = -1;
                for (int j = 0; j < changes.Length; j++)
                {
                    if (s.Substring(i, 1) == changes.Substring(j, 1))
                    {
                        changeIt = j;
                        break;
                    }
                }
                if (changeIt == -1)
                {
                    outS = outS + s.Substring(i, 1);
                }
                else
                {
                    outS = outS + arr[changeIt];
                }
            }
            s = outS;
            if (begs.IndexOf(s.Substring(0, 1)) > -1)
            {
                s = "cls_" + s;
            }
            return s;
        }

        public static string MapDBtype(string t)
        {
            string t1 = string.Empty;
            if (t.ToUpper().Substring(0, 4) == "ENUM")
            {
                t1 = "dbtype.int16";
            }
            else
            {
                switch (t.ToUpper())
                {
                    case "STRING":
                        t1 = "dbtype.string";
                        break;
                    case "INTEGER":
                        t1 = "dbtype.Int16";
                        break;
                    case "LONG":
                        t1 = "dbtype.Int32";
                        break;
                    case "DOUBLE":
                        t1 = "dbtype.double";
                        break;
                    case "DATE":
                        t1 = "dbtype.DATETIME";
                        break;
                    case "FLOAT":
                        t1 = "dbtype.single";
                        break;
                    case "BOOLEAN":
                        t1 = "dbtype.boolean";
                        break;
                    case "GUID":
                        t1 = "dbtype.GUID";
                        break;
                    case "FILE":
                        t1 = "dbtype.BINARY";
                        break;
                    case "OBJECT":
                        t1 = "dbtype.Binary";
                        break;
                    default:
                        t1 = "dbtype.Binary";
                        break;
                }
            }
            return t1;
        }

        public static string MapSysType(string t)
        {
            string t1 = string.Empty;
            if (t.ToUpper().Substring(0, 4) == "ENUM")
            {
                t1 = "GetType(System.Int16)";
            }
            else
            {
                switch (t.ToUpper())
                {
                    case "STRING":
                        t1 = "Gettype(System.string)";
                        break;
                    case "INTEGER":
                        t1 = "Gettype(System.Int16)";
                        break;
                    case "LONG":
                        t1 = "Gettype(System.Int32)";
                        break;
                    case "DOUBLE":
                        t1 = "GetType(System.double)";
                        break;
                    case "DATE":
                        t1 = "GetType(System.DateTime)";
                        break;
                    case "FLOAT":
                        t1 = "GetType(System.single)";
                        break;
                    case "BOOLEAN":
                        t1 = "GetType(System.boolean)";
                        break;
                    case "GUID":
                        t1 = "GetType(System.guid)";
                        break;
                    case "FILE":
                        t1 = "GetType(System.object)";
                        break;
                    case "OBJECT":
                        t1 = "GetType(System.object)";
                        break;
                    default:
                        t1 = "Gettype(System.object)";
                        break;
                }
            }
            return t1;
        }
    }
}

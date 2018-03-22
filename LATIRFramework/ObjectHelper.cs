using System;
using System.Collections.Generic;
using System.Text;

namespace LATIR2Framework
{
    public class ObjectHelper
    {

        public static LATIR2.Document.Doc_Base GetDictionary(string OT, LATIR2.Manager Manager)
        {
            System.Data.DataTable dt;
            LATIR2.Document.Doc_Base pRes = null;
            dt = Manager.Session.GetData("select InstanceID from Instance where ObjType='" + OT + "'");
            if (dt != null)
            {
                if (dt.Rows.Count > 0)
                    pRes = Manager.GetInstanceObject(new System.Guid(dt.Rows[0]["InstanceID"].ToString()));
            }
            try
            {
                if (pRes == null && dt.Rows.Count <= 0)
                {
                    // create new one
                    Guid IID = new Guid();
                    string sName = GetNameFromObjectType(OT, Manager);
                    pRes = Manager.NewInstance(IID, sName, string.Empty, string.Empty);
                }
            }
            catch { }

            return pRes;
        }

        public static string GetNameFromObjectType(string OT, LATIR2.Manager Manager)
        {
            string sRes = string.Empty;
            System.Data.DataTable dTN;
            dTN = Manager.Session.GetData("select the_comment from objecttype where Name='" + OT + "'");
            if (dTN != null)
            {
                if (dTN.Rows.Count > 0)
                {
                    sRes = dTN.Rows[0]["the_comment"].ToString();
                }
            }
            return sRes;
        }

        public static string GetDynamicFieldFilter(MTZMetaModel.MTZMetaModel.DINAMICFILTERSCRIPT_col pDynamicFLTColl, string tid)
        {
            MTZMetaModel.MTZMetaModel.DINAMICFILTERSCRIPT objItem = null;
            Guid ID = new Guid(tid);
            for (int i = 1; i <= pDynamicFLTColl.Count; i++)
            {
                objItem = pDynamicFLTColl.Item(i);
                if (objItem.Target.ID.Equals(ID))
                {
                    return objItem.Code;
                }
            }
            return string.Empty;
        }

        //Count Stucts for mode
        public static int CountStructs(MTZMetaModel.MTZMetaModel.PART_col s, string mode)
        {
            MTZMetaModel.MTZMetaModel.OBJECTTYPE ot = null;
            MTZMetaModel.MTZMetaModel.OBJECTMODE om = null;
            MTZMetaModel.MTZMetaModel.OBJECTMODE dom = null;
            MTZMetaModel.MTZMetaModel.PART part = (MTZMetaModel.MTZMetaModel.PART)s.Parent;
            // Find object type
            ot = ObjectTypeHelper.TypeForStruct(part);
            // Find default mode
            for (int i = 1; i <= ot.OBJECTMODE.Count; i++)
            {
                if (ot.OBJECTMODE.Item(i).DefaultMode == MTZMetaModel.MTZMetaModel.enumBoolean.Boolean_Da)
                {
                    dom = ot.OBJECTMODE.Item(i);
                    break;
                }
            }

            for (int i = 1; i <= ot.OBJECTMODE.Count; i++)
            {
                if (ot.OBJECTMODE.Item(i).Name == mode)
                {
                    om = ot.OBJECTMODE.Item(i);
                    break;
                }
            }

            if (om == null)
            {
                om = dom;
            }

            if (om == null)
            {
                return int.Parse(s.Count.ToString());
            }

            int CNT;
            bool OK = false;
            CNT = 0;
            for (int j = 1; j <= s.Count; j++)
            {
                OK = true;
                for (int i = 1; i <= om.STRUCTRESTRICTION.Count; i++)
                {
                    MTZMetaModel.MTZMetaModel.PART Struct = (MTZMetaModel.MTZMetaModel.PART)om.STRUCTRESTRICTION.Item(i).Struct;
                    if (Struct.ID.Equals(s.Item(j).ID))
                    {
                        if (om.STRUCTRESTRICTION.Item(i).AllowRead == MTZMetaModel.MTZMetaModel.enumBoolean.Boolean_Da)
                        {
                            OK = true;
                        }
                        else
                        {
                            OK = false;
                        }
                        break;
                    }
                }
            }
            if (OK)
            {
                CNT++;
            }
            return CNT;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="st"></param>
        /// <param name="mode"></param>
        /// <returns>True if struct exists in this mode</returns>
        public static bool IsPresent(MTZMetaModel.MTZMetaModel.PART st, string mode)
        {
            MTZMetaModel.MTZMetaModel.OBJECTTYPE ot = null;
            MTZMetaModel.MTZMetaModel.OBJECTMODE om = null;
            MTZMetaModel.MTZMetaModel.OBJECTMODE dom = null;


            //MTZMetaModel.MTZMetaModel.PART obj = (MTZMetaModel.MTZMetaModel.PART)st.Parent.Parent;
            // Find object type 
            ot = ObjectTypeHelper.TypeForStruct(st);

            for (int i = 1; i <= ot.OBJECTMODE.Count; i++)
            {
                if (ot.OBJECTMODE.Item(i).DefaultMode == MTZMetaModel.MTZMetaModel.enumBoolean.Boolean_Da)
                {
                    dom = ot.OBJECTMODE.Item(i);
                    break;
                }
            }

            for (int i = 1; i <= ot.OBJECTMODE.Count; i++)
            {
                if (ot.OBJECTMODE.Item(i).Name == mode)
                {
                    om = ot.OBJECTMODE.Item(i);
                    break;
                }
            }

            if (om == null)
            {
                om = dom;
            }

            if (om == null)
            {
                return true;
            }
            bool OK = true;
            for (int i = 1; i <= om.STRUCTRESTRICTION.Count; i++)
            {
                if ( om.STRUCTRESTRICTION.Item(i).Struct != null ){
                    if (om.STRUCTRESTRICTION.Item(i).Struct.ID.Equals(st.ID))
                    {
                        if (om.STRUCTRESTRICTION.Item(i).AllowRead == MTZMetaModel.MTZMetaModel.enumBoolean.Boolean_Da)
                        {
                            OK = true;
                        }
                        else
                        {
                            OK = false;
                        }
                        break;
                    }
                }
            }
            if (OK) return true;
            return false;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="st"></param>
        /// <param name="mode"></param>
        /// <returns>True if struct exists in this mode</returns>
        public static MTZMetaModel.MTZMetaModel.STRUCTRESTRICTION GetPartRestriction (MTZMetaModel.MTZMetaModel.PART st, string mode)
        {
            MTZMetaModel.MTZMetaModel.OBJECTTYPE ot = null;
            MTZMetaModel.MTZMetaModel.OBJECTMODE om = null;
            MTZMetaModel.MTZMetaModel.OBJECTMODE dom = null;


            // Find object type 
            ot = ObjectTypeHelper.TypeForStruct(st);

            for (int i = 1; i <= ot.OBJECTMODE.Count; i++)
            {
                if (ot.OBJECTMODE.Item(i).DefaultMode == MTZMetaModel.MTZMetaModel.enumBoolean.Boolean_Da)
                {
                    dom = ot.OBJECTMODE.Item(i);
                    break;
                }
            }

            for (int i = 1; i <= ot.OBJECTMODE.Count; i++)
            {
                if (ot.OBJECTMODE.Item(i).Name == mode)
                {
                    om = ot.OBJECTMODE.Item(i);
                    break;
                }
            }

            if (om == null)
            {
                om = dom;
            }

            if (om == null)
            {
                return null;
            }
        
            for (int i = 1; i <= om.STRUCTRESTRICTION.Count; i++)
            {
                if (om.STRUCTRESTRICTION.Item(i).Struct.ID.Equals(st.ID))
                {
                    return om.STRUCTRESTRICTION.Item(i);
                }
            }
            
            return null;
        }

        //Count fields for mode
        public static int CountFields(MTZMetaModel.MTZMetaModel.PART s, string mode)
        {
            MTZMetaModel.MTZMetaModel.OBJECTTYPE ot = null;
            MTZMetaModel.MTZMetaModel.OBJECTMODE om = null;
            MTZMetaModel.MTZMetaModel.OBJECTMODE dom = null;
            MTZMetaModel.MTZMetaModel.PART obj = (MTZMetaModel.MTZMetaModel.PART)s.Parent.Parent;
            ot = ObjectTypeHelper.TypeForStruct(obj);
            for (int i = 1; i <= ot.OBJECTMODE.Count; i++)
            {
                if (ot.OBJECTMODE.Item(i).DefaultMode == MTZMetaModel.MTZMetaModel.enumBoolean.Boolean_Da)
                {
                    dom = ot.OBJECTMODE.Item(i);
                    break;
                }
            }
            for (int i = 1; i <= ot.OBJECTMODE.Count; i++)
            {
                if (ot.OBJECTMODE.Item(i).Name == mode)
                {
                    om = ot.OBJECTMODE.Item(i);
                    break;
                }
            }
            if (om == null)
            {
                om = dom;
            }
            if (om == null)
            {
                return int.Parse(s.FIELD.Count.ToString());
            }

            int CNT = 0;
            bool OK = false;
            for (int j = 1; j <= s.FIELD.Count; j++)
            {
                OK = true;
                for (int i = 1; i <= om.FIELDRESTRICTION.Count; i++)
                {
                    if (om.FIELDRESTRICTION.Item(i).ThePart.ID.Equals(s.ID))
                    {
                        if (om.FIELDRESTRICTION.Item(i).TheField.ID.Equals(s.FIELD.Item(j).ID))
                        {
                            if (om.FIELDRESTRICTION.Item(i).AllowRead == MTZMetaModel.MTZMetaModel.enumBoolean.Boolean_Da)
                            {
                                OK = true;
                            }
                            else
                            {
                                OK = false;
                            }
                        }
                        break;
                    }

                }
                if (OK) CNT++;
            }
            return CNT;
        }


        public static bool IsFieldPresent(MTZMetaModel.MTZMetaModel.PART s, string FieldID, string mode)
        {
            return IsFieldPresent(s, new Guid(FieldID), mode);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="s"></param>
        /// <param name="FieldID"></param>
        /// <param name="mode"></param>
        /// <returns>Yes if field exists for mode</returns>
        public static bool IsFieldPresent(MTZMetaModel.MTZMetaModel.PART s, Guid FieldID, string mode)
        {
            MTZMetaModel.MTZMetaModel.OBJECTTYPE ot = null;
            MTZMetaModel.MTZMetaModel.OBJECTMODE om = null;
            MTZMetaModel.MTZMetaModel.OBJECTMODE dom = null;
            //MTZMetaModel.MTZMetaModel.PART obj = (MTZMetaModel.MTZMetaModel.PART)s.Parent.Parent;
            ot = ObjectTypeHelper.TypeForStruct(s);
            for (int i = 1; i <= ot.OBJECTMODE.Count; i++)
            {
                if (ot.OBJECTMODE.Item(i).DefaultMode == MTZMetaModel.MTZMetaModel.enumBoolean.Boolean_Da)
                {
                    dom = ot.OBJECTMODE.Item(i);
                    break;
                }
            }
            for (int i = 1; i <= ot.OBJECTMODE.Count; i++)
            {
                if (ot.OBJECTMODE.Item(i).Name == mode)
                {
                    om = ot.OBJECTMODE.Item(i);
                    break;
                }
            }
            if (om == null)
            {
                om = dom;
            }

            if (om == null)
            {
                return true;
            }

            bool OK = true;
            for (int i = 1; i <= om.FIELDRESTRICTION.Count; i++)
            {
                if (om.FIELDRESTRICTION.Item(i).ThePart != null)
                {
                    MTZMetaModel.MTZMetaModel.FIELDRESTRICTION FIELDRESTRICTION = om.FIELDRESTRICTION.Item(i);
                    if (FIELDRESTRICTION.ThePart.ID.Equals(s.ID))
                    {
                        if (FIELDRESTRICTION.TheField.ID.Equals(FieldID))
                        {
                            if (om.FIELDRESTRICTION.Item(i).AllowRead == MTZMetaModel.MTZMetaModel.enumBoolean.Boolean_Da)
                            {
                                OK = true;
                            }
                            else
                            {
                                OK = false;
                            }
                            break;
                        }
                    }
                }
                else
                {
                    om.FIELDRESTRICTION.Item(i).Delete();
                }
            }
            return OK;
        }

        public static bool IsFieldReadOnly(MTZMetaModel.MTZMetaModel.PART s, string FieldID, string mode)
        {
            return IsFieldReadOnly(s, new Guid(FieldID), mode);
        }

        public static bool IsFieldReadOnly(MTZMetaModel.MTZMetaModel.PART s, Guid FieldID, string mode)
        {
            MTZMetaModel.MTZMetaModel.OBJECTTYPE ot = null;
            MTZMetaModel.MTZMetaModel.OBJECTMODE om = null;
            MTZMetaModel.MTZMetaModel.OBJECTMODE dom = null;
            MTZMetaModel.MTZMetaModel.FIELD fld = null;
            //MTZMetaModel.MTZMetaModel.PART obj = (MTZMetaModel.MTZMetaModel.PART)s.Parent.Parent;
            ot = ObjectTypeHelper.TypeForStruct(s);


            for (int i = 1; i <= ot.OBJECTMODE.Count; i++)
            {
                if (ot.OBJECTMODE.Item(i).DefaultMode == MTZMetaModel.MTZMetaModel.enumBoolean.Boolean_Da)
                {
                    dom = ot.OBJECTMODE.Item(i);
                    break;
                }
            }


            for (int i = 1; i <= ot.OBJECTMODE.Count; i++)
            {
                if (ot.OBJECTMODE.Item(i).Name == mode)
                {
                    om = ot.OBJECTMODE.Item(i);
                    break;
                }
            }

            if (om == null)
            {
                om = dom;
            }

            if (om == null)
            {
                fld = (MTZMetaModel.MTZMetaModel.FIELD)(s.FIELD.Item(FieldID.ToString()));
                if (fld != null)
                {
                    if (fld.TheStyle.ToLower().Contains("readonly") )
                        return true;
                    else
                        return false;
                }
                return false;
            }

            bool OK = false;
            for (int i = 1; i <= om.FIELDRESTRICTION.Count; i++)
            {
                if (om.FIELDRESTRICTION.Item(i).ThePart != null)
                {
                    if (om.FIELDRESTRICTION.Item(i).ThePart.ID.Equals(s.ID))
                    {
                        if (om.FIELDRESTRICTION.Item(i).TheField != null)
                        {
                            if (om.FIELDRESTRICTION.Item(i).TheField.ID.Equals(FieldID))
                            {
                                if (om.FIELDRESTRICTION.Item(i).AllowModify  == MTZMetaModel.MTZMetaModel.enumBoolean.Boolean_Da)
                                {
                                   return false;
                                }
                                else
                                {
                                    return true;
                                }
                                
                            }
                        }
                    }
                }
            }
            fld = (MTZMetaModel.MTZMetaModel.FIELD)(s.FIELD.Item(FieldID.ToString()));
            if (fld != null)
            {
                if (fld.TheStyle.ToLower().Contains("readonly"))
                    return true;
                else
                    return false;
            }
            return false;
        }



        public static bool IsFieldMandatory(MTZMetaModel.MTZMetaModel.PART s, Guid FieldID, string mode)
        {
            MTZMetaModel.MTZMetaModel.FIELD fld = null;
            MTZMetaModel.MTZMetaModel.OBJECTTYPE ot = null;
            MTZMetaModel.MTZMetaModel.OBJECTMODE om = null;
            MTZMetaModel.MTZMetaModel.OBJECTMODE dom = null;
            
            ot = ObjectTypeHelper.TypeForStruct(s);


            for (int i = 1; i <= ot.OBJECTMODE.Count; i++)
            {
                if (ot.OBJECTMODE.Item(i).DefaultMode == MTZMetaModel.MTZMetaModel.enumBoolean.Boolean_Da)
                {
                    dom = ot.OBJECTMODE.Item(i);
                    break;
                }
            }


            for (int i = 1; i <= ot.OBJECTMODE.Count; i++)
            {
                if (ot.OBJECTMODE.Item(i).Name == mode)
                {
                    om = ot.OBJECTMODE.Item(i);
                    break;
                }
            }

            if (om == null)
            {
                om = dom;
            }

            if (om == null)
            {
                fld = (MTZMetaModel.MTZMetaModel.FIELD)(s.FIELD.Item(FieldID.ToString()));
                if (fld != null)
                {
                    if (fld.AllowNull == MTZMetaModel.MTZMetaModel.enumBoolean.Boolean_Da)
                        return false;
                    else
                        return true;
                }
                return false;
            }

           
            for (int i = 1; i <= om.FIELDRESTRICTION.Count; i++)
            {
                if (om.FIELDRESTRICTION.Item(i).ThePart != null)
                {
                    if (om.FIELDRESTRICTION.Item(i).ThePart.ID.Equals(s.ID))
                    {
                        if (om.FIELDRESTRICTION.Item(i).TheField != null)
                        {
                            if (om.FIELDRESTRICTION.Item(i).TheField.ID.Equals(FieldID))
                            {
                                if (om.FIELDRESTRICTION.Item(i).MandatoryField == MTZMetaModel.MTZMetaModel.enumTriState.TriState_Da  )
                                {
                                    return true;
                                }

                                else if (om.FIELDRESTRICTION.Item(i).MandatoryField == MTZMetaModel.MTZMetaModel.enumTriState.TriState_Net )
                                {
                                    return false;
                                }
                                else
                                {
                                    fld = (MTZMetaModel.MTZMetaModel.FIELD)(om.FIELDRESTRICTION.Item(i).TheField);
                                    if (fld.AllowNull== MTZMetaModel.MTZMetaModel.enumBoolean.Boolean_Da )
                                        return false;
                                    else
                                        return true ;
                                }
                                
                            }
                        }
                    }
                }
            }

            fld = (MTZMetaModel.MTZMetaModel.FIELD)(s.FIELD.Item(FieldID.ToString()) );
            if (fld != null)
            {
                if (fld.AllowNull == MTZMetaModel.MTZMetaModel.enumBoolean.Boolean_Da)
                    return false;
                else
                    return true;
            }
            return false;
           
        }


        	
        public enum InterfaceType
        {
            InterfaceTypeCommon = 0,
            InterfaceTypeRightTree = 1,
            InterfaceTypeRightGrid = 2,
            InterfaceTypeRightPanel = 3,
            InterfaceTypeBottomTree = 4,
            InterfaceTypeBottomGrid = 5,
            InterfaceTypeBottomPanel = 6,
            InterfaceTypeLeftTree = 7,
            InterfaceTypeTopGrid = 8,
            InterfaceTypeLeftPanel = 9,
            InterfaceTypeTree = 10,
            InterfaceTypeGrid = 11,
            InterfaceTypePanel = 12,
            InterfaceTypeGridGrid = 13,
            InterfaceTypeTreeGrid = 14,
            InterfaceTypeExtention = 100

        }


        public static InterfaceType AnalyzeInterface(MTZMetaModel.MTZMetaModel.PART s, string mode)
        {
            MTZMetaModel.MTZMetaModel.OBJECTTYPE ot = null;
            MTZMetaModel.MTZMetaModel.PART prev = null;
            int level = 0;
            //MTZMetaModel.MTZMetaModel.PART prev = (MTZMetaModel.MTZMetaModel.PART)s.Parent.Parent;
            ot = ObjectTypeHelper.TypeForStruct(s, ref level);
            if (level > 2)
            {
                return InterfaceType.InterfaceTypeCommon;
            }
            if (level == 2)
            {
                prev = (MTZMetaModel.MTZMetaModel.PART)s.Parent.Parent;
                if (LATIR2Framework.ObjectHelper.CountStructs(prev.PART, mode) > 1)
                {
                    return InterfaceType.InterfaceTypeCommon;
                }
                if (LATIR2Framework.ObjectHelper.CountStructs(s.PART, mode) > 0)
                {
                    return InterfaceType.InterfaceTypeCommon;
                }
                if (prev.PartType == MTZMetaModel.MTZMetaModel.enumPartType.PartType_Stroka  || prev.PartType == MTZMetaModel.MTZMetaModel.enumPartType.PartType_Derevo)
                {
                    if (s.PartType == MTZMetaModel.MTZMetaModel.enumPartType.PartType_Derevo)
                    {
                        return InterfaceType.InterfaceTypeRightTree;
                    }
                    if (s.PartType == MTZMetaModel.MTZMetaModel.enumPartType.PartType_Kollekciy)
                    {
                        return InterfaceType.InterfaceTypeRightGrid;
                    }
                    if (s.PartType == MTZMetaModel.MTZMetaModel.enumPartType.PartType_Stroka)
                    {
                        return InterfaceType.InterfaceTypeRightPanel;
                    }
                }
                else
                {
                    if (s.PartType == MTZMetaModel.MTZMetaModel.enumPartType.PartType_Derevo)
                    {
                        return InterfaceType.InterfaceTypeBottomTree;
                    }
                    if (s.PartType == MTZMetaModel.MTZMetaModel.enumPartType.PartType_Kollekciy)
                    {
                        return InterfaceType.InterfaceTypeBottomGrid;
                    }
                    if (s.PartType == MTZMetaModel.MTZMetaModel.enumPartType.PartType_Stroka)
                    {
                        return InterfaceType.InterfaceTypeBottomPanel;
                    }
                }
            }

            if (level == 1)
            {
                if (LATIR2Framework.ObjectHelper.CountStructs(s.PART, mode) > 1)
                {
                    return InterfaceType.InterfaceTypeCommon;
                }
                for (int i = 1; i <= s.PART.Count; i++)
                {
                    if (LATIR2Framework.ObjectHelper.IsPresent(s.PART.Item(i), mode))
                    {
                        if (LATIR2Framework.ObjectHelper.CountStructs(s.PART.Item(1).PART, mode) > 0)
                        {
                            return InterfaceType.InterfaceTypeCommon;
                        }
                    }
                }

                if (LATIR2Framework.ObjectHelper.CountStructs(s.PART, mode) == 1)
                {
                    if (s.PartType == MTZMetaModel.MTZMetaModel.enumPartType.PartType_Derevo)
                    {
                        return InterfaceType.InterfaceTypeLeftTree;
                    }
                    if (s.PartType == MTZMetaModel.MTZMetaModel.enumPartType.PartType_Kollekciy)
                    {
                        return InterfaceType.InterfaceTypeTopGrid;
                    }
                    if (s.PartType == MTZMetaModel.MTZMetaModel.enumPartType.PartType_Stroka)
                    {
                        return InterfaceType.InterfaceTypeLeftPanel;
                    }
                    else
                    {
                        if (s.PartType == MTZMetaModel.MTZMetaModel.enumPartType.PartType_Derevo)
                        {
                            return InterfaceType.InterfaceTypeLeftTree;
                        }
                        if (s.PartType == MTZMetaModel.MTZMetaModel.enumPartType.PartType_Kollekciy)
                        {
                            return InterfaceType.InterfaceTypeRightGrid;
                        }
                        if (s.PartType == MTZMetaModel.MTZMetaModel.enumPartType.PartType_Stroka)
                        {
                            return InterfaceType.InterfaceTypePanel;
                        }
                    }
                }
            }
            return InterfaceType.InterfaceTypeCommon;
        }

        public static InterfaceType AnalyzeInterfaceForGUI(MTZMetaModel.MTZMetaModel.PART s, string mode)
        {
            MTZMetaModel.MTZMetaModel.OBJECTTYPE ot = null;
            MTZMetaModel.MTZMetaModel.PART prev = null;

            int level = 0;

            ot = ObjectTypeHelper.TypeForStruct(s, ref level);

            if (level > 2)
            {
                return InterfaceType.InterfaceTypeCommon;
            }


            if (level == 2)
            {
                if (s.PartType == MTZMetaModel.MTZMetaModel.enumPartType.PartType_Stroka)
                {
                    return InterfaceType.InterfaceTypeCommon;
                }

                //'        ' сколько детей у родительской структуры
                prev = (MTZMetaModel.MTZMetaModel.PART)s.Parent.Parent;
                if (LATIR2Framework.ObjectHelper.CountStructs(prev.PART, mode) > 1)
                {
                    return InterfaceType.InterfaceTypeCommon;
                }
                // '        ' сколько детей у текущей структуры
                if (LATIR2Framework.ObjectHelper.CountStructs(s.PART, mode) > 0)
                {
                    return InterfaceType.InterfaceTypeCommon;
                }
                if (prev.PartType == MTZMetaModel.MTZMetaModel.enumPartType.PartType_Derevo)
                {

                    if (s.PartType == MTZMetaModel.MTZMetaModel.enumPartType.PartType_Derevo)
                    {
                        return InterfaceType.InterfaceTypeCommon;
                    }
                    if (s.PartType == MTZMetaModel.MTZMetaModel.enumPartType.PartType_Kollekciy)
                    {
                        return InterfaceType.InterfaceTypeTreeGrid;
                    }

                    if (s.PartType == MTZMetaModel.MTZMetaModel.enumPartType.PartType_Stroka)
                    {
                        return InterfaceType.InterfaceTypeCommon;
                    }
                }
                else
                {
                    if (s.PartType == MTZMetaModel.MTZMetaModel.enumPartType.PartType_Derevo)
                    {
                        return InterfaceType.InterfaceTypeCommon;
                    }
                    if (s.PartType == MTZMetaModel.MTZMetaModel.enumPartType.PartType_Kollekciy)
                    {
                        return InterfaceType.InterfaceTypeGridGrid;
                    }

                    if (s.PartType == MTZMetaModel.MTZMetaModel.enumPartType.PartType_Stroka )
                    {
                        return InterfaceType.InterfaceTypeCommon;
                    }

                }

            }


            if (level == 1)
            {


                if (s.PartType == MTZMetaModel.MTZMetaModel.enumPartType.PartType_Rassirenie)
                {
                    return InterfaceType.InterfaceTypeExtention ;
                }

                // много детей
                if (LATIR2Framework.ObjectHelper.CountStructs(s.PART, mode) > 1)
                {
                    return InterfaceType.InterfaceTypeCommon;
                }

                for (int i = 1; i <= s.PART.Count; i++)
                {
                    if (LATIR2Framework.ObjectHelper.IsPresent(s.PART.Item(i), mode))
                    {
                        // ' у зависимой коллекции есть много детей
                        if (LATIR2Framework.ObjectHelper.CountStructs(s.PART.Item(1).PART, mode) > 0)
                        {
                            return InterfaceType.InterfaceTypeCommon;
                        }
                    }
                }




                if (LATIR2Framework.ObjectHelper.CountStructs(s.PART, mode) == 1)
                {
                    if (s.PartType == MTZMetaModel.MTZMetaModel.enumPartType.PartType_Stroka)
                    {
                        return InterfaceType.InterfaceTypeCommon;

                    }

                    //' если дочерняя строка - без вариантов
                    for (int i = 1; i <= s.PART.Count; i++)
                    {
                        if (LATIR2Framework.ObjectHelper.IsPresent(s.PART.Item(i), mode))
                        {
                            //'                    ' у зависимой коллекции есть много детей
                            if (s.PART.Item(i).PartType == MTZMetaModel.MTZMetaModel.enumPartType.PartType_Stroka)
                            {
                                return InterfaceType.InterfaceTypeCommon;

                            }
                        }
                    }



                    if (s.PartType == MTZMetaModel.MTZMetaModel.enumPartType.PartType_Derevo)
                    {
                        return InterfaceType.InterfaceTypeTreeGrid;
                    }

                    if (s.PartType == MTZMetaModel.MTZMetaModel.enumPartType.PartType_Kollekciy)
                    {
                        //'                ' исключаем вариант таблица - дерево
                        for (int i = 1; i <= s.PART.Count; i++)
                        {
                            if (LATIR2Framework.ObjectHelper.IsPresent(s.PART.Item(i), mode))
                            {
                                //'                        ' у зависимой коллекции есть много детей
                                if (s.PART.Item(i).PartType == MTZMetaModel.MTZMetaModel.enumPartType.PartType_Derevo)
                                {
                                    return InterfaceType.InterfaceTypeCommon;
                                }
                            }
                        }
                        return InterfaceType.InterfaceTypeGridGrid;
                    }


                }
                if (LATIR2Framework.ObjectHelper.CountStructs(s.PART, mode) == 0)
                {
                    if (s.PartType == MTZMetaModel.MTZMetaModel.enumPartType.PartType_Derevo)
                    {
                        return InterfaceType.InterfaceTypeTree;
                    }
                    if (s.PartType == MTZMetaModel.MTZMetaModel.enumPartType.PartType_Kollekciy)
                    {
                        return InterfaceType.InterfaceTypeGrid;
                    }

                    if (s.PartType == MTZMetaModel.MTZMetaModel.enumPartType.PartType_Stroka)
                    {
                        return InterfaceType.InterfaceTypePanel;
                    }
                }

            }
            return InterfaceType.InterfaceTypeCommon;
        }
	

        public static MTZMetaModel.MTZMetaModel.PARAMETERS_col GetParameters(MTZMetaModel.MTZMetaModel.SCRIPT_col scol, string tid)
        {
            try
            {
                for (int i = 1; i <= scol.Count; i++)
                {
                    if (scol.Item(i).Target.ID.Equals(tid))
                    {
                        return (MTZMetaModel.MTZMetaModel.PARAMETERS_col)scol.Item(i).PARAMETERS;
                    }
                }
            }
            catch { }
            return null;
        }

        public static string GetDocumentMode(ROLES.ROLES.Application MyRole, LATIR2.Document.Doc_Base Obj)
        {
            Guid sid = Guid.Empty;
            string tn = string.Empty;
            string result = string.Empty;
            if (MyRole == null) return result;
            try
            {
                tn = Obj.TypeName;
                sid = Obj.StatusID;
                for (int i = 1; i <= MyRole.ROLES_DOC.Count; i++)
                {
                    // нашли тип
                    if ((MyRole.ROLES_DOC.Item(i).The_Document as MTZMetaModel.MTZMetaModel.OBJECTTYPE).Name.ToLower() == tn.ToLower())
                    {
                        // тип разрешен к работе
                        if (MyRole.ROLES_DOC.Item(i).The_Denied == ROLES.ROLES.enumYesNo.YesNo_Net)
                        {
                            for (int j = 1; j <= MyRole.ROLES_DOC.Item(i).ROLES_DOC_STATE.Count; j++)
                            {
                                // у документа не определено сосотояние
                                if (sid.Equals(Guid.Empty))
                                {
                                    // ищем строку без состояния
                                    if (MyRole.ROLES_DOC.Item(i).ROLES_DOC_STATE.Item(j).The_State == null)
                                    {
                                        //' забираем оттуда режим
                                        result = ((MyRole.ROLES_DOC.Item(i).ROLES_DOC_STATE.Item(j).The_Mode) as MTZMetaModel.MTZMetaModel.OBJECTMODE).Name;
                                    }
                                    return result;
                                }
                                else
                                {
                                    // ' есть состояние  -  перебираем строки с установленным состоянием
                                    if (MyRole.ROLES_DOC.Item(i).ROLES_DOC_STATE.Item(j).The_State != null)
                                    {
                                        //' нашли
                                        if (MyRole.ROLES_DOC.Item(i).ROLES_DOC_STATE.Item(j).The_State.ID.Equals(sid))
                                        {
                                            if (MyRole.ROLES_DOC.Item(i).ROLES_DOC_STATE.Item(j).The_Mode == null)
                                            {
                                                result = string.Empty;
                                            }
                                            else
                                            {
                                                // ' получаем режим открытия
                                                result = (MyRole.ROLES_DOC.Item(i).ROLES_DOC_STATE.Item(j).The_Mode as MTZMetaModel.MTZMetaModel.OBJECTMODE).Name;
                                            }
                                            return result;
                                        }
                                    }
                                    else // ДОбавил denisk для того чтобы документы получали mode по умолчанию (когда не указан The_State)
                                    {
                                        if (MyRole.ROLES_DOC.Item(i).ROLES_DOC_STATE.Item(j).The_Mode == null)
                                        {
                                            result = string.Empty;
                                        }
                                        else
                                        {
                                            // ' получаем режим открытия
                                            result = (MyRole.ROLES_DOC.Item(i).ROLES_DOC_STATE.Item(j).The_Mode as MTZMetaModel.MTZMetaModel.OBJECTMODE).Name;
                                        }
                                        return result;
                                    }

                                }
                            }
                        }
                        break;
                    }
                }

            }
            catch
            { }
            return result;
        }
    }
}

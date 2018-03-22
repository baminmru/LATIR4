using System;
using System.Collections.Generic;
using System.Text;

namespace LATIR2Framework
{
    public class ObjectTypeHelper
    {

        public static MTZMetaModel.MTZMetaModel.OBJECTTYPE TypeForStruct(MTZMetaModel.MTZMetaModel.PART part)
        {
            object obj;
            obj = part.Parent.Parent;
            // Find object type
            while (!(obj is MTZMetaModel.MTZMetaModel.OBJECTTYPE))
            {
                obj = obj.GetType().InvokeMember("Parent", System.Reflection.BindingFlags.GetProperty, null, obj, null);
                obj = obj.GetType().InvokeMember("Parent", System.Reflection.BindingFlags.GetProperty, null, obj, null);
            }
            return (MTZMetaModel.MTZMetaModel.OBJECTTYPE)obj;
        }

        public static MTZMetaModel.MTZMetaModel.OBJECTTYPE TypeForStruct(MTZMetaModel.MTZMetaModel.PART part, ref int Level)
        {
            object obj;
            Level = 1;
            obj = part.Parent.Parent;
            // Find object type
            while (!(obj is MTZMetaModel.MTZMetaModel.OBJECTTYPE))
            {
                obj = obj.GetType().InvokeMember("Parent", System.Reflection.BindingFlags.GetProperty, null, obj, null);
                obj = obj.GetType().InvokeMember("Parent", System.Reflection.BindingFlags.GetProperty, null, obj, null);
                Level++;
            }
            return (MTZMetaModel.MTZMetaModel.OBJECTTYPE)obj;
        }
    }
}

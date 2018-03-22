using System;
using System.Data;
using System.Configuration;

namespace LATIR2Framework
{

    /// <summary>
    /// Summary description for PartFieldValue
    /// </summary>
    public class PartFieldValue
    {
        public System.Type FieldType = typeof(string);
        public string FieldPart = string.Empty;
        public string FieldName = string.Empty;
        public object FieldValue = null;

        public PartFieldValue(string fieldPart, string fieldName, System.Type fieldType, object fieldValue)
        {
            FieldType = fieldType;
            FieldPart = fieldPart;
            FieldName = fieldName;
            FieldValue = fieldValue;
        }
    }
}

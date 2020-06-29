using System.Collections.Generic;

namespace OneAttributeBulkUpload.Models
{
    public class AttributeMetadata
    {
        /// <summary>
        /// Type of the Attribute get set
        /// </summary>
        public string AttributeType { get; set; }

        /// <summary>
        /// CRM Logical name of the Attribute get set
        /// </summary>
        public string LogicalName { get; set; }

        /// <summary>
        /// Display name of the attrbiute 
        /// </summary>
        public string DisplayName { get; set; }

        /// <summary>
        /// Option set metadata for the OPtion set type of attrbiutes
        /// </summary>
        public Microsoft.Xrm.Sdk.Metadata.OptionSetMetadata OptionSetMetadata { get; set; }

        /// <summary>
        /// Target entity logical names for ref atrbute types
        /// </summary>
        public List<string> TargetSchemaName { get; set; }


        //Override ToString method
        public override string ToString()
        {
            return DisplayName;
        }
    }
}

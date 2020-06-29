using System.Collections.Generic;

namespace OneAttributeBulkUpload.Models
{
    /// <summary>
    /// Model class for Update attribute structure
    /// </summary>
    public class UpdateAttributeStructure
    {
        public FileUpdateModel FileRecord { get; set; }

        public string EntityName { get; set; }

        public string UpdateAttrName { get; set; }

        public string UpdateAttrDataType { get; set; }

        public string TargetEntityName { get; set; }

        public string TargetEntityAttrName { get; set; }

        public string UniqueAttrName { get; set; }
    }
}

namespace OneAttributeBulkUpload.Models
{
    /// <summary>
    /// Entity Metadata class
    /// </summary>
    public class EntityMetadata
    {
        /// <summary>
        /// Display name of the Entity, which will be shown in the combobox
        /// </summary>
        public string DisplayName { get; set; }

        /// <summary>
        /// Logical name of the entity in CRM
        /// </summary>
        public string LogicalName { get; set; }

        //Constructor
        public EntityMetadata(string displayName, string logicalName)
        {
            DisplayName = displayName;
            LogicalName = logicalName;
        }
        
        //Override ToString method
        public override string ToString()
        {
            return DisplayName;
        }
    }

}

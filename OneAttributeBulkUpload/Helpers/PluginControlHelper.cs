using OneAttributeBulkUpload.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneAttributeBulkUpload.Helpers
{
    /// <summary>
    /// Helper class to main plugin control 
    /// </summary>
    public class PluginControlHelper
    {

        /// <summary>
        /// Hemper method to get the list of Customized attrbiutes metadata
        /// </summary>
        /// <param name="attributeMetadatas"></param>
        /// <returns></returns>
        public List<AttributeMetadata> GetCustomizedAttributes(List<Microsoft.Xrm.Sdk.Metadata.AttributeMetadata> attributeMetadatas)
        {
            var attrCutomizedList = attributeMetadatas.Where(x => x.IsCustomizable.Value == true && x.IsDataSourceSecret == false
                    && x.IsPrimaryId == false && x.IsValidForUpdate == true && x.DisplayName.UserLocalizedLabel != null)
                    .OrderBy(x => x.DisplayName.UserLocalizedLabel.Label).ToList();

            var attrListMetadata = new List<AttributeMetadata>();

            foreach (var attrMetadata in attrCutomizedList)
            {
                var attrType = attrMetadata.AttributeType.Value.ToString();
                var attrLogicalName = attrMetadata.LogicalName;
                var attrDisplayName = attrMetadata.DisplayName.UserLocalizedLabel.Label;
                Microsoft.Xrm.Sdk.Metadata.OptionSetMetadata optionSetMetadata = null;
                List<string> entiRefForLookUp = null;
                var allowedRefTypes = (Enum.GetValues(typeof(AllowedRefAttrType))).OfType<object>().Select(o => o.ToString()).ToArray();

                if (attrType == AttributeType.Picklist.ToString())
                {                    
                    var pickListMetaData = (Microsoft.Xrm.Sdk.Metadata.PicklistAttributeMetadata)attrMetadata;
                    optionSetMetadata = pickListMetaData.OptionSet;
                }
                if (Array.Exists(allowedRefTypes, element => element.ToLower() == attrType.ToLower()))
                {                  
                    var lookupMetadata = (Microsoft.Xrm.Sdk.Metadata.LookupAttributeMetadata)attrMetadata;
                    if (lookupMetadata.Targets.Count() > 0)
                    {
                        entiRefForLookUp = lookupMetadata.Targets.ToList();
                    }
                }
                attrListMetadata.Add(new AttributeMetadata
                {
                    DisplayName = attrDisplayName,
                    LogicalName = attrLogicalName,
                    AttributeType = attrType,
                    TargetSchemaName = entiRefForLookUp,
                    OptionSetMetadata = optionSetMetadata
                });
            }

            return attrListMetadata;
        }


        /// <summary>
        /// Helper method to get the list of string attrbutes from provided attribute list metadata
        /// </summary>
        /// <param name="attributeMetadatas"></param>
        /// <returns></returns>
        public List<AttributeMetadata> GetStringAttributes(List<Microsoft.Xrm.Sdk.Metadata.AttributeMetadata> attributeMetadatas)
        {
            var attrStringList = attributeMetadatas.Where(x => (x.IsCustomizable.Value == true && x.IsDataSourceSecret == false
                    && x.IsPrimaryId == false && x.IsValidForUpdate == true && x.DisplayName.UserLocalizedLabel != null
                    && x.AttributeType.Value.ToString() == AttributeType.String.ToString()) || x.AttributeType.Value.ToString() == AttributeType.Uniqueidentifier.ToString())
                    .OrderBy(x => x.DisplayName.UserLocalizedLabel.Label).ToList();
            var attrListMetadata = new List<AttributeMetadata>();

            foreach (var attrMetadata in attrStringList)
            {
                var attrType = attrMetadata.AttributeType.Value.ToString();
                var attrLogicalName = attrMetadata.LogicalName;
                var attrDisplayName = attrMetadata.DisplayName.UserLocalizedLabel.Label;

                attrListMetadata.Add(new AttributeMetadata
                {
                    DisplayName = attrDisplayName,
                    LogicalName = attrLogicalName,
                    AttributeType = attrType,
                    TargetSchemaName = null,
                    OptionSetMetadata = null
                });
            }
            return attrListMetadata;

        }

        /// <summary>
        /// Creates list of File Record value class from file lines and returns
        /// </summary>
        /// <param name="lines"></param>
        /// <param name="delimeter"></param>
        /// <param name="stringBuilder"></param>
        /// <returns></returns>
        public List<FileUpdateModel> CreateDictionaryListForLoad(string[] lines, string delimeter, ref StringBuilder stringBuilder)
        {
            var fileValues = new List<FileUpdateModel>();
             for (int i = 0; i < lines.Length; i++)
            {
                if (lines[i].Contains(delimeter))
                {
                    var index = lines[i].IndexOf(delimeter);
                    var first = lines[i].Substring(0, index);
                    var second = lines[i].Substring(index + delimeter.Length);
                    var fileRecordValue = new FileUpdateModel { UniqueAttrValue = first, UpdateAttrValue = second };
                    fileValues.Add(fileRecordValue);
                }
                else
                {
                    stringBuilder.AppendLine($"Delimeter not found for the line : Line No : {i + 1}");
                }
            }
            stringBuilder.AppendLine($"Total records to be processed are : {fileValues.Count}");
            return fileValues;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneAttributeBulkUpload.Models
{
    /// <summary>
    /// File upload model class, to hold file values
    /// </summary>
    public class FileUpdateModel
    {
        /// <summary>
        /// First column value of the load file, which is to be unique attrbute to find out the update record
        /// </summary>
        public string UniqueAttrValue { get; set; }

        /// <summary>
        /// Second column value of the load file, which represents the value to be updated
        /// </summary>
        public string UpdateAttrValue { get; set; }
    }
}

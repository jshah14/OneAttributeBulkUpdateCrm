using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Messages;
using Microsoft.Xrm.Sdk.Query;
using OneAttributeBulkUpload.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneAttributeBulkUpload.Helpers
{
    /// <summary>
    /// CRM helper class
    /// Respnsible to perform all CRM related operations
    /// </summary>
    public class CrmHelper
    {
        /// <summary>
        /// Organization service get set
        /// </summary>
        public IOrganizationService OrgService { get; set; }

        /// <summary>
        /// Default Constructor
        /// </summary>
        /// <param name="service"></param>
        public CrmHelper(IOrganizationService service)
        {
            OrgService = service;
        }

        /// <summary>
        /// Get the Entity list from the CRM, it filtered out entities which are not customizable
        /// </summary>
        /// <returns></returns>
        public List<EntityMetadata> GetEntitylist()
        {
            RetrieveAllEntitiesRequest retrieveAllEntitiesRequest = new RetrieveAllEntitiesRequest();
            retrieveAllEntitiesRequest.EntityFilters.Equals(1);
            var response = (RetrieveAllEntitiesResponse)OrgService.Execute(retrieveAllEntitiesRequest);
            var respList = response.EntityMetadata.ToList();

            var respListFiltered = respList.Where(x => x.IsCustomizable.Value == true && x.DisplayName.UserLocalizedLabel != null && x.IsIntersect == false).OrderBy(m => m.DisplayName.UserLocalizedLabel.Label).ToList();

            var entityList = new List<EntityMetadata>();

            foreach (var metadata in respListFiltered)
            {
                var displayName = metadata.DisplayName.UserLocalizedLabel.Label;
                var logicalName = metadata.LogicalName;
                entityList.Add(new EntityMetadata(displayName, logicalName));
            }
            return entityList;
        }

        /// <summary>
        /// Helper method to get the list of attrbutes of an entity
        /// </summary>
        /// <param name="entityLogicalName"></param>
        /// <returns></returns>
        public List<Microsoft.Xrm.Sdk.Metadata.AttributeMetadata> GetAttributeListFromEntity(string entityLogicalName)
        {
            RetrieveEntityRequest retrieveEntityRequest = new RetrieveEntityRequest
            {
                EntityFilters = Microsoft.Xrm.Sdk.Metadata.EntityFilters.Attributes,
                LogicalName = entityLogicalName
            };

            var respAttr = (RetrieveEntityResponse)OrgService.Execute(retrieveEntityRequest);

            return respAttr.EntityMetadata.Attributes.ToList();
        }

        
        /// <summary>
        /// Helper method to execute query expression and retunr the entity collection
        /// </summary>
        /// <param name="queryExpression"></param>
        /// <returns></returns>
        public EntityCollection GetEntityCollection (QueryExpression queryExpression)
        {
            return OrgService.RetrieveMultiple(queryExpression);
        }

        /// <summary>
        /// Helper method to update a record in CRM
        /// </summary>
        /// <param name="updEntity"></param>
        public void UpdateRecord (Entity updEntity)
        {
            OrgService.Update(updEntity);
        }

    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;

namespace MsCrmExtensions
{
    /// <summary>
    /// Extensions for IOrganizationService
    /// </summary>
    public static class IOrganizationServiceExtensions
    {
        /// <summary>
        /// Associate method override. Takes EntityReference as primary entity input parameter
        /// </summary>
        /// <param name="reference">Entity to delete</param>
        public static void Associate(this IOrganizationService service, EntityReference primaryEntity, Relationship relationship, EntityReferenceCollection relatedEntities)
        {
            СheckParam(primaryEntity, nameof(primaryEntity));
            СheckParam(relationship, nameof(relationship));
            СheckParam(relatedEntities, nameof(relatedEntities));

            service.Associate(primaryEntity.LogicalName, primaryEntity.Id, relationship, relatedEntities);
        }

        /// <summary>
        /// Associate method override. Takes EntityReference as primary entity input parameter and list of EntityReferences as related entities parameter
        /// </summary>
        /// <param name="reference">Entity to delete</param>
        public static void Associate(this IOrganizationService service, EntityReference primaryEntity, Relationship relationship, IList<EntityReference> relatedEntities)
        {
            СheckParam(primaryEntity, nameof(primaryEntity));
            СheckParam(relationship, nameof(relationship));
            СheckParam(relatedEntities, nameof(relatedEntities));

            service.Associate(primaryEntity.LogicalName, primaryEntity.Id, relationship, new EntityReferenceCollection(relatedEntities));
        }

        /// <summary>
        /// Delete method override. Takes EntityReference as input parameter
        /// </summary>
        /// <param name="reference">Entity to delete</param>
        public static void Delete(this IOrganizationService service, EntityReference reference)
        {
            СheckParam(reference, nameof(reference));

            service.Delete(reference.LogicalName, reference.Id);
        }

        /// <summary>
        /// Delete method override. Takes Entity as input parameter
        /// </summary>
        /// <param name="entity">Entity to delete</param>
        public static void Delete(this IOrganizationService service, Entity entity)
        {
            СheckParam(entity, nameof(entity));

            service.Delete(entity.LogicalName, entity.Id);
        }

        /// <summary>
        /// Disassociate method override. Takes EntityReference as primary entity input parameter
        /// </summary>
        /// <param name="reference">Entity to delete</param>
        public static void Disassociate(this IOrganizationService service, EntityReference primaryEntity, Relationship relationship, EntityReferenceCollection relatedEntities)
        {
            СheckParam(primaryEntity, nameof(primaryEntity));
            СheckParam(relationship, nameof(relationship));
            СheckParam(relatedEntities, nameof(relatedEntities));

            service.Disassociate(primaryEntity.LogicalName, primaryEntity.Id, relationship, relatedEntities);
        }

        /// <summary>
        /// Disassociate method override. Takes EntityReference as primary entity input parameter and list of EntityReferences as related entities parameter
        /// </summary>
        /// <param name="reference">Entity to delete</param>
        public static void Disassociate(this IOrganizationService service, EntityReference primaryEntity, Relationship relationship, IList<EntityReference> relatedEntities)
        {
            СheckParam(primaryEntity, nameof(primaryEntity));
            СheckParam(relationship, nameof(relationship));
            СheckParam(relatedEntities, nameof(relatedEntities));

            service.Disassociate(primaryEntity.LogicalName, primaryEntity.Id, relationship, new EntityReferenceCollection(relatedEntities));
        }

        /// <summary>
        /// Retrieve method override. Takes EntityReference as input parameter
        /// </summary>
        /// <param name="reference">Entity to delete</param>
        public static Entity Retrieve(this IOrganizationService service, EntityReference reference, ColumnSet columnSet)
        {
            СheckParam(reference, nameof(reference));
            СheckParam(columnSet, nameof(columnSet));

            return service.Retrieve(reference.LogicalName, reference.Id, columnSet);
        }

        /// <summary>
        /// Retrieve method override. Takes EntityReference as input parameter and return strongly typed entity object
        /// </summary>
        /// <param name="reference">Entity to delete</param>
        public static T Retrieve<T>(this IOrganizationService service, EntityReference reference, ColumnSet columnSet) where T : Entity
        {
            СheckParam(reference, nameof(reference));
            СheckParam(columnSet, nameof(columnSet));

            Entity entity = service.Retrieve(reference.LogicalName, reference.Id, columnSet);
            return entity?.ToEntity<T>();
        }

        private static void СheckParam(Object parameter, String name)
        {
            if (parameter == null)
            {
                throw new ArgumentNullException(name);
            }
        }
    }
}
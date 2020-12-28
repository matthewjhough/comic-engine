using System;

namespace ComicEngine.Data
{
    /// <summary>
    /// Helper extension methods for <see cref="PersistedResource"/> fields.
    /// </summary>
    public static class DataSupport
    {
        public static void SetCreatedFields(
            this PersistedResource resource, 
            string subject)
        {
            resource.CreatedAt = DateTime.Now;
            resource.CreatedBy = subject;
        }

        public static void SetUpdatedFields(
            this PersistedResource resource,
            string subject)
        {
            resource.UpdatedAt = DateTime.Now;
            resource.UpdatedBy = subject;
        }
    }
}
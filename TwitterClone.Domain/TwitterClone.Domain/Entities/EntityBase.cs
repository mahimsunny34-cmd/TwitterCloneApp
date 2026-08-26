using System;
using System.Collections.Generic;
using System.Text;

namespace TwitterClone.Domain.Entities
{
    public class EntityBase
    {
        public Guid Id { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime ModifiedAt { get; private set; }
        public Guid CreatedBy { get; private set; }
        public Guid ModifiedBy { get; private set; }

        public EntityBase(Guid id)
        {
            Id = id;
            CreatedAt = DateTime.UtcNow;
        }

        public virtual string DescribeRecord()
        {
            return $"Base Entity : Id: {Id}, CreatedAt: {CreatedAt}, ModifiedAt: {ModifiedAt}, CreatedBy: {CreatedBy}, ModifiedBy: {ModifiedBy}";
        }

        public bool CanBeLiked()
        {
            return false ;
        }
    }
}

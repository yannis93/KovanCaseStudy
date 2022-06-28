using MediatR;

namespace KovanCaseStudy.SharedKernel.SeedWork;

public abstract class EntityBase<TId> : IEntity<TId>
    {
        public virtual TId Id { get; protected set; }

        public virtual DateTime CreatedOn { get; protected set; }
        public virtual DateTime? UpdatedOn { get; protected set; }
        public virtual DateTime? DeletedOn { get; protected set; }

        public bool IsDeleted()
        {
            return DeletedOn != null;
        }
    }
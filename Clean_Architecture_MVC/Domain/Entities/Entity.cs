using Domain.Validations;
using System;

namespace Domain.Entities
{
    public abstract class Entity
    {
        public int Id { get; protected set; }
        public DateTime CreatedAt { get; protected set; }
        public DateTime UpdatedAt { get;protected set; }

        public void ValidateEntity(int id, DateTime createdAt, DateTime updatedAt)
        {
            DomainExceptionValidation.When(id < 0, "Invalid Id value");
            DomainExceptionValidation.When(createdAt > DateTime.Now, "Invalid CreatedAt value: THE DATE CANNOT BE LATER THAN THE CURRENT ");
            DomainExceptionValidation.When(updatedAt > DateTime.Now, "Invalid UpdatedAt value: THE DATE CANNOT BE LATER THAN THE CURRENT ");
            Id = id;
            UpdatedAt = updatedAt;
            CreatedAt = createdAt;
        }
    }
}
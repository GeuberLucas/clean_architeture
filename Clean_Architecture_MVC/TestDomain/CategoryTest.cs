using Domain.Entities;
using Domain.Validations;
using FluentAssertions;
using System;
using Xunit;

namespace TestDomain
{
    public class CategoryTest
    {
        [Fact]
        public void CreateCategory_ValidParams_ResultValidState()
        {
            Action action = () => new Category(1,DateTime.Now,DateTime.Now, "Sou foda");

            action.Should().NotThrow<DomainExceptionValidation>();
        }
        
        [Fact]
        public void CreateCategory_InvalidNameLenght_ExceptionNameLenght()
        {
            Action action = () => new Category(1,DateTime.Now,DateTime.Now, "So");

            action.Should().Throw<DomainExceptionValidation>().WithMessage("Name is too short, please insert minimum 3 charecters");
        }
        [Fact]
        public void CreateCategory_InvalidNameEmpty_ExceptionNameEmpty()
        {
            Action action = () => new Category(1,DateTime.Now,DateTime.Now, "");

            action.Should().Throw<DomainExceptionValidation>().WithMessage("Invalid name.Name is required");
        }
        [Fact]
        public void CreateCategory_InvalidId_ExceptionId()
        {
            Action action = () => new Category(-1,DateTime.Now,DateTime.Now, "Sou foda");

            action.Should().Throw<DomainExceptionValidation>().WithMessage("Invalid Id value");
        }
        [Fact]
        public void CreateCategory_InvalidCreatedAt_ExceptionCreatedAt()
        {
            Action action = () => new Category(1,DateTime.Now.AddDays(1),DateTime.Now, "Sou foda");

            action.Should().Throw<DomainExceptionValidation>().WithMessage("Invalid CreatedAt value: THE DATE CANNOT BE LATER THAN THE CURRENT ");
        }
        [Fact]
        public void CreateCategory_InvalidUpdatedAt_ExceptionUpdatedAt()
        {
            Action action = () => new Category(1, DateTime.Now, DateTime.Now.AddDays(1), "Sou foda");

            action.Should().Throw<DomainExceptionValidation>().WithMessage("Invalid UpdatedAt value: THE DATE CANNOT BE LATER THAN THE CURRENT ");
        }
    }
}

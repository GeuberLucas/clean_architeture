using Domain.Entities;
using Domain.Validations;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace TestDomain
{
    public class ProductTest
    {
        [Fact]
        public void CreateCategory_ValidParams_ResultValidState()
        {
            Action action = () => new Product(1, DateTime.Now, DateTime.Now, "Festa da mae Aparecida",  "a melhor festa de outubro", 30.00m,  3,  "gb.gg");
            action.Should().NotThrow<DomainExceptionValidation>();
        }

        [Fact]
        public void CreateCategory_InvalidNameLenght_ExceptionNameLenght()
        {
            Action action = () => new Product(1, DateTime.Now, DateTime.Now, "Fe", "a melhor festa de outubro", 30.00m, 3, "gb.gg");

            action.Should().Throw<DomainExceptionValidation>().WithMessage("Name is too short, please insert minimum 3 charecters");
        }
        [Fact]
        public void CreateCategory_InvalidNameEmpty_ExceptionNameEmpty()
        {
            Action action = () => new Product(1, DateTime.Now, DateTime.Now, "", "a melhor festa de outubro", 30.00m, 3, "gb.gg");

            action.Should().Throw<DomainExceptionValidation>().WithMessage("Invalid name.Name is required");
        }
          
        [Fact]
        public void CreateCategory_InvalidDescriptionLenght_ExceptionDescriptionLenght()
        {
            Action action = () => new Product(1, DateTime.Now, DateTime.Now, "Festa da mae Aparecida", "a", 30.00m, 3, "gb.gg");

            action.Should().Throw<DomainExceptionValidation>().WithMessage("Description is too short, please insert minimum 3 charecters");
        }
        [Fact]
        public void CreateCategory_InvalidDescriptionEmpty_ExceptionDescriptionEmpty()
        {
            Action action = () => new Product(1, DateTime.Now, DateTime.Now, "Festa da mae Aparecida", "", 30.00m, 3, "gb.gg");

            action.Should().Throw<DomainExceptionValidation>().WithMessage("Invalid description.Description is required");
        }
        [Fact]
        public void CreateCategory_InvalidUrlImageLenght_ExceptionUrlImageLenght()
        {
            Action action = () => new Product(1, DateTime.Now, DateTime.Now, "Festa da mae Aparecida", "a melhor festa de outubro", 30.00m, 3, "dhfgjldshgfljedfhgdsjkfhgdfljkhgsdfljghfedsfljhkgfljhgsdklufgskdjfhksdjfhskjfhksjdfhksjfhskjdfhsikjdfhklsjhdflsdkjfhsdlkjhgfdkljfghdskfjdhlkjefhgioewuryhpowiserhgopçwsldjehbfglwsijghbsçgjiklohnswçolgujhbsiujgheiofujhwfçjefgheujghejfghfujgeufjhrujoghedrçolujgfhsddhgjkfhsdgjfshgfjkshfgjshfgjshdgfjshgjshgjhgjhgjhgjhggb.gghfdldgfhlkdfughlidfugyhdiughdliçfugjhasedpiufyhsdiufydisufgyhdsiugyhdilugyhadiugydisufgyhdiufgyiudfygiudsfygidufgydiufg");

            action.Should().Throw<DomainExceptionValidation>().WithMessage("Url Image is too long, please insert maximum 250 charecters");
        }
        [Fact]
        public void CreateCategory_NullUrlImage_NotException()
        {
            Action action = () => new Product(1, DateTime.Now, DateTime.Now, "Festa da mae Aparecida", "a melhor festa de outubro", 30.00m, 3, "gb.gghfdldgfhlkdfughlidfugyhdiughdliçfugjhasedpiufyhsdiufydisufgyhdsiugyhdilugyhadiugydisufgyhdiufgyiudfygiudsfygidufgydiufg");

            action.Should().NotThrow<DomainExceptionValidation>();
        }
        
        [Fact]
        public void CreateCategory_InvalidPrice_ExceptionPrice()
        {
            Action action = () => new Product(1, DateTime.Now, DateTime.Now, "Festa da mae Aparecida", "a melhor festa de outubro", -30.00m, 3, "gb.gg"); 

            action.Should().Throw<DomainExceptionValidation>().WithMessage("Invalid Price value");
        }
        [Fact]
        public void CreateCategory_InvalidStock_ExceptionStock()
        {
            Action action = () => new Product(1, DateTime.Now, DateTime.Now, "Festa da mae Aparecida", "a melhor festa de outubro", 30.00m, -3, "gb.gg"); 

            action.Should().Throw<DomainExceptionValidation>().WithMessage("Invalid Stock value");
        }
        [Fact]
        public void CreateCategory_InvalidId_ExceptionId()
        {
            Action action = () => new Product(-1, DateTime.Now, DateTime.Now, "Festa da mae Aparecida", "a melhor festa de outubro", 30.00m, 3, "gb.gg"); 

            action.Should().Throw<DomainExceptionValidation>().WithMessage("Invalid Id value");
        }
        [Fact]
        public void CreateCategory_InvalidCreatedAt_ExceptionCreatedAt()
        {
            Action action = () => new Product(1, DateTime.Now.AddDays(1), DateTime.Now, "Festa da mae Aparecida", "a melhor festa de outubro", 30.00m, 3, "gb.gg");

            action.Should().Throw<DomainExceptionValidation>().WithMessage("Invalid CreatedAt value: THE DATE CANNOT BE LATER THAN THE CURRENT ");
        }
        [Fact]
        public void CreateCategory_InvalidUpdatedAt_ExceptionUpdatedAt()
        {
            Action action = () => new Product(1, DateTime.Now, DateTime.Now.AddDays(1), "Festa da mae Aparecida", "a melhor festa de outubro", 30.00m, 3, "gb.gg");

            action.Should().Throw<DomainExceptionValidation>().WithMessage("Invalid UpdatedAt value: THE DATE CANNOT BE LATER THAN THE CURRENT ");
        }
    }
}

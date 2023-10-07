using Domain.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public sealed class Product : Entity
    {
        
        public string Name { get; private set; }
        public string Description { get; private set; }
        public decimal Price { get; private set; }
        public int Stock { get; private set; }
        public string UrlImage { get; private set; }

        public Product(string name, string description, decimal price, int stock, string urlImage)
        {
            ValidateDomain(name, description, price, stock, urlImage);
        }

        
        public Product(int id, DateTime createdAt, DateTime updatedAt, string name, string description, decimal price, int stock, string urlImage)
        {
            ValidateDomain(name, description, price, stock, urlImage);
            DomainExceptionValidation.When(id < 0, "Invalid Id value");
            DomainExceptionValidation.When(createdAt > DateTime.Now, "Invalid CreatedAt value: THE DATE CANNOT BE LATER THAN THE CURRENT ");
            DomainExceptionValidation.When(updatedAt > DateTime.Now, "Invalid UpdatedAt value: THE DATE CANNOT BE LATER THAN THE CURRENT ");
           

            Id = id;
            UpdatedAt = updatedAt;
            CreatedAt = createdAt;
        }

        //metodo para atualizar o produto
        public void Update(string name, string description, decimal price, int stock, string urlImage, int categoryId)
        {
            ValidateDomain(name, description, price, stock, urlImage);
            CategoryId = categoryId;
        }

        //metodo para fazer as validações da classe
        private void ValidateDomain(string name, string description, decimal price, int stock, string urlImage)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(name), "Invalid name.Name is required");
            DomainExceptionValidation.When(name.Length < 3, "Name is too short, please insert minimum 3 charecters");
            DomainExceptionValidation.When(string.IsNullOrEmpty(description), "Invalid description.Description is required");
            DomainExceptionValidation.When(description.Length < 3, "Description is too short, please insert minimum 3 charecters");

            DomainExceptionValidation.When(price < 0, "Invalid Price value");
            DomainExceptionValidation.When(stock < 0, "Invalid Stock value");

            DomainExceptionValidation.When(urlImage.Length >250 , "Url Image is too long, please insert maximum 250 charecters");



            Name = name;
            Description = description;
            Price = price;
            Stock   = stock;
            UrlImage= urlImage;
        }

        //propriedades de navegação
        //nao fazem parte do modelo de dominio
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }

}

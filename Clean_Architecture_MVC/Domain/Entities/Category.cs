using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Validations;

namespace Domain.Entities
{
    public sealed class Category :Entity
    {
        
        public string Name { get; private set; }


        //Construtor com validação do nome 
        public Category(string name)
        {
            ValidateDomain(name);
        }

        //para popular o banco !!!!
        //Construtor com validação do nome e do id
        public Category(int id,DateTime createdAt, DateTime updatedAt,string name)
        {
            
            ValidateDomain(name);
            ValidateEntity(id, createdAt, updatedAt);
        }

        //metodo para atualizar a categoria 
        public void Update(string name)
        {
            ValidateDomain(name);
        }

        //propriedade de navegação
        //buscar todos os produtos com a categoria
        public ICollection<Product> Products { get; set; }

        //metodo para fazer as validações da classe 
        private void ValidateDomain(string name)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(name),"Invalid name.Name is required");
            DomainExceptionValidation.When(name.Length<3,"Name is too short, please insert minimum 3 charecters");
            Name = name;
        }
    }
}

using Dapper;
using Domain.Entities;
using Domain.Interfaces;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra_Data.Repositories
{
    class ProductRepositoriy : IProductRepository
    {
        private readonly IApplicationDbContext _applicationDbContext;

        public async Task<Product> CreateAsync(Product Product)
        {
            MySqlConnection connection = null;
            try
            {
                connection = _applicationDbContext.GetConnection();
                connection.Open();
                var sql = @$"
                    INSERT INTO categories
                        (`id`,
                        `created_at`,
                        `updated_at`,
                        `name`)
                        VALUES
                        (@id,
                        @createdAt,
                        @updatedAt,
                        @name);
                ";
                DynamicParameters productParams = new DynamicParameters();
                productParams.Add("@id", Product.Id);
                productParams.Add("@createdAt", Product.CreatedAt);
                productParams.Add("@updatedAt", Product.UpdatedAt);
                productParams.Add("@name", Product.Name);
                productParams.Add("@description", Product.Description);
                productParams.Add("@price", Product.Price);
                productParams.Add("@Stock", Product.Stock);
                productParams.Add("@urlImage", Product.UrlImage);
                await connection.ExecuteAsync(sql, productParams, connection.BeginTransaction());
                return Product;
            }

            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                connection.Close();
            }
        }

        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            MySqlConnection connection = null;
            try
            {
                connection = _applicationDbContext.GetConnection();
                connection.Open();
                var sql = @$"
                   SELECT id as Id,
                    created_at as CreatedAt,
                    updated_at as UpdatedAt,
                    name as Name
                        description as Description,
                        price as Price,
                        
                        idCategory as 
                    FROM products;

                ";

                var allCategories = await connection.QueryAsync<Product>(sql);

                return allCategories;
            }

            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                connection.Close();
            }

        }

        public async Task<Product> GetByIdAsync(int id)
        {
            MySqlConnection connection = null;
            try
            {
                connection = _applicationDbContext.GetConnection();
                connection.Open();
                var sql = @$"
                   SELECT id as Id,
                    created_at as CreatedAt,
                    updated_at as UpdatedAt,
                    name as Name
                    FROM categories
                    where id = @id;
                ";
                DynamicParameters productParams = new DynamicParameters();
                productParams.Add("@id", id);
                var Product = await connection.QueryFirstOrDefaultAsync<Product>(sql, productParams, connection.BeginTransaction());
                return Product;
            }

            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                connection.Close();
            }
        }

        public async Task<Product> RemoveAsync(Product Product)
        {
            MySqlConnection connection = null;
            try
            {
                connection = _applicationDbContext.GetConnection();
                connection.Open();
                var sql = @$"
                   DELETE FROM categories
                   WHERE id=@id;
                ";
                DynamicParameters productParams = new DynamicParameters();
                productParams.Add("@id", Product.Id);

                await connection.ExecuteAsync(sql, productParams, connection.BeginTransaction());
                return Product;
            }

            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                connection.Close();
            }
        }

        public async Task<Product> UpdateAsync(Product Product)
        {
            MySqlConnection connection = null;
            try
            {
                connection = _applicationDbContext.GetConnection();
                connection.Open();
                var sql = @"
                   UPDATE `clean_database`.`categories`
                    SET
                    `id` =@id,
                    `created_at` = @createdAt,
                    `updated_at` = @updatedAt,
                    `name` = @name,
                    WHERE `id` = @id;
                ";
                DynamicParameters productParams = new DynamicParameters();
                productParams.Add("@id", Product.Id);
                productParams.Add("@createdAt", Product.CreatedAt);
                productParams.Add("@updatedAt", Product.UpdatedAt);
                productParams.Add("@name", Product.Name);

                await connection.ExecuteAsync(sql, productParams, connection.BeginTransaction());
                return Product;
            }

            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                connection.Close();
            }
        }
    }
}

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
    class CategoryRepository: ICategoryRepository
    {
        private readonly IApplicationDbContext _applicationDbContext;

        public CategoryRepository(IApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public async Task<Category> Create(Category category)
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
                DynamicParameters categoryParams = new DynamicParameters();
                categoryParams.Add("@id", category.Id);
                categoryParams.Add("@createdAt", category.CreatedAt);
                categoryParams.Add("@updatedAt", category.UpdatedAt);
                categoryParams.Add("@name", category.Name);
                await connection.ExecuteAsync(sql, categoryParams, connection.BeginTransaction());
                return category;
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

        public async Task<IEnumerable<Category>> GetAllCategories()
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
                    FROM categories;
                ";

                var allCategories = await connection.QueryAsync<Category>(sql);

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

        public async Task<Category> GetById(int id)
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
                DynamicParameters categoryParams = new DynamicParameters();
                categoryParams.Add("@id", id);
                var category = await connection.QueryFirstOrDefaultAsync<Category>(sql, categoryParams,connection.BeginTransaction());
                return category;
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

        public async Task<Category> Remove(Category category)
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
                DynamicParameters categoryParams = new DynamicParameters();
                categoryParams.Add("@id", category.Id);
               
                await connection.ExecuteAsync(sql, categoryParams, connection.BeginTransaction());
                return category;
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

        public async Task<Category> Update(Category category)
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
                DynamicParameters categoryParams = new DynamicParameters();
                categoryParams.Add("@id", category.Id);
                categoryParams.Add("@createdAt", category.CreatedAt);
                categoryParams.Add("@updatedAt", category.UpdatedAt);
                categoryParams.Add("@name", category.Name);

                await connection.ExecuteAsync(sql, categoryParams, connection.BeginTransaction());
                return category;
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

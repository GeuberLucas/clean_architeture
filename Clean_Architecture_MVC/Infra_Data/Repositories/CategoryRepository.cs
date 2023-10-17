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

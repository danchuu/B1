using System;
using System.Collections.Generic;
using System.Linq;
using Business_Layer;
using Microsoft.EntityFrameworkCore;

namespace Data_Layer
{
    public class CategoryContext : IDb<Category, int>
    {
        DBContext dbContext;
        public CategoryContext(DBContext dBContext)
        {
            this.dbContext = dBContext;
        }
        public void Create(Category item)
        {
            try
            {
                dbContext.Categories.Add(item);
                dbContext.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Delete(int key)
        {
            try
            {
                dbContext.Categories.Remove(dbContext.Categories.Find(key));
                dbContext.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Category Read(int key, bool useNavigationalProperties = false)
        {
            try
            {
                IQueryable<Category> query = dbContext.Categories;
                if (useNavigationalProperties)
                {
                    query = query.Include(p => p.Users);
                }
                return query.FirstOrDefault(p => p.ID == key);

            }
            catch (Exception)
            {

                throw;
            }
        }

        public IEnumerable<Category> ReadAll(bool useNavigationalProperties = false)
        {
            try
            {
                IQueryable<Category> query = dbContext.Categories;
                if (useNavigationalProperties)
                {
                    query = query.Include(p => p.Users);
                }
                return query.ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Update(Category item, bool useNavigationalProperties = false)
        {
            try
            {
                if (useNavigationalProperties)
                {
                    Category categoryFromDb = Read(item.ID);

                    if (categoryFromDb != null)
                    {
                        Create(item);
                        return;
                    }

                    categoryFromDb.Name = item.Name;

                    dbContext.SaveChanges();
                }



            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}

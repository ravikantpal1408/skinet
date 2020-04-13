using System.Linq;
using Core.Entities;
using Core.Specifications;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class SpecificationEvaluator<TEntity> where TEntity : BaseEntity
    {
        // 👇 below is the static method that return IQueryable
        // We are calling GetQuery and we are passing <TEntity> as an IQueryable and calling it as input query
        public static IQueryable<TEntity> GetQuery(IQueryable<TEntity> inputQuery, ISpecification<TEntity> spec)
        {
            var query = inputQuery; // IQueryable of Product 

            if (spec.Criteria != null)
            {
                /* Then we are saying that get me a
                 product where the product is whatever 
                 we specified as this criteria could be expression 
                 👇 */
                query = query.Where(spec.Criteria); // p => p.ProductTypeId == id
            }

            if (spec.OrderBy != null)
            {
                query = query.OrderBy(spec.OrderBy);
            }

            if (spec.OrderByDescending != null)
            {
                query = query.OrderByDescending(spec.OrderByDescending);
            }

            if (spec.IsPagingEnabled)
            {
                query = query.Skip(spec.Skip).Take(spec.Take);

            }
            

            // 👇 below is the lambda expression that we wrote in Repository where eager loading was happening 👇 
            query = spec.Includes.Aggregate(query, (current, include) => current.Include(include));

            return query;
        }
    }
}
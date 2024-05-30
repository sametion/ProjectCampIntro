using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    //generic repository design pattern
    public interface IEntityRepository<T> where T : class,IEntity,new()       //Generic constraint
    {
        //tek tek linq sorgusu yazmamız gerekmeyecek filtrelenmiş dataya erişebilmek için
        List<T> GetAll(Expression<Func<T,bool>> filter=null);      //more efficient way to get filtered data
        T Get(Expression<Func<T, bool>> filter);                    //filtre zorunlu
        void Add(T entity);
        void Delete(T entity);
        void Update(T entity);
    }
}

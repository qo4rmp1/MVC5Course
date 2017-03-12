using System;
using System.Linq;
using System.Collections.Generic;
	
namespace MVC5Course.Models
{   
	public  class ProductRepository : EFRepository<Product>, IProductRepository
	{
    public Product Find(int? id)
    {
      return this.All().FirstOrDefault(p => p.ProductId == id.Value);
    }

    /// <summary>
    /// 覆寫All(),顯示庫存小於500資料
    /// </summary>
    /// <returns></returns>
    public override IQueryable<Product> All()
    {
      return base.All().Where(p => false == p.IsDeleted && p.Stock < 500);
    }
    /// <summary>
    /// 顯示全部資料
    /// </summary>
    /// <param name="ShowAll"></param>
    /// <returns></returns>
    public IQueryable<Product> All(bool ShowAll)
    {
      if (ShowAll)
      {
        return base.All();
      }
      else
      {
        return this.All();
      }
    }

    /// <summary>
    /// Memo:若有一功能,執行刪除功能不刪除資料庫資料,只是Mark不顯示
    /// 在DB新增一欄位->更新edmx->
    /// </summary>
    /// <param name="entity"></param>
    public override void Delete(Product entity)
    {
      entity.IsDeleted = true;
    }
  }

  public  interface IProductRepository : IRepository<Product>
	{

	}
}
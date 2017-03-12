using System.Data.Entity;

namespace MVC5Course.Models
{
	public class EFUnitOfWork : IUnitOfWork
	{
		public DbContext Context { get; set; }

		public EFUnitOfWork()
		{
			Context = new FabricsEntities();
		}

		public void Commit()
		{
      try
      {
        Context.SaveChanges();
      }
      catch (System.Data.Entity.Validation.DbEntityValidationException ex)
      {
        throw ex;

        //一個或多個實體的驗證失敗。如需詳細資料，請參閱 'EntityValidationErrors' 屬性。
        //因為在UpdateDB的時候，會先驗證Field的屬性，再更新到DB
      }
    }
		
		public bool LazyLoadingEnabled
		{
			get { return Context.Configuration.LazyLoadingEnabled; }
			set { Context.Configuration.LazyLoadingEnabled = value; }
		}

		public bool ProxyCreationEnabled
		{
			get { return Context.Configuration.ProxyCreationEnabled; }
			set { Context.Configuration.ProxyCreationEnabled = value; }
		}
		
		public string ConnectionString
		{
			get { return Context.Database.Connection.ConnectionString; }
			set { Context.Database.Connection.ConnectionString = value; }
		}
	}
}

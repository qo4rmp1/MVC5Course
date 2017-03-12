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

        //�@�өΦh�ӹ��骺���ҥ��ѡC�p�ݸԲӸ�ơA�аѾ\ 'EntityValidationErrors' �ݩʡC
        //�]���bUpdateDB���ɭԡA�|������Field���ݩʡA�A��s��DB
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

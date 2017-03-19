using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MVC5Course.Models;
using PagedList;
using System.Data.Entity.Validation;

namespace MVC5Course.Controllers
{
    public class ProductsController : BaseController
    {
        //private FabricsEntities db = new FabricsEntities();
        //memo:要執行RepositoryHelper.GetProductRepository();才能建立資料庫連線
        //因為建立資料庫連線寫在GetUnitOfWork()中

        // GET: Products
        public ActionResult Index(string sortBy, string keyword, int pageNo = 1)
        {
            IQueryable<Product> repoData = DoSearchOnIndex(sortBy, keyword, pageNo);

            return View(repoData.ToPagedList(pageNo, 10));
        }

        private IQueryable<Product> DoSearchOnIndex(string sortBy, string keyword, int pageNo)
        {
            var repoData = repoProduct.All().AsQueryable();

            if (!String.IsNullOrEmpty(keyword))
            {
                repoData = repoData.Where(p => p.ProductName.Contains(keyword));
            }

            if (sortBy == "+Price")
            {
                repoData = repoData.OrderBy(p => p.Price);
            }
            else
            {
                repoData = repoData.OrderByDescending(p => p.Price);
            }

            ViewBag.keyword = keyword;

            ViewData.Model = repoData.ToPagedList(pageNo, 10);
            return repoData;
        }

        [HttpPost]
        public ActionResult Index(Product[] data)
        {
            if (ModelState.IsValid)
            {
                foreach (var item in data)
                {
                    var FindItem = repoProduct.Find(item.ProductId);
                    FindItem.ProductId = item.ProductId;
                    FindItem.ProductName = item.ProductName;
                    FindItem.Price = item.Price;
                    FindItem.Stock = item.Stock;
                    FindItem.Active = item.Active;
                }
                repoProduct.UnitOfWork.Commit();
                return RedirectToAction("Index");
            }

            //DoSearchOnIndex(sortBy, keyword, pageNo);
            return View();
        }

        /* var data = pro.All().AsQueryable();

            if (string.IsNullOrEmpty(keyword) == false)
            {
                data = data.Where(p => p.ProductName.Contains(keyword));
            }

            //if (sortby == "+price")
            //{
            //  data = data.OrderBy(p => p.Price);
            //}else if (sortby == "-price")
            //{
            //  data = data.OrderByDescending(p => p.Price);
            //}
            data = data.OrderBy(p => p.Price);
            ViewBag.keyword = keyword;
        */
        // GET: Products/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Product product = repoProduct.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // GET: Products/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Products/Create
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProductId,ProductName,Price,Active,Stock,IsDeleted")] Product product)
        {
            if (ModelState.IsValid)
            {
                repoProduct.Add(product);
                repoProduct.UnitOfWork.Commit();
                return RedirectToAction("Index");
            }

            return View(product);
        }

        // GET: Products/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = repoProduct.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }
        
        // POST: Products/Edit/5
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=317598。
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include = "ProductId,ProductName,Price,Active,Stock,IsDeleted")] Product product)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var db = repoProduct.UnitOfWork.Context;
        //        db.Entry(product).State = EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    return View(product);
        //}
        [HttpPost]
        [ValidateAntiForgeryToken]
        [HandleError(View = "Error_DbEntityValidationException", ExceptionType = typeof(DbEntityValidationException))]
        public ActionResult Edit(int id, FormCollection form)
        {
            var product = repoProduct.Find(id);
            if (TryUpdateModel(product, new string[] { "ProductName", "Stock" }))
            {
            }
                repoProduct.UnitOfWork.Commit();
                return RedirectToAction("Index");
            //return View(product);
        }
        // GET: Products/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = repoProduct.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Product product = repoProduct.Find(id);
            repoProduct.Delete(product);
            //memo:UnitOfWork處理所有和資料庫有關的動作。DB連線、儲存。
            repoProduct.UnitOfWork.Commit();

            return RedirectToAction("Index");
        }

        /*
        //若網站一秒瞬間流量有幾十萬筆以上，沒辦法等到GC.Collect()回收機制回收資料庫連線，就必須實做Dispose。
        protected override void Dispose(bool disposing)
        {
          if (disposing)
          {
            db.Dispose();
          }
          base.Dispose(disposing);
        }
        */
    }
}

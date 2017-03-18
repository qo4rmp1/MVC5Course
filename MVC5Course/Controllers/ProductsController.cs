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

namespace MVC5Course.Controllers
{
    public class ProductsController : BaseController
    {
        //private FabricsEntities db = new FabricsEntities();
        //memo:要執行RepositoryHelper.GetProductRepository();才能建立資料庫連線
        //因為建立資料庫連線寫在GetUnitOfWork()中

        // GET: Products
        public ActionResult Index(string sortby, string keyword, int pageNo = 1)
        {
            var data = pro.All().AsQueryable();

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
            //data = data.ToPagedList(pageNo, 10).AsQueryable();
            //return View(db.Product.OrderByDescending(p => p.ProductId).Take(10).ToList());
            ViewBag.keyword = keyword;

            /*
             　ViewData的用法
            　 return View((Object)Model);
            　 等同於
             　ViewData.Model = data.ToPagedList(pageNo, 10);
             　return View();
             */
            return View(data.ToPagedList(pageNo, 10));
        }

        // GET: Products/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Product product = pro.Find(id);
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
                pro.Add(product);
                pro.UnitOfWork.Commit();
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
            Product product = pro.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: Products/Edit/5
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProductId,ProductName,Price,Active,Stock,IsDeleted")] Product product)
        {
            if (ModelState.IsValid)
            {
                var db = pro.UnitOfWork.Context;
                db.Entry(product).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(product);
        }

        // GET: Products/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = pro.Find(id);
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
            Product product = pro.Find(id);
            pro.Delete(product);
            //memo:UnitOfWork處理所有和資料庫有關的動作。DB連線、儲存。
            pro.UnitOfWork.Commit();

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

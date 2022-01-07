using Khinkali.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Khinkali.Controllers
{
    public class PieController : Controller
    {
        SqlConnection con = new SqlConnection();
        SqlCommand com = new SqlCommand();
        SqlDataReader dr;
        List<Pie> pies = new List<Pie>();

        void connectionString()
        {
            con.ConnectionString = "data source=UZZZAKOV; database=WiPieDB; integrated security=SSPI";
        }

        private void FetchPie()
        {
            connectionString();
            if (pies.Count > 0)
            {
                pies.Clear();
            }
            try
            {
                con.Open();
                com.Connection = con;
                com.CommandText = "SELECT TOP 100 [id],[name],[compound],[cost],[diameter],[filling],[weight],[image] FROM [WiPieDB].[dbo].[pies]";
                dr = com.ExecuteReader();
                while (dr.Read())
                {
                    pies.Add(new Pie()
                    {
                        Id = dr["id"].ToString(),
                        Name = dr["name"].ToString(),
                        Compound = dr["compound"].ToString(),
                        Cost = dr["cost"].ToString(),
                        Diameter = dr["diameter"].ToString(),
                        Filling = dr["filling"].ToString(),
                        Weight = dr["weight"].ToString(),
                        Image = dr["image"].ToString()
                    });
                }
                con.Close();
            }
            catch (Exception)
            {
                throw;
            }
        }

            // GET: PieController
            public ActionResult Index()
        {
            FetchPie();
            return View(pies);
        }
        public ActionResult About(int id)
        {
            connectionString();
            if (pies.Count > 0)
            {
                pies.Clear();
            }
            try
            {
                con.Open();
                com.Connection = con;
                com.CommandText = "select * from pies where id='" + id + "'";
                dr = com.ExecuteReader();
                while (dr.Read())
                {
                    pies.Add(new Pie()
                    {
                        Id = dr["id"].ToString(),
                        Name = dr["name"].ToString(),
                        Compound = dr["compound"].ToString(),
                        Cost = dr["cost"].ToString(),
                        Diameter = dr["diameter"].ToString(),
                        Filling = dr["filling"].ToString(),
                        Weight = dr["weight"].ToString(),
                        Image = dr["image"].ToString()
                    });
                }
                con.Close();
            }
            catch (Exception)
            {
                throw;
            }

            return View(pies);
        }

        // GET: PieController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: PieController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PieController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PieController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: PieController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PieController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: PieController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}

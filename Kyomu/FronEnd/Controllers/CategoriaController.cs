﻿using FronEnd.Helpers.Implementations;
using FronEnd.Helpers.Interfaces;
using FronEnd.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FronEnd.Controllers
{
    public class CategoriaController : Controller
    {

        ICategoriaHelper _categoriaHelper;

        public CategoriaController(ICategoriaHelper categoriaHelper)
        {
            _categoriaHelper = categoriaHelper;
        }

        // GET: CategoryController
        public ActionResult Index()
        {
            var result = _categoriaHelper.GetCategorias();
            return View(result);
        }

        // GET: CategoryController/Details/5
        public ActionResult Details(int id)
        {
            var result = _categoriaHelper.GetCategoria(id);
            return View(result);
        }

        // GET: CategoryController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CategoryController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CategoriaViewModel category)
        {
            try
            {
                _categoriaHelper.Add(category);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CategoryController/Edit/5
        public ActionResult Edit(int id)
        {
            var categoria = _categoriaHelper.GetCategoria(id);
            if (categoria == null)
            {
                return NotFound();
            }
            return View(categoria);
        }

        // POST: CategoryController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, CategoriaViewModel categoria)
        {
            try
            {
                if (id != categoria.IdCategoria)
                {
                    return BadRequest();
                }


                var updatedCategoria = _categoriaHelper.Update(categoria);
                if (updatedCategoria == null)
                {
                    return NotFound();
                }

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CategoriaController/Delete/5
        public ActionResult Delete(int id)
        {
            var categoria = _categoriaHelper.GetCategoria(id);
            if (categoria == null)
            {
                return NotFound();
            }
            return View(categoria);
        }

        // POST: CategoriaController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, CategoriaViewModel categoria)
        {
            try
            {

                _categoriaHelper.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}

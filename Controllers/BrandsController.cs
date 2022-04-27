using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ClothingSize.Models;

namespace ClothingSize.Controllers
{
  public class BrandsController : Controller
  {
    public IActionResult Index()
    {
      var allBrands = Brand.GetBrands();
      return View(allBrands);
    }

    [HttpPost]
    public IActionResult Index(Brand brand)
    {
      Brand.Post(brand);
      return RedirectToAction("Index");
    }

    public IActionResult Details(int id)
    {
      var brand = Brand.GetDetails(id);
      return View(brand);
    }

    public IActionResult Edit(int id)
    {
      var brand = Brand.GetDetails(id);
      return View(brand);
    }

    [HttpPost]
    public IActionResult Details(int id, Brand brand)
    {
      brand.BrandId = id;
      Brand.Put(brand);
      return RedirectToAction("Details", id);
    }

    public IActionResult Delete(int id)
    {
      Brand.Delete(id);
      return RedirectToAction("Index");
    }
  }
}
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using testing_site_wil.Models;
using testing_site_wil.Repository.IRepository;

namespace testing_site_wil.Controllers
{
    public class ShoppingController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _HostEnvironment;

        public ShoppingController(IUnitOfWork unitOfWork, IWebHostEnvironment HostEnviroment)
        {
            _unitOfWork = unitOfWork;
            _HostEnvironment = HostEnviroment;
        }

        public IActionResult Index()
        {
            return View();
        }

        //GET
        public IActionResult Upsert(int? id)
        {
            Shopping product;

            if (id == null || id == 0)
            {
                // Create product
                product = new Shopping();
            }
            else
            {
                // Update the product
                product = _unitOfWork.Shopping.GetFirstOrDefault(i => i.ID == id);
            }

            return View(product);
        }




        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(Shopping obj, IFormFile? file)
        {

            if (ModelState.IsValid)
            {
                string wwwRootPath = _HostEnvironment.WebRootPath;
                if (file != null)
                {
                    string fileName = Guid.NewGuid().ToString();
                    var uploads = Path.Combine(wwwRootPath, @"images\shopping");
                    var extension = Path.GetExtension(file.FileName);

                    if (obj.Images != null)
                    {
                        var oldImagePath = Path.Combine(wwwRootPath, obj.Images.TrimStart('\\'));
                        if (System.IO.File.Exists(oldImagePath))
                        {
                            System.IO.File.Delete(oldImagePath);
                        }
                    }

                    using (var fileStreams = new FileStream(Path.Combine(uploads, fileName + extension), FileMode.Create))
                    {
                        file.CopyTo(fileStreams);
                    }
                    obj.Images= @"\images\shopping\" + fileName + extension;

                }

                if (obj.ID == 0)
                {
                    _unitOfWork.Shopping.Add(obj);
                }
                else
                {
                    _unitOfWork.Shopping.Update(obj);
                }


                _unitOfWork.Save();
                TempData["success"] = "Product created successfully";
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        #region API CALLS
        [HttpGet]
        public IActionResult GetAll()
        {
            var productList = _unitOfWork.Shopping.GetAll();
            return Json(productList);
        }
        [HttpDelete]
        public IActionResult DeleteShopping(int? id)
        {
            var obj = _unitOfWork.Shopping.GetFirstOrDefault(u => u.ID == id);
            if (obj == null)
            {
                return Json(new { success = false, message = "error while deleting" });
            }
            if (obj.Images != null)
            {
                var oldImagePath = Path.Combine(_HostEnvironment.WebRootPath, obj.Images.TrimStart('\\'));
                if (System.IO.File.Exists(oldImagePath))
                {
                    System.IO.File.Delete(oldImagePath);
                }
            }


            _unitOfWork.Shopping.Remove(obj);
            _unitOfWork.Save();
            return Json(new { success = true, message = "deleting successfull" });


        }
        }
        #endregion

    }



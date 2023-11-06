using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using testing_site_wil.Models;
using testing_site_wil.Repository.IRepository;

namespace testing_site_wil.Controllers
{
    public class EventsController : Controller
    {
   private readonly IUnitOfWork _unitOfWork;
    private readonly IWebHostEnvironment _HostEnvironment;

    public EventsController(IUnitOfWork unitOfWork, IWebHostEnvironment HostEnviroment)
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
        Event Event;

        if (id == null || id == 0)
        {
                // Create product
                Event = new Event();
        }
        else
        {
                // Update the product
                Event = _unitOfWork.Event.GetFirstOrDefault(i => i.ID == id);
        }

        return View(Event);
    }




    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Upsert(Event obj, IFormFile? file)
    {

        if (ModelState.IsValid)
        {
            string wwwRootPath = _HostEnvironment.WebRootPath;
            if (file != null)
            {
                string fileName = Guid.NewGuid().ToString();
                var uploads = Path.Combine(wwwRootPath, @"images\event");
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
                obj.Images= @"\images\event\" + fileName + extension;

            }

            if (obj.ID == 0)
            {
                _unitOfWork.Event.Add(obj);
            }
            else
            {
                _unitOfWork.Event.Update(obj);
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
        var productList = _unitOfWork.Event.GetAll();
        return Json(productList);
    }


    [HttpDelete]
    public IActionResult Delete(int? id)
    {
        var obj = _unitOfWork.Event.GetFirstOrDefault(u => u.ID == id);
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


        _unitOfWork.Event.Remove(obj);
        _unitOfWork.Save();
        return Json(new { success = true, message = "deleting successfull" });
    }
    #endregion

}


}

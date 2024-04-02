using AssetsBusinessLogic.BusinessLogicInterface;
using DataAccessLayer.Models;
using Microsoft.AspNetCore.Mvc;

namespace Assets.Controllers;

public class AssetsController : Controller
{
    private readonly IAssetsBusinessLogic _assets;
    private readonly IDeviceGroupBusinessLogic _deviceGroups;

    public AssetsController(IAssetsBusinessLogic assets, IDeviceGroupBusinessLogic deviceGroups)
    {
        _assets = assets;
        _deviceGroups = deviceGroups;
    }

    public IActionResult Assets()
    {
        var result = _assets.PopulateGrid();
        return View(result);
    }

    public PartialViewResult GetAssets(int id)
    {
        if (id == 0)
        {
            return PartialView("Modals/_SaveAssets", new AssetsViewModel
            {
                DeviceGroupList = _deviceGroups.GetAllActiveDeviceGroups().ToList(),
            });
        }
        else
        {
            var result = _assets.GetAssetsInformation(id);
            result.DeviceGroupList = _deviceGroups.GetAllActiveDeviceGroups().ToList();
            return PartialView("Modals/_SaveAssets", result);
        }
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult SaveAssets(AssetsViewModel model)
    {
        if (model.Id == 0)
        {
            var result = _assets.Add(model);
            return Json(result);
        }
        else
        {
            var result = _assets.Update(model);
            return Json(result);
        }
    }

    [HttpPost]
    public JsonResult DeactivateAssets(int id)
    {
        var result = _assets.Deactivate(id);
        return Json(result);
    }

    [HttpPost]
    public JsonResult ReactivateAssets(int id)
    {
        var result = _assets.Reactivate(id);
        return Json(result);
    }
}
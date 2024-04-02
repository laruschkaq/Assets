using AssetsBusinessLogic.BusinessLogicInterface;
using DataAccessLayer.Models;
using Microsoft.AspNetCore.Mvc;

namespace Assets.Controllers;

public class DeviceGroupsController : Controller
{
    private readonly IDeviceGroupBusinessLogic _deviceGroups;

    public DeviceGroupsController(IDeviceGroupBusinessLogic deviceGroups)
    {
        _deviceGroups = deviceGroups;
    }
    public IActionResult DeviceGroups()
    {
        var result = _deviceGroups.PopulateGrid();
        return View(result);
    }
    
    public PartialViewResult GetDeviceGroups(int id)
    {
        if (id == 0)
        {
            return PartialView("Modals/_SaveDeviceGroup", new DeviceGroupViewModel
            {
                
                ParentDeviceGroupList = _deviceGroups.GetAllActiveDeviceGroups().ToList(),
            });
        }
        else
        {
            var result = _deviceGroups.GetDeviceGroupInformation(id);
            result.ParentDeviceGroupList = _deviceGroups.GetAllActiveDeviceGroups().ToList();
            return PartialView("Modals/_SaveDeviceGroup", result);
        }
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult SaveDeviceGroups(DeviceGroupViewModel model)
    {
        if (model.Id == 0)
        {
            var result = _deviceGroups.Add(model);
            return Json(result);
        }
        else
        {
            var result = _deviceGroups.Update(model);
            return Json(result);
        }
    }

    [HttpPost]
    public JsonResult DeactivateDeviceGroups(int id)
    {
        var result = _deviceGroups.Deactivate(id);
        return Json(result);
    }

    [HttpPost]
    public JsonResult ReactivateDeviceGroups(int id)
    {
        var result = _deviceGroups.Reactivate(id);
        return Json(result);
    }

}
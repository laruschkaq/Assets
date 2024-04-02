using AssetsBusinessLogic.BusinessLogicInterface;
using DataAccesLayer.Entities;
using DataAccesLayer.Enums;
using DataAccessLayer.DBContext;
using DataAccessLayer.Models;

namespace AssetsBusinessLogic.BusinessLogic;

public class DeviceGroupBusinessLogic : IDeviceGroupBusinessLogic
{
    private readonly DbContext _dbContext;

    public DeviceGroupBusinessLogic()
    {
        _dbContext = new DbContext();
    }

    public GlobalViewModel.ResultModel Add(DeviceGroupViewModel data)
    {
        using var transaction = _dbContext.Database.BeginTransaction();
        try
        {
            bool deviceExist = false;
            var exists =
                _dbContext.DeviceGroup.FirstOrDefault(x => x.Name == data.Name);
            if (exists != null)
                deviceExist = true;

            if (deviceExist)
                return new GlobalViewModel.ResultModel()
                {
                    Message = "Device Group with Name " + data.Name + " already exists"
                };

            var device = new DeviceGroup()
            {
                Name = data.Name,
                Active = true,
                CreatedOnDateTime = DateTime.Now,
                ParentDeviceGroupId = data.ParentDeviceGroupId
            };

            _dbContext.Add(device);
            _dbContext.SaveChanges();

            transaction.Commit();

            return new GlobalViewModel.ResultModel
            {
                Id = (int)GlobalEnums.EnumResultValues.Success, Message = "Record Added"
            };
        }
        catch (Exception ex)
        {
            transaction.Rollback();
        }

        return new GlobalViewModel.ResultModel()
        {
            Id = (int)GlobalEnums.EnumResultValues.Failed,
            Message = "Failed"
        };
    }

    public GlobalViewModel.ResultModel Update(DeviceGroupViewModel data)
    {
        using var transaction = _dbContext.Database.BeginTransaction();
        try
        {
            var existingDevice =
                _dbContext.DeviceGroup.FirstOrDefault(x => x.Id == data.Id);
            if (existingDevice == null)
                return new GlobalViewModel.ResultModel()
                {
                    Message = "Device could not be found"
                };

            existingDevice.Name = data.Name;
            existingDevice.Active = true;
            existingDevice.ParentDeviceGroupId = data.ParentDeviceGroupId;
            existingDevice.LastModifiedOnDateTime = DateTime.Now;

            _dbContext.SaveChanges();

            transaction.Commit();


            return new GlobalViewModel.ResultModel
            {
                Id = (int)GlobalEnums.EnumResultValues.Success, Message = "Record Updated"
            };
        }
        catch (Exception ex)
        {
            transaction.Rollback();
        }

        return new GlobalViewModel.ResultModel()
        {
            Id = (int)GlobalEnums.EnumResultValues.Failed,
            Message = "Failed"
        };
    }

    public GlobalViewModel.ResultModel Deactivate(int id)
    {
        using var transaction = _dbContext.Database.BeginTransaction();
        try
        {
            var existingDevice =
                _dbContext.DeviceGroup.FirstOrDefault(x => x.Id == id);
            if (existingDevice == null)
                return new GlobalViewModel.ResultModel()
                {
                    Message = "Device could not be found"
                };

            existingDevice.Active = false;
            existingDevice.LastModifiedOnDateTime = DateTime.Now;

            _dbContext.SaveChanges();

            transaction.Commit();

            return new GlobalViewModel.ResultModel
            {
                Id = (int)GlobalEnums.EnumResultValues.Success, Message = "Deactivated"
            };
        }
        catch (Exception ex)
        {
            transaction.Rollback();
        }

        return new GlobalViewModel.ResultModel()
        {
            Id = (int)GlobalEnums.EnumResultValues.Failed,
            Message = "Failed"
        };
    }

    public GlobalViewModel.ResultModel Reactivate(int id)
    {
        using var transaction = _dbContext.Database.BeginTransaction();
        try
        {
            var existingDevice =
                _dbContext.DeviceGroup.FirstOrDefault(x => x.Id == id);
            if (existingDevice == null)
                return new GlobalViewModel.ResultModel()
                {
                    Message = "Device could not be found"
                };

            existingDevice.Active = true;
            existingDevice.LastModifiedOnDateTime = DateTime.Now;

            _dbContext.SaveChanges();

            transaction.Commit();

            return new GlobalViewModel.ResultModel
            {
                Id = (int)GlobalEnums.EnumResultValues.Success, Message = "Reactivated"
            };
        }
        catch (Exception ex)
        {
            transaction.Rollback();
        }

        return new GlobalViewModel.ResultModel()
        {
            Id = (int)GlobalEnums.EnumResultValues.Failed,
            Message = "Failed"
        };
    }


    public List<DeviceGroupGridViewModel> PopulateGrid()
    {
        return _dbContext.DeviceGroup.Select(o => new DeviceGroupGridViewModel
        {
            Id = o.Id,
            Name = o.Name,
            ParentDeviceGroup = o.NavParentDeviceGroups == null ? "" : o.NavParentDeviceGroups.Name,
            Active = o.Active
        }).ToList();
    }

    public IEnumerable<GlobalViewModel.DropdownListViewModel> GetAllActiveDeviceGroups()
    {
        return _dbContext.DeviceGroup.Where(x => x.Active == true).Select(a =>
            new GlobalViewModel.DropdownListViewModel()
            {
                Id = Convert.ToInt32(a.Id),
                Name = a.Name,
            }).OrderBy(a => a.Name).ToList();
    }

    public DeviceGroupViewModel GetDeviceGroupInformation(int id)
    {
        var deviceGroup =
            _dbContext.DeviceGroup.FirstOrDefault(x => x.Id == id);

        if (deviceGroup == null)
            return new DeviceGroupViewModel();

        var result = new DeviceGroupViewModel()
        {
            Id = deviceGroup.Id,
            Name = deviceGroup.Name,
            Active = deviceGroup.Active
        };
        return result;
    }
}
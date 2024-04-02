using AssetsBusinessLogic.BusinessLogicInterface;
using DataAccesLayer.Entities;
using DataAccesLayer.Enums;
using DataAccessLayer.DBContext;
using DataAccessLayer.Models;

namespace AssetsBusinessLogic.BusinessLogic;

public class AssetsBusinessLogic : IAssetsBusinessLogic
{
    private readonly DbContext _dbContext;

    public AssetsBusinessLogic()
    {
        _dbContext = new DbContext();
    }

    public GlobalViewModel.ResultModel Add(AssetsViewModel data)
    {
        using var transaction = _dbContext.Database.BeginTransaction();
        try
        {
            bool assetExist = false;
            var exists =
                _dbContext.Assets.FirstOrDefault(x => x.SerialNumber == data.SerialNumber && x.Name == data.Name);
            if (exists != null)
                assetExist = true;

            if (assetExist)
                return new GlobalViewModel.ResultModel()
                {
                    Message = "Asset with Name " + data.Name + " and Serial Number " + data.SerialNumber +
                              " already exists"
                };

            var asset = new Assets()
            {
                Name = data.Name,
                SerialNumber = data.SerialNumber,
                Active = true,
                DeviceGroupId = data.DeviceGroupId,
                FirmwareVersion = data.FirmwareVersion,
                CreatedOnDateTime = DateTime.Now
            };

            _dbContext.Add(asset);
            _dbContext.SaveChanges();

            transaction.Commit();

            return new GlobalViewModel.ResultModel
            {
                Id = (int)GlobalEnums.EnumResultValues.Success, Message = "Success"
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

    public GlobalViewModel.ResultModel Update(AssetsViewModel data)
    {
        using var transaction = _dbContext.Database.BeginTransaction();
        try
        {
            var existingAsset =
                _dbContext.Assets.FirstOrDefault(x => x.Id == data.Id);
            if (existingAsset == null)
                return new GlobalViewModel.ResultModel()
                {
                    Message = "Asset could not be found"
                };

            existingAsset.Name = data.Name;
            existingAsset.SerialNumber = data.SerialNumber;
            existingAsset.Active = true;
            existingAsset.DeviceGroupId = data.DeviceGroupId;
            existingAsset.FirmwareVersion = data.FirmwareVersion;
            existingAsset.LastModifiedOnDateTime = DateTime.Now;

            _dbContext.SaveChanges();

            transaction.Commit();

            return new GlobalViewModel.ResultModel
            {
                Id = (int)GlobalEnums.EnumResultValues.Success, Message = "Success"
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
            var existingAsset =
                _dbContext.Assets.FirstOrDefault(x => x.Id == id);
            if (existingAsset == null)
                return new GlobalViewModel.ResultModel()
                {
                    Message = "Asset could not be found"
                };

            existingAsset.Active = false;
            existingAsset.LastModifiedOnDateTime = DateTime.Now;

            _dbContext.SaveChanges();

            transaction.Commit();

            return new GlobalViewModel.ResultModel
            {
                Id = (int)GlobalEnums.EnumResultValues.Success, Message = "Success"
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
            var existingAsset =
                _dbContext.Assets.FirstOrDefault(x => x.Id == id);
            if (existingAsset == null)
                return new GlobalViewModel.ResultModel()
                {
                    Message = "Asset could not be found"
                };

            existingAsset.Active = true;
            existingAsset.LastModifiedOnDateTime = DateTime.Now;

            _dbContext.SaveChanges();

            transaction.Commit();

            return new GlobalViewModel.ResultModel
            {
                Id = (int)GlobalEnums.EnumResultValues.Success, Message = "Success"
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

    public List<AssetsGridViewModel> PopulateGrid()
    {
        return _dbContext.Assets.Select(o => new AssetsGridViewModel
        {
            Id = o.Id,
            Name = o.Name,
            SerialNumber = o.SerialNumber,
            DeviceGroup = o.NavDeviceGroups.Name,
            FirmwareVersion = o.FirmwareVersion,
            Active = o.Active
        }).ToList();
    }

    public IEnumerable<GlobalViewModel.DropdownListViewModel> GetAllActiveAssets()
    {
        return _dbContext.Assets.Where(x => x.Active == true).Select(a =>
            new GlobalViewModel.DropdownListViewModel()
            {
                Id = Convert.ToInt32(a.Id),
                Name = a.Name + " (" + a.SerialNumber + ")",
            }).OrderBy(a => a.Name).ToList();
    }

    public AssetsViewModel GetAssetsInformation(int id)
    {
        var assets =
            _dbContext.Assets.FirstOrDefault(x => x.Id == id);

        if (assets == null)
            return new AssetsViewModel();

        var result = new AssetsViewModel()
        {
            Id = assets.Id,
            Name = assets.Name,
            SerialNumber = assets.SerialNumber,
            DeviceGroupId = assets.DeviceGroupId,
            FirmwareVersion = assets.FirmwareVersion,
            Active = assets.Active
        };
        return result;
    }
}
using DataAccessLayer.Models;

namespace AssetsBusinessLogic.BusinessLogicInterface;

public interface IDeviceGroupBusinessLogic
{
    GlobalViewModel.ResultModel Add(DeviceGroupViewModel data);
    GlobalViewModel.ResultModel Update(DeviceGroupViewModel data);
    GlobalViewModel.ResultModel Deactivate(int id);
    GlobalViewModel.ResultModel Reactivate(int id);
    List<DeviceGroupGridViewModel> PopulateGrid();
    IEnumerable<GlobalViewModel.DropdownListViewModel> GetAllActiveDeviceGroups();
    DeviceGroupViewModel GetDeviceGroupInformation(int id);
}
using DataAccessLayer.Models;

namespace AssetsBusinessLogic.BusinessLogicInterface;

public interface IAssetsBusinessLogic
{

    GlobalViewModel.ResultModel Add(AssetsViewModel data);
    GlobalViewModel.ResultModel Update(AssetsViewModel data);
    GlobalViewModel.ResultModel Deactivate(int id);
    GlobalViewModel.ResultModel Reactivate(int id);
    List<AssetsGridViewModel> PopulateGrid();
    IEnumerable<GlobalViewModel.DropdownListViewModel> GetAllActiveAssets();
    AssetsViewModel GetAssetsInformation(int id);
}
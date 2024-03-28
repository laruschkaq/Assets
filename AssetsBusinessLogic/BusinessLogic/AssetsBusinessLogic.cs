using AssetsBusinessLogic.BusinessLogicInterface;
using DataAccessLayer.DBContext;
using DataAccessLayer.Models;

namespace AssetsBusinessLogic.BusinessLogic;

public class AssetsBusinessLogic : IAssetsBusinessLogic
{
    private readonly DbContext _dbContext;

    public GlobalViewModel.ResultModel Add(AssetsViewModel data, int loggedInUserId)
    {
        return new GlobalViewModel.ResultModel();
    }

    public GlobalViewModel.ResultModel Update(AssetsViewModel data, int loggedInUserId)
    {
        return new GlobalViewModel.ResultModel();
    }

    public GlobalViewModel.ResultModel Deactivate(int id, int loggedInUserId)
    {
        return new GlobalViewModel.ResultModel();
    }

    public GlobalViewModel.ResultModel Reactivate(int id, int loggedInUserId)
    {
        return new GlobalViewModel.ResultModel();
    }

    // public DataSourceResult PopulateGrid(DataSourceRequest data, int loggedInUserId)
    // {
    //     return null;
    // }

    public IEnumerable<GlobalViewModel.DropdownListViewModel> GetAllActivePatientInformation(int loggedInUserId)
    {
        return null;
    }

    public AssetsViewModel GetAssetsInformation(int id, int loggedInUserId)
    {
        return null;
    }
}
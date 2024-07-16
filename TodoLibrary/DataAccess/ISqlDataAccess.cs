
namespace TodoLibrary.DataAccess
{
    public interface ISqlDataAccess
    {
        Task<List<T>> LoadData<T, U>(string storedProcedure, U paramaters, string connectionStringName);
        Task SaveData<T>(string storedProcedure, T paramaters, string connectionStringName);
    }
}
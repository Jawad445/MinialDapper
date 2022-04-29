namespace DataAccess.DbAccess;
public interface ISqlDataAccess
{
    Task<IEnumerable<T>> LoadData<T, U>(string procedureName, U procedureParams, string ConnectionName = "Default");
    Task Save<T>(string procedureName, T procedureParams, string ConnectionName = "Default");
}
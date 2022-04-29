using DataAccess.DbAccess;
using DataAccess.Models;

namespace DataAccess.Data;

public class UserService : IUserService
{
    private readonly ISqlDataAccess _db;

    public UserService(ISqlDataAccess db)
    {
        _db = db;
    }

    public Task<IEnumerable<UserModel>> GetUser() =>
        _db.LoadData<UserModel, dynamic>("dbo.spUser_GetAll", new { });

    public async Task<UserModel?> GetUser(int id)
    {
        var result = await _db.LoadData<UserModel, dynamic>("dbo.spUser_Get", new { Id = id });
        return result.FirstOrDefault();
    }

    public Task InsertUser(UserModel user) =>
        _db.Save("dbo.spUser_Insert", new { user.FirstName, user.LastName });

    public Task UpdateUser(UserModel user) =>
        _db.Save("dbo.spUser_Update", user);


    public Task DeleteUser(int id) =>
        _db.Save("dbo.spUser_Delete", new { Id = id });

}

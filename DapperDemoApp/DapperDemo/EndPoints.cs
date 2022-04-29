namespace DapperDemo;
public static class EndPoints
{
    public static void ConfigureAPI(this WebApplication app)
    {
        app.MapGet("/Users", GetUsers).WithDisplayName("Get");
        app.MapGet("/User/{id}", GetUser).WithDisplayName("GetById");
        app.MapPost("/Users", AddUser);
        app.MapPut("/Users", UpdateUser);
        app.MapDelete("/Users/{id}", DeleteUser);
    }

    private static async Task<IResult> GetUsers(IUserService data)
    {
        try
        {
            return Results.Ok(await data.GetUser());
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }
    private static async Task<IResult> GetUser(int id, IUserService data)
    {
        try
        {
            var user = await data.GetUser(id);
            if (user == null)
                return Results.NotFound();

            return Results.Ok(user);
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }

    private static async Task<IResult> AddUser(UserModel user, IUserService data)
    {
        try
        {
            await data.InsertUser(user);
            
            return Results.Ok(user);
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }

    private static async Task<IResult> UpdateUser(UserModel user, IUserService data)
    {
        try
        {
            await data.UpdateUser(user);

            return Results.Ok(user);
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }
    
    private static async Task<IResult> DeleteUser(int id, IUserService data)
    {
        try
        {
            await data.DeleteUser(id);

            return Results.Ok();
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }
}

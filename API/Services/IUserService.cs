using Microsoft.Extensions.Options;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;

interface IUserService
{
    Task<IEnumerable<UserDto>> GetUsersAsync();
}

public class UserService : IUserService
{
    public async Task<IEnumerable<UserDto>> GetUsersAsync()
    {
        var users = new List<UserDto>();

        var options = new JsonSerializerOptions
        {
            WriteIndented = true
        };

        DirectoryInfo info = new DirectoryInfo("./Data/Users");
        var files = info.GetFiles();
            
        foreach (var file in files)
        {
            using (FileStream fs = file.OpenRead())
            {
                var userEntity = await JsonSerializer.DeserializeAsync<User>(fs);
                if (userEntity == null) { continue; }
                var t = userEntity.Registered;
                if(DateTime.TryParse(userEntity.Registered, out DateTime d))
                {
                    t = d.ToString("dd-mm-yyyy dd:mm:ss");
                }
                var user = new UserDto(userEntity.Name, userEntity.Age, t, userEntity.Email, userEntity.Balance, userEntity.IconName ?? "");
                users.Add(user);
            }
        }
        
        return users;
    }
}

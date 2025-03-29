using CustomPowerPoint.Data.Models;

namespace CustomPowerPoint.Data.Repositories
{
    public class UserRepository : BaseRepository<UserData>
    {
        public UserRepository(WebDbContext webDbContext) : base(webDbContext)
        {
        }

        public UserData? GetByNickname(string nickname)
        {
            return _dbSet.FirstOrDefault(u => u.Nickname == nickname);
        }

        public string? GetNicknameById(string id)
        {
            if (Guid.TryParse(id, out Guid guid))
            {
                var user = Get(guid);
                return user?.Nickname;
            }
            return null;
        }

        public Guid AddUser(UserData user)
        {
            return Add(user);
        }
    }
}

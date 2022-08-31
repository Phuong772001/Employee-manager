using Manage.Common;
using Manage.Model.Context;
using Manage.Model.DTO.User;
using Manage.Model.Models;
using Manage.Repository.Base.Repository;
using Manage.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Manage.Repository.Repository
{
    public class UserRepository : RepositoryBase<SeUser>, IUserRepository
    {
        public UserRepository(DatabaseContext context) : base(context)
        {
        }
        public async Task<bool> CheckPassword(SeUser user, string password)
        {
            if (user.Password == password)
                return true;
            return false;
        }

        public async Task<bool> CheckRefreshToken(string username, string refreshToken)
        {
            SeUser seUser = await FindByUsername(username);
            if (seUser.refresh_token == refreshToken)
            {
                long refresh_exp_long = long.Parse(ConvertToUnixTimestamp(seUser.expired_time).ToString());
                DateTime refresh_exp_datetime = ConvertToDateTime(refresh_exp_long);
                if (refresh_exp_datetime < DateTime.UtcNow)
                    return false;
                return true;
            }
            return false;
        }

        public async Task<string> CheckUserLogin(string username, string password)
        {
            SeUser seUser = await FindByUsername(username);
            if (seUser == null)
                return "wrong username";
            bool isTrue = await CheckPassword(seUser, password);
            if (isTrue == false)
                return "wrong password";
            return null;
        }

        public async Task<List<SeUser>> FindAllData(BaseRequest baseRequest)
        {
            if (baseRequest.keyworks != null)
            {
                return await FindAll()
           .Where(n => n.Role.Equals(baseRequest.keyworks) && n.Activeflg.Equals("A") && n.Id >0)
           .OrderBy(a => a.Id)
           .Skip((baseRequest.pageNum - 1) * baseRequest.pageSize)
           .Take(baseRequest.pageSize)
           .ToListAsync();
            }

            return await FindAll()
           .Where(n => n.Activeflg.Equals("A")&& n.Id >0)
           .OrderBy(a => a.Id)
           .Skip((baseRequest.pageNum - 1) * baseRequest.pageSize)
           .Take(baseRequest.pageSize)
           .ToListAsync();
        }
        public async Task<SeUser> FindByUsername(string username)
        {
            return await FindByCondition(u => u.Username.Equals(username)).FirstOrDefaultAsync();
        }
        private DateTime ConvertToDateTime(long expDate)
        {
            DateTime dateTimeInterval = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            dateTimeInterval = dateTimeInterval.AddSeconds(expDate).ToUniversalTime();
            return dateTimeInterval;
        }
        public double ConvertToUnixTimestamp(DateTime date)
        {
            DateTime origin = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            TimeSpan diff = date.ToUniversalTime() - origin;
            return Math.Floor(diff.TotalSeconds);
        }
    }
}

using App.Data.Infrastructure;
using App.Data.Repositories;
using App.Model;
using MongoDB.Driver;
using System.Threading.Tasks;

namespace App.Service
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IUnitOfWork _unitOfWork;
        public UserService(IUserRepository userRepository, IUnitOfWork unitOfWork)
        {
            _userRepository = userRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<User> GetUserByEmail(string email)
        {
            var filter = Builders<User>.Filter.And(Builders<User>.Filter.Eq(x => x.Email, email));
            var result = await _userRepository.GetByFilter(filter);
            //return result;
        }

        public async Task<User> RegisterUser(User user)
        {
           user = _userRepository.Add(user);
           await _unitOfWork.Commit();
            return user;
        }
    }

    public interface IUserService
    {
        Task<User> GetUserByEmail(string email);
        Task<User> RegisterUser(User user);

    }

}

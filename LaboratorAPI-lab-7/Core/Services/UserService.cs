using Core.Dtos;
using DataLayer;
using DataLayer.Dtos;
using DataLayer.Entities;
using DataLayer.Mapping;

namespace Core.Services
{
    public class UserService
    {
        private readonly UnitOfWork unitOfWork;

        public UserService(UnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public UserAddDto Add(UserAddDto payload)
        {
            if (payload == null) return null;

            var hasNameConflict = unitOfWork.Users
                .Any(c => c.Username == payload.Username);

            if (hasNameConflict) return null;

            var newUser= new User
            {
                Username = payload.Username,
                Role = payload.Role
            };

            unitOfWork.Users.Insert(newUser);
            unitOfWork.SaveChanges();

            return payload;
        }
        public UserDto GetByUserName(string username)
        {
            return unitOfWork.Users.GetAll().FirstOrDefault(user => user.Username == username).ToUserDto();
        }
    }
}

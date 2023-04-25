using Core.Dtos;
using DataLayer;
using DataLayer.Entities;


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
    }
}

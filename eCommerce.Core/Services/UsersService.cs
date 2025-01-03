using AutoMapper;
using eCommerce.Core.DTO;
using eCommerce.Core.Entities;
using eCommerce.Core.RepositoryContracts;
using eCommerce.Core.ServiceContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Core.Services
{
    internal class UsersService : IUsersService
    {
        private readonly IUsersRepository _usersRepository;
        private readonly IMapper _mapper;

        public UsersService(IUsersRepository usersService, IMapper mapper)
        {
            _usersRepository = usersService;
            _mapper = mapper;
        }
        public async Task<AuthenticationResponse?> Login(LoginRequest loginRequest)
        {
            ApplicationUser? applicationUser = await _usersRepository.GetUserByEmailAndPassword(loginRequest.Email, loginRequest.Password);
            if (applicationUser == null)
            {
                return null;
            }
            //return new AuthenticationResponse(applicationUser.UserID, applicationUser.Email, applicationUser.PersonName, 
            //     applicationUser.Gender,"token", true);           

            return _mapper.Map<AuthenticationResponse>(applicationUser) with { Success = true, Token = "token" };
        }

        public async Task<AuthenticationResponse?> Registration(RegisterRequest registerRequest)
        {
            //ApplicationUser applicationUser = new ApplicationUser()
            //{
            //    Email = registerRequest.Email,
            //    Password = registerRequest.Password,
            //    PersonName = registerRequest.PersonName,
            //    Gender = registerRequest.Gender.ToString()
            //};

            ApplicationUser applicationUser = _mapper.Map<ApplicationUser>(registerRequest);

            ApplicationUser? registeredUser = await _usersRepository.AddUser(applicationUser);
            if (registeredUser == null) {
                return null;
            }

            //return new AuthenticationResponse(registeredUser.UserID, registeredUser.Email, registeredUser.PersonName, 
            //    registeredUser.Gender, "", true);
            return _mapper.Map<AuthenticationResponse>(registeredUser) with { Success = true, Token = "token" };
        }
    }
}

﻿using AutoMapper;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using Template.Application.Interfaces;
using Template.Application.ViewModels;
using Template.Domain.Entities;
using Template.Domain.Interfaces;

namespace Template.Application.Services
{
    public class UserService: IUserService
    {
        private readonly IUserRepository userRepository;
        private readonly IMapper mapper;

        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            this.userRepository = userRepository;
            this.mapper = mapper;   
        }

        public List<UserViewModel> Get()
        {
            List<UserViewModel> _userviewModels = new List<UserViewModel>();

            IEnumerable<User> _users = this.userRepository.GetAll();

            _userviewModels = mapper.Map<List<UserViewModel>>(_users);

           // foreach (var item in _users)            
              //  _userviewModels.Add(new UserViewModel { Id = item.Id, Email= item.Email, Name = item.Name });
            

            return _userviewModels;
        }

        public bool Post(UserViewModel userViewModel)
        {
            //mapeamento manual antes de usar o AutoMapper
            /*User _user = new User
            {
                Id = Guid.NewGuid(),
                Email = userViewModel.Email,
                Name = userViewModel.Name
               

            };*/

            User _user = mapper.Map<User>(userViewModel);   

            this.userRepository.Create( _user );

            return true;
        }

        public UserViewModel GetById (string id)
        {
            if (!Guid.TryParse(id, out Guid userId))
            {
                throw new Exception("UserID is not valid");
            }

            User _user = this.userRepository.Find(x => x.Id == userId && !x.IsDeleted);
            if (_user == null)
                throw new Exception("User not found");

            return mapper.Map<UserViewModel>( _user );
        }

        public bool Put(UserViewModel userViewModel)
        {
            User _user = this.userRepository.Find(x => x.Id == userViewModel.Id && !x.IsDeleted);
            if (_user == null)
                throw new Exception("User not found");

            _user = mapper.Map<User>(userViewModel);

            this.userRepository.Update(_user);

            return true;
        }

        public bool Delete(string id)
        {
            if (!Guid.TryParse(id, out Guid userId))
            {
                throw new Exception("UserID is not valid");
            }

            User _user = this.userRepository.Find(x => x.Id == userId && !x.IsDeleted);
            if (_user == null)
                throw new Exception("User not found");            

            return this.userRepository.Delete(_user);
        }
    }
}

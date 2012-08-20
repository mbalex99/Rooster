using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Rooster.DataAccess.Infrastructure;
using Rooster.DataAccess.Repositories;
using Rooster.Domain.Entities;
using Rooster.Security;

namespace Rooster.Service
{
    public interface ISecurityService
    {
        bool ValidateMember(string emailAddress, string password);
        bool ChangeMemberPassword(Member member, string oldPassword, string newPassword);

        IEnumerable<T> GetUsers<T>() where T : User;
        T GetUserByUserId<T>(int userId) where T : User;
        T GetUserByEmailAddress<T>(string emailAddress) where T : User;

        void CreateUser(User user);
        void DeleteUserById(int userId);
        void UpdateUser(User user);

        Role GetRoleByRoleId(int roleId);
        Role GetRoleByRoleName(string roleName);
        
        void CreateRole(Role role);
        void DeleteRoleById(int roleId);
        void UpdateRole(Role role);

        bool IsMemberInRole(Member member, int roleId);
        void AssignRoleToMember(Member member, Role role);
        void UnassignRoleFromMember(Member member, Role role);
    }

    public class SecurityService:ISecurityService
    {
        private readonly IUserRepository _userRepository;
        private readonly IRoleRepository _roleRepository;
        private readonly IUnitOfWork _unitOfWork;

        public SecurityService(IUserRepository userRepository, IRoleRepository roleRepository, IUnitOfWork unitOfWork)
        {
            _userRepository = userRepository;
            _roleRepository = roleRepository;
            _unitOfWork = unitOfWork;
        }

        public bool ValidateMember(string emailAddress, string password)
        {
            throw new NotImplementedException();
        }

        public bool ChangeMemberPassword(Member member, string oldPassword, string newPassword)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> GetUsers<T>() where T : User
        {
            return _userRepository.GetAll().OfType<T>();
        }

        public T GetUserByUserId<T>(int userId) where T : User
        {
            return _userRepository.Get(n => n.UserId == userId) as T;
        }

        public T GetUserByEmailAddress<T>(string emailAddress) where T : User
        {
            return _userRepository.Get(n => n.Email.EmailAddress == emailAddress) as T;
        }

        public void CreateUser(User user)
        {
            _userRepository.Add(user);
            SaveChanges();
        }

        public void DeleteUserById(int userId)
        {
            _userRepository.Delete(n => n.UserId == userId);
            SaveChanges();
        }

        public void UpdateUser(User user)
        {
            _userRepository.Update(user);
            SaveChanges();
        }

        public Role GetRoleByRoleId(int roleId)
        {
            return _roleRepository.GetById(roleId);
        }

        public Role GetRoleByRoleName(string roleName)
        {
            return _roleRepository.Get(n => n.Name.Equals(roleName));
        }

        public void CreateRole(Role role)
        {
            _roleRepository.Add(role);
            SaveChanges();
        }

        public void DeleteRoleById(int roleId)
        {
            _roleRepository.Delete(n => n.RoleId == roleId);
            SaveChanges();
        }

        public void UpdateRole(Role role)
        {
            _roleRepository.Update(role);
            SaveChanges();
        }

        public bool IsMemberInRole(Member member, int roleId)
        {
            Role role = GetRoleByRoleId(roleId);
            return role.Members.Any(n => n.Equals(member));
        }

        public bool IsMemberInRole(Member member, string roleName)
        {
            Role role = GetRoleByRoleName(roleName);
            return role.Members.Any(n => n.Equals(member));
        }

        public void AssignRoleToMember(Member member, Role role)
        {
            member.Roles.Add(role);
            _userRepository.Update(member);
            SaveChanges();
        }

        public void UnassignRoleFromMember(Member member, Role role)
        {
            member.Roles.Remove(role);
            _userRepository.Update(member);
            SaveChanges();
        }

        private void SaveChanges()
        {
            _unitOfWork.Commit();
        }



    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Rooster.DataAccess.Infrastructure;
using Rooster.DataAccess.Repositories;
using Rooster.Domain.Entities;

namespace Rooster.Service
{
    public interface IProfileService
    {
        void CreateProfile(Profile profile);
        void UpdateProfile(Profile profile);
        Profile GetProfileById(int profileId);
        IEnumerable<Profile> GetProfiles(); 
        void DeleteProfileId(int profileId);
    }

    public class ProfileService:IProfileService
    {
        private readonly IProfileRepository _profileRepository;
        private readonly IUnitOfWork _unitOfWork;

        public ProfileService(IProfileRepository profileRepository, IUnitOfWork unitOfWork)
        {
            _profileRepository = profileRepository;
            _unitOfWork = unitOfWork;
        }

        public void CreateProfile(Profile profile)
        {
            _profileRepository.Add(profile);
            SaveChanges();
        }

        public void UpdateProfile(Profile profile)
        {
            _profileRepository.Update(profile);
            SaveChanges();
        }

        public Profile GetProfileById(int profileId)
        {
            return _profileRepository.GetById(profileId);
        }

        public IEnumerable<Profile> GetProfiles()
        {
            return _profileRepository.GetAll();
        }

        public void DeleteProfileId(int profileId)
        {
            _profileRepository.Delete(GetProfileById(profileId));
            SaveChanges();
        }

        private void SaveChanges()
        {
            _unitOfWork.Commit();
        }


    }
}

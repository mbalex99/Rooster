using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Rooster.DataAccess.Infrastructure;
using Rooster.DataAccess.Repositories;
using Rooster.Domain.Entities;

namespace Rooster.Service
{
    public interface IPostService
    {
        void CreatePost(Post post);
        Post GetPostById(int postId);
        IEnumerable<Post> GetPosts();
        void DeletePost(int postId);
    }
    public class PostService:IPostService
    {
        private readonly IPostRepostiory _postRepository;
        private readonly IUnitOfWork _unitOfWork;
        
        public PostService(IPostRepostiory postRepostiory, IUnitOfWork unitOfWork)
        {
            _postRepository = postRepostiory;
            _unitOfWork = unitOfWork;
        }

        public void CreatePost(Post post)
        {
            _postRepository.Add(post);
            SaveChanges();
        }

        public Post GetPostById(int postId)
        {
            return _postRepository.GetById(postId);
        }

        public IEnumerable<Post> GetPosts()
        {
            return _postRepository.GetAll();
        }

        public void DeletePost(int postId)
        {
            _postRepository.Delete(GetPostById(postId));
            SaveChanges();
        }

        private void SaveChanges()
        {
            _unitOfWork.Commit();
        }
    }
}

using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Rooster.DataAccess;
using Rooster.DataAccess.Infrastructure;
using Rooster.DataAccess.Repositories;
using Rooster.Service;


namespace Rooster.Website.Infrastructure
{
    public static class UnityBootstrapper
    {
        public static IUnityContainer GetUnityContainer()
        {
            IUnityContainer container = new UnityContainer();

            //DataAccess Type Registration
            container
                .RegisterType<IDatabaseFactory, DatabaseFactory>(new HttpContextLifetimeManager<IDatabaseFactory>())
                .RegisterType<IUnitOfWork, UnitOfWork>(new HttpContextLifetimeManager<IUnitOfWork>());


            //Repository Type Registration
            container
                .RegisterType<IUserRepository, UserRepository>(new HttpContextLifetimeManager<UserRepository>())
                .RegisterType<IEmailRepository, EmailRepository>(new HttpContextLifetimeManager<EmailRepository>())
                .RegisterType<IPostRepostiory, PostRepository>(new HttpContextLifetimeManager<PostRepository>())
                .RegisterType<IRoleRepository, RoleRepository>(new HttpContextLifetimeManager<RoleRepository>())
                .RegisterType<IProfileRepository, ProfileRepository>(new HttpContextLifetimeManager<ProfileRepository>());

            //Service Type Registration
            container
                .RegisterType<ISecurityService, SecurityService>(new HttpContextLifetimeManager<SecurityService>());


            return container;
        }
    }
}
using AKS.BLL.IRepository;
using AKS.BLL.Repository;
using System.Web.Mvc;
using Unity;
using Unity.Mvc5;

namespace AKS
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<IUserRepository, UserRepository>();
            container.RegisterType<IUserRepository, UserRepository>();
            container.RegisterType<IInventoryRepository, InventoryRepository>();
            container.RegisterType<IMasterRepository, MasterRepository>();
            container.RegisterType<IAccountsRepository, AccountsRepository>();
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using AutoMapper;
using Banks;
using DataAccess.Repo;
using FluentScheduler;
using HtmlParse;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SimpleInjector;
using SqlLiteData;

namespace LogicApp
{
    public class ParserJob : IJob
    {
        public void Execute()
        {
            var container = CreateContainer();
            container.GetInstance<Parser>().Start();
        }

        private static Container CreateContainer()
        {
            var container = new Container();
            container.Register<ICityService, CityService>(Lifestyle.Singleton);
            container.Register<ICityRepository, CityRepository>(Lifestyle.Singleton);

            container.Register<IBankService, BankService>(Lifestyle.Singleton);
            container.Register<IBankRepository, BankRepository>(Lifestyle.Singleton);

            container.Register<IBranchService, BranchService>(Lifestyle.Singleton);
            container.Register<IBranchRepository, BranchRepository>(Lifestyle.Singleton);

            container.Register<ICurrencyService, CurrencyService>(Lifestyle.Singleton);
            container.Register<ICurrencyRepository, CurrencyRepository>(Lifestyle.Singleton);

            container.Register<IQuotationService, QuotationService>(Lifestyle.Singleton);
            container.Register<IQuotationRepository, QuotationRepository>(Lifestyle.Singleton);

            container.Register<IMapper>(() => CreateMapper(), Lifestyle.Singleton);
            container.Register<Parser>(Lifestyle.Singleton);
            container.Verify();
            return container;
        }

        private static IMapper CreateMapper()
        {
            var config = new MapperConfiguration(cfg => cfg.AddProfiles(new List<Profile>()
            {
                new BankMappingProfile(), 
                new BranchMappingProfile(),
                new CityMappingProfile(),
                new CurrencyMappingProfile(),
                new QuotationMappingProfile()
            }));
            var mapper = config.CreateMapper();
            return mapper;
        }

    }
}

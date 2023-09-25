using MotoApp.Data;
using MotoApp.Entities;
using MotoApp.Repositories;
using MotoApp.Repositories.Extensions;

var businessPartnerRepository = new SqlRepository<BusinessPartner>(new MotoAppDbContext());

AddEmployees(businessPartnerRepository);
WriteAllToConsole(businessPartnerRepository);

static void AddEmployees(IRepository<BusinessPartner> businessPartnerRepository)
{
    var businessPartner = new[]
    {
        new Employee { },
        new Employee { },
        new Employee { }
    };
    businessPartnerRepository.AddBatch(businessPartner);
}



static void WriteAllToConsole(IReadRepository<IEntity> repository)
{
    var items = repository.GetAll();
    foreach (var item in items)
    {
        Console.WriteLine(item);
    }
}

using System.Collections;
namespace DokanyApp.Core.InterfacesRepo
{
    public interface ICustomerRepository
    {
        void Add(Customer p);
        void Edit(Customer p);
        void Remove(int Id);
        IEnumerable GetCustomers();
        Customer FindById(int Id);
    }
}

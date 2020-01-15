using DokanyApp.Core.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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

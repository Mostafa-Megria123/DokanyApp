using DokanyApp.Core.Models;
using System;
using System.Collections;
using System.Collections.Generic;

namespace DokanyApp.Core.InterfacesRepo
{
    public interface IShippingInfoRepository
    {

        void Add(ShippingInfo p);
        void Edit(ShippingInfo p);
        void Remove(int Id);
        IEnumerable GetShippingInfo();
        ShippingInfo FindById(int Id);
    }
}

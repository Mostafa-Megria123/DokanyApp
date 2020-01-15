using System;
using System.Collections.Generic;

namespace DokanyApp.Core.Interfaces
{
    public interface ICategory
    {
        int CategoryId { get; set; }
        string CategoryName { get; set; }
        string Description { get; set; }

        ICollection<IProduct> Product { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Client.Models;

namespace Client.Interfaces;

// public interface ISupplierService<T> : IServices<T>
// {

// }
public interface ISupplierService
{
    Task Add(Supplier data);
    Task<Supplier> FindById(int id);
    Task<List<Supplier>> ListAll();
    Task Delete(Supplier data);
    Task Update(Supplier data);
}

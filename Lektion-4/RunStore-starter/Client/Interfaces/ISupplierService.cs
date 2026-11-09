using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Client.Models;

namespace Client.Interfaces;

// public interface ISupplierService<T> : IServices<T>
// {


public interface ISupplierService<T> : IServices<T> where T : class
{
    Task Add(Supplier data);
    new Task<Supplier> FindById(int id);
    new Task<List<Supplier>> ListAll();
    Task Delete(Supplier data);
    Task Update(Supplier data);
}

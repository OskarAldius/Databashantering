using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Client.Interfaces;
using Client.Models;
using Npgsql;

namespace Client.Services;

// public class SupplierServices : BaseService, ISupplierService<Supplier>
public class SupplierServices : BaseService, ISupplierService
{
    public Task Add(Supplier data)
    {
        throw new NotImplementedException();
    }

    public Task Delete(Supplier data)
    {
        throw new NotImplementedException();
    }

    public Task<Supplier> FindById(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<List<Supplier>> ListAll()
    {
        try
        {
            List<Supplier> suppliers = [];

            // Hämta data ifron postgres
            //1. Skapa ett anslutingsobjekt
            using NpgsqlConnection connection = new(ConnectionString);
            // 2. Skapa ett fråge objekt
            using NpgsqlCommand command = connection.CreateCommand();
            // 3. Lägg till sql frågan till frågeobjektet
            command.CommandText = @"SELECT 
                                       id,
                                        suppliername
                                    FROM suppliers";

            // 4. Öppna nu anslutningen till databasen => neon.com...
            await connection.OpenAsync();
            // 5. kör frågan
            using NpgsqlDataReader reader = await command.ExecuteReaderAsync();
            // iterar igenom resultatet
            while (await reader.ReadAsync())
            {
                suppliers.Add(new Supplier
                {
                    Id = reader.GetInt32(0),
                    Name = reader.GetString(1)

                });
            }


            return suppliers;
        }
        catch (InvalidOperationException ex)
        {
            throw new Exception(ex.Message);

        }
        catch (Exception ex)
        {

            throw new Exception(ex.Message);
        }
    }

    public Task Update(Supplier data)
    {
        throw new NotImplementedException();
    }


}

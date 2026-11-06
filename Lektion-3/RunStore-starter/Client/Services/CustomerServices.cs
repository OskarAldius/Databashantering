using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Client.Interfaces;
using Client.Models;
using Npgsql;

namespace Client.Services;

public class CustomerServices : BaseService, ICustomerService
{
    public async Task<List<Customer>> List()
    {
        try
        {
            List<Customer> customers = [];

            // Hämta data ifron postgres
            //1. Skapa ett anslutingsobjekt
            using NpgsqlConnection connection = new(ConnectionString);
            // 2. Skapa ett fråge objekt
            using NpgsqlCommand command = connection.CreateCommand();
            // 3. Lägg till sql frågan till frågeobjektet
            command.CommandText = @"SELECT 
                                        id,
                                        firstname,
                                        lastname,
                                        email
                                        FROM customers";
            // 4. Öppna nu anslutningen till databasen => neon.com...
            await connection.OpenAsync();
            // 5. kör frågan
            using NpgsqlDataReader reader = await command.ExecuteReaderAsync();
            // iterar igenom resultatet
            while (await reader.ReadAsync())
            {
                customers.Add(new Customer
                {
                    Id = reader.GetInt32(0),
                    FirstName = reader.GetString(1),
                    LastName = reader.GetString(2),
                    Email = reader.GetString(3)

                });
            }


            return customers;
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
}

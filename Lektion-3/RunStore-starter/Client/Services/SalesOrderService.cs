using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Client.Interfaces;
using Client.Models;
using Npgsql;

namespace Client.Services;

public class SalesOrderService : BaseService, ISalesOrdersService
{
    public async Task Add(SalesOrder order)
    {

    }

    public async Task<List<SalesOrder>> List()
    {
        try
        {
            List<SalesOrder> salesOrders = [];

            // Hämta data ifron postgres
            //1. Skapa ett anslutingsobjekt
            using NpgsqlConnection connection = new(ConnectionString);
            // 2. Skapa ett fråge objekt
            using NpgsqlCommand command = connection.CreateCommand();
            // 3. Lägg till sql frågan till frågeobjektet
            command.CommandText = @"SELECT
                            o.id,
                            o.orderdate,
                            c.firstname,
                            c.lastname,
                            c.email,
                            CAST(SUM(od.quantity * od.price) AS INT) AS ordersum
                        FROM salesorders AS o
                        INNER JOIN orderitems AS od ON o.id = od.order_id
                        INNER JOIN customers AS c ON o.customer_id = c.id
                        GROUP BY o.id, o.orderdate, c.firstname, c.lastname, c.email
                        ORDER BY o.id";
            // 4. Öppna nu anslutningen till databasen => neon.com...
            await connection.OpenAsync();
            // 5. kör frågan
            using NpgsqlDataReader reader = await command.ExecuteReaderAsync();
            // iterar igenom resultatet
            while (await reader.ReadAsync())
            {
                salesOrders.Add(new SalesOrder
                {
                    OrderId = reader.GetInt32(0),
                    OrderDate = reader.GetDateTime(1),
                    Customer = new Customer
                    {
                        FirstName = reader.GetString(2),
                        LastName = reader.GetString(3),
                        Email = reader.GetString(4)
                    },
                    OrderSum = reader.GetInt32(5)

                });
            }


            return salesOrders;
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


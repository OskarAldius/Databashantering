using System;

namespace Client.Entities;

public class SalesOrders
{
    public int Id { get; set; }
    public required string OrderNumber { get; set; }
    public DateOnly OrderDate { get; set; }
}

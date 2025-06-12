using System;
using TestAdvanced.ECommerce.Domain.Entities;

namespace TestAdvanced.ECommerce.Application.UserCases.CreateOrder;

public record CreateOrderInput(
    int CustomerId,
    CreateOrderAddressInput Address,
    IEnumerable<CreateOrderItemInput> Items);

public record CreateOrderAddressInput(
    string Street,
    string City,
    string State,
    string ZipCode,
    int Number
    )
{
    public Address ToAddress() => new(Street, City, State, ZipCode, Number);
    }

public record CreateOrderItemInput(
    String Name,
    int Quantity,
    decimal Price
    )
{
        public OrderItem ToOrderItem() => new(Name, Quantity, Price);
    }
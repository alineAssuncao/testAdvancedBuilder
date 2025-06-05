using TestAdvanced.ECommerce.Domain;
using FluentAssertions;
using Xunit;
using System;
using TestAdvanced.ECommerce.UnitTests.DataBuilders;
using System.Collections.Generic;
using static TestAdvanced.ECommerce.UnitTests.DataBuilders.CustomerDataBuilder;
using static TestAdvanced.ECommerce.UnitTests.DataBuilders.OrderDataBuilder;
using static TestAdvanced.ECommerce.UnitTests.DataBuilders.OrderItemDataBuilder;
using System.Threading;

namespace TestAdvanced.ECommerce.UnitTests.Domain;

public class OrderTest
{
    [Fact]
    public void throwsAnExceptionWhenConstructionWithCustomerNull()
    {

        var act = () => new OrderDataBuilder()
            .WithCustomer(null!)
            .Build();
        act.Should().Throw<ArgumentNullException>();
    }

    [Fact]
    public void CreateOrderWhenArgumentsAreValid()
    {
        var order = new OrderDataBuilder().Build();
        order.Should().NotBeNull();
    }

    [Fact]
    public void Give10PercentDiscountWhenCustomerIsPremium()
    {
        var anOrder = AnOrder()
            .From(APremiumCustomer())
            .WithItem(quantity: 2, price: 10)
            .WithItem(quantity: 4, price: 20)
            .Build();

        anOrder.Amount.Should().Be(90);
    }

    [Fact]
    public void CalculateAmmountWithDiscountForMultipleItemsOfSameProduct()
    {
        var book = AnOrderItem()
            .WithName("Refactoring")
            .WithPrice(100)
            .WithQuantity(1);

        var bookWithSmallerDiscount = book
            .WithDiscount(0.1m)
            .Build();

        var bookWithGreaterDiscount = book
          .WithDiscount(0.2m)
          .Build();

        var order = AnOrder()
            .WithItems(bookWithSmallerDiscount, bookWithGreaterDiscount)
            .From(ARegularCustomer())
            .Build();

        order.Amount.Should().Be(170);
    }

    [Fact]  
    public void throwsAnExceptionWhenTryingToCancelADeliveredOrder()
    {
        var order = AnOrder()
            .WithStatus(OrderStatus.Delivered)
            .Build();

        var act = () => order.Cancel();

        act.Should().Throw<InvalidOperationException>();
    }
}
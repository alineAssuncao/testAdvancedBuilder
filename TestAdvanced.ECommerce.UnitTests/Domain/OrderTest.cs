using TestAdvanced.ECommerce.Domain;
using FluentAssertions;
using Xunit;
using System;
using TestAdvanced.ECommerce.UnitTests.DataBuilders;
using System.Collections.Generic;
using static TestAdvanced.ECommerce.UnitTests.DataBuilders.CustomerDataBuilder;
using static TestAdvanced.ECommerce.UnitTests.DataBuilders.OrderDataBuilder;

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
            .With(APremiumCustomer())
            .WithItem(quantity: 2, price: 10)
            .WithItem(quantity: 4, price: 20)
            .Build();

        anOrder.Amount.Should().Be(90); 
    }
}
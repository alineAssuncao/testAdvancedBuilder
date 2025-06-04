using TestAdvanced.ECommerce.Domain;
using FluentAssertions;
using Xunit;
using System;
using TestAdvanced.ECommerce.UnitTests.DataBuilders;

namespace TestAdvanced.ECommerce.UnitTests.Domain;

public class OrderTest
{
    [Fact]
    public void throwsAnExceptionWhenConstructionWithCustomerNull()
    {

        var act = () => new OrderDataBuilder()
            .WithCustomer(null)
            .Build();
        act.Should().Throw<ArgumentNullException>();
    }

    [Fact]
    public void CreateOrderWhenArgumentsAreValid()
    {
        var order = new OrderDataBuilder().Build();
        order.Should().NotBeNull();
    }
}
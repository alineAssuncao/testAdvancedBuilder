using TestAdvanced.ECommerce.Domain;
using FluentAssertions;
using Xunit;
using System;
using TestAdvanced.ECommerce.UnitTests.DataBuilders;

namespace TestAdvanced.ECommerce.UnitTests.Domain;

public class AddressTest
{
    [Fact]
    public void ThrowExeptionWhenConstructingAndStreetIsNull()
    {
        Action act = () => new AddressDataBuilder()
            .WithStreet(null!)
            .Build();

        act.Should().Throw<ArgumentNullException>();
    }

    [Fact]
    public void ThrowExeptionWhenConstructingAndStreetIsEmpty()
    {
        Action act = () => new AddressDataBuilder()
            .WithStreet("")
            .Build();

        act.Should().Throw<ArgumentException>();
    }

    [Fact]
    public void ThrowExeptionWhenConstructingAndCityIsNull()
    {
        Action act = () => new AddressDataBuilder()
            .WithCity(null!)
            .Build();

        act.Should().Throw<ArgumentNullException>();
    }

    [Fact]
    public void ThrowExeptionWhenConstructingAndCityIsEmpty()
    {
        Action act = () => new AddressDataBuilder()
            .WithCity("")
            .Build();

        act.Should().Throw<ArgumentException>();
    }

    [Fact]
    public void CreateAddressWhenArgumentsAreValid()
    {
        var Address = new AddressDataBuilder().Build();
        Address.Should().NotBeNull();
    }
}
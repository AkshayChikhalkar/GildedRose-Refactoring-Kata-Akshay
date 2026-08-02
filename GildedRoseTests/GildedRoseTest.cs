using System.Collections.Generic;
using GildedRoseKata;
using Xunit;

namespace GildedRoseTests;

public class GildedRoseTest
{
    private static Item Update(string name, int sellIn, int quality)
    {
        var item = new Item
        {
            Name = name,
            SellIn = sellIn,
            Quality = quality
        };

        var app = new GildedRose(new List<Item> { item });
        app.UpdateQuality();

        return item;
    }

    [Fact]
    public void NormalItem_DegradesByOne_BeforeSellDate()
    {
        var item = Update("+5 Dexterity Vest", sellIn: 10, quality: 20);

        Assert.Equal(9, item.SellIn);
        Assert.Equal(19, item.Quality);
    }

    [Fact]
    public void NormalItem_DegradesByTwo_AfterSellDate()
    {
        var item = Update("+5 Dexterity Vest", sellIn: 0, quality: 20);

        Assert.Equal(-1, item.SellIn);
        Assert.Equal(18, item.Quality);
    }

    [Fact]
    public void NormalItem_QualityIsNeverNegative()
    {
        var item = Update("+5 Dexterity Vest", sellIn: 5, quality: 0);

        Assert.Equal(4, item.SellIn);
        Assert.Equal(0, item.Quality);
    }

    [Fact]
    public void AgedBrie_QualityIsNeverMoreThan50()
    {
        var item = Update("Aged Brie", sellIn: 5, quality: 50);

        Assert.Equal(4, item.SellIn);
        Assert.Equal(50, item.Quality);
    }

    [Fact]
    public void AgedBrie_IncreasesInQuality_BeforeSellDate()
    {
        var item = Update("Aged Brie", sellIn: 5, quality: 0);

        Assert.Equal(4, item.SellIn);
        Assert.Equal(1, item.Quality);
    }

    [Fact]
    public void AgedBrie_IncreasesBy2_AfterSellDate()
    {
        var item = Update("Aged Brie", sellIn: 0, quality: 0);

        Assert.Equal(-1, item.SellIn);
        Assert.Equal(2, item.Quality);
    }

    [Fact]
    public void Sulfuras_DoesNotChange()
    {
        var item1 = Update("Sulfuras, Hand of Ragnaros", sellIn: 5, quality: 80);
        var item2 = Update("Sulfuras, Hand of Ragnaros", sellIn: 2, quality: 80);
        var item3 = Update("Sulfuras, Hand of Ragnaros", sellIn: 0, quality: 80);

        Assert.Equal(5, item1.SellIn);
        Assert.Equal(80, item1.Quality);
        Assert.Equal(2, item2.SellIn);
        Assert.Equal(80, item2.Quality);
        Assert.Equal(0, item3.SellIn);
        Assert.Equal(80, item3.Quality);
    }

    [Fact]
    public void Backstage_IncreasesByOne_WhenSellInAbove10()
    {
        var item = Update(
            "Backstage passes to a TAFKAL80ETC concert",
            sellIn: 11,
            quality: 0);

        Assert.Equal(10, item.SellIn);
        Assert.Equal(1, item.Quality);
    }

    [Fact]
    public void Backstage_IncreasesByTwo_WhenSellInBetween10And5()
    {
        var item = Update(
            "Backstage passes to a TAFKAL80ETC concert",
            sellIn: 10,
            quality: 0);

        Assert.Equal(9, item.SellIn);
        Assert.Equal(2, item.Quality);
    }

    [Fact]
    public void Backstage_IncreasesByThree_WhenSellInBelow5()
    {
        var item = Update(
            "Backstage passes to a TAFKAL80ETC concert",
            sellIn: 5,
            quality: 0);

        Assert.Equal(4, item.SellIn);
        Assert.Equal(3, item.Quality);
    }

    [Fact]
    public void Backstage_QualityDropsTo0_AfterSellDate()
    {
        var item = Update(
            "Backstage passes to a TAFKAL80ETC concert",
            sellIn: 0,
            quality: 10);

        Assert.Equal(-1, item.SellIn);
        Assert.Equal(0, item.Quality);
    }

    [Fact]
    public void Conjured_DegradesByTwo_BeforeSellDate()
    {
        var item = Update("Conjured", sellIn: 10, quality: 20);

        Assert.Equal(9, item.SellIn);
        Assert.Equal(18, item.Quality);
    }

    [Fact]
    public void Conjured_DegradesByFour_AfterSellDate()
    {
        var item = Update("Conjured", sellIn: 0, quality: 20);

        Assert.Equal(-1, item.SellIn);
        Assert.Equal(16, item.Quality);
    }

    [Fact]
    public void Conjured_StartsWithConjured()
    {
        var item = Update("Conjured Test Item", sellIn: 5, quality: 0);

        Assert.Equal(4, item.SellIn);
        Assert.Equal(0, item.Quality);
    }

    [Fact]
    public void Conjured_QualityDoesNotGoNegative_WhenQualityIsOne()
    {
        var item = Update("Conjured Mana Cake", sellIn: 5, quality: 1);

        Assert.Equal(4, item.SellIn);
        Assert.Equal(0, item.Quality);
    }

    [Fact]
    public void Normal_AfterSellDateAtQuality1_Stays0()
    {
        var item = Update("+5 Dexterity Vest", sellIn: 0, quality: 1);

        Assert.Equal(-1, item.SellIn);
        Assert.Equal(0, item.Quality);
    }

    [Fact]
    public void AgedBrie_AtQuality49AfterSellDate_CapsAt50()
    {
        var item = Update("Aged Brie", sellIn: 0, quality: 49);

        Assert.Equal(-1, item.SellIn);
        Assert.Equal(50, item.Quality);
    }

    [Fact]
    public void Backstage_AtQuality49WhenSellIn5_CapsAt50()
    {
        var item = Update(
            "Backstage passes to a TAFKAL80ETC concert",
            sellIn: 5,
            quality: 49);

        Assert.Equal(4, item.SellIn);
        Assert.Equal(50, item.Quality);
    }

    [Fact]
    public void Backstage_AtSellIn6_IncreasesBy2()
    {
        var item = Update(
            "Backstage passes to a TAFKAL80ETC concert",
            sellIn: 6,
            quality: 0);

        Assert.Equal(5, item.SellIn);
        Assert.Equal(2, item.Quality);
    }

    [Fact]
    public void Conjured_AfterSellDateAtQuality3_Stays0()
    {
        var item = Update("Conjured Mana Cake", sellIn: 0, quality: 3);

        Assert.Equal(-1, item.SellIn);
        Assert.Equal(0, item.Quality);
    }
}

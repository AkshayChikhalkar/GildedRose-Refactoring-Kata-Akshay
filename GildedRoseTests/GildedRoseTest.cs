using Xunit;
using System.Collections.Generic;
using GildedRoseKata;

namespace GildedRoseTests;

public class GildedRoseTest
{
    // [Fact]
    // public void foo()
    // {
    //     IList<Item> Items = new List<Item> { new Item { Name = "foo", SellIn = 0, Quality = 0 } };
    //     GildedRose app = new GildedRose(Items);
    //     app.UpdateQuality();
    //     Assert.Equal("fixme", Items[0].Name);
    // }

    //Test 1
    [Fact]
    public void NormalItem_DegradesByOne_BeforeSellDate()
    {
        var items = new List<Item>
        {
            new Item { Name = "+5 Dexterity Vest", SellIn = 10, Quality = 20 }
        };
        var app = new GildedRose(items);

        app.UpdateQuality();

        Assert.Equal(9, items[0].SellIn);
        Assert.Equal(19, items[0].Quality);
    }

    //Test 2
    [Fact]
    public void NormalItem_DegradesByTwo_AfterSellDate()
    {
        var items = new List<Item>
        {
            new Item { Name = "+5 Dexterity Vest", SellIn = 0, Quality = 20 }
        };
        var app = new GildedRose(items);

        app.UpdateQuality();

        Assert.Equal(-1, items[0].SellIn);
        Assert.Equal(18, items[0].Quality);
    }

    //Test 3
    [Fact]
    public void NormalItem_QualityIsNeverNegative(){
        var items = new List<Item>
        {
            new Item { Name = "+5 Dexterity Vest", SellIn = 5, Quality = 0 }
        };
        var app = new GildedRose(items);
        app.UpdateQuality();
        Assert.Equal(0, items[0].Quality);
        Assert.Equal(4, items[0].SellIn);
    }


    //Test 4
    [Fact]
    public void AgedBrie_QualityIsNeverMoreThan50(){
        var items = new List<Item>
        {
            new Item { Name = "Aged Brie", SellIn = 5, Quality = 50 }
        };
        var app = new GildedRose(items);
        app.UpdateQuality();
        Assert.Equal(50, items[0].Quality);
        Assert.Equal(4, items[0].SellIn);
    }

    //Test 5
    [Fact]
    public void AgedBrie_IncreasesInQuality_BeforeSellDate(){
        var items = new List<Item>
        {
            new Item { Name = "Aged Brie", SellIn = 5, Quality = 0 }
        };
        var app = new GildedRose(items);
        app.UpdateQuality();
        Assert.Equal(1, items[0].Quality);
        Assert.Equal(4, items[0].SellIn);
    }

    //Test 6
    [Fact]
    public void AgedBrie_IncreasesBy2_AfterSellDate(){
        var items = new List<Item>
        {
            new Item { Name = "Aged Brie", SellIn = 0, Quality = 0 }
        };
        var app = new GildedRose(items);
        app.UpdateQuality();
        Assert.Equal(2, items[0].Quality);
        Assert.Equal(-1, items[0].SellIn);
    }


    //Test 7
    [Fact]
    public void Sulfuras_QualityIsAlways80(){
        var items = new List<Item>
        {
            new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = 5, Quality = 80 },
            new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = 2, Quality = 80 },
            new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80 }
        };
        var app = new GildedRose(items);
        app.UpdateQuality();
        Assert.Equal(80, items[0].Quality);
        Assert.Equal(5, items[0].SellIn);
        Assert.Equal(80, items[1].Quality);
        Assert.Equal(2, items[1].SellIn);
        Assert.Equal(80, items[2].Quality);
        Assert.Equal(0, items[2].SellIn);
    }

    //Test 8
    [Fact]
    public void Backstage_IncreasesByOne_WhenSellInAbove10(){
        var items = new List<Item>
        {
            new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 11, Quality = 0 }
        };
        var app = new GildedRose(items);
        app.UpdateQuality();
        Assert.Equal(10, items[0].SellIn);
        Assert.Equal(1, items[0].Quality);
    }

    //Test 9
    [Fact]
    public void Backstage_IncreasesByTwo_WhenSellInBetween10And5(){
        var items = new List<Item>
        {
            new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 10, Quality = 0 }
        };
        var app = new GildedRose(items);
        app.UpdateQuality();
        Assert.Equal(9, items[0].SellIn);
        Assert.Equal(2, items[0].Quality);
    }
    
    //Test 10
    [Fact]
    public void Backstage_IncreasesByThree_WhenSellInBelow5(){
        var items = new List<Item>
        {
            new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 5, Quality = 0 }
        };
        var app = new GildedRose(items);
        app.UpdateQuality();
        Assert.Equal(4, items[0].SellIn);
        Assert.Equal(3, items[0].Quality);
    }

    //Test 11
    [Fact]
    public void Backstage_QualityDropsTo0_AfterSellDate(){
        var items = new List<Item>
        {
            new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 0, Quality = 10 }
        };
        var app = new GildedRose(items);
        app.UpdateQuality();
        Assert.Equal(-1, items[0].SellIn);
        Assert.Equal(0, items[0].Quality);
    }


    //Test 12
    [Fact]
    public void Conjured_DegradesByTwo_BeforeSellDate(){
        var items = new List<Item>
        {
            new Item { Name = "Conjured", SellIn = 10, Quality = 20 }
        };
        var app = new GildedRose(items);
        app.UpdateQuality();
        Assert.Equal(9, items[0].SellIn);
        Assert.Equal(18, items[0].Quality);
    }
    
    //Test 13
    [Fact]
    public void Conjured_DegradesByFour_AfterSellDate(){
        var items = new List<Item>
        {
            new Item { Name = "Conjured", SellIn = 0, Quality = 20 }
        };
        var app = new GildedRose(items);
        app.UpdateQuality();
        Assert.Equal(-1, items[0].SellIn);
        Assert.Equal(16, items[0].Quality);
    }

    //Test 14
    [Fact]
    public void Conjured_StartsWithConjured(){
        var items = new List<Item>
        {
            new Item { Name = "Conjured Test Item", SellIn = 5, Quality = 0 }
        };
        var app = new GildedRose(items);
        app.UpdateQuality();
        Assert.Equal(4, items[0].SellIn);
        Assert.Equal(0, items[0].Quality);
    }

    //Test 15
    [Fact]
    public void Conjured_QualityDoesNotGoNegative_WhenQualityIsOne()
    {
        var items = new List<Item>
        {
            new Item { Name = "Conjured Mana Cake", SellIn = 5, Quality = 1 }
        };
        var app = new GildedRose(items);

        app.UpdateQuality();

        Assert.Equal(4, items[0].SellIn);
        Assert.Equal(0, items[0].Quality); // would be -1 without the floor
    }

// Corner Cases
    //Test 16
    [Fact]
    public void Normal_AfterSellDateAtQuality1_Stays0(){
        var items = new List<Item>
        {
            new Item { Name = "+5 Dexterity Vest", SellIn = 0, Quality = 1 }
        };
        var app = new GildedRose(items);
        app.UpdateQuality();
        Assert.Equal(0, items[0].Quality);
        Assert.Equal(-1, items[0].SellIn);
    }

    //Test 17
    [Fact]
    public void AgedBrie_AtQuality49AfterSellDate_CapsAt50(){
        var items = new List<Item>
        {
            new Item { Name = "Aged Brie", SellIn = 0, Quality = 49 }
        };
        var app = new GildedRose(items);
        app.UpdateQuality();
        Assert.Equal(50, items[0].Quality);
        Assert.Equal(-1, items[0].SellIn);
    }

    //Test 18
    [Fact]
    public void Backstage_AtQuality49WhenSellIn5_CapsAt50(){
        var items = new List<Item>
        {
            new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 5, Quality = 49 }
        };
        var app = new GildedRose(items);
        app.UpdateQuality();
        Assert.Equal(50, items[0].Quality);
        Assert.Equal(4, items[0].SellIn);
    }

    //Test 19
    [Fact]
    public void Backstage_AtSellIn6_IncreasesBy2(){
        var items = new List<Item>
        {
            new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 6, Quality = 0 }
        };
        var app = new GildedRose(items);
        app.UpdateQuality();
        Assert.Equal(5, items[0].SellIn);
        Assert.Equal(2, items[0].Quality);
    }



    //Test 2
    [Fact]
    public void Conjured_AfterSelDateAtQuality3_Stays0()
    {
        var items = new List<Item>
        {
            new Item { Name = "Conjured Mana Cake", SellIn = 0, Quality = 3 }
        };
        var app = new GildedRose(items);
        app.UpdateQuality();
        Assert.Equal(-1, items[0].SellIn);
        Assert.Equal(0, items[0].Quality); // would be -1 without the floor (3 - 2 - 2)
    }
}

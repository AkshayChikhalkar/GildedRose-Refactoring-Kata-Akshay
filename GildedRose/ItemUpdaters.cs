using System.Collections.Generic;

namespace GildedRoseKata;

public interface IItemUpdater
{
    void Update(Item item);
}

public static class ItemUpdaterFactory
{
    private const string AgedBrie = "Aged Brie";
    private const string BackstagePasses = "Backstage passes to a TAFKAL80ETC concert";
    private const string Sulfuras = "Sulfuras, Hand of Ragnaros";
    private const string Conjured = "Conjured";

    private static readonly IItemUpdater NormalUpdater = new NormalItemUpdater();
    private static readonly IItemUpdater AgedBrieUpdaterInstance = new AgedBrieUpdater();
    private static readonly IItemUpdater BackstagePassUpdaterInstance = new BackstagePassUpdater();
    private static readonly IItemUpdater SulfurasUpdaterInstance = new SulfurasUpdater();
    private static readonly IItemUpdater ConjuredUpdaterInstance = new ConjuredUpdater();

    private static readonly Dictionary<string, IItemUpdater> UpdatersByName = new()
    {
        [AgedBrie] = AgedBrieUpdaterInstance,
        [BackstagePasses] = BackstagePassUpdaterInstance,
        [Sulfuras] = SulfurasUpdaterInstance,
        //[Conjured] = ConjuredUpdaterInstance
    };

    public static IItemUpdater For(Item item)
    {
        if (UpdatersByName.TryGetValue(item.Name, out var updater))
        {
            return updater;
        }
        
        if (item.Name?.StartsWith(Conjured) == true)
        {
            return ConjuredUpdaterInstance;
        }
        
        return NormalUpdater;
    }
}

internal static class ItemQuality
{
    public const int Max = 50;
    public const int Min = 0;

    public static void Increase(Item item)
    {
        if (item.Quality < Max)
        {
            item.Quality++;
        }
    }

    public static void Decrease(Item item, int amount)
    {
        item.Quality -= amount;
        if (item.Quality < Min)
        {
            item.Quality = Min;
        }
    }
}

class NormalItemUpdater : IItemUpdater
{
    public void Update(Item item)
    {
        ItemQuality.Decrease(item, amount: 1);
        item.SellIn--;

        if (item.SellIn < 0)
        {
            //  after sell date, quality decreases by 2
            ItemQuality.Decrease(item, amount: 1);
        }
    }
}

class AgedBrieUpdater : IItemUpdater
{
    public void Update(Item item)
    {
        ItemQuality.Increase(item);
        item.SellIn--;

        if (item.SellIn < 0)
        {
            // after sell date, the quality increases by 2
            ItemQuality.Increase(item);
        }
    }
}

class BackstagePassUpdater : IItemUpdater
{
    public void Update(Item item)
    {
        ItemQuality.Increase(item);

        if (item.SellIn < 11)
        {
            ItemQuality.Increase(item); // increases by 2
        }

        if (item.SellIn < 6)
        {
            ItemQuality.Increase(item); // increases by 3
        }

        item.SellIn--;

        if (item.SellIn < 0)
        {
            item.Quality = ItemQuality.Min; // quality = 0
        }
    }
}

class SulfurasUpdater : IItemUpdater
{
    public void Update(Item item){}// no change}
}


class ConjuredUpdater : IItemUpdater{
    public void Update(Item item)
    {
        ItemQuality.Decrease(item, amount: 2);
        item.SellIn--;
        if (item.SellIn < 0)
        {
            ItemQuality.Decrease(item, amount: 2);// after sell date, quality decreases by 4
        } 
    }
}

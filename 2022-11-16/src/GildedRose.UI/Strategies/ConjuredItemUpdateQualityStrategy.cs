using GildedRose.UI.Interfaces;

namespace GildedRose.UI
{
    public class ConjuredItemUpdateQualityStrategy : IUpdateQualityStrategy
    {
        public void UpdateQuality(StoreItem item)
        {
            item.DecrementQuality();
            item.DecrementQuality();
            item.SellIn--;
            if (item.SellIn < 0)
            {
                item.DecrementQuality();
                item.DecrementQuality();
            }
        }
    }
}
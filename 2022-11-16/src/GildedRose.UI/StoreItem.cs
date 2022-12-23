using GildedRose.UI.Interfaces;
using GildedRose.UI.Strategies;

namespace GildedRose.UI
{
    public class StoreItem
    {
        private readonly Item _item;
        private readonly IUpdateQualityStrategy _updateQualityStrategy;

        public StoreItem()
        {

        }

        public StoreItem(Item item)
        {
            this._item = item;
            _updateQualityStrategy = new DefaultUpdateQualityStrategy();

            if (Name == "Aged Brie")
            {
                _updateQualityStrategy = new BetterWithTimeUpdateQualityStrategy();
            }

            if (Name == "Sulfuras, Hand of Ragnaros")
            {
                _updateQualityStrategy = new LegendaryUpdateQualityStrategy();
            }

            if (Name == "Backstage passes to a TAFKAL80ETC concert")
            {
                _updateQualityStrategy = new BackstagePassUpdateQualityStrategy();
            }

            if (Name == "Conjured Mana Cake")
            {
                _updateQualityStrategy = new ConjuredItemUpdateQualityStrategy();
            }
        }


        public string Name
        {
            get => _item.Name;
            set => _item.Name = value;
        }


        public int SellIn
        {
            get => _item.SellIn;
            set => _item.SellIn = value;
        }

        public int Quality
        {
            get => _item.Quality;
            set => _item.Quality = value;
        }

        public void IncrementQuality()
        {
            if (Quality < 50)
            {
                Quality++;
            }
        }

        public void DecrementQuality()
        {
            if (Quality > 0)
            {
                Quality--;
            }
        }

        public void Expire()
        {
            Quality = 0;
        }

        public void UpdateQuality()
        {

            _updateQualityStrategy.UpdateQuality(this);
        }
    }
}

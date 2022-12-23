using FluentAssertions;
using GildedRose.UI;

namespace GildedRose.UnitTests.Strategies
{
    public class ConjuredItemUpdateQualityStrategy_UpdateQualityShould : BaseStrategyTest
    {
        private ConjuredItemUpdateQualityStrategy _strategy;

        public ConjuredItemUpdateQualityStrategy_UpdateQualityShould()
        {
            _strategy = new ConjuredItemUpdateQualityStrategy();
        }
        [Fact]
        public void ReduceConjuredItemQualityByTwo()
        {
            var conjuredItem = GetConjuredItem();
            int startingQuality = conjuredItem.Quality;

            _strategy.UpdateQuality(conjuredItem);

            conjuredItem.Quality.Should().Be(startingQuality - 2);
        }


        [Fact]
        public void ReduceConjuredItemSellInByOne()
        {
            var conjuredItem = GetConjuredItem();
            int startingSellIn = conjuredItem.SellIn;

            _strategy.UpdateQuality(conjuredItem);

            conjuredItem.SellIn.Should().Be(startingSellIn - 1);
        }

        [Fact]
        public void ReduceConjuredItemQualityByFourWhenSellInLessThanOne()
        {
            var conjuredItem = GetConjuredItem(sellIn: 0);
            int startingQuality = conjuredItem.Quality;

            _strategy.UpdateQuality(conjuredItem);

            conjuredItem.Quality.Should().Be(startingQuality - 4);
        }

        [Fact]
        public void NotReduceQualityCanNeverBeBelowZero()
        {
            var conjuredItem = GetConjuredItem(quality: 0);
            int startingQuality = conjuredItem.Quality;

            _strategy.UpdateQuality(conjuredItem);

            conjuredItem.Quality.Should().Be(0);
        }

        private static StoreItem GetConjuredItem(int sellIn = DEFAULT_START_SELLIN, int quality = DEFAULT_START_QUALITY)
        {
            return new StoreItem(new Item { Name = "Conjured Mana Cake", SellIn = sellIn, Quality = quality });
        }
    }
}

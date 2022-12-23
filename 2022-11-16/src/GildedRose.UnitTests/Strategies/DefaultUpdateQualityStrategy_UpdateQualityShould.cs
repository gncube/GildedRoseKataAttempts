using FluentAssertions;
using GildedRose.UI;
using GildedRose.UI.Strategies;

namespace GildedRose.UnitTests.Strategies
{
    public class DefaultUpdateQualityStrategy_UpdateQualityShould : BaseStrategyTest
    {
        private DefaultUpdateQualityStrategy _strategy;

        public DefaultUpdateQualityStrategy_UpdateQualityShould()
        {
            _strategy = new DefaultUpdateQualityStrategy();
        }

        [Fact]
        public void ReduceNormalItemQualityByOne()
        {
            var normalItem = GetNormalItem();
            int startingQuality = normalItem.Quality;

            _strategy.UpdateQuality(normalItem);

            normalItem.Quality.Should().Be(startingQuality - 1);
        }


        [Fact]
        public void ReduceNormalItemSellInByOne()
        {
            var normalItem = GetNormalItem();
            int startingSellIn = normalItem.SellIn;

            _strategy.UpdateQuality(normalItem);

            normalItem.SellIn.Should().Be(startingSellIn - 1);
        }

        [Fact]
        public void ReduceNormalItemQualityByTwoWhenSellInLessThanOne()
        {
            var normalItem = GetNormalItem(sellIn: 0);
            int startingQuality = normalItem.Quality;

            _strategy.UpdateQuality(normalItem);

            normalItem.Quality.Should().Be(startingQuality - 2);
        }

        [Fact]
        public void NotReduceQualityCanNeverBeBelowZero()
        {
            var normalItem = GetNormalItem(quality: 0);
            int startingQuality = normalItem.Quality;

            _strategy.UpdateQuality(normalItem);

            normalItem.Quality.Should().Be(0);
        }

        private static StoreItem GetNormalItem(int sellIn = DEFAULT_START_SELLIN, int quality = DEFAULT_START_QUALITY)
        {
            return new StoreItem(new Item { Name = "Normal Item", SellIn = sellIn, Quality = quality });
        }
    }
}

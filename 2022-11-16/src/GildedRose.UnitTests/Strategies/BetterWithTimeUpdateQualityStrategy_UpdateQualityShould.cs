using FluentAssertions;
using GildedRose.UI;
using GildedRose.UI.Strategies;

namespace GildedRose.UnitTests.Strategies
{
    public class BetterWithTimeUpdateQualityStrategy_UpdateQualityShould : BaseStrategyTest
    {
        private BetterWithTimeUpdateQualityStrategy _strategy;

        public BetterWithTimeUpdateQualityStrategy_UpdateQualityShould()
        {
            _strategy = new BetterWithTimeUpdateQualityStrategy();
        }

        [Fact]
        public void IncreaseQualityOfAgedBrie()
        {
            var agedBrie = GetAgedBrie(quality: 0);
            int startingQuality = agedBrie.Quality;

            _strategy.UpdateQuality(agedBrie);

            agedBrie.Quality.Should().Be(startingQuality + 1);
        }

        [Fact]
        public void NotIncreaseQualityOfAgedBriePast50()
        {
            var agedBrie = GetAgedBrie(quality: SYSTEM_MAX_QUALITY);
            int startingQuality = agedBrie.Quality;

            _strategy.UpdateQuality(agedBrie);

            agedBrie.Quality.Should().Be(startingQuality);
        }

        [Fact]
        public void IncreaseQualityOfAgedBrieBy2AfterSellIn()
        {
            var agedBrie = GetAgedBrie(sellIn: 0);
            int startingQuality = agedBrie.Quality;

            _strategy.UpdateQuality(agedBrie);

            agedBrie.Quality.Should().Be(startingQuality + 2);
        }

        private static StoreItem GetAgedBrie(int sellIn = DEFAULT_START_SELLIN, int quality = DEFAULT_START_QUALITY)
        {
            return new StoreItem(new Item { Name = "Aged Brie", SellIn = sellIn, Quality = quality });
        }
    }
}

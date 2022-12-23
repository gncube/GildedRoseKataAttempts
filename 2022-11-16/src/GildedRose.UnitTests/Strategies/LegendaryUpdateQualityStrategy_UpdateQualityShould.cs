using FluentAssertions;
using GildedRose.UI;
using GildedRose.UI.Strategies;

namespace GildedRose.UnitTests.Strategies
{
    public class LegendaryUpdateQualityStrategy_UpdateQualityShould : BaseStrategyTest
    {
        private LegendaryUpdateQualityStrategy _strategy;

        public LegendaryUpdateQualityStrategy_UpdateQualityShould()
        {
            _strategy = new LegendaryUpdateQualityStrategy();
        }

        [Fact]
        public void NotIncreaseQualityOfSulfuras()
        {
            var sulfuras = GetSulfuras();
            int startingQuality = sulfuras.Quality;

            _strategy.UpdateQuality(sulfuras);

            sulfuras.Quality.Should().Be(startingQuality);
        }

        [Fact]
        public void NotChangeSellInOfSulfuras()
        {
            var sulfuras = GetSulfuras();
            int startingSellIn = sulfuras.SellIn;

            _strategy.UpdateQuality(sulfuras);

            sulfuras.SellIn.Should().Be(startingSellIn);
        }

        private static StoreItem GetSulfuras(int sellIn = DEFAULT_START_SELLIN, int quality = DEFAULT_START_QUALITY)
        {
            return new StoreItem(new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = sellIn, Quality = quality });
        }
    }
}

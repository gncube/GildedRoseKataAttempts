using FluentAssertions;
using GildedRose.UI;
using GildedRose.UI.Strategies;

namespace GildedRose.UnitTests.Strategies
{
    public class BackstagePassUpdateQualityStrategy_UpdateQualityShould : BaseStrategyTest
    {
        private BackstagePassUpdateQualityStrategy _strategy;

        public BackstagePassUpdateQualityStrategy_UpdateQualityShould()
        {
            _strategy = new BackstagePassUpdateQualityStrategy();
        }
        [Fact]
        public void IncreaseQualityOfBackstagePassesByOneWith11DaysLeft()
        {
            var backstage = GetBackStage(sellIn: 11);
            int startingQuality = backstage.Quality;

            _strategy.UpdateQuality(backstage);

            backstage.Quality.Should().Be(startingQuality + 1);
        }

        [Fact]
        public void IncreaseQualityOfBackstagePassesByTwoWith10DaysLeft()
        {
            var backstage = GetBackStage(sellIn: 10);
            int startingQuality = backstage.Quality;

            _strategy.UpdateQuality(backstage);

            backstage.Quality.Should().Be(startingQuality + 2);
        }

        [Fact]
        public void IncreaseQualityOfBackstagePassesByTwoWith6DaysLeft()
        {
            var backstage = GetBackStage(sellIn: 6);
            int startingQuality = backstage.Quality;

            _strategy.UpdateQuality(backstage);

            backstage.Quality.Should().Be(startingQuality + 2);
        }

        [Fact]
        public void IncreaseQualityOfBackstagePassesByThreeWith5DaysLeft()
        {
            var backstage = GetBackStage(sellIn: 5);
            int startingQuality = backstage.Quality;

            _strategy.UpdateQuality(backstage);

            backstage.Quality.Should().Be(startingQuality + 3);
        }

        [Fact]
        public void IncreaseQualityOfBackstagePassesByThreeWith1DayLeft()
        {
            var backstage = GetBackStage(sellIn: 1);
            int startingQuality = backstage.Quality;

            _strategy.UpdateQuality(backstage);

            backstage.Quality.Should().Be(startingQuality + 3);
        }

        [Fact]
        public void IncreaseQualityOfBackstagePassesByZeroWithZeroDaysLeft()
        {
            var backstage = GetBackStage(sellIn: 0);
            int startingQuality = backstage.Quality;

            _strategy.UpdateQuality(backstage);

            backstage.Quality.Should().Be(0);
        }

        private static StoreItem GetBackStage(int sellIn = DEFAULT_START_SELLIN, int quality = DEFAULT_START_QUALITY)
        {
            return new StoreItem(new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = sellIn, Quality = quality });
        }
    }
}

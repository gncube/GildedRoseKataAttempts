using FluentAssertions;
using GildedRose.UI;

namespace GildedRose.UnitTests
{
    public class StoreItem_UpdateQualityShould
    {
        private const int DEFAULT_START_SELLIN = 10;
        private const int DEFAULT_START_QUALITY = 20;
        private const int SYSTEM_MAX_QUALITY = 50;

        private readonly ItemQualityService _qualityService;

        public StoreItem_UpdateQualityShould()
        {
            _qualityService = new ItemQualityService();
        }

        [Fact]
        public void ReduceNormalItemQualityByOne()
        {
            var normalItem = GetNormalItem();
            int startingQuality = normalItem.Quality;

            normalItem.UpdateQuality();

            normalItem.Quality.Should().Be(startingQuality - 1);
        }


        [Fact]
        public void ReduceNormalItemSellInByOne()
        {
            var normalItem = GetNormalItem();
            int startingSellIn = normalItem.SellIn;

            normalItem.UpdateQuality();

            normalItem.SellIn.Should().Be(startingSellIn - 1);
        }

        [Fact]
        public void ReduceNormalItemQualityByTwoWhenSellInLessThanOne()
        {
            var normalItem = GetNormalItem(sellIn: 0);
            int startingQuality = normalItem.Quality;

            normalItem.UpdateQuality();

            normalItem.Quality.Should().Be(startingQuality - 2);
        }

        [Fact]
        public void NotReduceQualityCanNeverBeBelowZero()
        {
            var normalItem = GetNormalItem(quality: 0);
            int startingQuality = normalItem.Quality;

            normalItem.UpdateQuality();

            normalItem.Quality.Should().Be(0);
        }

        [Fact]
        public void IncreaseQualityOfAgedBrie()
        {
            var agedBrie = GetAgedBrie(quality: 0);
            int startingQuality = agedBrie.Quality;

            agedBrie.UpdateQuality();

            agedBrie.Quality.Should().Be(startingQuality + 1);
        }


        [Fact]
        public void NotIncreaseQualityOfAgedBriePast50()
        {
            var agedBrie = GetAgedBrie(quality: SYSTEM_MAX_QUALITY);
            int startingQuality = agedBrie.Quality;

            agedBrie.UpdateQuality();

            agedBrie.Quality.Should().Be(startingQuality);
        }

        [Fact]
        public void IncreaseQualityOfAgedBrieBy2AfterSellIn()
        {
            var agedBrie = GetAgedBrie(sellIn: 0);
            int startingQuality = agedBrie.Quality;

            agedBrie.UpdateQuality();

            agedBrie.Quality.Should().Be(startingQuality + 2);
        }

        [Fact]
        public void NotIncreaseQualityOfSulfuras()
        {
            var sulfuras = GetSulfuras();
            int startingQuality = sulfuras.Quality;

            sulfuras.UpdateQuality();

            sulfuras.Quality.Should().Be(startingQuality);
        }

        [Fact]
        public void NotChangeSellInOfSulfuras()
        {
            var sulfuras = GetSulfuras();
            int startingSellIn = sulfuras.SellIn;

            sulfuras.UpdateQuality();

            sulfuras.SellIn.Should().Be(startingSellIn);
        }

        [Fact]
        public void IncreaseQualityOfBackstagePassesByOneWith11DaysLeft()
        {
            var backstage = GetBackStage(sellIn: 11);
            int startingQuality = backstage.Quality;

            backstage.UpdateQuality();

            backstage.Quality.Should().Be(startingQuality + 1);
        }

        [Fact]
        public void IncreaseQualityOfBackstagePassesByTwoWith10DaysLeft()
        {
            var backstage = GetBackStage(sellIn: 10);
            int startingQuality = backstage.Quality;

            backstage.UpdateQuality();

            backstage.Quality.Should().Be(startingQuality + 2);
        }

        [Fact]
        public void IncreaseQualityOfBackstagePassesByTwoWith6DaysLeft()
        {
            var backstage = GetBackStage(sellIn: 6);
            int startingQuality = backstage.Quality;

            backstage.UpdateQuality();

            backstage.Quality.Should().Be(startingQuality + 2);
        }

        [Fact]
        public void IncreaseQualityOfBackstagePassesByThreeWith5DaysLeft()
        {
            var backstage = GetBackStage(sellIn: 5);
            int startingQuality = backstage.Quality;

            backstage.UpdateQuality();

            backstage.Quality.Should().Be(startingQuality + 3);
        }

        [Fact]
        public void IncreaseQualityOfBackstagePassesByThreeWith1DayLeft()
        {
            var backstage = GetBackStage(sellIn: 1);
            int startingQuality = backstage.Quality;

            backstage.UpdateQuality();

            backstage.Quality.Should().Be(startingQuality + 3);
        }

        [Fact]
        public void IncreaseQualityOfBackstagePassesByZeroWithZeroDaysLeft()
        {
            var backstage = GetBackStage(sellIn: 0);
            int startingQuality = backstage.Quality;

            backstage.UpdateQuality();

            backstage.Quality.Should().Be(0);
        }
        private static StoreItem GetNormalItem(int sellIn = DEFAULT_START_SELLIN, int quality = DEFAULT_START_QUALITY)
        {
            return new StoreItem(new Item { Name = "Normal Item", SellIn = sellIn, Quality = quality });
        }

        private static StoreItem GetAgedBrie(int sellIn = DEFAULT_START_SELLIN, int quality = DEFAULT_START_QUALITY)
        {
            return new StoreItem(new Item { Name = "Aged Brie", SellIn = sellIn, Quality = quality });
        }

        private static StoreItem GetSulfuras(int sellIn = DEFAULT_START_SELLIN, int quality = DEFAULT_START_QUALITY)
        {
            return new StoreItem(new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = sellIn, Quality = quality });
        }

        private static StoreItem GetBackStage(int sellIn = DEFAULT_START_SELLIN, int quality = DEFAULT_START_QUALITY)
        {
            return new StoreItem(new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = sellIn, Quality = quality });
        }
    }
}
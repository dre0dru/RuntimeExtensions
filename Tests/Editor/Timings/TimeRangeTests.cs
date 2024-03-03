using NUnit.Framework;

namespace Dre0Dru.Timings.Editor.Tests
{
    public class TimeRangeTests
    {
        [Test]
        public void TimeRange_IsInside_IsTrue_OnBoundaryValues()
        {
            var timeRange = new TimeRange(0, 1);
            
            Assert.IsTrue(timeRange.IsInside(0));
            Assert.IsTrue(timeRange.IsInside(1));
        }
        
        [Test]
        public void TimeRange_IsOutside_IsTrue_OnBoundaryValues()
        {
            var timeRange = new TimeRange(0, 1);
            
            Assert.IsTrue(timeRange.IsOutside(0));
            Assert.IsTrue(timeRange.IsOutside(1));
        }

        [Test]
        public void TimeRange_HasEntered_IsTrue_FromBoundaryValues()
        {
            var timeRange = new TimeRange(0, 1);

            Assert.IsTrue(timeRange.HasEntered(0, 0.5f));
            Assert.IsTrue(timeRange.HasEntered(0, 1));
        }
        
        [Test]
        public void TimeRange_HasEntered_IsFalse_FromSameValue()
        {
            var timeRange = new TimeRange(0, 1);

            Assert.IsFalse(timeRange.HasEntered(0, 0));
        }
        
        [Test]
        public void TimeRange_HasExited_IsTrue_WhenExitingRange()
        {
            var timeRange = new TimeRange(0, 1);

            Assert.IsTrue(timeRange.HasExited(0.5f, 1.5f));
            Assert.IsTrue(timeRange.HasExited(0, 2));
        }

        [Test]
        public void TimeRange_HasExited_IsFalse_WhenStayingInside()
        {
            var timeRange = new TimeRange(0, 1);

            Assert.IsFalse(timeRange.HasExited(0.5f, 0.75f));
        }

        [Test]
        public void TimeRange_Evaluate_ReturnsCorrectValue()
        {
            var timeRange = new TimeRange(0, 10);

            Assert.AreEqual(0.5f, timeRange.Evaluate(5), 0.01f);
            Assert.AreEqual(0f, timeRange.Evaluate(0), 0.01f);
            Assert.AreEqual(1f, timeRange.Evaluate(10), 0.01f);
        }

        [Test]
        public void TimeRange_IsInside_IsFalse_OutsideRange()
        {
            var timeRange = new TimeRange(0, 1);

            Assert.IsFalse(timeRange.IsInside(-1));
            Assert.IsFalse(timeRange.IsInside(2));
        }

        [Test]
        public void TimeRange_IsOutside_IsFalse_InsideRange()
        {
            var timeRange = new TimeRange(0, 1);

            Assert.IsFalse(timeRange.IsOutside(0.5f));
        }
    }
}

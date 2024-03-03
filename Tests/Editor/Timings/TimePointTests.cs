using NUnit.Framework;

namespace Dre0Dru.Timings.Editor.Tests
{
    public class TimePointTests
    {
        [Test]
        public void TimePoint_IsBefore_Success_OnExactTime()
        {
            var timePoint = new TimePoint(0);
            
            Assert.IsTrue(timePoint.IsBefore(0));
        }
        
        [Test]
        public void TimePoint_IsPast_Success_OnExactTime()
        {
            var timePoint = new TimePoint(0);
            
            Assert.IsTrue(timePoint.IsPast(0));
        }
        
        [Test]
        public void TimePoint_IsTriggered_OnEnteringExactTime()
        {
            var timePoint = new TimePoint(0);
            
            Assert.IsTrue(timePoint.IsTriggered(-1,0));
        }
        
        [Test]
        public void TimePoint_IsNotTriggered_OnEnteringSameTime()
        {
            var timePoint = new TimePoint(0);
            Assert.IsFalse(timePoint.IsTriggered(0,0));
        }
        
        [Test]
        public void TimePoint_IsBefore_Success_AfterTime()
        {
            var timePoint = new TimePoint(1);
    
            Assert.IsTrue(timePoint.IsBefore(0));
        }

        [Test]
        public void TimePoint_IsPast_Success_BeforeTime()
        {
            var timePoint = new TimePoint(0);
    
            Assert.IsTrue(timePoint.IsPast(1));
        }

        [Test]
        public void TimePoint_IsTriggered_Fails_WhenTimeDoesNotChange()
        {
            var timePoint = new TimePoint(0);
    
            Assert.IsFalse(timePoint.IsTriggered(0, 0));
        }

        [Test]
        public void TimePoint_IsTriggered_Fails_WhenTimeDecreases()
        {
            var timePoint = new TimePoint(0);
    
            Assert.IsFalse(timePoint.IsTriggered(1, -1));
        }

        [Test]
        public void TimePoint_IsTriggered_Success_WhenCrossingTimePoint()
        {
            var timePoint = new TimePoint(0);
    
            Assert.IsTrue(timePoint.IsTriggered(-1, 1));
        }
    }
}

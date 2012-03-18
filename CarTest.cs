using System;
using NUnit.Framework;
using Expedia;
using Rhino.Mocks;

namespace ExpediaTest
{
	[TestFixture()]
	public class CarTest
	{	
		private Car targetCar;
		private MockRepository mocks;
		
		[SetUp()]
		public void SetUp()
		{
			targetCar = new Car(5);
			mocks = new MockRepository();
		}
		
		[Test()]
		public void TestThatCarInitializes()
		{
			Assert.IsNotNull(targetCar);
		}	
		
		[Test()]
		public void TestThatCarHasCorrectBasePriceForFiveDays()
		{
			Assert.AreEqual(50, targetCar.getBasePrice()	);
		}
		
		[Test()]
		public void TestThatCarHasCorrectBasePriceForTenDays()
		{
            var target = new Car(10);
			Assert.AreEqual(80, target.getBasePrice());	
		}
		
		[Test()]
		public void TestThatCarHasCorrectBasePriceForSevenDays()
		{
			var target = new Car(7);
			Assert.AreEqual(10*7*.8, target.getBasePrice());
		}
		
		[Test()]
		[ExpectedException(typeof(ArgumentOutOfRangeException))]
		public void TestThatCarThrowsOnBadLength()
		{
			new Car(-5);
		}

        [Test()]
        public void TestThatCarDoesGetLocationFromTheDatabase()
        {
            IDatabase mockDatabase = mocks.Stub<IDatabase>();
            String location1 = "Over a tree";
            String location2 = "On the lake";

            using (mocks.Record())
            {
                mockDatabase.getCarLocation(34);
                LastCall.Return(location1);
        
                mockDatabase.getCarLocation(1222);
                LastCall.Return(location2);
            }

            var target = ObjectMother.Saab();
            target.Database = mockDatabase;

            String result;
            result = target.getCarLocation(34);
            Assert.AreEqual(result, location1);
            result = target.getCarLocation(1222);
            Assert.AreEqual(result, location2);
        }

        [Test()]
        public void TestThatCarDoesGetMileageFromDatabase()
        {
            IDatabase mockDatabase = mocks.Stub<IDatabase>();
            Int32 expectedMileage = 123123;

            mockDatabase.Miles = expectedMileage;

            var target = ObjectMother.BMW();
            target.Database = mockDatabase;

            int mileage = target.Mileage;
            Assert.AreEqual(mileage, expectedMileage);
        }
	}
}

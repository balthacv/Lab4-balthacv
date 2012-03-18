using Expedia;
using System;

namespace ExpediaTest
{
	public class ObjectMother
	{
        public static Car Saab()
        {
            return new Car(7) { Name = "Saab 9-5 Sports Sedan" };
        }

        public static Car BMW()
        {
            return new Car(10) { Name = "Awesome BWM Sports Sedan" };
        }

        public static Flight CoupleOfDaysFlight()
        {
            return new Flight(new DateTime(2012, 03, 15), new DateTime(2012, 03, 17), 1000);
        }

        public static Flight LotsOfDaysFlight()
        {
            return new Flight(new DateTime(2012, 03, 15), new DateTime(2012, 05, 29), 1000);
        }
	}
}

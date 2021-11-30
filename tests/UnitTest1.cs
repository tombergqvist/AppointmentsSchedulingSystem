using AppointmentsAPI.Models;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System.Linq;
using tests.MockModels;

namespace tests
{
    public class Tests
    {
        [Test]
        public void AddAndGet()
        {
            var options = new DbContextOptionsBuilder<MockModels.Context>()
            .UseInMemoryDatabase(databaseName: "AppointmentsSchedulingSystem")
            .Options;

            using (var context = new MockModels.Context(options))
            {
                var name = "Bob";
                var expectedCount = 5;

                var service = new AppointmentsAPI.Services.InternalService(context);
                for (int i=0; i< expectedCount; i++)
                {
                    service.AddAppointment(new AppointmentDTO()
                    {
                        name = name,
                        email = "bob@bob.bob",
                        phoneNumber = "1234567890",
                        startTime = System.DateTime.Now.AddDays(i),
                        endTime = System.DateTime.Now.AddHours(2),
                        date = System.DateTime.Now
                    });
                }
                service.AddAppointment(new AppointmentDTO()
                {
                    name = "not Bob",
                    email = "bob@bob.bob",
                    phoneNumber = "1234567890",
                    startTime = System.DateTime.Now,
                    endTime = System.DateTime.Now.AddHours(2),
                    date = System.DateTime.Now
                });

                var result = service.GetAppointments(name).Result;
                Assert.AreEqual(result.Count(), expectedCount);
            }
        }
    }
}
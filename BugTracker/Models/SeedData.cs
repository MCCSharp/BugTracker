using Microsoft.EntityFrameworkCore;

namespace BugTracker.Models
{
    public class SeedData
    {
        public static void EnsurePopulated(IApplicationBuilder app)
        {
            BugContext context = app.ApplicationServices.CreateScope().ServiceProvider.GetRequiredService<BugContext>();

            if (context.Database.GetPendingMigrations().Any()) {
                context.Database.Migrate();

            }

            //if(!context.Mitarbeiters.Any())
            //{
            //    context.Mitarbeiters.AddRange(
            //        new Mitarbeiter
            //        {
            //            Firstname = "Mike",
            //            Lastname = "Doe",
            //            Aufgabe = "Programmer"
            //        },
            //        new Mitarbeiter
            //        {
            //            Firstname = "Edward",
            //            Lastname = "Teach",
            //            Aufgabe = "Programmer"
            //        },
            //        new Mitarbeiter
            //        {
            //            Firstname = "Lucky",
            //            Lastname = "Luciano",
            //            Aufgabe = "Programmer"
            //        },
            //        new Mitarbeiter
            //        {
            //            Firstname = "Shaka",
            //            Lastname = "Zouloux",
            //            Aufgabe = "Programmer"
            //        },
            //         new Mitarbeiter
            //        {
            //             Firstname = "Grace",
            //             Lastname = "Hopper",
            //             Aufgabe = "Tester"
            //        },
            //        new Mitarbeiter
            //        {
            //            Firstname = "Kuniyoshi",
            //            Lastname = "Utagawa",
            //            Aufgabe = "Tester"
            //        },
            //        new Mitarbeiter
            //        {
            //            Firstname = "Dalai",
            //            Lastname = "Lama",
            //            Aufgabe = "Tester"
            //        },
            //        new Mitarbeiter
            //        {
            //            Firstname = "Alan",
            //            Lastname = "Turing",
            //            Aufgabe = "Tester"
            //        });
            //    context.SaveChanges();

            //}
        }
    }
}

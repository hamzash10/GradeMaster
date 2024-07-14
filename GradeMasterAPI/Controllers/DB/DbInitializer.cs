using GradeMasterAPI.Controllers.DB.DBModels;

namespace GradeMasterAPI.Controllers.DB
{
    public static class DbInitializer
    {

        public static void Initialize(GradeMasterDbContext dbContext)
        {
            dbContext.Database.EnsureCreated();
            if (!dbContext.Teachers.Any())
            {
                var teachers = new Teacher[]
                {
                new Teacher {FirstName="Albet",LastName="Einstein", Email="albert@gmail.com", PhoneNumber="0534267235",Password="123456"},
                new Teacher {FirstName="David",LastName="Hamelech", Email="david@gmail.com", PhoneNumber="0549236496",Password="987654"}
                };

                dbContext.Teachers.Add(teachers[0]);
                dbContext.Teachers.Add(teachers[1]);
                dbContext.SaveChanges();
            }
        }

    }
}

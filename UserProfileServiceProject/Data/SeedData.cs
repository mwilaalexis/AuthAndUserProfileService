

using UserProfileServiceProject.Entities;

namespace UserProfileServiceProject.Data
{
    public static class SeedData
    {
        public static void Initialize(IApplicationBuilder app)
        {
            using var scope = app.ApplicationServices.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();

            if (context.Users.Any())
                return;

            
            var ids = Enumerable.Range(1, 20)
                .ToDictionary(i => i, i => Guid.NewGuid());

            
            var users = new List<User>
            {
                new User { Id = ids[1], Email="alexis@example.com", PasswordHash=BCrypt.Net.BCrypt.HashPassword("Pass123!"), Role="Admin", CreatedAt=DateTime.UtcNow },
                new User { Id = ids[2], Email="bob@example.com", PasswordHash=BCrypt.Net.BCrypt.HashPassword("Pass123!"), Role="User", CreatedAt=DateTime.UtcNow },
                new User { Id = ids[3], Email="emma@example.com", PasswordHash=BCrypt.Net.BCrypt.HashPassword("Pass123!"), Role="User", CreatedAt=DateTime.UtcNow },
                new User { Id = ids[4], Email="lucas@example.com", PasswordHash=BCrypt.Net.BCrypt.HashPassword("Pass123!"), Role="User", CreatedAt=DateTime.UtcNow },
                new User { Id = ids[5], Email="sara@example.com", PasswordHash=BCrypt.Net.BCrypt.HashPassword("Pass123!"), Role="Admin", CreatedAt=DateTime.UtcNow },

                new User { Id = ids[6], Email="john@example.com", PasswordHash=BCrypt.Net.BCrypt.HashPassword("Pass123!"), Role="User", CreatedAt=DateTime.UtcNow },
                new User { Id = ids[7], Email="mila@example.com", PasswordHash=BCrypt.Net.BCrypt.HashPassword("Pass123!"), Role="User", CreatedAt=DateTime.UtcNow },
                new User { Id = ids[8], Email="noah@example.com", PasswordHash=BCrypt.Net.BCrypt.HashPassword("Pass123!"), Role="User", CreatedAt=DateTime.UtcNow },
                new User { Id = ids[9], Email="lina@example.com", PasswordHash=BCrypt.Net.BCrypt.HashPassword("Pass123!"), Role="User", CreatedAt=DateTime.UtcNow },

                new User { Id = ids[10], Email="user10@example.com", PasswordHash=BCrypt.Net.BCrypt.HashPassword("Pass123!"), Role="User", CreatedAt=DateTime.UtcNow },
                new User { Id = ids[11], Email="user11@example.com", PasswordHash=BCrypt.Net.BCrypt.HashPassword("Pass123!"), Role="User", CreatedAt=DateTime.UtcNow },
                new User { Id = ids[12], Email="user12@example.com", PasswordHash=BCrypt.Net.BCrypt.HashPassword("Pass123!"), Role="User", CreatedAt=DateTime.UtcNow },
                new User { Id = ids[13], Email="user13@example.com", PasswordHash=BCrypt.Net.BCrypt.HashPassword("Pass123!"), Role="Admin", CreatedAt=DateTime.UtcNow },
                new User { Id = ids[14], Email="user14@example.com", PasswordHash=BCrypt.Net.BCrypt.HashPassword("Pass123!"), Role="User", CreatedAt=DateTime.UtcNow },
                new User { Id = ids[15], Email="user15@example.com", PasswordHash=BCrypt.Net.BCrypt.HashPassword("Pass123!"), Role="User", CreatedAt=DateTime.UtcNow },
                new User { Id = ids[16], Email="user16@example.com", PasswordHash=BCrypt.Net.BCrypt.HashPassword("Pass123!"), Role="User", CreatedAt=DateTime.UtcNow },
                new User { Id = ids[17], Email="user17@example.com", PasswordHash=BCrypt.Net.BCrypt.HashPassword("Pass123!"), Role="User", CreatedAt=DateTime.UtcNow },
                new User { Id = ids[18], Email="user18@example.com", PasswordHash=BCrypt.Net.BCrypt.HashPassword("Pass123!"), Role="User", CreatedAt=DateTime.UtcNow },
                new User { Id = ids[19], Email="user19@example.com", PasswordHash=BCrypt.Net.BCrypt.HashPassword("Pass123!"), Role="User", CreatedAt=DateTime.UtcNow },
                new User { Id = ids[20], Email="user20@example.com", PasswordHash=BCrypt.Net.BCrypt.HashPassword("Pass123!"), Role="User", CreatedAt=DateTime.UtcNow }
            };

            
            var profiles = new List<Profile>
            {
                new Profile { UserId = ids[1], FullName="Alexis", Age=21, DietType="balanced", Goal="weight_loss", ActivityLevel="moderate", Allergies="peanuts", BiologicalSex="male", HeightCm=175, WeightKg=70, Email="alexis@example.com" },
                new Profile { UserId = ids[2], FullName="Bob", Age=30, DietType="vegan", Goal="muscle_gain", ActivityLevel="active", Allergies="", BiologicalSex="male", HeightCm=180, WeightKg=75, Email="bob@example.com" },
                new Profile { UserId = ids[3], FullName="Emma", Age=25, DietType="keto", Goal="weight_loss", ActivityLevel="low", Allergies="gluten", BiologicalSex="female", HeightCm=165, WeightKg=60, Email="emma@example.com" },
                new Profile { UserId = ids[4], FullName="Lucas", Age=28, DietType="balanced", Goal="maintenance", ActivityLevel="moderate", Allergies="", BiologicalSex="male", HeightCm=178, WeightKg=72, Email="lucas@example.com" },
                new Profile { UserId = ids[5], FullName="Sara", Age=32, DietType="vegetarian", Goal="weight_loss", ActivityLevel="active", Allergies="dairy", BiologicalSex="female", HeightCm=160, WeightKg=58, Email="sara@example.com" },

                new Profile { UserId = ids[6], FullName="John", Age=40, DietType="balanced", Goal="maintenance", ActivityLevel="low", Allergies="", BiologicalSex="male", HeightCm=182, WeightKg=85, Email="john@example.com" },
                new Profile { UserId = ids[7], FullName="Mila", Age=22, DietType="vegan", Goal="weight_loss", ActivityLevel="active", Allergies="soy", BiologicalSex="female", HeightCm=168, WeightKg=55, Email="mila@example.com" },
                new Profile { UserId = ids[8], FullName="Noah", Age=35, DietType="keto", Goal="muscle_gain", ActivityLevel="high", Allergies="", BiologicalSex="male", HeightCm=185, WeightKg=90, Email="noah@example.com" },
                new Profile { UserId = ids[9], FullName="Lina", Age=27, DietType="balanced", Goal="maintenance", ActivityLevel="moderate", Allergies="nuts", BiologicalSex="female", HeightCm=170, WeightKg=62, Email="lina@example.com" },

                new Profile { UserId = ids[10], FullName="User10", Age=29, DietType="balanced", Goal="weight_loss", ActivityLevel="low", Allergies="", BiologicalSex="female", HeightCm=165, WeightKg=68, Email="user10@example.com" },
                new Profile { UserId = ids[11], FullName="User11", Age=31, DietType="vegan", Goal="maintenance", ActivityLevel="moderate", Allergies="gluten", BiologicalSex="male", HeightCm=175, WeightKg=80, Email="user11@example.com" },
                new Profile { UserId = ids[12], FullName="User12", Age=24, DietType="vegetarian", Goal="muscle_gain", ActivityLevel="active", Allergies="", BiologicalSex="female", HeightCm=162, WeightKg=54, Email="user12@example.com" },
                new Profile { UserId = ids[13], FullName="User13", Age=45, DietType="keto", Goal="weight_loss", ActivityLevel="low", Allergies="", BiologicalSex="male", HeightCm=180, WeightKg=95, Email="user13@example.com" },
                new Profile { UserId = ids[14], FullName="User14", Age=33, DietType="balanced", Goal="maintenance", ActivityLevel="moderate", Allergies="", BiologicalSex="female", HeightCm=170, WeightKg=65, Email="user14@example.com" },
                new Profile { UserId = ids[15], FullName="User15", Age=26, DietType="vegan", Goal="weight_loss", ActivityLevel="high", Allergies="soy", BiologicalSex="female", HeightCm=160, WeightKg=50, Email="user15@example.com" },
                new Profile { UserId = ids[16], FullName="User16", Age=38, DietType="balanced", Goal="muscle_gain", ActivityLevel="active", Allergies="", BiologicalSex="male", HeightCm=185, WeightKg=88, Email="user16@example.com" },
                new Profile { UserId = ids[17], FullName="User17", Age=20, DietType="vegetarian", Goal="maintenance", ActivityLevel="low", Allergies="", BiologicalSex="female", HeightCm=158, WeightKg=52, Email="user17@example.com" },
                new Profile { UserId = ids[18], FullName="User18", Age=29, DietType="keto", Goal="weight_loss", ActivityLevel="moderate", Allergies="dairy", BiologicalSex="male", HeightCm=178, WeightKg=82, Email="user18@example.com" },
                new Profile { UserId = ids[19], FullName="User19", Age=41, DietType="balanced", Goal="maintenance", ActivityLevel="low", Allergies="", BiologicalSex="female", HeightCm=165, WeightKg=70, Email="user19@example.com" },
                new Profile { UserId = ids[20], FullName="User20", Age=36, DietType="vegan", Goal="muscle_gain", ActivityLevel="active", Allergies="", BiologicalSex="male", HeightCm=182, WeightKg=78, Email="user20@example.com" }
            };

            
            context.Users.AddRange(users);
            context.Profiles.AddRange(profiles);

            context.SaveChanges();
        }

    }

}

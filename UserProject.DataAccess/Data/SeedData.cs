using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using UserProject.DataAccess.Entities;

namespace UserProject.DataAccess.Data
{
    public static class SeedData
    {
        public static void Initialize(IApplicationBuilder app)
        {
            using var scope = app.ApplicationServices.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();

            // Ne rien faire si des utilisateurs existent déjà
            if (context.Users.Any())
                return;

            var ids = Enumerable.Range(1, 26)
                .ToDictionary(i => i, i => Guid.NewGuid());

            var users = new List<User>
            {
                // Admins (3)
                new User { Id = ids[1],FullName="alexis", Email = "alexis@example.com",   PasswordHash = BCrypt.Net.BCrypt.HashPassword("Pass123!"), Role = "Admin",      CreatedAt = DateTime.UtcNow },
                new User { Id = ids[2],FullName="sara", Email = "sara@example.com",     PasswordHash = BCrypt.Net.BCrypt.HashPassword("Pass123!"), Role = "Admin",      CreatedAt = DateTime.UtcNow },
                new User { Id = ids[3],FullName="david", Email = "david@example.com",    PasswordHash = BCrypt.Net.BCrypt.HashPassword("Pass123!"), Role = "Admin",      CreatedAt = DateTime.UtcNow },

                // Moderators (3)
                new User { Id = ids[4],FullName="michael", Email = "michael@example.com",  PasswordHash = BCrypt.Net.BCrypt.HashPassword("Pass123!"), Role = "Moderator", CreatedAt = DateTime.UtcNow },
                new User { Id = ids[5],FullName="olivia", Email = "olivia@example.com",   PasswordHash = BCrypt.Net.BCrypt.HashPassword("Pass123!"), Role = "Moderator", CreatedAt = DateTime.UtcNow },
                new User { Id = ids[6],FullName="james", Email = "james@example.com",    PasswordHash = BCrypt.Net.BCrypt.HashPassword("Pass123!"), Role = "Moderator", CreatedAt = DateTime.UtcNow },

                // Regular Users (20)
                new User { Id = ids[7],FullName="bob",  Email = "bob@example.com",      PasswordHash = BCrypt.Net.BCrypt.HashPassword("Pass123!"), Role = "User", CreatedAt = DateTime.UtcNow },
                new User { Id = ids[8],FullName="emma",  Email = "emma@example.com",     PasswordHash = BCrypt.Net.BCrypt.HashPassword("Pass123!"), Role = "User", CreatedAt = DateTime.UtcNow },
                new User { Id = ids[9],FullName="lucas",  Email = "lucas@example.com",    PasswordHash = BCrypt.Net.BCrypt.HashPassword("Pass123!"), Role = "User", CreatedAt = DateTime.UtcNow },
                new User { Id = ids[10],FullName="john", Email = "john@example.com",     PasswordHash = BCrypt.Net.BCrypt.HashPassword("Pass123!"), Role = "User", CreatedAt = DateTime.UtcNow },
                new User { Id = ids[11],FullName="mila", Email = "mila@example.com",     PasswordHash = BCrypt.Net.BCrypt.HashPassword("Pass123!"), Role = "User", CreatedAt = DateTime.UtcNow },
                new User { Id = ids[12],FullName="noah", Email = "noah@example.com",     PasswordHash = BCrypt.Net.BCrypt.HashPassword("Pass123!"), Role = "User", CreatedAt = DateTime.UtcNow },
                new User { Id = ids[13],FullName="lina", Email = "lina@example.com",     PasswordHash = BCrypt.Net.BCrypt.HashPassword("Pass123!"), Role = "User", CreatedAt = DateTime.UtcNow },
                new User { Id = ids[14],FullName="sophia", Email = "@example.com",   PasswordHash = BCrypt.Net.BCrypt.HashPassword("Pass123!"), Role = "User", CreatedAt = DateTime.UtcNow },
                new User { Id = ids[15],FullName="ethan", Email = "ethan@example.com",    PasswordHash = BCrypt.Net.BCrypt.HashPassword("Pass123!"), Role = "User", CreatedAt = DateTime.UtcNow },
                new User { Id = ids[16],FullName="isabella", Email = "isabella@example.com", PasswordHash = BCrypt.Net.BCrypt.HashPassword("Pass123!"), Role = "User", CreatedAt = DateTime.UtcNow },
                new User { Id = ids[17],FullName="liam", Email = "liam@example.com",     PasswordHash = BCrypt.Net.BCrypt.HashPassword("Pass123!"), Role = "User", CreatedAt = DateTime.UtcNow },
                new User { Id = ids[18],FullName="ava", Email = "ava@example.com",      PasswordHash = BCrypt.Net.BCrypt.HashPassword("Pass123!"), Role = "User", CreatedAt = DateTime.UtcNow },
                new User { Id = ids[19],FullName="william", Email = "william@example.com",  PasswordHash = BCrypt.Net.BCrypt.HashPassword("Pass123!"), Role = "User", CreatedAt = DateTime.UtcNow },
                new User { Id = ids[20],FullName="charlotte", Email = "charlotte@example.com",PasswordHash = BCrypt.Net.BCrypt.HashPassword("Pass123!"), Role = "User", CreatedAt = DateTime.UtcNow },
                new User { Id = ids[21],FullName="benjamin", Email = "benjamin@example.com", PasswordHash = BCrypt.Net.BCrypt.HashPassword("Pass123!"), Role = "User", CreatedAt = DateTime.UtcNow },
                new User { Id = ids[22],FullName="mia", Email = "mia@example.com",      PasswordHash = BCrypt.Net.BCrypt.HashPassword("Pass123!"), Role = "User", CreatedAt = DateTime.UtcNow },
                new User { Id = ids[23],FullName="henry", Email = "henry@example.com",    PasswordHash = BCrypt.Net.BCrypt.HashPassword("Pass123!"), Role = "User", CreatedAt = DateTime.UtcNow },
                new User { Id = ids[24],FullName="amelia", Email = "amelia@example.com",   PasswordHash = BCrypt.Net.BCrypt.HashPassword("Pass123!"), Role = "User", CreatedAt = DateTime.UtcNow },
                new User { Id = ids[25],FullName="alexander", Email = "alexander@example.com",PasswordHash = BCrypt.Net.BCrypt.HashPassword("Pass123!"), Role = "User", CreatedAt = DateTime.UtcNow },
                new User { Id = ids[26],FullName="evelyn", Email = "evelyn@example.com",   PasswordHash = BCrypt.Net.BCrypt.HashPassword("Pass123!"), Role = "User", CreatedAt = DateTime.UtcNow }
            };

            var profiles = new List<Profile>
            {
                // Admins
                new Profile { UserId = ids[1], FullName = "Alexis Rivera",     Age = 21, DietType = "balanced",   Goal = "weight_loss", ActivityLevel = "moderate", Allergies = "peanuts", BiologicalSex = "male",   HeightCm = 175, WeightKg = 70,  Email = "alexis@example.com" },
                new Profile { UserId = ids[2], FullName = "Sara Patel",        Age = 32, DietType = "vegetarian", Goal = "weight_loss", ActivityLevel = "active",   Allergies = "dairy",   BiologicalSex = "female", HeightCm = 160, WeightKg = 58,  Email = "sara@example.com" },
                new Profile { UserId = ids[3], FullName = "David Thompson",    Age = 45, DietType = "keto",       Goal = "weight_loss", ActivityLevel = "low",      Allergies = "",        BiologicalSex = "male",   HeightCm = 180, WeightKg = 95,  Email = "david@example.com" },

                // Moderators
                new Profile { UserId = ids[4], FullName = "Michael Anderson",  Age = 29, DietType = "balanced",   Goal = "maintenance", ActivityLevel = "moderate", Allergies = "",        BiologicalSex = "male",   HeightCm = 175, WeightKg = 72,  Email = "michael@example.com" },
                new Profile { UserId = ids[5], FullName = "Olivia Martinez",   Age = 31, DietType = "vegan",       Goal = "weight_loss", ActivityLevel = "active",   Allergies = "soy",     BiologicalSex = "female", HeightCm = 168, WeightKg = 58,  Email = "olivia@example.com" },
                new Profile { UserId = ids[6], FullName = "James Wilson",      Age = 27, DietType = "keto",       Goal = "muscle_gain", ActivityLevel = "high",      Allergies = "",        BiologicalSex = "male",   HeightCm = 182, WeightKg = 85,  Email = "james@example.com" },

                // Regular Users
                new Profile { UserId = ids[7],  FullName = "Bob Johnson",       Age = 30, DietType = "vegan",       Goal = "muscle_gain", ActivityLevel = "active",   Allergies = "",        BiologicalSex = "male",   HeightCm = 180, WeightKg = 75,  Email = "bob@example.com" },
                new Profile { UserId = ids[8],  FullName = "Emma Garcia",       Age = 25, DietType = "keto",       Goal = "weight_loss", ActivityLevel = "low",      Allergies = "gluten",  BiologicalSex = "female", HeightCm = 165, WeightKg = 60,  Email = "emma@example.com" },
                new Profile { UserId = ids[9],  FullName = "Lucas Brown",       Age = 28, DietType = "balanced",   Goal = "maintenance", ActivityLevel = "moderate", Allergies = "",        BiologicalSex = "male",   HeightCm = 178, WeightKg = 72,  Email = "lucas@example.com" },
                new Profile { UserId = ids[10], FullName = "John Smith",        Age = 40, DietType = "balanced",   Goal = "maintenance", ActivityLevel = "low",      Allergies = "",        BiologicalSex = "male",   HeightCm = 182, WeightKg = 85,  Email = "john@example.com" },
                new Profile { UserId = ids[11], FullName = "Mila Rodriguez",    Age = 22, DietType = "vegan",       Goal = "weight_loss", ActivityLevel = "active",   Allergies = "soy",     BiologicalSex = "female", HeightCm = 168, WeightKg = 55,  Email = "mila@example.com" },
                new Profile { UserId = ids[12], FullName = "Noah Williams",     Age = 35, DietType = "keto",       Goal = "muscle_gain", ActivityLevel = "high",      Allergies = "",        BiologicalSex = "male",   HeightCm = 185, WeightKg = 90,  Email = "noah@example.com" },
                new Profile { UserId = ids[13], FullName = "Lina Chen",         Age = 27, DietType = "balanced",   Goal = "maintenance", ActivityLevel = "moderate", Allergies = "nuts",    BiologicalSex = "female", HeightCm = 170, WeightKg = 62,  Email = "lina@example.com" },
                new Profile { UserId = ids[14], FullName = "Sophia Lee",        Age = 29, DietType = "balanced",   Goal = "weight_loss", ActivityLevel = "low",      Allergies = "",        BiologicalSex = "female", HeightCm = 165, WeightKg = 68,  Email = "sophia@example.com" },
                new Profile { UserId = ids[15], FullName = "Ethan Kim",         Age = 31, DietType = "vegan",       Goal = "maintenance", ActivityLevel = "moderate", Allergies = "gluten",  BiologicalSex = "male",   HeightCm = 175, WeightKg = 80,  Email = "ethan@example.com" },
                new Profile { UserId = ids[16], FullName = "Isabella Lopez",    Age = 24, DietType = "vegetarian", Goal = "muscle_gain", ActivityLevel = "active",   Allergies = "",        BiologicalSex = "female", HeightCm = 162, WeightKg = 54,  Email = "isabella@example.com" },
                new Profile { UserId = ids[17], FullName = "Liam Patel",        Age = 33, DietType = "keto",       Goal = "weight_loss", ActivityLevel = "low",      Allergies = "",        BiologicalSex = "male",   HeightCm = 180, WeightKg = 82,  Email = "liam@example.com" },
                new Profile { UserId = ids[18], FullName = "Ava Singh",         Age = 26, DietType = "vegan",       Goal = "weight_loss", ActivityLevel = "high",      Allergies = "soy",     BiologicalSex = "female", HeightCm = 160, WeightKg = 50,  Email = "ava@example.com" },
                new Profile { UserId = ids[19], FullName = "William Dubois",    Age = 38, DietType = "balanced",   Goal = "muscle_gain", ActivityLevel = "active",   Allergies = "",        BiologicalSex = "male",   HeightCm = 185, WeightKg = 88,  Email = "william@example.com" },
                new Profile { UserId = ids[20], FullName = "Charlotte Moreau",  Age = 20, DietType = "vegetarian", Goal = "maintenance", ActivityLevel = "low",      Allergies = "",        BiologicalSex = "female", HeightCm = 158, WeightKg = 52,  Email = "charlotte@example.com" },
                new Profile { UserId = ids[21], FullName = "Benjamin Moreau",   Age = 29, DietType = "keto",       Goal = "weight_loss", ActivityLevel = "moderate", Allergies = "dairy",   BiologicalSex = "male",   HeightCm = 178, WeightKg = 82,  Email = "benjamin@example.com" },
                new Profile { UserId = ids[22], FullName = "Mia Leclerc",       Age = 41, DietType = "balanced",   Goal = "maintenance", ActivityLevel = "low",      Allergies = "",        BiologicalSex = "female", HeightCm = 165, WeightKg = 70,  Email = "mia@example.com" },
                new Profile { UserId = ids[23], FullName = "Henry Bernard",     Age = 36, DietType = "vegan",       Goal = "muscle_gain", ActivityLevel = "active",   Allergies = "",        BiologicalSex = "male",   HeightCm = 182, WeightKg = 78,  Email = "henry@example.com" },
                new Profile { UserId = ids[24], FullName = "Amelia Dubois",     Age = 28, DietType = "balanced",   Goal = "weight_loss", ActivityLevel = "moderate", Allergies = "",        BiologicalSex = "female", HeightCm = 170, WeightKg = 65,  Email = "amelia@example.com" },
                new Profile { UserId = ids[25], FullName = "Alexander Kim",     Age = 34, DietType = "keto",       Goal = "maintenance", ActivityLevel = "high",      Allergies = "",        BiologicalSex = "male",   HeightCm = 178, WeightKg = 88,  Email = "alexander@example.com" },
                new Profile { UserId = ids[26], FullName = "Evelyn Laurent",    Age = 30, DietType = "vegan",       Goal = "weight_loss", ActivityLevel = "moderate", Allergies = "",        BiologicalSex = "female", HeightCm = 165, WeightKg = 60,  Email = "evelyn@example.com" }
            };

            context.Users.AddRange(users);
            context.Profiles.AddRange(profiles);
            context.SaveChanges();
        }
    }
}
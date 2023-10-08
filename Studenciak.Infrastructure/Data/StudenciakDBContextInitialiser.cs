using Domain.Entities;
using Domain.ValueObjects;

namespace Infrastructure.Data;

public class StudenciakDbContextInitialiser
{
    private readonly StudenciakDbContext _dbContext;

    public StudenciakDbContextInitialiser(StudenciakDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public void Seed()
    {
        if (!_dbContext.Places.Any())
        {
            var places = GetPlaces();
            _dbContext.Places.AddRange(places);
            _dbContext.SaveChanges();
        }
    }
    private List<Place> GetPlaces()
    {
        var places = new List<Place>
        {
            new Place()
            {
                Name = "KFC",
                Description =
                    "KFC (short for Kentucky Fried Chicken) is an American fast food restaurant chain headquartered in Louisville, Kentucky, that specializes in fried chicken. It is the world's second-largest restaurant chain (as measured by sales) after McDonald's, with 22,621 locations globally in 150 countries as of December 2019. The chain is a subsidiary of Yum! Brands, a restaurant company that also owns the Pizza Hut, Taco Bell, and WingStreet chains.",
                FoodType = "Fast Food",
                Rating = 8.5,
                Location = new Location()
                {
                    Latitude = 40.7128,
                    Longitude = 74.0060
                },
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
            },
            new Place()
            {
                Name = "McDonald",
                Description =
                    "McDonald's Corporation is an American fast food company, founded in 1940 as a restaurant operated by Richard and Maurice McDonald, in San Bernardino, California, United States. They rechristened their business as a hamburger stand, and later turned the company into a franchise, with the Golden Arches logo being introduced in 1953 at a location in Phoenix, Arizona. In 1955, Ray Kroc, a businessman, joined the company as a franchise agent and proceeded to purchase the chain from the McDonald brothers. McDonald's had its previous headquarters in Oak Brook, Illinois, but moved its global headquarters to Chicago in June 2018.",
                FoodType = "Fast Food",
                Rating = 9.5,
                TypeOfPlace = 0,
                Location = new Location()
                {
                    Latitude = 46.7128,
                    Longitude = 71.0060
                },
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
            }
        };
        return places;
    }
}
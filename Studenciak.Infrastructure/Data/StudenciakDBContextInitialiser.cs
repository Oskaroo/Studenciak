using Domain.Entities;
using Domain.ValueObjects;
using Newtonsoft.Json;

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
            var placesSerialized =
                File.ReadAllText(@"C:\Users\Oskar\RiderProjects\Studenciak\Studenciak.Infrastructure\Data\placesSerialized.json");
            var places = JsonConvert.DeserializeObject<List<Place>>(placesSerialized);
            if(places == null) throw new Exception("Places are empty");
            _dbContext.Places.AddRange(places);
            _dbContext.SaveChanges();
        }
    }
}
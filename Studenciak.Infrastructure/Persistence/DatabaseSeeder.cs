using Application.Abstraction;
using Application.Security;
using Domain.Entities;
using Domain.ValueObjects;
using Newtonsoft.Json;

namespace Infrastructure.Persistence;

public class DatabaseSeeder : IDatabaseSeeder
{
    private readonly StudenciakDbContext _dbContext;
    private readonly IPasswordManager _passwordManager;

    public DatabaseSeeder(StudenciakDbContext dbContext, IPasswordManager passwordManager)
    {
        _dbContext = dbContext;
        _passwordManager = passwordManager;
    }

    public void SeedData()
    {
        
        string projectName = "Studenciak";
        string solutionDirectory = Path.GetDirectoryName(Path.GetDirectoryName(Directory.GetCurrentDirectory()));
        string projectPath = Path.Combine(solutionDirectory, projectName);
        
        var persistenceDirectory = Path.Combine(projectPath, "Studenciak.Infrastructure\\Persistence");
        #region FilesPaths;
        var roleSeederPath = Path.Combine(persistenceDirectory, "RolesSeeder.json");
        var placeTypeSeederPath = Path.Combine(persistenceDirectory, "PlaceTypesSeeder.json");
        var locationSeederPath = Path.Combine(persistenceDirectory, "LocationSeeder.json");
        var placesSeederPath = Path.Combine(persistenceDirectory, "PlacesSeeder.json");
        var userSeederPath = Path.Combine(persistenceDirectory, "UsersSeeder.json");
        
        #endregion
        
        #region Roles
        if (!File.Exists(roleSeederPath)) throw new Exception("RolesSeeder.json file not found.");
        if (!_dbContext.Roles.Any())
        {
            var rolesSeederJson = File.ReadAllText(roleSeederPath);
            var roles = JsonConvert.DeserializeObject<List<Role>>(rolesSeederJson);
            
            if (roles == null) throw new Exception("RolesSeeder.json file is empty.");
            
            _dbContext.Roles.AddRange(roles);
            _dbContext.SaveChanges();
        }
        
        #endregion
        #region PlaceTypes
        if (!File.Exists(placeTypeSeederPath)) throw new Exception("PlaceTypesSeeder.json file not found.");
        
        if (!_dbContext.PlaceTypes.Any())
        {
            var placeTypesSeederJson = File.ReadAllText(placeTypeSeederPath);
            var placeTypes = JsonConvert.DeserializeObject<List<PlaceType>>(placeTypesSeederJson);
            
            if (placeTypes == null) throw new Exception("PlaceTypesSeeder.json file is empty.");
            _dbContext.PlaceTypes.AddRange(placeTypes);
            _dbContext.SaveChanges();
        }
        
        #endregion
        #region Locations

        if (!File.Exists(locationSeederPath)) throw new Exception("LocationSeeder.json file not found.");
            
        if (!_dbContext.Locations.Any())
        {
            var locationSeederJson =  File.ReadAllText(locationSeederPath);
            var locations = JsonConvert.DeserializeObject<List<Location>>(locationSeederJson);
            
            if (locations == null) throw new Exception("LocationSeeder.json file is empty.");
             _dbContext.Locations.AddRange(locations);
             _dbContext.SaveChanges();
        }
        
        #endregion
        #region Places
        if (!File.Exists(placesSeederPath)) throw new Exception("PlacesSeeder.json file not found.");
        
        if (!_dbContext.Places.Any())
        {
            var placesSeederJson = File.ReadAllText(placesSeederPath);
            var places = JsonConvert.DeserializeObject<List<Place>>(placesSeederJson);
            
            if (places == null) throw new Exception("PlacesSeeder.json file is empty.");
             _dbContext.Places.AddRange(places);
             _dbContext.SaveChanges();
        }
        
        #endregion
        #region Users
        if (!File.Exists(userSeederPath)) throw new Exception("UsersSeeder.json file not found.");
        
        if (!_dbContext.Users.Any())
        {
            var userSeederJson = File.ReadAllText(userSeederPath);
            var users = JsonConvert.DeserializeObject<List<User>>(userSeederJson);
            if (users == null) throw new Exception("UsersSeeder.json file is empty.");
            
            foreach (var user in users)
            {
                user.PasswordHash = _passwordManager.Secure(user.PasswordHash);
            }
             _dbContext.Users.AddRange(users);
             _dbContext.SaveChanges();
        }
        
        #endregion
    }
}

using Microsoft.EntityFrameworkCore;

namespace AnimaxPlayApi.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }


        
    }
}


//public DbSet<Anime> Animes { get; set; }
//public DbSet<AnimeEpisode> AnimeEpisodes { get; set; }
//public DbSet<AnimeGenre> AnimeGenres { get; set; }
//public DbSet<Genre> Genres { get; set; }
//public DbSet<User> Users { get; set; }
//public DbSet<WatchHistory> WatchHistories { get; set; }


using Microsoft.EntityFrameworkCore;
using SongApi.Models;
using SongCategoryApi.Models;

namespace SongApi.Data {

    public class SongContext : DbContext {

        public SongContext(DbContextOptions<SongContext> options) : base(options)
        {

        }

        public DbSet<Song> Songs {get; set;}
        public DbSet<SongCategory> Categories {get; set;}
    }

}
using kolos.Services;
using Microsoft.EntityFrameworkCore;
using System;

namespace kolos.Models
{
    public partial class MainDbContext : DbContext
    {
        public MainDbContext()
        {
        }

        public MainDbContext(DbContextOptions options)
            : base(options)
        {
        }
        public DbSet<Album> Albums { get; set; }
        public DbSet<Track> Tracks { get; set; }
        public DbSet<Musician> Musicians { get; set; }
        public DbSet<Musician_Track> Musician_Tracks { get; set; }
        public DbSet<MusicLabel> MusicLabels { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Musician_Track>().HasKey(e => new { e.IdMusician, e.IdTrack });


            modelBuilder.Entity<Musician_Track>().HasOne(e => e.Musician)
                .WithMany(m => m.Musician_Tracks)
                .HasForeignKey(m => m.IdMusician)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Musician_Track>().HasOne(e => e.Track)
                .WithMany(m => m.Musician_Tracks)
                .HasForeignKey(m => m.IdTrack)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Track>().HasOne(e => e.Album)
                .WithMany(m => m.Tracks)
                .HasForeignKey(m => m.IdMusicAlbum);


            modelBuilder.Entity<Album>().HasOne(e => e.MusicLabel)
                .WithMany(m => m.Albums)
                .HasForeignKey(m => m.IdMusicLabel)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Musician>().HasData(
                new Musician() { IdMusician = 1, FirstName = "Kamil", LastName = "Bel", NickName = "Fleti" },
                new Musician() { IdMusician = 2, FirstName = "And", LastName = "Rzej", NickName = "Trabka" }
                );

            modelBuilder.Entity<Track>().HasData(
                new Track() { IdTrack = 1, TrackName = "Rock", Duration = 2, IdMusicAlbum = 1},
                new Track() { IdTrack = 2, TrackName = "Popstar", Duration = 5, IdMusicAlbum = 1 }

                );

            modelBuilder.Entity<Album>().HasData(
                new Album() { IdAlbum = 1, AlbumName = "Igni", PublishDate = DateTime.Now, IdMusicLabel = 1},
                new Album() { IdAlbum = 2, AlbumName = "Fireball" , PublishDate = DateTime.Now, IdMusicLabel = 1}

                );

            modelBuilder.Entity<MusicLabel>().HasData(
                new MusicLabel() { IdMusicLabel = 1, Name = "Cos"}
                );
            modelBuilder.Entity<Musician_Track>().HasData(
                new Musician_Track() { IdTrack = 1, IdMusician = 1 },
                new Musician_Track() { IdTrack = 2, IdMusician = 2 }
                );
        }
    }
}

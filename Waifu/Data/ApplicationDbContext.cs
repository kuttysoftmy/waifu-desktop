﻿using Microsoft.EntityFrameworkCore;
using Serilog;
using Waifu.Models;

namespace Waifu.Data;

public class ApplicationDbContext : DbContext
{
    public DbSet<ChatChannel> ChatChannels { get; set; }

    public DbSet<ChatMessage> ChatMessages { get; set; }

    public DbSet<RoleplayCharacter> RoleplayCharacters { get; set; }
    public DbSet<LocalLlamaModel> LocalLlamaModels { get; set; }
    
    public DbSet<Settings> Settings { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        // Configure SQLite as the database provider
        optionsBuilder.UseSqlite($"Data Source={Constants.DatabasePath}");
    }
}
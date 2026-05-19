using Abc.Data;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Abc.Infra;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) 
    : IdentityDbContext<ApplicationUser>(options) {
    public DbSet<Movie> Movies { get; set; } = default!;
    public DbSet<Country> Countries { get; set; } = default!;
    public DbSet<Currency> Currencies { get; set; } = default!;
}


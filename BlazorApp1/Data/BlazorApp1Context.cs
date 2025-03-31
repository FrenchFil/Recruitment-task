using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using BlazorApp1.Data;

namespace BlazorApp1.Data
{
    public class BlazorApp1Context(DbContextOptions<BlazorApp1Context> options) : IdentityDbContext<User>(options)
    {
    }
}

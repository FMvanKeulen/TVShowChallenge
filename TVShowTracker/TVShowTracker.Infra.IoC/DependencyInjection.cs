using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TVShowTracker.Application.Interfaces;
using TVShowTracker.Application.Mappings;
using TVShowTracker.Application.Services;
using TVShowTracker.Domain.Interfaces;
using TVShowTracker.Infra.Data.Context;
using TVShowTracker.Infra.Data.Repositories;

namespace TVShowTracker.Infra.IoC
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped<IShowRepository, ShowRepository>();
            services.AddScoped<IGenreRepository, GenreRepository>();
            services.AddScoped<IActorRepository, ActorRepository>();
            services.AddScoped<IEpisodeRepository, EpisodeRepository>();

            services.AddScoped<IShowService, ShowService>();
            services.AddScoped<IGenreService, GenreService>();
            services.AddScoped<IActorService, ActorService>();
            services.AddScoped<IEpisodeService, EpisodeService>();

            services.AddAutoMapper(typeof(DomainToDTOMappingProfile));

            return services;
        }
    }
}
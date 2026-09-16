using GreenLibrary.Interfaces;
using GreenLibrary.Data.Xml;
using GreenLibrary.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace GreenLibrary.DIExtensions;

public static class DIExtension 
{
    // Note: we use it in Parent Project. Also we can override it or init without it.
    public static IServiceCollection AddGreenLibrary(this IServiceCollection services)
    {
        services.TryAddSingleton<IBookStorage, XmlBookStorage>();
        services.TryAddSingleton<BookLibrary>();

        return services;
    }
}

using API.Services.Constract;
using Domain.Entities;

namespace API.Mapper.MappingSupports
{
    public static class MappingSupport
    {
        public static string? GetFilePath(this AppFile? file, IAppServices? appServices)
            => appServices?.File.GetPresignedUrl(file?.Path ?? string.Empty);
    }
}

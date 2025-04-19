namespace AnimaxPlayApi.Core.Model
{
    public class EmbedAvailability
    {
        public string TmdbId { get; set; } = string.Empty;

        public bool IsAvailableOnEmbedSu { get; set; }
        public bool IsAvailableOnVidsrc { get; set; }

        public string EmbedSuUrl => $"https://embed.su/embed/movie/{TmdbId}";
        public string VidsrcUrl => $"https://vidsrc.xyz/embed/movie?tmdb={TmdbId}";

        public string? EmbedSuIframe => IsAvailableOnEmbedSu
            ? $"<iframe src='{EmbedSuUrl}' width='100%' height='500' frameborder='0' allowfullscreen></iframe>"
            : null;

        public string? VidsrcIframe => IsAvailableOnVidsrc
            ? $"<iframe src='{VidsrcUrl}' width='100%' height='500' frameborder='0' allowfullscreen></iframe>"
            : null;
    }
}

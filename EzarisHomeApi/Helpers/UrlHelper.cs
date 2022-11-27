using Flurl;

namespace EzarisHomeApi.Helpers {
    public static class UrlHelper {
        public static string BuildUrl(string baseUrl, string pathSegment, object parameters = null) {
            var url = baseUrl
                .AppendPathSegment(pathSegment)
                .SetQueryParams(parameters);

            return url;
        }
    }
}

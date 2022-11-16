using Flurl;

namespace EzarisHomeApi.Helpers {
    public static class UrlHelper {
        public static string BuildUrl(string baseUrl, string pathSegment, object parameters = null) {
            var url = baseUrl
                .AppendPathSegment(pathSegment)
                //.AppendPathSegment("users")
                .SetQueryParams(parameters);

            return url;
        }
    }
}

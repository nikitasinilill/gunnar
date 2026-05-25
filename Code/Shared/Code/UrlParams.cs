using Abc.Infra;

namespace Abc.Shared.Code;

public class UrlParams(Uri url) {
    private readonly Dictionary<string, string> values = [];

    public Query Parse() {
        var query = url?.Query?.TrimStart('?');
        if (string.IsNullOrEmpty(query)) return new Query();

        var parameters = query.Split('&', StringSplitOptions.RemoveEmptyEntries);
        foreach (var parameter in parameters) Add(parameter.Split('=', 2));
        return new Query(values);
    }

    private void Add(string[] pair) {
        if (pair.Length != 2) return;
        values[pair[0]] = Uri.UnescapeDataString(pair[1]);
    }
}

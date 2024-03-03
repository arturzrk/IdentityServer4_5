using System.Text.Json;

namespace IdentityServer.IntegrationTests.Clients;

public static class JsonElementExtensions
{
    public static object ToPrimitiveType(this JsonElement jsonElement)
    {
        if (jsonElement.ValueKind == JsonValueKind.String)
        {
            return jsonElement.GetString();
        }

        if (jsonElement.ValueKind == JsonValueKind.Number)
        {
            return jsonElement.GetInt64();
        }

        return jsonElement;
    }
}
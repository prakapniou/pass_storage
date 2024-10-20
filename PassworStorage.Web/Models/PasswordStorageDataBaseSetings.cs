namespace PasswordStorage.Web.Models;

public class PasswordStorageDataBaseSettings
{
    public string? ConnectionString { get; set; }

    public string? DatabaseName { get; set; }

    public string? PasswordCollectionName { get; set; }
}

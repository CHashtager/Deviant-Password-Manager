using System.Web;

namespace DeviantPasswordManager.FunctionalTests;

public static class Utilities
{
  public static string GetQueryString(object obj)
  {
    var properties = from p in obj.GetType().GetProperties()
      let value = p.GetValue(obj, null)
      where value != null
      select $"{p.Name}={HttpUtility.UrlEncode(value.ToString())}";

    return string.Join("&", properties.ToArray());
  }
}

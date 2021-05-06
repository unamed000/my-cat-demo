using System;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace MyOrg.Storage.Secure
{
    public interface IMyOrgSecureStorage
    {
        Task SetValue(string key, string value);
        Task<string> GetValue(string key);
    }

    public class MyOrgSecureStorage : IMyOrgSecureStorage
    {
        public Task SetValue(string key, string value)
        {
            return SecureStorage.SetAsync(key, value);
        }

        public Task<string> GetValue(string key)
        {
            return SecureStorage.GetAsync(key);
        }
    }
}
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using jcMSA.Common.PCL.Enums;
using jcMSA.Common.PCL.PlatformAbstractions;

using Newtonsoft.Json;

namespace jcMSA.Common.PCL {
    public class BaseHandler {
        private string _baseURL { get; set; }

        internal string _baseArgURL { get; set; }

        internal IBaseCachePa _cacheInterface;

        public BaseHandler(string webAPIURL, string baseArgURL, IBaseCachePa cacheInterface) {
            _baseURL = webAPIURL;
            _baseArgURL = baseArgURL;
            _cacheInterface = cacheInterface;
        }

        private HttpClient HC {
            get {
                var handler = new HttpClientHandler();

                var client = new HttpClient(handler) { Timeout = TimeSpan.FromMinutes(1) };
                
                return client;
            }
        }

        private string BASEURL => _baseURL + _baseArgURL;

        private static HttpContent convertObj<T>(T objValue) {
            return new StringContent(JsonConvert.SerializeObject(objValue), Encoding.UTF8, "application/json");
        }

        public async Task<TK> PUT<T, TK>(T obj) { return await PUT<T, TK>(_baseArgURL, obj); }

        public async Task<TK> PUT<T, TK>(string urlArgs, T obj) {
            var result = await HC.PutAsync(BASEURL, convertObj(obj));

            var data = result.Content.ReadAsStringAsync().GetAwaiter().GetResult();

            return JsonConvert.DeserializeObject<TK>(data);
        }

        public async Task<TK> POST<T, TK>(string urlArgs, T obj) {
            var result = await HC.PostAsync(BASEURL, convertObj(obj));

            var data = result.Content.ReadAsStringAsync().GetAwaiter().GetResult();

            return JsonConvert.DeserializeObject<TK>(data);
        }

        public async Task<K> GET<T, K>(string urlArguments, T obj) {
            var str = await HC.GetStringAsync($"{BASEURL}{convertObj(obj)}");

            return JsonConvert.DeserializeObject<K>(str);
        }

        private string parseUrlArguments(string urlArguments) {
            return string.IsNullOrEmpty(urlArguments) ? "" : $"?{urlArguments}";
        }

        public async Task<T> GET<T>(string urlArguments, CacheItems cacheItem) {
            if (_cacheInterface.Exists(cacheItem)) {
                return _cacheInterface.Get<T>(cacheItem).ReturnValue;
            }

            try {
                var str = await HC.GetStringAsync($"{BASEURL}{parseUrlArguments(urlArguments)}");
                
                var result = JsonConvert.DeserializeObject<T>(str);

                _cacheInterface.Add(cacheItem, result);

                return result;
            } catch (Exception ex) {
                dynamic result = default(T);

                result.ErrorCode = ErrorCodes.HTTP_CLIENT_FAILED_TO_CONNECT;
                result.Exception = ex.ToString();

                return result;
            }
        }
    }
}
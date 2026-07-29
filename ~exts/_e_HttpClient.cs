using System.Net;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text.Json;

namespace Ans.Net10.Common
{

	/*

	Пример использования:
	
	string myJwtToken = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9...";

	// Пример 1: Обычный Bearer запрос (схема по умолчанию)
	var result1 = await client.SendGetAsync<UserDto>(
		"https://example.com", 
		"/profile", 
		authValue: myJwtToken);

	// Пример 2: Запрос со специфичной схемой (например, "ApiKey")
	var result2 = await client.SendGetAsync<UserDto>(
		"https://example.com", 
		"/data", 
		authValue: "my-secret-api-key", 
		authScheme: "ApiKey");



	 */


	public class WebApiResult<T>
	{
		/// <summary>
		/// Код ответа от сервера
		/// </summary>
		public HttpStatusCode StatusCode { get; set; }

		/// <summary>
		/// Заголовки ответа от сервера
		/// </summary>
		public HttpResponseHeaders Headers { get; set; }

		/// <summary>
		/// Контент
		/// </summary>
		public T Content { get; set; }

		/// <summary>
		/// Индикатор ошибки десериализации
		/// </summary>
		public bool IsDeserializationError { get; set; }

		/// <summary>
		/// Исключение ошибки десериализации
		/// </summary>
		public Exception DeserializationException { get; set; }

		/// <summary>
		/// Текст ошибки от сервера
		/// </summary>
		public string ErrorBody { get; set; }
	}



	public static partial class _e_HttpClient
	{

		/* functions */


		public static async Task<WebApiResult<T>> SendGetAsync<T>(
			this HttpClient client,
			string baseUrl,
			string queryString,
			JsonSerializerOptions jsonOptions = null,
			CancellationToken cancellationToken = default,
			string authValue = null,
			string authScheme = "Bearer")
		{
			var url1 = _combineUrl(baseUrl, queryString);
			var request1 = new HttpRequestMessage(HttpMethod.Get, url1);
			_applyAuthorization(request1, authScheme, authValue);
			var response1 = await client.SendAsync(
				request1,
				HttpCompletionOption.ResponseHeadersRead,
				cancellationToken);
			return await _processResponseAsync<T>(response1, jsonOptions, cancellationToken);
		}


		public static Task<WebApiResult<T>> SendGetAsync<T>(
			this HttpClient client,
			string baseUrl,
			ParamsBuilder paramsBuilder,
			JsonSerializerOptions jsonOptions = null,
			CancellationToken cancellationToken = default,
			string authValue = null,
			string authScheme = "Bearer")
		{
			ArgumentNullException.ThrowIfNull(paramsBuilder);
			return client.SendGetAsync<T>(
				baseUrl,
				paramsBuilder.ToString(),
				jsonOptions,
				cancellationToken,
				authValue,
				authScheme);
		}


		public static async Task<WebApiResult<T>> SendPostAsync<T, TBody>(
			this HttpClient client,
			string baseUrl,
			string queryString,
			TBody body,
			JsonSerializerOptions jsonOptions = null,
			CancellationToken cancellationToken = default,
			string authValue = null,
			string authScheme = "Bearer")
		{
			var url1 = _combineUrl(baseUrl, queryString);
			var request1 = new HttpRequestMessage(HttpMethod.Post, url1)
			{
				Content = JsonContent.Create(body, options: jsonOptions)
			};
			_applyAuthorization(request1, authScheme, authValue);
			var response1 = await client.SendAsync(
				request1,
				HttpCompletionOption.ResponseHeadersRead,
				cancellationToken);
			return await _processResponseAsync<T>(response1, jsonOptions, cancellationToken);
		}


		public static async Task<WebApiResult<T>> SendPutAsync<T, TBody>(
			this HttpClient client,
			string baseUrl,
			string queryString,
			TBody body,
			JsonSerializerOptions jsonOptions = null,
			CancellationToken cancellationToken = default,
			string authValue = null,
			string authScheme = "Bearer")
		{
			var url1 = _combineUrl(baseUrl, queryString);
			var request1 = new HttpRequestMessage(HttpMethod.Put, url1)
			{
				Content = JsonContent.Create(body, options: jsonOptions)
			};
			_applyAuthorization(request1, authScheme, authValue);
			var response1 = await client.SendAsync(
				request1,
				HttpCompletionOption.ResponseHeadersRead,
				cancellationToken);
			return await _processResponseAsync<T>(response1, jsonOptions, cancellationToken);
		}


		public static async Task<WebApiResult<T>> SendPatchAsync<T, TBody>(
			this HttpClient client,
			string baseUrl,
			string queryString,
			TBody body,
			JsonSerializerOptions jsonOptions = null,
			CancellationToken cancellationToken = default,
			string authValue = null,
			string authScheme = "Bearer")
		{
			var url1 = _combineUrl(baseUrl, queryString);
			var request1 = new HttpRequestMessage(HttpMethod.Patch, url1)
			{
				Content = JsonContent.Create(body, options: jsonOptions)
			};
			_applyAuthorization(request1, authScheme, authValue);
			var response1 = await client.SendAsync(
				request1,
				HttpCompletionOption.ResponseHeadersRead,
				cancellationToken);
			return await _processResponseAsync<T>(response1, jsonOptions, cancellationToken);
		}


		/// <summary>
		/// DELETE-запрос без тела (передача параметров через query-строку)
		/// </summary>
		public static async Task<WebApiResult<T>> SendDeleteAsync<T>(
			this HttpClient client,
			string baseUrl,
			string queryString,
			JsonSerializerOptions jsonOptions = null,
			CancellationToken cancellationToken = default,
			string authValue = null,
			string authScheme = "Bearer")
		{
			var url1 = _combineUrl(baseUrl, queryString);
			var request1 = new HttpRequestMessage(HttpMethod.Delete, url1);
			_applyAuthorization(request1, authScheme, authValue);
			var response1 = await client.SendAsync(
				request1,
				HttpCompletionOption.ResponseHeadersRead,
				cancellationToken);
			return await _processResponseAsync<T>(response1, jsonOptions, cancellationToken);
		}


		/// <summary>
		/// DELETE-запрос с телом (передача сложного объекта в формате JSON)
		/// </summary>
		public static async Task<WebApiResult<T>> SendDeleteAsync<T, TBody>(
			this HttpClient client,
			string baseUrl,
			string queryString,
			TBody body,
			JsonSerializerOptions jsonOptions = null,
			CancellationToken cancellationToken = default,
			string authValue = null,
			string authScheme = "Bearer")
		{
			var url1 = _combineUrl(baseUrl, queryString);
			var request1 = new HttpRequestMessage(HttpMethod.Delete, url1)
			{
				Content = JsonContent.Create(body, options: jsonOptions)
			};
			_applyAuthorization(request1, authScheme, authValue);
			var response1 = await client.SendAsync(
				request1,
				HttpCompletionOption.ResponseHeadersRead,
				cancellationToken);
			return await _processResponseAsync<T>(response1, jsonOptions, cancellationToken);
		}


		/* privates */


		private static void _applyAuthorization(
			HttpRequestMessage request,
			string scheme,
			string value)
		{
			if (!string.IsNullOrEmpty(value))
				request.Headers.Authorization = new AuthenticationHeaderValue(scheme, value);
		}


		private static async Task<WebApiResult<T>> _processResponseAsync<T>(
			HttpResponseMessage response,
			JsonSerializerOptions jsonOptions,
			CancellationToken cancellationToken)
		{
			var result1 = new WebApiResult<T>
			{
				StatusCode = response.StatusCode,
				Headers = response.Headers
			};
			try
			{
				if (response.IsSuccessStatusCode)
				{
					if (response.StatusCode != HttpStatusCode.NoContent)
					{
						try
						{
							result1.Content = await response.Content
								.ReadFromJsonAsync<T>(jsonOptions, cancellationToken);
						}
						catch (JsonException ex)
						{
							result1.IsDeserializationError = true;
							result1.DeserializationException = ex;
						}
					}
				}
				else
				{
					result1.ErrorBody = await response.Content
						.ReadAsStringAsync(cancellationToken);
				}
				return result1;
			}
			finally
			{
				response.Dispose();
			}
		}


		private static string _combineUrl(
			string baseUri,
			string query)
		{
			if (string.IsNullOrEmpty(query))
				return baseUri;
			baseUri = baseUri.TrimEnd('/');
			if (query.StartsWith('?'))
				return baseUri + query;
			if (query.StartsWith('/'))
				return baseUri + query;
			return $"{baseUri}/{query}";
		}

	}

}

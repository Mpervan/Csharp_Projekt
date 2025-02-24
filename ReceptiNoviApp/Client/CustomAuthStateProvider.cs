﻿using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text.Json;

namespace ReceptiNoviApp.Client
{
    public class CustomAuthStateProvider : AuthenticationStateProvider
    {
		private readonly HttpClient _httpClient;
		private readonly ILocalStorageService _localStorage;
		public CustomAuthStateProvider(HttpClient http, ILocalStorageService localStorage)
		{
			_httpClient = http;
			_localStorage = localStorage;
		}
		public override async Task<AuthenticationState> GetAuthenticationStateAsync()
		{
            string token = await _localStorage.GetItemAsStringAsync("token");
			var identity = new ClaimsIdentity();

			_httpClient.DefaultRequestHeaders.Authorization = null;

			if (!string.IsNullOrEmpty(token))
			{
				identity = new ClaimsIdentity(ParseClaimsFromJwt(token), "jwt");
				_httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token.Replace("\"", ""));
			}

			var user = new ClaimsPrincipal(identity);
			var state = new AuthenticationState(user);
			NotifyAuthenticationStateChanged(Task.FromResult(state));
			return state;
		}
		public static IEnumerable<Claim> ParseClaimsFromJwt(string jwt)
		{
			var payload = jwt.Split('.')[1];
			var jsonBytes = ParseBase64WithoutPadding(payload);
			var keyValuePairs = JsonSerializer.Deserialize<Dictionary<string, object>>(jsonBytes);
			return keyValuePairs.Select(kvp => new Claim(kvp.Key, kvp.Value.ToString()));
		}

		private static byte[] ParseBase64WithoutPadding(string base64)
		{
			switch (base64.Length % 4)
			{
				case 2: base64 += "=="; break;
				case 3: base64 += "="; break;
			}
			return Convert.FromBase64String(base64);
		}
	}
}

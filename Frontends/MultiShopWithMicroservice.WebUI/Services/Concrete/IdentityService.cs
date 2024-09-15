using IdentityModel.Client;
using IdentityServer4.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using MultiShopWithMicroservice.DtoLayer.IdentityDtos;
using MultiShopWithMicroservice.WebUI.Services.Interfaces;
using MultiShopWithMicroservice.WebUI.Settings;
using System.Security.Claims;

namespace MultiShopWithMicroservice.WebUI.Services.Concrete
{
	public class IdentityService : IIdentityService
	{
		private readonly HttpClient _httpClient;
		private readonly IHttpContextAccessor _httpContextAccessor;
		private readonly ClientSettings _clientSettings;
		private readonly ServiceApiSettings _serviceApiSettings;

		public IdentityService(IOptions<ClientSettings> clientSettings, 
			                  IHttpContextAccessor httpContextAccessor, 
							  HttpClient httpClient,
							  IOptions<ServiceApiSettings> serviceApiSettings)
		{
			_clientSettings = clientSettings.Value;
			_httpContextAccessor = httpContextAccessor;
			_httpClient = httpClient;
			_serviceApiSettings= serviceApiSettings.Value;
		}

		public async Task<bool> GetRefreshToken()
		{
			var discoveryEndPoint = await _httpClient.GetDiscoveryDocumentAsync(new DiscoveryDocumentRequest
			{
				Address = _serviceApiSettings.IdentityServerUrl,
				
			});

			var refreshToken = await _httpContextAccessor.HttpContext.GetTokenAsync(OpenIdConnectParameterNames.RefreshToken);

			RefreshTokenRequest refreshTokenRequest = new()
			{
				ClientId = _clientSettings.MultiShopManagerClient.ClientId,
				ClientSecret = _clientSettings.MultiShopManagerClient.ClientSecret,
				RefreshToken = refreshToken,
				Address = discoveryEndPoint.TokenEndpoint
			};

			var token = await _httpClient.RequestRefreshTokenAsync(refreshTokenRequest);

			var authenticationToken = new List<AuthenticationToken>()
			{
				new AuthenticationToken
				{
					Name=OpenIdConnectParameterNames.AccessToken,
					Value = token.AccessToken
				},
				new AuthenticationToken
				{
					Name=OpenIdConnectParameterNames.RefreshToken,
					Value = token.RefreshToken
				},
				new AuthenticationToken
				{
					Name=OpenIdConnectParameterNames.ExpiresIn,
					Value=DateTime.Now.AddSeconds(token.ExpiresIn).ToString()
				}
			};

			var result = await _httpContextAccessor.HttpContext.AuthenticateAsync();

			if (result.Succeeded)
			{
				var properties = result.Properties;
				properties.StoreTokens(authenticationToken);

				await _httpContextAccessor.HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, result.Principal, properties);

				return true;
			}

			return false;
		}

		public async Task<bool> SignIn(LoginDto loginDto)
		{
			var discoveryEndpoint=await _httpClient.GetDiscoveryDocumentAsync(new DiscoveryDocumentRequest
			{
				Address = _serviceApiSettings.IdentityServerUrl,
				
			});

			var passwordTokenRequest = new PasswordTokenRequest
			{
				ClientId = _clientSettings.MultiShopManagerClient.ClientId,
				ClientSecret = _clientSettings.MultiShopManagerClient.ClientSecret,
				UserName = loginDto.UserName,
				Password = loginDto.Password,
				Address = discoveryEndpoint.TokenEndpoint
			};

			var token = await _httpClient.RequestPasswordTokenAsync(passwordTokenRequest);

			var userInfoRequest = new UserInfoRequest
			{
				Address = discoveryEndpoint.UserInfoEndpoint,
				Token = token.AccessToken
			};

			var userValues = await _httpClient.GetUserInfoAsync(userInfoRequest);

			ClaimsIdentity claimsIdentity = new ClaimsIdentity(userValues.Claims, CookieAuthenticationDefaults.AuthenticationScheme, "name", "role");
			ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(claimsIdentity);

			var authenticationProperties = new AuthenticationProperties();

			authenticationProperties.StoreTokens(new List<AuthenticationToken>(){
				new AuthenticationToken
				{
					Name= OpenIdConnectParameterNames.AccessToken,
					Value= token.AccessToken
				},
				new AuthenticationToken
				{
					Name=OpenIdConnectParameterNames.RefreshToken,
					Value= token.RefreshToken
				},

				new AuthenticationToken
				{
					Name= OpenIdConnectParameterNames.ExpiresIn,
					Value= DateTime.Now.AddSeconds(token.ExpiresIn).ToString()
				}
			});

			authenticationProperties.IsPersistent = false;

			await _httpContextAccessor.HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, claimsPrincipal, authenticationProperties);

			return true;
			
		}
	}
}

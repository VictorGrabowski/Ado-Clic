﻿using System.Net.Http.Headers;

namespace Ado_Clic.Handlers
{
    public class JwtCookieHandler(IHttpContextAccessor httpContextAccessor) : DelegatingHandler
    {
        private readonly IHttpContextAccessor _httpContextAccessor = httpContextAccessor;

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var token = _httpContextAccessor.HttpContext?.Request.Cookies["jwtToken"];

            if (!string.IsNullOrEmpty(token))
            {
                request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
            }

            return await base.SendAsync(request, cancellationToken);
        }
    }

}

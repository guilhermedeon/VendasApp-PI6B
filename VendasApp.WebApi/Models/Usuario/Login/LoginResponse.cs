﻿namespace VendasApp.WebApi.Models.Usuario.Login
{
    public class LoginResponse
    {
        public LoginResponse()
        {
            Token = string.Empty;
            responseMsg =
            new HttpResponseMessage()
            {
                StatusCode =
               System.Net.HttpStatusCode.Unauthorized
            };
        }

        public string Token { get; set; }

        public HttpResponseMessage responseMsg
        {
            get; set;
        }
    }
}
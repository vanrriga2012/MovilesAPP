﻿using AppMovile.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using Newtonsoft.Json;
using System.Threading.Tasks;
using Plugin.Connectivity;

namespace AppMovile.Services
{
    public class ApiServices
    {
        public async Task<Response> CheckConnection()
        {
            if (!CrossConnectivity.Current.IsConnected)
            {
                return new Response
                {
                    IsSucces = false,
                    Message = "Por favor activa tu configuracion de Internet"
                };
            }
            var isReachable = await CrossConnectivity.Current.IsRemoteReachable("google.com");
            if(!isReachable)
            {
                return new Response
                {
                    IsSucces = false,
                    Message = "Revisar tu conexion a Internet"
                };
            }
            return new Response
            {
                IsSucces = true,
                Message = "Ok"
            };
        }
        public async Task<Response> GetList<T>(string urlBase, string serviceprefix, string controller)
        {
            try
            {
                var cliente = new HttpClient();
                cliente.BaseAddress = new Uri(urlBase);
                var url = string.Format("{0}{1}", serviceprefix, controller);
                var response = await cliente.GetAsync(url);
                var result = await response.Content.ReadAsStringAsync();
                if (!response.IsSuccessStatusCode)
                {
                    return new Response
                    {
                        IsSucces = false,
                        Message = result
                    };
                }
                var list = JsonConvert.DeserializeObject<List<T>>(result);
                return new Response
                {
                    IsSucces = true,
                    Message = "ok",
                    Result = list
                };

            }
            catch (Exception ex )
            {
                return new Response
                {
                    IsSucces = false,
                    Message = ex.Message,
                    Result = ex.Message
                };
             
            }
        
        }

    }
}

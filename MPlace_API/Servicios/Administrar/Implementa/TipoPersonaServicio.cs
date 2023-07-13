using EntidadesNegocio.Administrar;
using Microsoft.Extensions.Configuration;
using MPlace_API.Servicios.Administrar.Interface;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MPlace_API.Servicios.Administrar.Implementa
{
    public class TipoPersonaServicio: ITipoPersonaServicio
    {
        private IConfiguration _configuration;
        public TipoPersonaServicio(IConfiguration configuration)
        {
            _configuration = configuration; 
        }
        public async Task<List<TipoPersonaDto>> ConsultaTipoPersona() 
        {
            var url = _configuration["Urls:Administrar:Url"];
            var metodo = _configuration["Urls:Administrar:ConsultarTipoPersona"];
            var tiposPersonas = new List<TipoPersonaDto>();


            using (var client = new HttpClient())
            {
                var byteArray = Encoding.UTF8.GetBytes("crojas");
                var autenticacion = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray));
                client.DefaultRequestHeaders.Authorization = autenticacion;
                using (var httpResponseMessage = await client.GetAsync(url + metodo))
                {
                    if (httpResponseMessage.IsSuccessStatusCode)
                    {
                        var response = await httpResponseMessage.Content.ReadAsStringAsync();
                        if (!string.IsNullOrEmpty(response))
                        {
                            tiposPersonas = JsonConvert.DeserializeObject<List<TipoPersonaDto>>(response);
                        }
                    }
                }
            }

            //using (var client = new HttpClient())
            //{
            //    var byteArray = Encoding.UTF8.GetBytes("crojas");
            //    var autenticacion = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray));
            //    client.DefaultRequestHeaders.Authorization = autenticacion;

            //    using (var httpResponseMessage = await client.GetAsync(url + metodo).ConfigureAwait(false))
            //    {
            //        if (httpResponseMessage.IsSuccessStatusCode)
            //        {
            //            var response = await httpResponseMessage.Content.ReadAsStringAsync();

            //            if (!string.IsNullOrEmpty(response))
            //            {
            //                tiposPersonas = JsonConvert.DeserializeObject<List<TipoPersonaDto>>(response);
            //            }
            //        }
            //    }
            //}


            //using (var client = new HttpClient()) 
            //{
            //    var requestMenssage = new HttpRequestMessage(HttpMethod.Get, url + metodo);
            //    requestMenssage.Headers.Add("User-Agent", "crojas");
            //    var httpResponseMessage = await client.SendAsync(requestMenssage).ConfigureAwait(false);
            //    if (httpResponseMessage.IsSuccessStatusCode)
            //    {
            //        var response = await httpResponseMessage.Content.ReadAsStringAsync();

            //        if (!string.IsNullOrEmpty(response))
            //        {
            //            tiposPersonas = JsonConvert.DeserializeObject<List<TipoPersonaDto>>(response);
            //        }
            //    }
            //}

            return tiposPersonas;
        }

    }
}

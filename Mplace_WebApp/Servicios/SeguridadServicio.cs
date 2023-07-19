using EntidadesNegocio.Administrar;
using Mplace_WebApp.Areas.Identity.Data;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Text;
using System;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;
using EntidadesNegocio.Seguridad;
using JsonText = System.Text.Json;

namespace Mplace_WebApp.Servicios
{
    public class SeguridadServicio
    {
        private IConfiguration _configuration;
        public SeguridadServicio(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public async Task<UsuarioDto> RegistrarUsuario(UsuarioDto usuario) 
        {
            var url = _configuration["Urls:Seguridad:Url"];
            var metodo = _configuration["Urls:Seguridad:RegistrarUsuario"];
            var usuarioResult = new UsuarioDto();

            using (var client = new HttpClient())
            {
                var byteArray = Encoding.UTF8.GetBytes("crojas");
                var autenticacion = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray));
                client.DefaultRequestHeaders.Authorization = autenticacion;


                string usuarioJson = JsonText.JsonSerializer.Serialize(usuario);

                var content = new StringContent(usuarioJson, Encoding.UTF8, "application/json");

                using (var httpResponseMessage = await client.PostAsync($"{url}{metodo}", content))
                {
                    if (httpResponseMessage.IsSuccessStatusCode)
                    {
                        var response = await httpResponseMessage.Content.ReadAsStringAsync();
                        if (!string.IsNullOrEmpty(response))
                        {
                            usuarioResult = JsonConvert.DeserializeObject<UsuarioDto>(response);
                        }
                    }
                }
            }
            return usuarioResult;
        }

        public async Task<List<RolDto>> ConsultarRoles()
        {
            var url = _configuration["Urls:Seguridad:Url"];
            var metodo = _configuration["Urls:Seguridad:ConsultarRoles"];
            var roles = new List<RolDto>();

            using (var client = new HttpClient())
            {
                var byteArray = Encoding.UTF8.GetBytes("crojas");
                var autenticacion = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray));
                client.DefaultRequestHeaders.Authorization = autenticacion;

                using (var httpResponseMessage = await client.GetAsync($"{url}{metodo}"))
                {
                    if (httpResponseMessage.IsSuccessStatusCode)
                    {
                        var response = await httpResponseMessage.Content.ReadAsStringAsync();
                        if (!string.IsNullOrEmpty(response))
                        {
                            roles = JsonConvert.DeserializeObject<List<RolDto>>(response);
                        }
                    }
                }
            }
            return roles;
        }
        public async Task<bool> Login(UsuarioDto usuario)
        {
            var url = _configuration["Urls:Seguridad:Url"];
            var metodo = _configuration["Urls:Seguridad:Login"];
            bool loginResult = false;

            using (var client = new HttpClient())
            {
                var byteArray = Encoding.UTF8.GetBytes("crojas");
                var autenticacion = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray));
                client.DefaultRequestHeaders.Authorization = autenticacion;


                string usuarioJson = JsonText.JsonSerializer.Serialize(usuario);

                var content = new StringContent(usuarioJson, Encoding.UTF8, "application/json");

                using (var httpResponseMessage = await client.PostAsync($"{url}{metodo}", content))
                {
                    if (httpResponseMessage.IsSuccessStatusCode)
                    {
                        var response = await httpResponseMessage.Content.ReadAsStringAsync();
                        if (!string.IsNullOrEmpty(response))
                        {
                            loginResult = JsonConvert.DeserializeObject<bool>(response);
                        }
                    }
                }
            }
            return loginResult;
        }
    }
}

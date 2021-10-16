using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace QueryApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }

// Nombre de la escuela: Universidad Tecnologica Metropolitana
// Asignatura: Aplicaciones Web Orientada a Servicios
// Nombre del Maestro: Joel Ivan Chuc Uc
// Nombre de la actividad: Practica 1
// Nombre del alumno: Crystian Ramirez Cruz
// Cuatrimestre: 4
// Grupo:B
// Parcial:2



}

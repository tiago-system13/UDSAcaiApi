using System;
using System.Collections.Generic;
using System.Text;

namespace UDSAcaiApi.Dominio.Constantes
{
    public static class EnviromentConstante
    {
        public static readonly string DATABASE_CONNECTION_STRING = Environment.GetEnvironmentVariable("DATABASE_CONNECTION_STRING");
    }
}

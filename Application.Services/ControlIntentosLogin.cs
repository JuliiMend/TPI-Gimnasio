using System;
using System.Collections.Concurrent;

namespace Application.Services
{
    // Bloquea temporalmente un usuario después de varios intentos fallidos de login seguidos,
    // para frenar ataques de fuerza bruta. Se registra como singleton y vive en memoria de la API.
    public class ControlIntentosLogin
    {
        public const int MaximoIntentos = 5;
        public static readonly TimeSpan DuracionBloqueo = TimeSpan.FromMinutes(15);

        private sealed class Registro
        {
            public int Fallidos;
            public DateTime UltimoFalloUtc;
            public DateTime? BloqueadoHastaUtc;
        }

        private readonly ConcurrentDictionary<string, Registro> _registros = new();

        private static string Clave(string username) => username.Trim().ToLowerInvariant();

        public TimeSpan? TiempoRestanteBloqueo(string username)
        {
            if (!_registros.TryGetValue(Clave(username), out var registro))
            {
                return null;
            }

            lock (registro)
            {
                var restante = registro.BloqueadoHastaUtc - DateTime.UtcNow;
                return restante > TimeSpan.Zero ? restante : null;
            }
        }

        // Devuelve cuántos intentos le quedan antes del bloqueo (0 = quedó bloqueado)
        public int RegistrarFallo(string username)
        {
            var registro = _registros.GetOrAdd(Clave(username), _ => new Registro());
            var ahora = DateTime.UtcNow;

            lock (registro)
            {
                // Si pasó el bloqueo o los fallos son viejos, se empieza a contar de nuevo
                if (registro.BloqueadoHastaUtc <= ahora || ahora - registro.UltimoFalloUtc > DuracionBloqueo)
                {
                    registro.Fallidos = 0;
                    registro.BloqueadoHastaUtc = null;
                }

                registro.Fallidos++;
                registro.UltimoFalloUtc = ahora;

                if (registro.Fallidos >= MaximoIntentos)
                {
                    registro.BloqueadoHastaUtc = ahora.Add(DuracionBloqueo);
                    return 0;
                }

                return MaximoIntentos - registro.Fallidos;
            }
        }

        public void RegistrarExito(string username)
        {
            _registros.TryRemove(Clave(username), out _);
        }
    }
}

using Data;
using Domain.Model;
using DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Services
{
    // Carga datos de prueba representativos cuando la base está vacía (sin usuarios).
    // Las fechas son relativas a hoy para que los estados (demoras, bajas, cuotas) tengan sentido siempre.
    //
    // Usuarios creados (usuario / contraseña):
    //   admin / Admin123!                 (rol Admin)
    //   lgomez, mdiaz, cruiz / Profesor123!   (rol Profesor)
    //   socio1 ... socio8 / Socio123!     (rol Socio; socio8 está dado de baja)
    public static class DatosDePrueba
    {
        public const string PasswordAdmin = "Admin123!";
        public const string PasswordProfesor = "Profesor123!";
        public const string PasswordSocio = "Socio123!";

        public static async Task CargarAsync(GimnasioContext context)
        {
            if (await context.Usuarios.AnyAsync())
            {
                return;
            }

            var hoy = DateTime.Today;

            // ---------- Actividades y planes ----------
            var musculacion = new Actividad { Tipo = "Musculación", Descripcion = "Entrenamiento con pesas y máquinas" };
            var spinning = new Actividad { Tipo = "Spinning", Descripcion = "Ciclismo indoor con música" };
            var yoga = new Actividad { Tipo = "Yoga", Descripcion = "Elongación, respiración y equilibrio" };
            var funcional = new Actividad { Tipo = "Funcional", Descripcion = "Circuitos con peso corporal" };
            var boxeo = new Actividad { Tipo = "Boxeo", Descripcion = "Técnica y acondicionamiento de boxeo" };

            var planBasico = new Plan
            {
                Nombre = "Básico", Tipo = "Mensual", Precio = 15000m,
                Descripcion = "Acceso a la sala de musculación",
                Actividades = new List<Actividad> { musculacion }
            };
            var planEstandar = new Plan
            {
                Nombre = "Estándar", Tipo = "Mensual", Precio = 22000m,
                Descripcion = "Musculación más clases grupales",
                Actividades = new List<Actividad> { musculacion, funcional, spinning }
            };
            var planPaseLibre = new Plan
            {
                Nombre = "Pase Libre", Tipo = "Mensual", Precio = 30000m,
                Descripcion = "Acceso ilimitado a todas las actividades",
                Actividades = new List<Actividad> { musculacion, spinning, yoga, funcional, boxeo }
            };

            context.Planes.AddRange(planBasico, planEstandar, planPaseLibre);

            // ---------- Administrador ----------
            context.Administradores.Add(new Administrador
            {
                Dni = "20111222", Nombre = "Ana", Apellido = "Pérez", Telefono = "3415550001",
                FechaNac = new DateTime(1985, 3, 14),
                Usuario = NuevoUsuario("admin", "admin@gimnasio.com", PasswordAdmin, Roles.Admin)
            });

            // ---------- Profesores con su histórico de sueldos ----------
            var lgomez = NuevoProfesor("27333444", "Laura", "Gómez", "Instructora de musculación", new DateTime(1990, 7, 2), "lgomez");
            var mdiaz = NuevoProfesor("25444555", "Martín", "Díaz", "Coordinador de clases grupales", new DateTime(1987, 11, 20), "mdiaz");
            var cruiz = NuevoProfesor("30555666", "Carla", "Ruiz", "Instructora de yoga", new DateTime(1994, 1, 9), "cruiz");

            context.Profesores.AddRange(lgomez, mdiaz, cruiz);

            context.HistoricoSueldos.AddRange(
                NuevoSueldo(lgomez, hoy.AddMonths(-14), 480000m),
                NuevoSueldo(lgomez, hoy.AddMonths(-8), 560000m),
                NuevoSueldo(lgomez, hoy.AddMonths(-2), 650000m),
                NuevoSueldo(mdiaz, hoy.AddMonths(-12), 600000m),
                NuevoSueldo(mdiaz, hoy.AddMonths(-3), 720000m),
                NuevoSueldo(cruiz, hoy.AddMonths(-6), 450000m));

            // ---------- Turnos ----------
            var lunesManiana = NuevoTurno("Lunes", 8, 9);
            var lunesTarde = NuevoTurno("Lunes", 18, 19);
            var martesNoche = NuevoTurno("Martes", 19, 20);
            var miercolesManiana = NuevoTurno("Miércoles", 8, 9);
            var juevesNoche = NuevoTurno("Jueves", 19, 20);
            var viernesTarde = NuevoTurno("Viernes", 18, 19);
            var sabadoManiana = NuevoTurno("Sábado", 10, 11);

            context.Turnos.AddRange(lunesManiana, lunesTarde, martesNoche, miercolesManiana, juevesNoche, viernesTarde, sabadoManiana);

            // ---------- Clases (una queda llena para probar el control de cupo) ----------
            var claseMusculacion = new Clase { Actividad = musculacion, Profesor = lgomez, Turno = lunesManiana, Cupo = 15 };
            var claseSpinning = new Clase { Actividad = spinning, Profesor = mdiaz, Turno = lunesTarde, Cupo = 3 };
            var claseYoga = new Clase { Actividad = yoga, Profesor = cruiz, Turno = miercolesManiana, Cupo = 10 };
            var claseFuncional = new Clase { Actividad = funcional, Profesor = mdiaz, Turno = martesNoche, Cupo = 12 };
            var claseBoxeo = new Clase { Actividad = boxeo, Profesor = lgomez, Turno = juevesNoche, Cupo = 8 };
            var claseYogaSabado = new Clase { Actividad = yoga, Profesor = cruiz, Turno = sabadoManiana, Cupo = 4 };

            context.Clases.AddRange(claseMusculacion, claseSpinning, claseYoga, claseFuncional, claseBoxeo, claseYogaSabado);

            // ---------- Socios (socio8 dado de baja) ----------
            var socios = new List<Socio>
            {
                NuevoSocio(1, "38111001", "Juan", "Martínez", planPaseLibre, hoy.AddMonths(-10)),
                NuevoSocio(2, "39222002", "Sofía", "López", planEstandar, hoy.AddMonths(-8)),
                NuevoSocio(3, "40333003", "Lucas", "Fernández", planBasico, hoy.AddMonths(-6)),
                NuevoSocio(4, "41444004", "Valentina", "García", planPaseLibre, hoy.AddMonths(-5)),
                NuevoSocio(5, "37555005", "Tomás", "Romero", planEstandar, hoy.AddMonths(-4)),
                NuevoSocio(6, "42666006", "Camila", "Sosa", planPaseLibre, hoy.AddMonths(-3)),
                NuevoSocio(7, "36777007", "Nicolás", "Álvarez", planBasico, hoy.AddMonths(-2)),
                NuevoSocio(8, "35888008", "Martina", "Torres", planEstandar, hoy.AddMonths(-12), fechaBaja: hoy.AddMonths(-1))
            };

            context.Socios.AddRange(socios);

            // ---------- Inscripciones (spinning queda 3/3, sin cupo) ----------
            var inscripciones = new (Socio socio, Clase clase)[]
            {
                (socios[0], claseMusculacion), (socios[0], claseSpinning), (socios[0], claseBoxeo),
                (socios[1], claseSpinning), (socios[1], claseFuncional),
                (socios[2], claseMusculacion),
                (socios[3], claseSpinning), (socios[3], claseYoga), (socios[3], claseYogaSabado),
                (socios[4], claseFuncional), (socios[4], claseMusculacion),
                (socios[5], claseYoga), (socios[5], claseYogaSabado), (socios[5], claseBoxeo),
                (socios[6], claseMusculacion)
            };

            context.Inscripciones.AddRange(inscripciones.Select((x, i) => new Inscripcion
            {
                Socio = x.socio,
                Clase = x.clase,
                FechaInscripcion = hoy.AddDays(-30 + i)
            }));

            // ---------- Cuotas de los últimos 3 meses (con matrícula en la primera de cada socio) ----------
            foreach (var socio in socios.Where(s => s.FechaBaja == null))
            {
                for (int mesesAtras = 2; mesesAtras >= 0; mesesAtras--)
                {
                    // El último socio activo debe la cuota del mes actual
                    if (mesesAtras == 0 && socio == socios[6])
                    {
                        continue;
                    }

                    var mes = hoy.AddMonths(-mesesAtras);
                    var detalles = new List<DetalleCuota>
                    {
                        new DetalleCuota { Concepto = $"Mensualidad plan {socio.Plan!.Nombre}", Subtotal = socio.Plan.Precio, Monto = socio.Plan.Precio }
                    };

                    if (mesesAtras == 2)
                    {
                        detalles.Add(new DetalleCuota { Concepto = "Matrícula anual", Subtotal = 5000m, Monto = 5000m });
                    }

                    context.Cuotas.Add(new Cuota
                    {
                        Socio = socio,
                        MesAnio = mes.Year * 100 + mes.Month,
                        FechaPago = new DateTime(mes.Year, mes.Month, Math.Min(10, DateTime.DaysInMonth(mes.Year, mes.Month))),
                        Valor = detalles.Sum(d => d.Monto),
                        Detalles = detalles
                    });
                }
            }

            // ---------- Máquinas, materiales y mantenimientos (los 4 estados del reporte) ----------
            var cinta = new Maquina { Nombre = "Cinta de correr 1", Descripcion = "Cinta motorizada 3HP", Tipo = "Cardio", Estado = "Operativa" };
            var bici = new Maquina { Nombre = "Bicicleta de spinning 4", Descripcion = "Bicicleta con volante de inercia", Tipo = "Cardio", Estado = "En mantenimiento" };
            var prensa = new Maquina { Nombre = "Prensa 45°", Descripcion = "Prensa de piernas con discos", Tipo = "Fuerza", Estado = "En mantenimiento" };
            var rack = new Maquina { Nombre = "Rack de sentadillas", Descripcion = "Rack con barra olímpica", Tipo = "Fuerza", Estado = "Operativa" };
            var remo = new Maquina { Nombre = "Remo ergómetro", Descripcion = "Remo de aire", Tipo = "Cardio", Estado = "Operativa" };
            var eliptica = new Maquina { Nombre = "Elíptica 2", Descripcion = "Elíptica con 16 niveles", Tipo = "Cardio", Estado = "Fuera de servicio" };

            context.Maquinas.AddRange(cinta, bici, prensa, rack, remo, eliptica);

            context.Materiales.AddRange(
                new Material { Descripcion = "Mancuernas 5 kg (par)", Stock = 10 },
                new Material { Descripcion = "Mancuernas 10 kg (par)", Stock = 8 },
                new Material { Descripcion = "Colchonetas de yoga", Stock = 20 },
                new Material { Descripcion = "Bandas elásticas", Stock = 15 },
                new Material { Descripcion = "Guantes de boxeo (par)", Stock = 12 },
                new Material { Descripcion = "Sogas de saltar", Stock = 0 });

            context.Mantenimientos.AddRange(
                // En curso
                new Mantenimiento { Maquina = bici, Descripcion = "Cambio de correa", FechaInicio = hoy.AddDays(-2), FechaFinEsperada = hoy.AddDays(3) },
                // Demorado
                new Mantenimiento { Maquina = prensa, Descripcion = "Reparación de rodamientos", FechaInicio = hoy.AddDays(-15), FechaFinEsperada = hoy.AddDays(-4) },
                // Finalizado en término
                new Mantenimiento { Maquina = cinta, Descripcion = "Lubricación de banda", FechaInicio = hoy.AddDays(-40), FechaFinEsperada = hoy.AddDays(-38), FechaFinReal = hoy.AddDays(-38) },
                // Finalizado con demora
                new Mantenimiento { Maquina = remo, Descripcion = "Cambio de cadena", FechaInicio = hoy.AddDays(-60), FechaFinEsperada = hoy.AddDays(-55), FechaFinReal = hoy.AddDays(-50) },
                // Sin fecha de fin: la elíptica está fuera de servicio y su reparación está demorada
                new Mantenimiento { Maquina = eliptica, Descripcion = "Falla en el panel electrónico", FechaInicio = hoy.AddDays(-25), FechaFinEsperada = hoy.AddDays(-10) });

            await context.SaveChangesAsync();
        }

        private static Usuario NuevoUsuario(string username, string email, string password, string rol)
        {
            return new Usuario
            {
                Username = username,
                Email = email,
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(password),
                FechaCreacion = DateTime.Now,
                Activo = true,
                Rol = rol
            };
        }

        private static Profesor NuevoProfesor(string dni, string nombre, string apellido, string cargo, DateTime fechaNac, string username)
        {
            return new Profesor
            {
                Dni = dni, Nombre = nombre, Apellido = apellido, Cargo = cargo,
                Telefono = "34155" + dni[^5..], FechaNac = fechaNac,
                Usuario = NuevoUsuario(username, $"{username}@gimnasio.com", PasswordProfesor, Roles.Profesor)
            };
        }

        private static Socio NuevoSocio(int numero, string dni, string nombre, string apellido, Plan plan, DateTime fechaAlta, DateTime? fechaBaja = null)
        {
            return new Socio
            {
                Dni = dni, Nombre = nombre, Apellido = apellido,
                Telefono = "34166" + dni[^5..],
                FechaNac = new DateTime(1990 + numero, numero, 10 + numero),
                FechaAlta = fechaAlta, FechaBaja = fechaBaja, Plan = plan,
                Usuario = NuevoUsuario($"socio{numero}", $"socio{numero}@mail.com", PasswordSocio, Roles.Socio)
            };
        }

        private static Turno NuevoTurno(string dia, int horaDesde, int horaHasta)
        {
            return new Turno
            {
                DiaSemana = dia,
                HoraDesde = TimeSpan.FromHours(horaDesde),
                HoraHasta = TimeSpan.FromHours(horaHasta)
            };
        }

        private static HistoricoSueldo NuevoSueldo(Profesor profesor, DateTime desde, decimal valor)
        {
            return new HistoricoSueldo
            {
                Profesor = profesor,
                FechaDesde = new DateTime(desde.Year, desde.Month, 1),
                Valor = valor
            };
        }
    }
}

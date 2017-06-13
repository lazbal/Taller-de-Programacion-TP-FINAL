using System;
using CapaEntidad;
using System.Linq;
using System.Collections.Generic;

namespace CapaDatos
{
	class Program
	{
		public static void Main (string[] args)
		{

			CapaDatosFachada iFachada = new CapaDatosFachada();

            #region Creaciones
            //Campaña campaña1 = new Campaña(); campaña1.TiempoXImagen = new TimeSpan(20);
            //campaña1.AgregarImagen(@"C:\Users\Public\Pictures\Sample Pictures\Koala.jpg");
            //Banner banner1 = new BannerEstatico("holis");
            ////			Banner banner1 = new RSSFeed("google.com");
            //Horario horario1 = new Horario(DayOfWeek.Friday, new TimeSpan(20), new TimeSpan(40));
            //ElementoCarteleria elemento1 = new ElementoCarteleria();
            //elemento1.Nombre = "Elemento 1";
            //elemento1.Descripcion = "Desc Elem 1";
            //elemento1.FechaInicio = new DateTime(1993, 12, 22);
            //elemento1.FechaFin = new DateTime(2006, 8, 11);
            //elemento1.Frecuencia.Add(horario1);
            //elemento1.Campaña = campaña1;
            //elemento1.Banner = banner1;

            //iFachada.Create(elemento1);
            #endregion

            #region Actualizaciones
            //ElementoCarteleria elementoActualizado = iFachada.GetByIdElementoCarteleria(3);
            //elementoActualizado.Campaña.ListaImagenes.Clear();
            //elementoActualizado.Campaña.AgregarImagen(@"C:\Users\Public\Pictures\Sample Pictures\Koala.jpg");

            //iFachada.Update(elementoActualizado);

            ElementoCarteleria elementoActualizado = iFachada.GetByIdElementoCarteleria(3);
            elementoActualizado.Frecuencia.Clear();

            iFachada.Update(elementoActualizado);
            #endregion

            #region Eliminaciones
            //iFachada.DeleteElementoCarteleria(1);
            //iFachada.DeleteCampaña(1);
            #endregion

            #region Métodos del Día
            #region Campaña
            #endregion
            #region Banner Estatico
            #endregion
            #region RSSFeed
            #endregion
            #endregion

            #region Getters
            #endregion

            #region Buscadores
            #endregion

            Console.WriteLine ("¿Será verdura el apio?");
            Console.ReadKey();
		}
	}
}

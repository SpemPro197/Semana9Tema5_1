using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Semana9Tema4o5
{
    internal class Program
    {
        static int max_emp = 50;
        static string[] nombres = new string[max_emp];
        static string[] correo = new string[max_emp];
        static int cant_emp = 0;

        static public void Titulo()
        {
            Console.WriteLine("********************");
            Console.WriteLine("SISTEMA DE EMPLEADOS");
            Console.WriteLine("********************") ;
        }

        static public void Registro_empleados()
        {
            Console.WriteLine("********** Registrar Empleado **********");
            Console.WriteLine("");
            if (cant_emp >= max_emp)
            {
                Console.WriteLine("Alcanzo la capacidad maxima de datos.");
                return;
            }

       

            Console.WriteLine("Ingresar nombres y apellidos: ");
            string nombres_emp = Console.ReadLine()?.Trim();

            if (string.IsNullOrEmpty(nombres_emp))
            {
                Console.WriteLine("Error, El nombre no puede estar vacio. ");
                return;
            }

            Console.WriteLine("Ingrese la direccion de su correo electronico, va a usar 1. [gmail], 2.[hotmail], o 3.[upn.edu.pe]");
            int direccion_1 = int.Parse(Console.ReadLine());

            string direccion_final = "";

            if (direccion_1 == 1)
            {
                direccion_final = "gmail.com";
            }

            if (direccion_1 == 2)
            {
                direccion_final = "hotmail.com";
            }

            if (direccion_1 == 3)
            {
                direccion_final = "upn.edu.pe";
            }

            string nombres_Mayus = nombres_emp.ToUpper();
            string[] partes = nombres_Mayus.Split(' ');
            string primer_nombre = "";

            if (partes.Length > 0)
            {
                primer_nombre = partes[0];
            }
            else
            {
                primer_nombre = "usuario";
            }

            


            string correo_emp = $"{primer_nombre.ToLower()}.{partes[1].ToLower()}@{direccion_final}";

            nombres[cant_emp] = nombres_Mayus;
            correo[cant_emp] = correo_emp;
            cant_emp++;

            Console.WriteLine("");
            Console.WriteLine("****************************************");
        }

        static public void Buscar_Empleado()
        {
            Console.WriteLine("********** Buscar empleado **********");
            Console.WriteLine("");

            if (cant_emp == 0)
            {
                Console.WriteLine("No hay registro de empleados");
                return;
            }
            Console.Write("Ingresr nombre o apellido a buscar: ");
            string buscar = Console.ReadLine()?.Trim().ToUpper();
            if (string.IsNullOrEmpty(buscar))
            {
                return;
            }
            bool encontrado = false;
            for (int i = 0; i< cant_emp; i++)
            {
                if (nombres[i].Contains(buscar))
                {
                    Console.WriteLine("Encontrado, Nombres: [" + nombres[i] + "], Correo: [" + correo[i] + "]");
                    encontrado = true;

                }

                if (!encontrado)
                {
                    Console.WriteLine("No se encuentra al coincidencias en empleado.");

                }


            }
            Console.WriteLine("");
            Console.WriteLine("****************************************");

        }

        static public void Ordenamiento()
        {
            Console.WriteLine("********** Ordenando..... ********");
            Console.WriteLine("* ... *");
            Console.WriteLine("* ...... *");
            Console.WriteLine("* ......... *");
            Console.WriteLine("* Listo *");

            if(cant_emp <= 1)
            {
                Console.WriteLine("No hay suficientes registros para ordenar.");
                return;
            }

            for(int i = 0; i < cant_emp - 1; i++)
            {
                for(int j = 0; j < cant_emp - 1 - i; j++)
                {
                    if (string.Compare(nombres[j], nombres[j + 1]) > 0)
                    {
                        string temp_nom = nombres[j];
                        nombres[j] = nombres[j + 1];
                        nombres[j + 1] = temp_nom;
                        string temp_correo = correo[j];
                        correo[j] = correo[j + 1];
                        correo[j + 1] = temp_correo;
                    }

                }
            }

            Console.WriteLine("Se ha ordenado alfabeticamente.");
        }

        static public void mostrar()
        {
            Console.WriteLine("********** Listado de empleados **********");
            
            if (cant_emp == 0)
            {
                Console.WriteLine("No hay registror por mostrar");
                return;
            }

            Console.WriteLine(" Nombres y apellidos \t\t Correo");
            for (int i = 0; i < cant_emp; i++)
            {
                Console.WriteLine(nombres[i] + "\t\t" + correo[i]);

            }

            Console.WriteLine("");
            Console.WriteLine("******************************************");

        }

        static public void Guardar_datos_archivo()
        {

            Console.WriteLine("*********** Guardado de datos ***********");
            
            if (cant_emp == 0)
            {
                Console.WriteLine("No hay suficientes empleados para guardar datos.");
                return;
            }

            using (StreamWriter escribir = new StreamWriter("Empleados.txt"))
            {
                for (int i = 0; i < cant_emp; i++)
                {
                    escribir.WriteLine(nombres[i] + "," + correo[i]);
                }
            }

            Console.WriteLine(" * Datos guardados exitosamente. *");
            Console.WriteLine(" Cantidad de empleados guardados: [" + cant_emp + "]");



            Console.WriteLine("****************************************");
        }

        static public void Leer_datos_archivo()
        {
            Console.WriteLine("********** Leer datos guardados **********");

            if (!File.Exists("Empleados.txt"))
            {
                Console.WriteLine("No existe el archivo de empleados.");
                return;
            }

            int num_linea = 0;
            using (StreamReader lector = new StreamReader("Empleados.txt"))
            {
                string linea;
                while((linea = lector.ReadLine()) != null)
                {
                    string[] partes = linea.Split(',');
                    if(partes.Length == 2)
                    {
                        Console.WriteLine(num_linea + ".-" + "nombres:" + partes[0] + "Correo: " + partes[1]);

                    }

                }




            }
            
            Console.WriteLine("******************************************");



        }

        static public void Cargar_datos_archivo()
        {
            if (!File.Exists("Empleados.txt"))
            {
                Console.WriteLine("No existe el archvo de empleados");
                return;
            }

            string[] lineas = File.ReadAllLines("Empleados.txt");

            for(int i = 0; i < lineas.Length && i < max_emp; i++)
            {
                string[] partes = lineas[i].Split(',');
                if (partes.Length == 2)
                {
                    nombres[i] = partes[0];
                    correo[i] = partes[1];
                    cant_emp++;

                }
            }

        }


        static void Main(string[] args)
        {
            int opc = 0;


            Titulo();
            while (opc != 5) 
            {
                
                Console.WriteLine("[1] Registrar empleado");
                Console.WriteLine("[2] Buscar empleado");
                Console.WriteLine("[3] Ordenar alfabeticamente (A-Z)");
                Console.WriteLine("[4] Mostrar empleados");
                Console.WriteLine("[5] Guardar los datos actuales");
                Console.WriteLine("[6] Leer los datos del archivo");
                Console.WriteLine("[7] Cargar los datos del archivo");
                Console.WriteLine("[8] Salir");
                Console.WriteLine("Ingresar opcion: ");

                
                if(!int.TryParse(Console.ReadLine(), out opc))
                {
                    Console.WriteLine("Ingrese un valor numerico");
                    continue;
                }


                switch (opc)
                {
                    case 1:
                        Registro_empleados();
                        break;

                    case 2:
                        Buscar_Empleado();
                        break;

                    case 3:
                        Ordenamiento();
                        break;

                    case 4:
                        mostrar();
                        break;

                    case 5:
                        Guardar_datos_archivo();
                        break;

                    case 6:
                        Leer_datos_archivo();
                        break;

                    case 7:
                        Cargar_datos_archivo();
                        break;

                    case 8:
                        Console.WriteLine("Gracias por usar el sistema, ¡hasta pronto!");
                        break;

                    default:
                        Console.WriteLine("Opcion incorrecta, por favor ingrese un valor numero [1 - 5]. ");
                        break;

                    
                        
                }
              

            }
        }
    }
}

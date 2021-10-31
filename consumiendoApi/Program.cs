using System;
using HTTPupt;
using System.Threading;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace consumiendoApi
{
    class Program
    {
        //API DE USUARIOS RANDOM
        static PeticionHTTP peticion = new PeticionHTTP("https://randomuser.me");        

        static async Task<usuario> consumirApiUsuario(int numApi)
        {
            mensajeInicio(numApi);
            string url = "api/?results=" + numApi;
            peticion.PedirComunicacion(url, MetodoHTTP.GET, TipoContenido.JSON);
            string respuesta = peticion.ObtenerJson();
            Thread.Sleep(2000);                        
            Console.WriteLine("Resultado:");
            usuario user = JsonConvertidor.Json_Objeto<usuario>(respuesta);
            return user;                       
        }
        public static async Task consumoApi1Async(object objeto)
        {
            int numApi = (int)objeto;
            usuario user = await consumirApiUsuario(numApi);
            foreach (results dato in user.results)
            {
                Console.WriteLine("----------------------------------------------------------------");
                Console.WriteLine(
               $"Nombre: {dato.name.title} {dato.name.first} {dato.name.last}\n" +
               $"Genero: {dato.gender}\n" +
               $"correo: {dato.email}\n" +
               $"Nombre de usuario: {dato.login.username}\n" +
               $"Edad: {dato.dob.age}\n" +
               $"Numero Telefono: {dato.phone}\n"
               );
                Console.WriteLine("----------------------------------------------------------------");
            }
            mensajeTermino(numApi);
        }
        //public static void consumoApi2(object objeto)
        //{
        //    int numApi = (int)objeto;
        //    usuario user = consumirApiUsuario(numApi);
        //    foreach (results dato in user.results)
        //    {
        //        Console.WriteLine("----------------------------------------------------------------");
        //        Console.WriteLine(
        //       $"Nombre: {dato.name.title} {dato.name.first} {dato.name.last}\n" +
        //       $"Genero: {dato.gender}\n" +
        //       $"correo: {dato.email}\n" +
        //       $"Nombre de usuario: {dato.login.username}\n" +
        //       $"Edad: {dato.dob.age}\n" +
        //       $"Numero Telefono: {dato.phone}\n"
        //       );
        //        Console.WriteLine("----------------------------------------------------------------");
        //    }
        //    mensajeTermino(numApi);
        //}
        //public static void consumoApi3(object objeto)
        //{
        //    int numApi = (int)objeto;
        //    usuario user = consumirApiUsuario(numApi);
        //    foreach (results dato in user.results)
        //    {
        //        Console.WriteLine("----------------------------------------------------------------");
        //        Console.WriteLine(
        //       $"Nombre: {dato.name.title} {dato.name.first} {dato.name.last}\n" +
        //       $"Genero: {dato.gender}\n" +
        //       $"correo: {dato.email}\n" +
        //       $"Nombre de usuario: {dato.login.username}\n" +
        //       $"Edad: {dato.dob.age}\n" +
        //       $"Numero Telefono: {dato.phone}\n"
        //       );
        //        Console.WriteLine("----------------------------------------------------------------");
        //    }
        //    mensajeTermino(numApi);
        //}
        //public static void consumoApi4(object objeto)
        //{
        //    int numApi = (int)objeto;
        //    usuario user = consumirApiUsuario(numApi);
        //    foreach (results dato in user.results)
        //    {
        //        Console.WriteLine("----------------------------------------------------------------");
        //        Console.WriteLine(
        //       $"Nombre: {dato.name.title} {dato.name.first} {dato.name.last}\n" +
        //       $"Genero: {dato.gender}\n" +
        //       $"correo: {dato.email}\n" +
        //       $"Nombre de usuario: {dato.login.username}\n" +
        //       $"Edad: {dato.dob.age}\n" +
        //       $"Numero Telefono: {dato.phone}\n"
        //       );
        //        Console.WriteLine("----------------------------------------------------------------");
        //    }
        //    mensajeTermino(numApi);
        //}

        static async Task Main(string[] args)
        {

            tituloConsola();
            //API 1            
            await consumoApi1Async(1);
            Thread.Sleep(5000); //Esperar 5 seg.



            //ThreadPool

            ////API 1
            //ThreadPool.QueueUserWorkItem(consumoApi1, 1);
            //Thread.Sleep(5000); //Esperar 5 seg.

            ////API 2 
            //ThreadPool.QueueUserWorkItem(consumoApi2, 2);
            //Thread.Sleep(5000); //Esperar 5 seg.

            ////API 3 
            //ThreadPool.QueueUserWorkItem(consumoApi2, 3);
            //Thread.Sleep(5000); //Esperar 5 seg.

            ////API 4 
            //ThreadPool.QueueUserWorkItem(consumoApi2, 4);
            //Thread.Sleep(5000); //Esperar 5 seg.

            Console.WriteLine("FIN DEL PROGRAMA");


            Console.ReadLine();        
        }
        public static void tituloConsola()
        {
            Console.WriteLine("--------------------------");
            Console.WriteLine("| ThreadPool y promesas |");
            Console.WriteLine("--------------------------");
        }
        public static void mensajeInicio(int numApi)
        {
            Console.WriteLine("---------------------------------------------------------------");
            Console.WriteLine("| INICIO: Consumo de la api " + numApi + " en el thread numero: " + Thread.CurrentThread.ManagedThreadId + ". |");
            Console.WriteLine("---------------------------------------------------------------");
        }
        public static void mensajeTermino(int numApi)
        {
            Console.WriteLine("---------------------------------------------------------------");
            Console.WriteLine("| TERMINO: El thread numero: " + Thread.CurrentThread.ManagedThreadId + " ah terminado el consumo de la api " + numApi + ". |");
            Console.WriteLine("----------------------------------------------------------------");
        }
    }

    public class usuario
    {
        public List<results> results { get; set; }        
    }

    public class results
    {
        public string gender { get; set; }
        public name name { get; set; }
        public string email { get; set; }
        public login login { get; set; }
        public dob dob { get; set; }        
        public string phone { get; set; }
    }

    public class name
    {
        public string title { get; set; }
        public string first { get; set; }
        public string last { get; set; }
    }

    public class login
    {        
        public string username { get; set; }        
    }

    public class dob
    {        
        public int age { get; set; }
    }    
}

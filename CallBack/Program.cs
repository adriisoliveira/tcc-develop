using System;
using System.Diagnostics;
using System.Net;
using System.Configuration;
using System.IO;
using System.Text;
namespace CallBack
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            ReturnListener();
        }

        public static void ReturnListener()
        {
            HttpListener listener = null;
            try
            {
                 
                listener = new HttpListener();
                listener.Prefixes.Add("http://localhost:5000/teste/");
                try
                {
                    listener.Start();
                }
                catch (HttpListenerException hlex)
                {
                    return;
                }
                while (listener.IsListening)
                {
                    Console.WriteLine("wating request...");
                    HttpListenerContext context = listener.GetContext();
                    context.Response.StatusCode = (int)HttpStatusCode.OK;
                    Console.WriteLine("codigo " + context.Response.StatusCode);
                    listener.Close();
                    Console.ReadKey();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}

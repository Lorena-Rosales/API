using API;
using System.Net;
using System.Text.Json;

namespace WinFormsAPI
{

    public class Program
    {
        static async Task Main(string[] args)
        {
            using (var cliente = new HttpClient())  // Abro el puerto
            {
                var endPoint = new Uri("https://api.disneyapi.dev/character"); // Se establece la API que se va a consultar

                var response = cliente.GetAsync(endPoint).Result;   // Hace el GET (petición a la API - API request). Se usa el .Result porque la función es asíncrona, para esperar y continuar con la aplicación

                var json = response.Content.ReadAsStringAsync().Result; //El json hace la lectura como cadena de la respuesta

                Console.WriteLine("-------------------GET DE API DE DISNEY---------------------------\n");
                Console.WriteLine(json);
            }

            using (var cliente = new HttpClient())  // Abro el puerto
            {
                var endPoint = new Uri("https://zenquotes.io/api/random "); // Se establece la API que se va a consultar

                var response = cliente.GetAsync(endPoint).Result;   // Hace el GET (petición a la API - API request). Se usa el .Result porque la función es asíncrona, para esperar y continuar con la aplicación

                var json = response.Content.ReadAsStringAsync().Result; //El json hace la lectura como cadena de la respuesta

                Console.WriteLine("\n\n");
                Console.WriteLine("-------------------GET DE API DE FRASES ALEATORIAS---------------------------\n");
                Console.WriteLine(json);
            }

            using (var cliente = new HttpClient())  // Abro el puerto
            {
                var endPoint = new Uri("https://jsonplaceholder.typicode.com/posts "); // Se establece la API que se va a consultar

                var response = cliente.GetAsync(endPoint).Result;   // Hace el GET (petición a la API - API request). Se usa el .Result porque la función es asíncrona, para esperar y continuar con la aplicación

                var json = response.Content.ReadAsStringAsync().Result; //El json hace la lectura como cadena de la respuesta

                Post post = new Post()
                {
                    userId = 5,
                    body = "La felicidad puede ser encontrada en los momnetos mas oscuros, solo no olvides encender la luz",
                    title = "Harry Potter y el Prisionero de Azkaban"
                };

                var data = JsonSerializer.Serialize<Post>(post);
                HttpContent content = new StringContent(data, System.Text.Encoding.UTF8, "application/json");
                var httpResponse = await cliente.PostAsync(endPoint, content);

                if (httpResponse.IsSuccessStatusCode)
                {
                    var result = await httpResponse.Content.ReadAsStringAsync();

                    var postResult = JsonSerializer.Deserialize<Post>(result);

                    Console.WriteLine("\n\n-------------------POST DE API---------------------------\n");
                    Console.WriteLine("Datos del post:\n { \n\tuserId: "+ postResult.userId + ",\n\tbody: " + postResult.body + ",\n\ttitle: " + postResult.title + "\n};");
                    Console.WriteLine("\nPost exitoso con Id: " + postResult.id);


                }

                
            }
        }
    }
}


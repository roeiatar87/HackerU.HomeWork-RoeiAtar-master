namespace Demos.HackerU.Client
{
    internal class Program
    {


        static async Task Main(string[] args)
        {
            //HttpRequestor httpRequestor = new HttpRequestor();
            //var resp = await httpRequestor.GetItemServerDataAsync("todos", 5);
            //Console.WriteLine(resp);
            //Console.WriteLine("____________________");
            //resp = await httpRequestor.GetItemServerDataAsync("posts", 5);
            //Console.WriteLine(resp);
            //Console.WriteLine("____________________");
            //await httpRequestor.PostItemToServerAsync(
            // new
            // {
            //     userId = 77,
            //     id = 1,
            //     title = "write code sample",
            //     completed = false
            // });


            //Console.WriteLine("Press Any Key - after server http://localhost:7011 is up and running....");
            //Console.ReadKey();

            TodosAPI api = new TodosAPI();
            await api.PostItemToServerAsync("ABAGADAVAZA");
            Console.ReadKey();

        }


    }
}
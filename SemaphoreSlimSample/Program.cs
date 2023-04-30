class Program
{
    static HttpClient client = new HttpClient();
    static SemaphoreSlim slim = new(3);

    static async Task Main(string[] args)
    {
        var urls = new List<string>()
        {
    "https://www.ietf.org/rfc/rfc791.txt",
    "https://www.ietf.org/rfc/rfc792.txt",
    "https://www.ietf.org/rfc/rfc793.txt",
    "https://www.ietf.org/rfc/rfc794.txt",
    "https://www.ietf.org/rfc/rfc795.txt",
    "https://www.ietf.org/rfc/rfc796.txt",
    "https://www.ietf.org/rfc/rfc797.txt",
    "https://www.ietf.org/rfc/rfc798.txt",
    "https://www.ietf.org/rfc/rfc799.txt",
    "https://www.ietf.org/rfc/rfc800.txt",

        };

        var task = new List<Task>();

        foreach (var url in urls)
        {
            task.Add(DownloadFileAsync(url));
        }

        await Task.WhenAll(task);

        Console.WriteLine("Completed downloading all files");
    }

    static async Task DownloadFileAsync(string url)
    {
        await slim.WaitAsync();

        try
        {
            Console.WriteLine($"Downloading file {url}");

            var responser = await client.GetAsync(url);

            responser.EnsureSuccessStatusCode();

            using (var stream = await responser.Content.ReadAsStreamAsync())
            using (var fileStream = File.Create(Path.GetFileName(url)))
            {
                await stream.CopyToAsync(fileStream);
            }

            Console.WriteLine($"Completed download file {url}");
        }
        finally
        {
            slim.Release();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;

public class Servers
{
    private static readonly Servers instance = new Servers();
    private static readonly object syncRoot = new object();

    private HashSet<string> _servers = new HashSet<string>();

    private Servers() { }

    public static Servers Instance => instance;

    public bool AddServer(string serverUrl)
    {
        if (serverUrl.StartsWith("http://") || serverUrl.StartsWith("https://"))
        {
            lock (syncRoot)
            {
                if (_servers.Add(serverUrl))
                {
                    return true;
                }
            }
        }
        return false;
    }

    public List<string> GetHttpServers()
    {
        lock (syncRoot)
        {
            return _servers.Where(url => url.StartsWith("http://")).ToList();
        }
    }

    public List<string> GetHttpsServers()
    {
        lock (syncRoot)
        {
            return _servers.Where(url => url.StartsWith("https://")).ToList();
        }
    }
}

public class Program
{
    public static void Main()
    {
        var servers = Servers.Instance;
        Console.WriteLine(servers.AddServer("http://guess/word/com"));
        Console.WriteLine(servers.AddServer("https://google.com"));
        Console.WriteLine(servers.AddServer("http://Yandex.com"));
        Console.WriteLine(servers.AddServer("hp://Yandex.com"));
        Console.WriteLine(servers.AddServer("https://ci.nsu.com"));
        Console.WriteLine(servers.AddServer("https://ci.nsu.com"));
        Console.WriteLine(servers.AddServer("http://guess/word/com"));

        Console.WriteLine("HTTP servers: " + string.Join(", ", servers.GetHttpServers()));
        Console.WriteLine("HTTPS servers: " + string.Join(", ", servers.GetHttpsServers()));
    }
}

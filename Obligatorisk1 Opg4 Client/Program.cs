using System.Net.Sockets;

Console.WriteLine("Client");

TcpClient socket = new TcpClient("127.0.0.1", 7);
NetworkStream ns = socket.GetStream();

StreamReader reader = new StreamReader(ns);
StreamWriter writer = new StreamWriter(ns);

bool keepSending = true;

while (keepSending)
{
    Console.Write("Enter message ('stop' to exit): ");
    string message = Console.ReadLine();

    if (message.ToLower() == "stop")
    {
        keepSending = false;
        continue;
    }

    writer.WriteLine(message);
    writer.Flush();

    string response = reader.ReadLine();
    if (response != null)
    {
        Console.WriteLine($"Server: {response}");
    }
    else
    {
        Console.WriteLine("No response received.");
    }

    if (!socket.Connected)
    {
        Console.WriteLine("Connection closed");
        break;
    }
}

socket.Close();


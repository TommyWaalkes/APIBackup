using System;
using System.IO;
using System.Net;

namespace API_Backup
{
    class Program
    {
        static void Main(string[] args)
        {
            string APIText = "";

            while (true)
            {
                try
                {
                    Console.WriteLine("Please paste in the api url you wish to call");
                    string Url = Console.ReadLine().Trim();
                    HttpWebRequest request = WebRequest.CreateHttp(Url);
                    HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                    StreamReader rd = new StreamReader(response.GetResponseStream());
                    APIText = rd.ReadToEnd();
                    //Console.WriteLine(APIText);
                    rd.Close();

                    Console.WriteLine(Url + " called successfully. Data has been returned.");
                    break;

                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    Console.WriteLine("Let's try that again");
                }
            }
            while (true)
            {
                try
                {
                    Console.WriteLine("Time to output it to a file, what do you wish to name the file?");
                    string fileName = Console.ReadLine() + ".json";
                    Console.WriteLine("Paste in the file path you wish to ouput to:");
                    string filePath = Console.ReadLine();
                    string fullPath = filePath + "\\" + fileName;
                    File.Create(fullPath).Dispose();

                    StreamWriter writer = new StreamWriter(fullPath);
                    writer.Write(APIText);
                    writer.Close();
                    Console.WriteLine("Json exported to "+fullPath+" successfully, closing...");
                    break;

                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    Console.WriteLine("Let's try that again");
                }
            }
          

        }
    }
}

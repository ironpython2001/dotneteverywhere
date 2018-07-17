using System;
using static System.Console;
using System.Collections.Generic;
using Docker.DotNet;
using Docker.DotNet.Models;

namespace DockerApiDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            
            DockerClient client = new DockerClientConfiguration(new Uri("npipe://./pipe/docker_engine")).CreateClient();
            var containers = client.Containers.ListContainersAsync(
                        new ContainersListParameters(){Limit = 10,}).Result;

            Console.WriteLine("Listing Containers");
            foreach (var item in containers)
            {
                Console.WriteLine(item.Image);
            }
            ReadLine();
            

        }
    }
}

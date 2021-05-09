﻿using FxSsh;
using FxSsh.Messages.Connection;
using FxSsh.Services;
using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SshServerLoader
{
    class Program
    {
        static void Main(string[] args)
        {
            var server = new SshServer();
            server.AddHostKey("ssh-rsa", "BwIAAACkAABSU0EyAAQAAAEAAQADKjiW5UyIad8ITutLjcdtejF4wPA1dk1JFHesDMEhU9pGUUs+HPTmSn67ar3UvVj/1t/+YK01FzMtgq4GHKzQHHl2+N+onWK4qbIAMgC6vIcs8u3d38f3NFUfX+lMnngeyxzbYITtDeVVXcLnFd7NgaOcouQyGzYrHBPbyEivswsnqcnF4JpUTln29E1mqt0a49GL8kZtDfNrdRSt/opeexhCuzSjLPuwzTPc6fKgMc6q4MBDBk53vrFY2LtGALrpg3tuydh3RbMLcrVyTNT+7st37goubQ2xWGgkLvo+TZqu3yutxr1oLSaPMSmf9bTACMi5QDicB3CaWNe9eU73MzhXaFLpNpBpLfIuhUaZ3COlMazs7H9LCJMXEL95V6ydnATf7tyO0O+jQp7hgYJdRLR3kNAKT0HU8enE9ZbQEXG88hSCbpf1PvFUytb1QBcotDy6bQ6vTtEAZV+XwnUGwFRexERWuu9XD6eVkYjA4Y3PGtSXbsvhwgH0mTlBOuH4soy8MV4dxGkxM8fIMM0NISTYrPvCeyozSq+NDkekXztFau7zdVEYmhCqIjeMNmRGuiEo8ppJYj4CvR1hc8xScUIw7N4OnLISeAdptm97ADxZqWWFZHno7j7rbNsq5ysdx08OtplghFPx4vNHlS09LwdStumtUel5oIEVMYv+yWBYSPPZBcVY5YFyZFJzd0AOkVtUbEbLuzRs5AtKZG01Ip/8+pZQvJvdbBMLT1BUvHTrccuRbY03SHIaUM3cTUc=");
            server.AddHostKey("ssh-dss", "BwIAAAAiAABEU1MyAAQAAG+6KQWB+crih2Ivb6CZsMe/7NHLimiTl0ap97KyBoBOs1amqXB8IRwI2h9A10R/v0BHmdyjwe0c0lPsegqDuBUfD2VmsDgrZ/i78t7EJ6Sb6m2lVQfTT0w7FYgVk3J1Deygh7UcbIbDoQ+refeRNM7CjSKtdR+/zIwO3Qub2qH+p6iol2iAlh0LP+cw+XlH0LW5YKPqOXOLgMIiO+48HZjvV67pn5LDubxru3ZQLvjOcDY0pqi5g7AJ3wkLq5dezzDOOun72E42uUHTXOzo+Ct6OZXFP53ZzOfjNw0SiL66353c9igBiRMTGn2gZ+au0jMeIaSsQNjQmWD+Lnri39n0gSCXurDaPkec+uaufGSG9tWgGnBdJhUDqwab8P/Ipvo5lS5p6PlzAQAAACqx1Nid0Ea0YAuYPhg+YolsJ/ce");
            server.ConnectionAccepted += OnConnectionAccepted;

           //  var server = new SshServer(new SshServerSettings { Port = 4022 });
            //server.AddHostKey("ssh-rsa", "<RSAKeyValue><Modulus>xXKzcIH/rzcfv2D7VcvLdxR5S5iw2TTsP65Aa82S4+9ZIqLPTNtuzr76Mz6Cx0yDOhawHlIujtalqaaQzaUvkudCtMcVMnj37OcCYz7XDAYejalCxf/vtJo7U4mnYdCM+nAOQKNIDKLGbLtGuEAGwdi560DOJY2plhnBf1oOI+k=</Modulus><Exponent>AQAB</Exponent><P>37kMr9YiU4cSqHqTJSjBJ/szG2O4n5xSIlPy4MZ4aAN5NALHxfsN0dq1y8NL6GTLMI5qoykvp4Bjrm2ZgU1cDQ==</P><Q>4e84rF+UsFBfQEKJc2pbACWWJjttNW0hccdQZzA3IUxRmd/Z4yEMr1L70TP0XV7dw1RDs1JyU7xnXBIbGy5ETQ==</Q><DP>vP0TbI6VnL3j0xMIrkFJOj8Ho0GQOrTQ5VLJP3wpRqR4hKk8nVBBEl+RZznpK73Jr5D/ICmwqezZSAYpwILbGQ==</DP><DQ>bHdzZtWwRYEgaXJIGL+7lnN1BT/MazTMNJpykEeGgBbqqgvcx/zq4RTezg26SEUuBANlSSbQukCeAoayurbYlQ==</DQ><InverseQ>Irq9vR7CXIVR+r09caYIxIY8BOig+HShN1bXvATERJcjTW2jUgJrUttDGNEx70/hBd7m1NWCZz5YO3RH9Bdf5w==</InverseQ><D>AqxsufxFcW9TDCAmQK4mwVdsoQjRp2jfcULmkM8fl9u40dtxTr6Csv5dz7qfKLWxHTGlDUDabCK2t/DCcZZoA3rsqwLADe4ZerDdg6xiq4MBzNprM8Y0IfNESEdFB9T0T73ONQCsMalUzEvUknC4Ed4Fya34LUHntgQtEhXpDJE=</D></RSAKeyValue>");
            //server.AddHostKey("ssh-dss", "<DSAKeyValue><P>1fge/S/6Y42F73v/RhtkZQUEgNktLUzjf4zcJPse2JfXGqtg3lMaEiEDbb/2Nm4Q/M7iksZxlIxge0BkP1ul69+Tovl+Gg+hI+OPGaKlD/1dnX4D4i1FiOpnjtyoCTeZysJ5X8nO1lSInDRnRv46gHk4cHSFVKILKY7CVo1sf0s=</P><Q>tb2irBOnujteP+kf5HmH0yXepE8=</Q><G>HJfQK2Sdd5vN47HWVdmRRYhwAhiVoP98l7FZ3FzVxZvE/CurAL2xVrDi9modbLg0UA1JHeOi6h9FTI9ijepnqRscBKFlyIny0wh15sc8EMcZzG/vJVH2M48ps1knt793sxEwjU/SPYxE7UEX5HGa/KyLuP6Ev/0z4WOOIJ62B5w=</G><Y>ebWWjjGiFpfKfaXlrY3SiMorrkvge/UEeHd5E27RS4B/BBlm9OhdNBFq3zzILAa3X8KvDOGlVZgTYqDchp3/SK/Y8HsbqNyTyqDMNvcnHILDqSrWmGMQEA/0kGiPn0nwEcA87F1osCro7Y70SuLNwUOl3xh+gQKdi5V6WU75gaw=</Y><Seed>w0QY1PFWINvz3x2OZlVF6Vi5cCw=</Seed><PgenCounter>UQ==</PgenCounter><X>SFKXJnLYP8UM5tlOCpVQ0S2yE78=</X></DSAKeyValue>");
            // server.ConnectionAccepted += OnConnectionAccepted;

            server.Start();

            Task.Delay(-1).Wait();
        }

        static void OnConnectionAccepted(object sender, Session e)
        {
            Console.WriteLine("Accepted a client.");

            e.ServiceRegistered += OnServiceRegistered;
        }


        static void OnServiceRegistered(object sender, SshService e)
        {
            var session = (Session)sender;
            Console.WriteLine("Session {0} requesting {1}.",
                BitConverter.ToString(session.SessionId).Replace("-", ""), e.GetType().Name);

            if (e is UserAuthService)
            {
                var service = (UserAuthService)e;
                service.UserAuth += OnUserAuth;
            }
            else if (e is ConnectionService)
            {
                var service = (ConnectionService)e;
                service.CommandOpened += OnServiceCommandOpened;
                
                
                //service.TcpForwardRequest += OnDirectTcpIpReceived
                //service.DirectTcpIpReceived += OnDirectTcpIpReceived;

            }
        }

        static void OnUserAuth(object sender, UserAuthArgs e)
        {
            if (e is PKUserAuthArgs)
            {
                var pk = e as PKUserAuthArgs;
                Console.WriteLine("Client {0} fingerprint: {1}.", pk.KeyAlgorithm, pk.Fingerprint);
            }
            else if (e is PasswordUserAuthArgs)
            {
                var pw = e as PasswordUserAuthArgs;
                Console.WriteLine("Client {0} password length: {1}.", pw.Username, pw.Password?.Length);
            }

            e.Result = true;
        }



     
        static void OnServiceCommandOpened(object sender, CommandRequestedArgs e)
        {

            Console.WriteLine("Channel {0} runs command: \"{1}\".", e.Channel.ServerChannelId, e.CommandText);
            e.Channel.SendData(Encoding.UTF8.GetBytes($"You ran {e.CommandText}\n"));
            e.Channel.SendClose();
        }
    }
}

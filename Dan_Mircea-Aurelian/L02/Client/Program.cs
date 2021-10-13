using RestSharp;
using System;

namespace laborator
{
    class Program
    {
        static void Main(string[] args)
        {
            var client = new RestClient("http://localhost:61495/Students");
            int id, an;
            string nume, facultate, val, op, camp;
            client.Timeout = -1;
            RestRequest request;
            IRestResponse response;
            do
            {
                Console.WriteLine("1. Adaugare student");
                Console.WriteLine("2. Afisare student");
                Console.WriteLine("3. Actualizare student");
                Console.WriteLine("4. Stergere student");
                Console.WriteLine("0. Iesire");
                Console.Write("Optiunea dvs. este: ");
                op = Console.ReadLine();
                switch(op)
                {
                    case "1":   Console.Write("Introduceti identificatorul: ");
                                id = Convert.ToInt32(Console.ReadLine());
                                Console.Write("Introduceti numele: ");
                                nume = Console.ReadLine();
                                Console.Write("Introduceti facultatea: ");
                                facultate = Console.ReadLine();
                                Console.Write("Introduceti anul: ");
                                an = Convert.ToInt32(Console.ReadLine());
                                request = new RestRequest(Method.POST);
                                request.AddJsonBody(new { Id = id, Nume = nume, Facultate = facultate, An = an });
                                response = client.Execute(request);
                                Console.WriteLine(response.Content);
                                break;
                    case "2":   Console.Write("Dati identificatorul studentului: ");
                                id = Convert.ToInt32(Console.ReadLine());
                                request = new RestRequest("{id}", Method.GET);
                                request.AddParameter("id", id, ParameterType.UrlSegment);    
                                response = client.Execute(request);
                                Console.WriteLine(response.Content);

                                break;
                    case "3":   Console.Write("Dati identificatorul studentului: ");
                                id = Convert.ToInt32(Console.ReadLine());
                                Console.Write("Dati campul pe care doriti sa il actualizati (id, nume, facultate, an): ");
                                camp = Console.ReadLine();
                                Console.Write("Dati noua valoare a campului: ");
                                val = Console.ReadLine();
                                request = new RestRequest(Method.PUT);
                                request.AddJsonBody(new { Id = id, Camp = camp, Valoare = val }) ;

                                response = client.Execute(request);
                                Console.WriteLine(response.Content);

                                break;
                    case "4":   Console.Write("Dati identificatorul studentului: ");
                                id = Convert.ToInt32(Console.ReadLine());
                                request = new RestRequest("{id}", Method.DELETE);
                                request.AddParameter("id", id, ParameterType.UrlSegment);
                                response = client.Execute(request);
                                Console.WriteLine(response.Content);

                                break;
                    case "0": break;
                    default: Console.WriteLine("Eroare! Optiune necunoscuta!");
                             break;
                }
            } while (op != "0");
        }
    }
}

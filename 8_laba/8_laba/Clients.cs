using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _8_laba
{
    public class Clients
    {
        private List<Client> clients;
        public int Count => clients.Count;
        public Clients()
        {
            clients = new List<Client>();
        }
        public Clients(params Client[] clients) : this()
        {
            for (int i = 0; i < clients.Length; i++)
            {
                this.clients.Add(clients[i]);
            }
        }
        public Client this[int index]
        {
            get
            {
                if (index < 0 || index >= clients.Count)
                {
                    throw new IndexOutOfRangeException("Індекс поза межами допустимого діапазону.");
                }
                return clients[index];
            }
        }
        public void AddClient(Client client)
        {
            if (!clients.Contains(client))
            {
                clients.Add(client);
            }
        }
        public void RemoveClient(Client client)
        {
            foreach (Client c in clients)
            {
                if (c.Equals(client))
                {
                    clients.Remove(c);
                    break;
                }
            }
        }
        public void SortClientstByName()
        {
            clients.Sort(new ClientComparer(SortFieldClient.Name));
        }
        public void SortClientsBySurname()
        {
            clients.Sort(new ClientComparer(SortFieldClient.Surname));
        }
        public void SortClientsByFirstBankNum()
        {
            clients.Sort(new ClientComparer(SortFieldClient.BankAccount));
        }
        public void PrintClients()
        {
            Console.WriteLine();
            foreach (Client c in clients)
            {
                c.ShowClientInfo();
            }
        }
        public Client FindClientByID(int ID)
        {
            foreach (Client c in clients)
            {
                if (c.ID == ID)
                {
                    return c;
                }
            }
            return null;
        }
    }
    internal enum SortFieldClient
    {
        Name,
        Surname,
        BankAccount
    }
    internal class ClientComparer : IComparer<Client>
    {
        SortFieldClient sortField;
        public ClientComparer(SortFieldClient sortField)
        {
            this.sortField = sortField;
        }
        public int Compare(Client x, Client y)
        {
            if (x == null || y == null)
            {
                throw new ArgumentNullException();
            }
            switch (sortField)
            {
                case SortFieldClient.Name:
                    {
                        return x.Name.CompareTo(y.Name);
                    }
                case SortFieldClient.Surname:
                    {
                        return x.Surname.CompareTo(y.Surname);
                    }
                case SortFieldClient.BankAccount:
                    {
                        char xFirstNum = x.BankAccount.ToString()[0];
                        char yFirstNum = y.BankAccount.ToString()[0];
                        return xFirstNum.CompareTo(yFirstNum);
                    }
                default:
                    {
                        return -1;
                    }
            }
        }
    }

}
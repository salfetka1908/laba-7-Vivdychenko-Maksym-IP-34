namespace _8_laba
{
    public class Client
    {
        private string name;
        public string Name { get { return name; } }

        private string surname;
        public string Surname { get { return surname; } }
        private int bankAccount;
        public int BankAccount
        {
            get { return bankAccount; }
        }
        private readonly int id;
        public int ID { get { return id;} }
        public Client(string name, string surname, int id, int bankAccount) 
        {
            this.name = name;
            this.surname = surname;
            this.id = id;
            this.bankAccount = bankAccount;
        }
        public void ShowClientInfo()
        {
            Console.WriteLine($"Client {name} {surname} info: \n ID: {id}\n Bank account : {bankAccount}");
        }
        public void ChangeName(string name)
        {
            this.name = name;
        }
        public void ChangeSurname(string surname)
        {
            this.surname = surname;
        }
        public void ChangeBankAccount(int bankAccount)
        {
            this.bankAccount = bankAccount;
        }
        public override bool Equals(object? obj)
        {
            if(obj == null)
            {
                throw new ArgumentNullException(nameof(obj));
            }
            Client? client = obj as Client;
            if(this.name == client.Name && this.surname == client.Surname && this.bankAccount == client.BankAccount && this.ID == client.ID)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}

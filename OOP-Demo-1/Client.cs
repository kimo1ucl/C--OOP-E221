namespace Classes
{
    public class Client
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Adress { get; set; }
        public Client(string firstName, 
            string lastName, 
            string adress)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Adress = adress;
        }   
    }
}

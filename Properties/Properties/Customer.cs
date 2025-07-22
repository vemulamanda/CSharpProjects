namespace Properties
{
    public class Customer
    {
        //We declare fields here..
        int _CustID;
        bool _Status;
        string? _Name, _State;
        double _Balance;
        Cities _city;

        //We call the constructor and intialize the fields
        public Customer(int CustID)
        {
            _CustID = CustID;
            _Status = true;
            _Name = "Sudheer";
            _Balance = 2000.98f;
            _city = 0;
            _State = "Telangana";
            Country = "India";
        }

        //We use properties, for the fields to be accessible outside the class Because by default the fields are set as private.
        
        public int CustID
        {
            get { return _CustID; }
        }

        public bool Status
        {
            get { return _Status; }
            set { _Status = value; }
        }

        public string Name
        {
            get {
                if (_Name == "Sudheer")
                    return _Name;
                return "Eswar";
            }

            set { _Name = value; }
        }

        public double Balance
        {
            set
            {
                if (_Balance > 500)
                    Console.WriteLine("Cannot adjust the value because it doesnt meet the condition.");
            }
            get 
            { 
                if(_Balance < 300)
                    return _Balance;
                return 0;
            }
        }

        public Cities City
        {
            get { return _city; }
            set
            {
                if(_Status)
                    _city = value;
            }
        }

        public string? State
        {
            get { return _State; }
            protected set
            {
                if(_Status)
                    _State = value;
            }
        }

        public string? Country
        {
            get; 
            private set; 
        }

        public string? Continent
        {
            get;
        } = "Australia";
    }
}

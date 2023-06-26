using System;

public class cardHolder
{
    String cardNum;
    int pin;
    String firstName;
    String lastName;
    double balance;

    public cardHolder(String cardNum, int pin, String firstName, String lastName, double balance)
    {
        this.cardNum = cardNum;
        this.pin = pin;
        this.firstName = firstName;
        this.lastName = lastName;
        this.balance = balance;
    }

    public String getCardNum()
    {
        return cardNum;
    }

    public int getPin()
    {
        return pin;
    }

    public String getFirstName()
    {
        return firstName;
    }

    public String getLastName()
    {
        return lastName;
    }

    public double getBalance()
    {
        return balance;
    }

    public void setBalance(double balance)
    {
        this.balance = balance;
    }

    public void setPin(int pin)
    {
        this.pin = pin;
    }

    public void setFirstName(String firstName)
    {
        this.firstName = firstName;
    }

    public void setLastName(String lastName)
    {
        this.lastName = lastName;
    }

    public void setCardNum(String cardNum)
    {
        this.cardNum = cardNum;
    }

    public void withdraw(double amount)
    {
        this.balance = balance - amount;
    }

    public static void Main(String[] args)
    {
        void printOptions()
        {
            Console.WriteLine("Please choose from one of the following options...");
            Console.WriteLine("1. Deposit");
            Console.WriteLine("2. Withdraw");
            Console.WriteLine("3. Show Balance");
            Console.WriteLine("4. Exit");
        }

        void deposit(cardHolder currentUser)
        {
            Console.WriteLine("How much $$ would you like to deposit");
            double deposit = Double.Parse(Console.ReadLine());
            currentUser.setBalance(currentUser.getBalance() + deposit);
            Console.WriteLine($"Thank  with us: {deposit}");
            Console.WriteLine($"Thank you for banking with us: {currentUser.getBalance()}");
        }


        void wtihdraw(cardHolder currentUser)
        {
            Console.WriteLine("How much $$ would you like to wtihdraw");
            double withdrawal = Double.Parse(Console.ReadLine());
            if (currentUser.getBalance() < withdrawal)
            {
                Console.WriteLine("Warning!!! insufficient balance :( ");
            }
            else
            {
                currentUser.setBalance(currentUser.getBalance() - withdrawal);
                Console.WriteLine($"Thank you for banking with us: {currentUser.getBalance()}");
            }
        }

        void balance(cardHolder currentUser)
        {
            Console.WriteLine("Current Balance: " + currentUser.getBalance());
        }

        List<cardHolder> cardHolders = new List<cardHolder>();
        cardHolders.Add(new cardHolder("123456789", 1234, "John", "Doe", 1000.00));
        cardHolders.Add(new cardHolder("987654321", 4321, "Jane", "Doe", 2000.00));
        cardHolders.Add(new cardHolder("123123123", 1111, "John", "Smith", 3000.00));
        cardHolders.Add(new cardHolder("321321321", 2222, "Jane", "Smith", 4000.00));


        // Prompt user 

        Console.WriteLine("Welcome to the ATM");
        Console.WriteLine("Please insert your debit card");
        String debitCardNum = "";
        cardHolder currentUser;


        while (true)
        {
            try
            {
                debitCardNum = Console.ReadLine();

                // Check against list of card holders
                currentUser = cardHolders.FirstOrDefault(a => a.cardNum == debitCardNum);
                if (currentUser != null) { break; }
                else { Console.WriteLine("Invalid card number, please try again"); }
            }
            catch (Exception e)
            {
                Console.WriteLine("Invalid card number, please try again");
            }
        }


        Console.WriteLine("Please enter your pin: ");
        int userPin = 0;

        while (true)
        {
            try
            {
                userPin = int.Parse(Console.ReadLine());
                if (currentUser.getPin() == userPin) { break; }
                else { Console.WriteLine("Invalid pin, please try again"); }
            }
            catch (Exception e)
            {
                Console.WriteLine("Invalid pin, please try again");
            }
        }

        Console.WriteLine("Welcom " + currentUser.getFirstName() + " " + currentUser.getLastName() + ":)");

        int option = 0;
        do
        {
            printOptions();
            try
            {
                option = int.Parse(Console.ReadLine());
            }
            catch (Exception e)
            {
                Console.WriteLine("Invalid option, please try again");
            }
            if (option == 1)
            {
                deposit(currentUser);
            }
            else if (option == 2)
            {
                wtihdraw(currentUser);
            }
            else if (option == 3)
            {
                balance(currentUser);
            }
            else if (option == 4)
            {
                Console.WriteLine("Thank you for banking with us");
                break;
            }
            else
            {
                Console.WriteLine("Invalid option, please try again");
                option = 0;
            }
        } while (true);


    }



}




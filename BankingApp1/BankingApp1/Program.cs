using System;
using System.Collections.Generic;

namespace BankingApp1
{
    static class Program
    {
        public static Dictionary<string, string> Text { get; set; }

        static readonly Dictionary<string, string> English = new Dictionary<string, string>
        {
            ["welcome"] = "=== Welcome to the Banking App ===",
            ["chosen_Lang"] = "Choose your language: \n1. English \n2. IsiZulu",
            ["invalid_Lang"] = "Invalid choice. Try again.",
            ["main_menu"] = "=== Main Menu === \n1. Deposit \n2. Withdraw \n3. Transaction History \n4. Exit",
            ["choose_option"] = "Choose an option:",
            ["enter_deposit"] = "Enter the amount to deposit: R",
            ["enter_withdraw"] = "Enter the amount to withdraw: R",
            ["deposited"] = "You have deposited: R",
            ["withdrawn"] = "You have withdrawn: R",
            ["insufficient_amount"] = "Insufficient funds!",
            ["invalid_amount"] = "Invalid amount. Try again(ONLY POSITIVE NUMBERS).",
            ["no_history"] = "No transactions yet.",
            ["history"] = "=== Transaction History ===",
            ["balance"] = "Your current balance is: R",
            ["goodbye"] = "Thank you for using the Banking App. Goodbye!",
            ["new_balance"] = "Your current balance is: R",
        };

        static readonly Dictionary<string, string> IsiZulu = new Dictionary<string, string>
        {
            ["welcome"] = "=== Siyakwamukela kwi-Banking App ===",
            ["chosen_Lang"] = "Khetha ulimi lwakho: \n1. English \n2. IsiZulu",
            ["invalid_Lang"] = "Ukukhetha okungavumelekile. Zama futhi.",
            ["main_menu"] = "=== Imenyu === \n1. Faka imali \n2. Khipha imali \n3. Umlando Wokuthengiselana \n4. Phuma",
            ["choose_option"] = "Khetha oyithandayo:",
            ["enter_deposit"] = "Faka imali ofuna ukuyifaka: R",
            ["enter_withdraw"] = "Faka imali ofuna ukuyikhipha: R",
            ["deposited"] = "Ufake: R",
            ["withdrawn"] = "Ukhiphe: R",
            ["insufficient_amount"] = "Imali ayanele!",
            ["invalid_amount"] = "Imali elingavumelekile. Zama futhi (INANI ELIHLE).",
            ["no_history"] = "Azikho izenzakalo okwamanje.",
            ["history"] = "=== Umlando Wezokuthengiselana ===",
            ["balance"] = "Ibhalansi yakho yamanje: R",
            ["goodbye"] = "Siyabonga ngokusebenzisa i-Banking App. Hamba kahle!",
            ["new_balance"] = "Ibhalansi yakho entsha: R",
        };

        static  readonly List<string> transactionHistory = new List<string>();
        static Dictionary<string, string> lang;


        static string T(string key) => lang[key];

        static void Main(string[] args)
        {
            double balance = 0;

            Console.WriteLine("=== Welcome to the Banking App ===");
            Console.WriteLine("Choose your language: \n1. English \n2. IsiZulu");


            while (true)
            {
                Console.WriteLine("Choice:");
                var choice = Console.ReadLine();

                if (choice == "1")
                {
                    lang = English;
                    break;
                }
                else if (choice == "2")
                {
                    lang = IsiZulu;
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid choice. / Ukhethe okungavumelekile.");
                }
            }

            Console.WriteLine("\n" + T("welcome"));

            while (true)
            {
                Console.WriteLine(T("main_menu"));
                Console.Write(T("choose_option"));
                string option = Console.ReadLine();

                switch (option)
                {


                    case "1":
                        Console.Write("\n" + T("enter_deposit"));
                        if (double.TryParse(Console.ReadLine(), out double deposit) && deposit > 0)
                        {
                            balance += deposit;
                            transactionHistory.Add($"+ R{deposit:F2}");
                            Console.WriteLine(T("deposited") + deposit.ToString("F2"));
                            Console.WriteLine(T("new_balance") + balance.ToString("F2"));
                        }
                        else
                        {
                            Console.WriteLine(T("invalid_amount"));
                        }
                        break;

                    case "2":
                        Console.Write("\n" + T("enter_withdraw"));
                        if (double.TryParse(Console.ReadLine(), out double withdraw) && withdraw > 0)
                        {
                            if (withdraw > balance)
                            {
                                Console.WriteLine(T("insufficient_amount"));
                            }
                            else
                            {
                                balance -= withdraw;
                                transactionHistory.Add($"- R{withdraw:F2}");
                                Console.WriteLine(T("withdrawn") + withdraw.ToString("F2"));
                                Console.WriteLine(T("new_balance") + balance.ToString("F2"));
                            }
                        }
                        else
                        {
                            Console.WriteLine(T("invalid_amount"));
                        }
                        break;

                    case "3":
                        Console.WriteLine("\n" + T("history"));
                        if (transactionHistory.Count == 0)
                        {
                            Console.WriteLine(T("no_history"));
                        }
                        else
                        {
                            foreach (var transaction in transactionHistory)
                            {
                                Console.WriteLine(transaction);
                            }
                        }
                        break;

                    case "4":
                        Console.WriteLine("\n" + T("goodbye"));
                        return;

                    default:
                        Console.WriteLine(T("invalid_amount"));
                        break;
                }
            }
        }
    }
}

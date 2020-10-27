using ExchangeRateApp.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExchangeRateApp.UI
{
    public class MainApplication
    {
        private readonly ExchangeRateService _exchangeRateService;

        public MainApplication(ExchangeRateService exchangeRateService)
        {
            _exchangeRateService = exchangeRateService;
        }
        
        public void Run()
        {
            Console.WriteLine("ExchangeRate Application\n\n");
            for (; ; )
                HandleMenu();
        }
        private void HandleMenu()
        {
            Console.WriteLine("Your current currency: ");
            Console.WriteLine(_exchangeRateService.CurrentCurrency);
            Console.WriteLine("Budget: ");
            Console.WriteLine(_exchangeRateService.Budget);

            Console.WriteLine("1.Change your current currency");
            Console.WriteLine("2.Change budget");
            Console.WriteLine("3.Convert to...");
            Console.WriteLine("4.Exit");

            Console.WriteLine("\nWhat do you want to do?:");

            try
            {
                int option;
                int.TryParse(Console.ReadLine(), out option);
                HandleOption(option);
            }
            catch(Exception e)
            {
                Console.WriteLine($"{e.Message} | You've picked wrong option");
            }
        }

        private void HandleOption(int option)
        {
            switch(option)
            {
                case 1:
                    Console.Clear();
                    ChangeCurrentCurrency();
                    break;
                case 2:
                    Console.Clear();
                    ChangeBudget();
                    break;
                case 3:
                    Console.Clear();
                    ConvertCurrency();
                    break;
                case 4:
                    System.Environment.Exit(1);
                    break;
                default:
                    Console.WriteLine("You've picked wrong option. Try again!");
                    break;
            }
        }

        private void ChangeCurrentCurrency()
        {
            List<Currency> currencies = _exchangeRateService.GetAllCurrencies();
            for(int i = 0; i < currencies.Count; i++)
                Console.WriteLine($"{i + 1}. {currencies[i].CurrencyName}");

            try
            {
                int option;
                int.TryParse(Console.ReadLine(), out option);
                if (option < currencies.Count)
                    _exchangeRateService.CurrentCurrency = currencies[option - 1].CurrencyName;
                else
                    throw new IndexOutOfRangeException();
                Console.WriteLine("You've changed current currency!");
            }
            catch(IndexOutOfRangeException e)
            {
                Console.WriteLine($"{e.Message} | Out of range exception!");
                Console.Clear();
                ChangeCurrentCurrency();
            }
            catch (Exception e)
            {
                Console.WriteLine($"{e.Message} | Wrong input, try again!");
                Console.Clear();
                ChangeCurrentCurrency();
            }
        }

        private void ChangeBudget()
        {
            try
            {
                decimal newBudget = Decimal.Parse(Console.ReadLine());
                _exchangeRateService.Budget = newBudget;
                Console.WriteLine("You've changed your budget!");
            }
            catch(Exception e)
            {
                Console.WriteLine($"{e.Message} | Wrong input, try again!");
                Console.Clear();
                ChangeBudget();
            }
        }

        private void ConvertCurrency()
        {
            List<Currency> currencies = _exchangeRateService.GetAllCurrencies();
            for (int i = 0; i < currencies.Count; i++)
                Console.WriteLine($"{i + 1}. {currencies[i].CurrencyName}");

            try
            {
                int option;
                int.TryParse(Console.ReadLine(), out option);
                if (option < currencies.Count)
                    Console.WriteLine("\n\nRESULT: " + _exchangeRateService.CalculateValueAfterExchange(currencies[option - 1].CurrencyName));
                else
                    throw new IndexOutOfRangeException();
            }
            catch (IndexOutOfRangeException e)
            {
                Console.WriteLine($"{e.Message} | Out of range exception!");
                Console.Clear();
                ChangeCurrentCurrency();
            }
            catch (Exception e)
            {
                Console.WriteLine($"{e.Message} | Wrong input, try again!");
                Console.Clear();
                ChangeCurrentCurrency();
            }
        }

    }
}

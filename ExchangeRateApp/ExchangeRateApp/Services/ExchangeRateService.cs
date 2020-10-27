using ExchangeRateApp.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExchangeRateApp.Controller
{
    public class ExchangeRateService
    {
        private readonly IExchangeRateRepository _exchangeRateRepository;
        public string CurrentCurrency { get; set; }
        public decimal Budget { get; set; } = 100.00m; // default value

        public ExchangeRateService(IExchangeRateRepository exchangeRateRepository)
        {
            _exchangeRateRepository = exchangeRateRepository;
            var currencies = _exchangeRateRepository.GetCurrencies();
            if (!currencies.Any())
                throw new Exception("Currencies failed to load");

            // Setting values to default
            CurrentCurrency = currencies[0].CurrencyName;
        }

        public List<Currency> GetAllCurrencies() => _exchangeRateRepository.GetCurrencies();

        public decimal CalculateValueAfterExchange(string currencyName)
        {
            var currentCurrencyFactor = _exchangeRateRepository.GetAverageMultiplier(CurrentCurrency) / _exchangeRateRepository.GetMultiplier(CurrentCurrency);
            var factor = _exchangeRateRepository.GetAverageMultiplier(currencyName) / _exchangeRateRepository.GetMultiplier(currencyName);
            return (Budget * currentCurrencyFactor) / factor;
        }
    }
}

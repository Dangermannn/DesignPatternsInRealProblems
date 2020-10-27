using ExchangeRateApp.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExchangeRateApp.Data
{
    public class ExchangeRateRepository : IExchangeRateRepository
    {
        private readonly CurrencyTable _context;

        public ExchangeRateRepository()
        {
            var exchangeRateService = new ExchangeRateDataProvider();
            _context = exchangeRateService.DeserializeXml();
        }

        public decimal GetAverageMultiplier(string currencyName) => 
            _context.CurrencyList.FirstOrDefault(x => x.CurrencyName == currencyName).AverageMultiplier;
    
        public List<Currency> GetCurrencies() => _context.CurrencyList;


        public string GetCurrencyCode(string currencyName) =>
            _context.CurrencyList.FirstOrDefault(x => x.CurrencyName == currencyName).CurrencyCode;

        public decimal GetMultiplier(string currencyName) =>
            _context.CurrencyList.FirstOrDefault(x => x.CurrencyName == currencyName).Multiplier;

        public string GetPublicationDate() => _context.PublicationDate;

        public string GetTableNumber() => _context.TableNumber;
    }
}

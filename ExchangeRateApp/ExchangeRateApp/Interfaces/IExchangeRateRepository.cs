using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExchangeRateApp.Interfaces
{
    public interface IExchangeRateRepository
    {
        string GetTableNumber();
        string GetPublicationDate();
        Decimal GetMultiplier(string currencyName);
        Decimal GetAverageMultiplier(string currencyName);
        string GetCurrencyCode(string currencyName);
        List<Currency> GetCurrencies();
    }
}

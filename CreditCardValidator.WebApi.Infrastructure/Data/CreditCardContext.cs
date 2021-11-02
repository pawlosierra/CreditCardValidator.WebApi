using CreditCardValidator.WebApi.Infrastructure.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace CreditCardValidator.WebApi.Infrastructure.Data
{
    public class CreditCardContext
    {
        private readonly string _path = @"C:\Users\JuanPawloSierra\source\repos\Projects\CreditCardValidator.WebApi\CreditCardValidator.WebApi.Infrastructure\Data\CreditCardService\json\BlackList.json";
        public List<CreditCardModel> DeserializeInfoCreditCards()
        {
            var jsonFile = File.ReadAllText(_path);
            List<CreditCardModel> lstCreditCards = JsonConvert.DeserializeObject<List<CreditCardModel>>(jsonFile);
            return lstCreditCards;
        }
    }
}

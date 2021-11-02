using CreditCardValidator.WebApi.Domain.Models;
using CreditCardValidator.WebApi.Domain.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace CreditCardValidator.WebApi.Application.Queries.creditCard.IsValidCreditCard
{
    public class IsValidCreditCardHandler : IRequestHandler<IsValidCreditCard, CreditCardValidation>
    {
        private readonly ICreditCardRepository _creditCardRepository;
        private readonly CreditCardValidation _creditCardValidation;

        public IsValidCreditCardHandler(ICreditCardRepository creditCardRepository)
        {
            _creditCardRepository = creditCardRepository;
            _creditCardValidation = new CreditCardValidation();
        }

        public async Task<CreditCardValidation> Handle(IsValidCreditCard request, CancellationToken cancellationToken)
        {
            string cardNumber = String.Concat(request.CardNumber.Where(c => !Char.IsWhiteSpace(c)));
            _creditCardValidation.CardNumber = cardNumber;
            var blackListedCards = await _creditCardRepository.GetBlackListedCreditCards();
            if (HaveSixteenDigits(cardNumber).IsValid &&
                    IsOnlyVisaAndMaster(cardNumber).IsValid &&
                    VerificationDigit(cardNumber).IsValid &&
                    ExpirationDateCardCreditIsValid(request.ExpirationDate, cardNumber).IsValid &&
                    IsPresentBlackList(blackListedCards, cardNumber).IsValid)
            {
                return _creditCardValidation;
            }
            return _creditCardValidation;
        }
        public CreditCardValidation HaveSixteenDigits(string cardNumber)
        {
            try
            {
                if (cardNumber.Length == 16)
                {

                    _creditCardValidation.IsValid = true;
                    return _creditCardValidation;
                }
                else
                {

                    _creditCardValidation.IsValid = false;
                    _creditCardValidation.ErrorCode = "ONLY_16_DIGITS_CREDIT_CARD";
                    _creditCardValidation.Message = "Only 16 digits";
                    return _creditCardValidation;
                }
            }
            catch (Exception ex)
            {
                throw new FormatException("Invalid format", ex);
            }
        }
        public CreditCardValidation IsOnlyVisaAndMaster(string cardNumber)
        {
            if (cardNumber.StartsWith("4"))
            {

                _creditCardValidation.IsValid = true;
                return _creditCardValidation;
            }
            if (cardNumber.StartsWith("5"))
            {
                string substring = cardNumber.Substring(0, 2);
                Boolean workRange = Regex.IsMatch(substring, @"^[51-55]+$");
                if (workRange)
                {

                    _creditCardValidation.IsValid = true;
                    return _creditCardValidation;
                }
            }

            _creditCardValidation.IsValid = false;
            _creditCardValidation.ErrorCode = "ONLY_VISA_AND_MASTERCARD_ALLOWED";
            _creditCardValidation.Message = "Only Visa and Master credit cards are accepted.";
            return _creditCardValidation;
        }
        public CreditCardValidation VerificationDigit(string cardNumber)
        {
            long sum = 0;

            for (int i = 0; i < cardNumber.Length; i++)
            {
                var digit = cardNumber[cardNumber.Length - 1 - i] - '0';
                sum += (i % 2 != 0) ? GetDouble(digit) : digit;
            }

            int GetDouble(long i)
            {
                switch (i)
                {
                    case 0: return 0;
                    case 1: return 2;
                    case 2: return 4;
                    case 3: return 6;
                    case 4: return 8;
                    case 5: return 1;
                    case 6: return 3;
                    case 7: return 5;
                    case 8: return 7;
                    case 9: return 9;
                    default: return 0;
                }
            }
            if (sum % 10 == 0)
            {

                _creditCardValidation.IsValid = true;
                return _creditCardValidation;
            }

            _creditCardValidation.IsValid = false;
            _creditCardValidation.ErrorCode = "INVALID_CREDIT_CARD_NUMBER";
            _creditCardValidation.Message = "Invalid credit card number";
            return _creditCardValidation;
            #region inf
            //return sum % 10 == 0;
            #endregion
        }

        public CreditCardValidation ExpirationDateCardCreditIsValid(string expirationDateStr, string cardNumber)
        {
            DateTime expirationDate;

            if (DateTime.TryParseExact(expirationDateStr, "MM/yy", null, System.Globalization.DateTimeStyles.None, out expirationDate))
            {
                if (expirationDate.Year > DateTime.Now.Year || (expirationDate.Year == DateTime.Now.Year && expirationDate.Month > DateTime.Now.Month))
                {
                    _creditCardValidation.IsValid = false;
                    _creditCardValidation.ErrorCode = "CREDIT_CARD_HAS_EXPIRED";
                    _creditCardValidation.Message = "Credit card has expired";
                    return _creditCardValidation;
                }
            }
            else
            {
                _creditCardValidation.IsValid = false;
                _creditCardValidation.ErrorCode = "INVALID_EXPIRATION_DATE_FORMAT";
                _creditCardValidation.Message = "Invalid expiration date format";
                return _creditCardValidation;
            }

            _creditCardValidation.IsValid = true;
            return _creditCardValidation;

            #region
            /*   DateTime.TryParseExact("20071122", "yyyyMMdd", null, System.Globalization.DateTimeStyles.None, out dt);
             DateTime temp = DateTime.ParseExact(expirationDate, "MM/yy", null, DateTimeStyles.None);
             var date = expirationDate.Split('/');
             int creditCardExpirationMonth = int.Parse(date[0]);
             int creditCardExpirationYear = int.Parse(date[1]);*/
            //int dateNowMonth = DateTime.Now.Month;
            //int dateNowYear = int.Parse(((DateTime.Now.Year).ToString()).Substring(2, 2));
            ///*        if (creditCardExpirationYear.ToString().Length > 2 ||
            //            creditCardExpirationMonth.ToString().Length > 2)
            //        {

            //            _creditCardValidation.IsValid = false;
            //            _creditCardValidation.ErrorCode = "INVALID_EXPIRATION_DATE_FORMAT";
            //            _creditCardValidation.Message = "Invalid expiration date format";
            //            return _creditCardValidation;
            //        }*/
            //if (dateNowYear > creditCardExpirationYear)
            //{

            //    _creditCardValidation.IsValid = false;
            //    _creditCardValidation.ErrorCode = "CREDIT_CARD_HAS_EXPIRED";
            //    _creditCardValidation.Message = "Credit card has expired";
            //    return _creditCardValidation;
            //}
            //else
            //{
            //    if (dateNowYear == creditCardExpirationYear)
            //    {
            //        if (dateNowMonth > creditCardExpirationMonth)
            //        {

            //            _creditCardValidation.IsValid = false;
            //            _creditCardValidation.ErrorCode = "CREDIT_CARD_HAS_EXPIRED";
            //            _creditCardValidation.Message = "Credit card has expired";
            //            return _creditCardValidation;
            //        }
            //    }

            //    _creditCardValidation.IsValid = true;
            //    return _creditCardValidation;
            //}
            #endregion

        }

        public CreditCardValidation IsPresentBlackList(IEnumerable<CreditCard> blackList, string cardNumber) //cuando utilizo el el nombre de un metodo como Is... siempre debe devolver un bool.
        {
            if (blackList.Any(x => x.CardNumber.Trim() == cardNumber))
            {
                _creditCardValidation.IsValid = false;
                _creditCardValidation.ErrorCode = "THE_CREDIT_CARD_IS_BLACKLIST";
                _creditCardValidation.Message = "The credit card is blacklist";
            }
            _creditCardValidation.IsValid = true;
            return _creditCardValidation;
            #region
            //foreach (var card in blackList)
            //{
            //    string suspectCard = String.Concat(card.CardNumber.Where(c => !Char.IsWhiteSpace(c)));
            //    if (cardNumber == suspectCard)
            //    {

            //        _creditCardValidation.IsValid = false;
            //        _creditCardValidation.ErrorCode = "THE_CREDIT_CARD_IS_BLACKLIST";
            //        _creditCardValidation.Message = "The credit card is blacklist";
            //        return _creditCardValidation;
            //    }
            //}
            //_creditCardValidation.IsValid = true;
            //return _creditCardValidation;
            #endregion



        }
    }
}


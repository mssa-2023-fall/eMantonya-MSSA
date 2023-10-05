using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MortgageCalculator2._0
{
    public class Customer
    {
        public string _accountNum;
        public string _accountHolder;
        public int _duration;
        public double _intrestRate;
        public double _principal;
        public double _downPayment;
        public double _purchasePrice;
        public int _totalPayments;
        public decimal _monthlyPayment;
        public DateTime _originationDate;

        public Customer(string name, int duration, double rate, double purchasePrice, double downPayment)
        {
            _originationDate = DateTime.Today;
            _accountNum = GenerateAccountNumber(_originationDate);
            _principal = purchasePrice - downPayment;
            _accountHolder = name;
            _duration = duration;
            _intrestRate = rate;
            _purchasePrice = purchasePrice;
            _downPayment = downPayment;
            _totalPayments = duration * 12;
            _monthlyPayment = CalculateMonthlyPayment();
        }
        public Customer(string name, int duration, double rate, double purchasePrice)
        {
            _originationDate = DateTime.Today.Date;
            _accountNum = GenerateAccountNumber(_originationDate);
            _principal = purchasePrice;
            _accountHolder = name;
            _duration = duration;
            _intrestRate = rate;
            _purchasePrice = purchasePrice;
            _downPayment = 0;
            _totalPayments = duration * 12;
            _monthlyPayment = CalculateMonthlyPayment();
        }

        public decimal CalculateMonthlyPayment()
        {
            double monthlyRate = (_intrestRate /12) / 100;
            double numerator = _principal * monthlyRate * Math.Pow((1 + monthlyRate), _totalPayments);
            double denominator = Math.Pow(1 + monthlyRate, _totalPayments) - 1;
            return Math.Round((decimal)(numerator / denominator), 2);
        }

        public DateTime GetPayoffDate() => _originationDate.AddYears(_duration);

        public decimal CalculateTotalIntrest() => (_monthlyPayment * _totalPayments) - (decimal)_principal;

        public string GenerateAccountNumber(DateTime date)
        {
            Random rand = new Random();
            string num = rand.Next(11111, 99999).ToString();
            string prefix = date.Year.ToString();

            return prefix + num;
        }

    }

    

}

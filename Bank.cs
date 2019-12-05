using System;
using System.Linq;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace funcprog
{
    public sealed class BicExistsValidator : IValidator<MakeTransfer>
    {
        readonly Func<IEnumerable<string>> getValidCodes;
        public BicExistsValidator(Func<IEnumerable<string>> getValidCodes){
            this.getValidCodes = getValidCodes;
        }
        public bool IsValid(MakeTransfer cmd)
           => getValidCodes().Contains(cmd.Bic);
    }
    public sealed class BicFormatValidator : IValidator<MakeTransfer>
    {
        static readonly Regex regex = new Regex("^[A-Z]{6}[A-Z1-9]{5}$");
        public bool IsValid(MakeTransfer cmd)
             => regex.IsMatch(cmd.Bic);
    }
    public class DateNotPastValidator : IValidator<MakeTransfer>
    {
        private readonly DateTime today;
        public DateNotPastValidator(DateTime today)
        {
            this.today = today;
        }
        public bool IsValid(MakeTransfer cmd)
           => (today.Date <= cmd.Date.Date);
    }

    public interface IValidator<T>
    {
        bool IsValid(T t);
    }
    public abstract class Command { }
    public sealed class MakeTransfer : Command
    {
        public Guid DebitedAccountId { get; set; }
        public string Beneficiary { get; set; }
        public string Iban { get; set; }
        public string Bic { get; set; }
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
    }
}

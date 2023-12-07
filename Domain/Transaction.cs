using Microsoft.AspNetCore.Components.Web;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineStore.Domain
{
    public class Transaction : IComparable<Transaction>, IEquatable<Transaction>
    {
        public string id { get; set; }
        public string AccountId { get; set; }
        [ForeignKey("AccountId")]
        public virtual Account account { get; set; }

        public double total { get; set; }
        public DateOnly date { get; set; }  // todo: move to DateTime

        public Transaction()
        {
            id = Id.generate();
        }

        public Transaction(string account_id, double total)
        {
            id = Id.generate();
            this.AccountId = account_id;
            this.total = total;
            date = DateOnly.FromDateTime(DateTime.UtcNow);
        }

        public int CompareTo(Transaction? other)
        {
            if (other == null)
                return 1;

            int result = date.CompareTo(other.date);
            if (result == 0)
                result = total.CompareTo(other.total);
            return result;
        }

        public bool Equals(Transaction? other)
        {
            return date.Equals(other) &&
                     id.Equals(other.id) &&
                  total.Equals(other.total);
        }
    }
}

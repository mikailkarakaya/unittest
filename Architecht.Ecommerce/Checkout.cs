using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Architecht.Ecommerce
{
    public class Checkout : ICheckout
    {
        public string GoBankForPayment(Bank bankName)
        {
            string webUrl = string.Empty;
            string downloadString = string.Empty;
            switch (bankName)
            {
                case Bank.ISBANK:
                    webUrl = "https://www.isbank.com.tr/";
                    break;
                case Bank.VAKIF:
                    webUrl = "https://www.vakifbank.com.tr/";
                    break;
                case Bank.KUVEYTTURK:
                    webUrl = "https://www.kuveytturk.com.tr/";
                    break;
                case Bank.AKBANK:
                    webUrl = "https://www.akbank.com/tr-tr/sayfalar/default.aspx";
                    break;
                default:
                    break;
            }

            using (WebClient client = new WebClient())
            {
                downloadString = client.DownloadString(webUrl);
            }
            return downloadString;
        }
    }


    public interface ICheckout
    {
        string GoBankForPayment(Bank bankName);
    }
    public enum Bank
    {
        ISBANK,
        VAKIF,
        KUVEYTTURK,
        AKBANK
    }
}

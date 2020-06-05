using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using COutlook = Microsoft.Office.Interop.Outlook;

namespace Bnska1
{
    static class Outlook
    {
        public static void CreateMailItemToMayorovYurzin(string[] attachments)
        {
            AppSettingsReader ar = new AppSettingsReader();
            string subjectStr = (string) ar.GetValue("OutlookSubject", typeof(string));
            string toStr = (string)ar.GetValue("OutlookTo", typeof(string));
            string bodyStr = (string)ar.GetValue("OutlookBody", typeof(string));
            COutlook.Application app = new COutlook.Application();
            COutlook.MailItem mailItem = app.CreateItem(COutlook.OlItemType.olMailItem);
            mailItem.Subject = subjectStr;
            mailItem.To = toStr;
            mailItem.Body = bodyStr;
            if (attachments != null)
            {
                foreach (var a in attachments)
                {
                    mailItem.Attachments.Add(a);
                }
            }
            mailItem.Importance = COutlook.OlImportance.olImportanceNormal;
            mailItem.Display(false);
        }
    }
}

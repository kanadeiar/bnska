using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using COutlook = Microsoft.Office.Interop.Outlook;

namespace Bnska1
{
    static class Outlook
    {
        public static void CreateMailItemToMayorovYurzin()
        {
            COutlook.Application app = new COutlook.Application();
            COutlook.MailItem mailItem = app.CreateItem(COutlook.OlItemType.olMailItem);
            mailItem.Subject = "Информация по насосам БНС Верхозим";
            mailItem.To = "yurzinin@ulneft.ru; mayoroviv@ulneft.ru";
            mailItem.Body = "Сообщение готово к отправке с вложенным файлом или ссылкой.";
            //mailItem.Attachments.Add();
            mailItem.Importance = COutlook.OlImportance.olImportanceNormal;
            mailItem.Display(false);
        }
    }
}

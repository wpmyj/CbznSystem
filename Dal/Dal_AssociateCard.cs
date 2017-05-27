using Model;
using System.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dal
{
    public class Dal_AssociateCard
    {
        public static DataTable GetUseUserName(string vicecardnumber)
        {
            string cmdtext = string.Format(" select DISTINCT h.CardNumber as CardNumber from CBAssociateCard as v inner join cbCardInfo as h on v.cardid=h.id where h.CardType = 1 and v.AssociateCardNumber like '%{0}%' ", vicecardnumber);
            DataTable dt = Dbhelper.Db.ToTable(cmdtext);
            return dt;
        }

        public static DataTable GetViceCard(string content)
        {
            string cmdtext = string.Format(" select DISTINCT v.AssociateCardNumber as ViceCardNumber from cbcardinfo as h inner join CBAssociateCard as v on h.id=v.cardid where  h.CardType = 1 and ( h.UserName like '%{0}%' or h.CardNumber like '%{0}%' ) ", content);
            return Dbhelper.Db.ToTable(cmdtext);
        }
    }
}

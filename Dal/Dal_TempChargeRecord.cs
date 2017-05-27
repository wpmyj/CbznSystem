using System.Data.SQLite;
using System.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dal
{
    public class Dal_TempChargeRecord
    {

        public static void InputRecord(DataTable dt)
        {
            try
            {
                using (SQLiteConnection conn = new SQLiteConnection(Dbhelper.Db.ConnectionStr))
                {
                    SQLiteCommand comm = new SQLiteCommand(" select * from CBTempChargeRecord limit 1", conn);
                    conn.Open();
                    SQLiteTransaction ts = conn.BeginTransaction();
                    SQLiteDataAdapter dadpter = new SQLiteDataAdapter(comm);
                    SQLiteCommandBuilder buider = new SQLiteCommandBuilder(dadpter);
                    dadpter.InsertCommand = buider.GetInsertCommand();
                    dadpter.Update(dt);
                    ts.Commit();
                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

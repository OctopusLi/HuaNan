﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Demo2015
{
    public class DBHelperSQL
    {
        public static string connStr = @"server=Triumph\Triumph;database=test2015;integrated security=true";
        public static SqlConnection conn = null;
        public static void TableChange(string sql,SqlParameter[]para=null)
        {
            try
            {
                SqlCommand cmd = new SqlCommand(sql, DBHelperSQL.conn);
                if(para!=null)
                {
                    cmd.Parameters.AddRange(para);
                }
                if(cmd.ExecuteNonQuery()>0)
                {
                    MessageBox.Show("操作成功！");
                }
                else
                {
                    MessageBox.Show("操作失败！\n请检查数据库中是否有该条数据！");
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public static DataTable TableSelect(string sql,SqlParameter[]para=null)
        {
            try
            {
                SqlCommand cmd = new SqlCommand(sql, DBHelperSQL.conn);
                DataTable dt = new DataTable();
                if(para!=null)
                {
                    cmd.Parameters.AddRange(para);
                }
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                return dt;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }
    }
}

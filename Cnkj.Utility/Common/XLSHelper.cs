using System;
using System.Data;
using System.Data.OleDb;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Web;
using System.Web.UI;

namespace Common
{
	public class XLSHelper
	{
		//�ô˷�������дҳ���VerifyRenderingInServerForm������
		/// <summary>
		/// ����Office�ļ�Excel��Word�ļ�,HtmoTextWriter��ʽ,�ô˷�������дҳ���VerifyRenderingInServerForm������Office FileType("application/ms-word")("application/ms-excel")
		/// </summary>
		/// <param name="webPage">Web.Page</param>
		/// <param name="webControl">Web���ؼ�������дҳ���VerifyRenderingInServerForm������</param>
		/// <param name="fileType">Office FileType("application/ms-word")("application/ms-excel")</param>
		/// <param name="fileName">FileFullName</param>
		public void ExportOffice(Page webPage, System.Web.UI.WebControls.WebControl webControl, string fileType, string fileName)
		{
			webPage.Response.Clear();
			webPage.Response.ClearHeaders();
			webPage.Response.Buffer = false;
			webPage.Response.Charset = "GB2312";
			webPage.Response.ContentEncoding = System.Text.Encoding.UTF8;
			webPage.Response.AppendHeader("Content-Disposition", "attachment;filename=" + HttpUtility.UrlEncode(fileName, Encoding.UTF8).ToString().Replace("+", "%20"));
			webPage.Response.ContentType = fileType;
			webPage.EnableViewState = false;
			StringWriter tw = new StringWriter();
			HtmlTextWriter hw = new HtmlTextWriter(tw);
			webControl.RenderControl(hw);
			webPage.Response.Write(tw.ToString());
			webPage.Response.End();
		}

		/// <summary>
		/// ����Office�ļ�Excel��Word�ļ�,HtmoTextWriter��ʽ,Office FileType("application/ms-word")("application/ms-excel")
		/// </summary>
		/// <param name="webPage">Web.Page,HtmoTextWriter��ʽ</param>
		/// <param name="table">Table���</param>
		/// <param name="fileType">Office FileType("application/ms-word")("application/ms-excel")</param>
		/// <param name="fileName">FileFullName</param>
		public void ExportOffice(Page webPage, DataTable table, string fileType, string fileName)
		{
			HttpResponse resp = webPage.Response;
			resp.Clear();
			resp.ClearHeaders();
			resp.Buffer = false;
			resp.Charset = "GB2312";
			resp.ContentEncoding = System.Text.Encoding.UTF8;
			//resp.ContentEncoding = System.Text.Encoding.GetEncoding("GBK");   
			resp.AppendHeader("Content-Disposition", "attachment;filename=" + HttpUtility.UrlEncode(fileName, Encoding.UTF8).ToString().Replace("+", "%20"));
			resp.ContentType = fileType;

			StringBuilder sb = new StringBuilder();
			//�����������ж��� 
			System.Data.DataTable dt = table;
			DataRow[] myRow = dt.Select();//��������dt.Select("id>10")֮��ʽ�ﵽ����ɸѡĿ��   
			int i = 0;
			int cl = dt.Columns.Count;

			//ȡ�����ݱ���б��⣬������֮����t�ָ���һ���б����ӻس���  
			sb.Append("<html ><meta http-equiv=\"content-type\" content=\"" + fileType + "; charset=UTF-8\"/><body><table border=\"1\" cellspacing=\"0\" cellpadding=\"2\"><tr>");
			//<html xmlns:x=\"urn:schemas-microsoft-com:office:excel\">
			for (i = 0; i < cl; i++)
			{
				//if (i == (cl - 1))//���һ�У���\n   
				//{   
				//    sb.Append("<th>"+dt.Columns[i].Caption.ToString() + "</th>");
				//}   
				//else  
				//{   
				sb.Append("<th>" + dt.Columns[i].Caption.ToString() + "</th>");
				//}   

			}
			sb.Append("</tr>");
			//resp.Write(colHeaders);   
			//��HTTP�������д��ȡ�õ�������Ϣ    

			//���д�������      
			foreach (DataRow row in myRow)
			{
				//��ǰ������д��HTTP������������ÿ�ls_item�Ա��������� 
				sb.Append("<tr>");
				for (i = 0; i < cl; i++)
				{
					decimal d;
					if (decimal.TryParse(row[i].ToString(), out d))
					{
						sb.Append("<td style=\"vnd.ms-excel.numberformat:@\">" + row[i].ToString() + "</td>");
					}
					else
					{
						sb.Append("<td>" + row[i].ToString() + "</td>");
					} 
					//if (i == (cl - 1))//���һ�У���\n   
					//{   
					//    sb.Append("<td>"+row[i].ToString() + "</td>");
					//}   
					//else  
					//{   
					//sb.Append("<td>" + row[i].ToString() + "</td>");
					//}   

				}
				sb.Append("</tr>");
				//resp.Write(ls_item);   
			}
			sb.Append("</table></body></html>");
			resp.Write(sb.ToString());
			resp.End();
		}

		/// <summary>
		/// ����Excel�ļ�,OleDb��ʽ
		/// </summary>
		/// <param name="gridView">GridView cell.Text, OleDb��ʽ</param>
		/// <param name="expFullPath">ExcelFileFullName</param>
		/// <param name="workSheetName">WorkSheetName</param>
		public void ExportXLS(System.Web.UI.WebControls.GridView gridView, string expFullPath, string workSheetName)
		{
			string strConn = " Provider = Microsoft.Jet.OLEDB.4.0;" + "Data Source = " + expFullPath + ";" +
			                 "Extended Properties ='Excel 8.0;HDR=No;'";
			using (OleDbConnection conn = new OleDbConnection(strConn))
			{
				try
				{
					conn.Open();
					using (OleDbCommand cmd = new OleDbCommand())
					{
						cmd.Connection = conn;
						string sql = "";
						for (int col = 0; col < gridView.Columns.Count; col++)
						{
							if (col != gridView.Columns.Count - 1)
							{
								sql += gridView.Columns[col].HeaderText + " char(255),";
							}
							else
							{
								sql += gridView.Columns[col].HeaderText + " char(255)";
							}
						}
						sql = " Create Table " + workSheetName + "(" + sql + ")";
						cmd.CommandText = sql;
						cmd.ExecuteNonQuery();

						for (int i = 0; i < gridView.Rows.Count; i++)
						{
							sql = "";
							for (int j = 0; j < gridView.Columns.Count; j++)
							{
								if (j != gridView.Columns.Count - 1)
								{
									sql += "'" + gridView.Rows[i].Cells[j].Text + "',";
								}
								else
								{
									sql += "'" + gridView.Rows[i].Cells[j].Text + "'";
								}
							}
							cmd.CommandText = "INSERT INTO [" + workSheetName + "$] VALUES(" + sql + ")";
							cmd.CommandText = cmd.CommandText.Replace("&nbsp;", " ");
							cmd.ExecuteNonQuery();
						}
					}
				}
				catch (System.Data.OleDb.OleDbException ex)
				{
					throw new Exception("����Excel��������" + ex.Message);
				}
				finally
				{
					if (conn.State != ConnectionState.Closed)
						conn.Close();
				}
			}
		}


		/// <summary> 
		/// ��ȡExcel�ĵ�,OleDb��ʽ
		/// </summary> 
		/// <param name="xlsFullPath">�ļ�����OleDb��ʽ</param> 
		/// <param name="workSheetNames">ExcelSheetNames</param>
		/// <returns>����һ�����ݼ�</returns> 
		public static System.Data.DataSet ImportXLS(string xlsFullPath, params string[] workSheetNames)
		{
			//Microsoft.ACE.OLEDB.12.0
			if (String.IsNullOrEmpty(xlsFullPath))
				throw new Exception("Please set ExcelFileFullName");
			string strConn = "Provider =Microsoft.Jet.OLEDB.4.0;" + "Data Source = " + xlsFullPath +
							 ";" + "Extended Properties ='Excel 8.0;HDR=No;IMEX=1;'";
			//Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\MyExcel.xls;Extended Properties="Excel 8.0;HDR=Yes;IMEX=1";
			System.Data.DataSet ds = null;
			using (OleDbConnection conn = new OleDbConnection(strConn))
			{
				try
				{
					conn.Open();
					string[] sqlStrs;
					if (workSheetNames == null || workSheetNames.Length == 0)
					{
						System.Data.DataTable tmpdt = conn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
						sqlStrs = new string[tmpdt.Rows.Count];
						int i = 0;
						foreach (DataRow dr in tmpdt.Rows)
						{
							sqlStrs[i] = String.Format("select * from [{0}]", dr["TABLE_NAME"].ToString());//A:IU ���� 500����
							i++;
						}
					}
					else
					{
						sqlStrs = new string[workSheetNames.Length];
						int i = 0;
						foreach (string sheetName in workSheetNames)
						{
							string tmpStr = sheetName;
							if (!tmpStr.Contains("$"))
								tmpStr = tmpStr + "$";
							sqlStrs[i] = String.Format("select * from [{0}]", tmpStr);
							i++;
						}
					}
					if (sqlStrs.Length == 0)
					{
						throw new Exception("Excel File's WorkSheet Count is none");
					}

					ds = new System.Data.DataSet();
					using (OleDbDataAdapter myDa = new OleDbDataAdapter())//;sb.ToString(), strConn))
					{
						using (OleDbCommand cmd = conn.CreateCommand())
						{
							foreach (string sql in sqlStrs)
							{
								cmd.CommandText = sql;
								myDa.SelectCommand = cmd;
								System.Data.DataTable dt = new System.Data.DataTable();
								myDa.Fill(dt);
								ds.Tables.Add(dt);
							}
						}
					}
				}
				finally
				{
					if (conn.State != ConnectionState.Closed)
						conn.Close();
				}
			}
			return ds;
		}

      
	}
}
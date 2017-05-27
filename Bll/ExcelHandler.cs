using NPOI.HPSF;
using NPOI.HSSF;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Text;

namespace Bll
{
    public class ExcelHandler
    {

        private void InitializeWorkbook(HSSFWorkbook workbook)
        {
            DocumentSummaryInformation dsi = PropertySetFactory.CreateDocumentSummaryInformation();
            dsi.Company = "深圳畅泊智能停车场有限公司";
            workbook.DocumentSummaryInformation = dsi;
            ////create a entry of SummaryInformation
            SummaryInformation si = PropertySetFactory.CreateSummaryInformation();
            si.Subject = "记录导出";
            si.Title = "记录导出";
            si.Author = "深圳畅泊";
            workbook.SummaryInformation = si;

        }

        /// <summary>
        /// 將DataTable轉成Stream輸出.
        /// </summary>
        /// <param name="SourceTable">The source table.</param>
        /// <returns></returns>
        public Stream RenderDataTableToExcel(DataTable SourceTable, string title)
        {
            HSSFWorkbook workbook = new HSSFWorkbook();
            InitializeWorkbook(workbook);
            MemoryStream ms = new MemoryStream();
            ISheet sheet = workbook.CreateSheet();
            //合并单元格
            sheet.AddMergedRegion(new NPOI.SS.Util.CellRangeAddress(0, 0, 0, 8));
            //设置标题的样式
            IRow titlerow = sheet.CreateRow(0);
            ICellStyle style = workbook.CreateCellStyle();
            style.Alignment = NPOI.SS.UserModel.HorizontalAlignment.Center;
            style.VerticalAlignment = NPOI.SS.UserModel.VerticalAlignment.Center;
            IFont font = workbook.CreateFont();
            font.FontHeightInPoints = 25;
            style.SetFont(font);
            titlerow.CreateCell(0).SetCellValue(title);
            titlerow.GetCell(0).CellStyle = style;
            //设置时间格式
            ICellStyle datetimestyle = workbook.CreateCellStyle();
            datetimestyle.DataFormat = workbook.CreateDataFormat().GetFormat("yyyy-MM-dd HH:mm:ss");

            IRow headerRow = sheet.CreateRow(1);

            // handling header.
            foreach (DataColumn column in SourceTable.Columns)
            {
                if (column.DataType == typeof(DateTime))
                    sheet.SetColumnWidth(column.Ordinal, 5120);
                headerRow.CreateCell(column.Ordinal).SetCellValue(column.ColumnName);
            }

            // handling value.
            int rowIndex = 2;
            object obj;
            foreach (DataRow row in SourceTable.Rows)
            {
                IRow dataRow = sheet.CreateRow(rowIndex);

                foreach (DataColumn column in SourceTable.Columns)
                {
                    obj = row[column];
                    if (column.DataType == typeof(double))
                    {
                        if (obj == DBNull.Value)
                            obj = 0.0;
                        dataRow.CreateCell(column.Ordinal).SetCellValue((double)obj);
                    }
                    else if (column.DataType == typeof(DateTime))
                    {
                        dataRow.CreateCell(column.Ordinal).SetCellValue((DateTime)obj);
                        dataRow.GetCell(column.Ordinal).CellStyle = datetimestyle;
                    }
                    else
                        dataRow.CreateCell(column.Ordinal).SetCellValue(obj.ToString());
                }

                rowIndex++;
            }

            workbook.Write(ms);
            ms.Flush();
            ms.Position = 0;

            sheet = null;
            headerRow = null;
            workbook = null;

            return ms;
        }

        /// <summary>
        /// 將DataTable資料輸出成檔案.
        /// </summary>
        /// <param name="SourceTable">The source table.</param>
        /// <param name="FileName">Name of the file.</param>
        public void RenderDataTableToExcel(DataTable SourceTable, string title, string FileName)
        {
            MemoryStream ms = RenderDataTableToExcel(SourceTable, title) as MemoryStream;
            WriteSteamToFile(ms, FileName);
        }

        private void WriteSteamToFile(MemoryStream ms, string FileName)
        {
            FileStream fs = new FileStream(FileName, FileMode.Create, FileAccess.Write);
            byte[] data = ms.ToArray();

            fs.Write(data, 0, data.Length);
            fs.Flush();
            fs.Close();

            data = null;
            ms = null;
            fs = null;
        }


        /// <summary>
        /// 從位元流讀取資料到DataTable.
        /// </summary>
        /// <param name="ExcelFileStream">The excel file stream.</param>
        /// <param name="SheetName">Name of the sheet.</param>
        /// <param name="HeaderRowIndex">Index of the header row.</param>
        /// <param name="HaveHeader">if set to <c>true</c> [have header].</param>
        /// <returns></returns>
        public DataTable RenderDataTableFromExcel(Stream ExcelFileStream, string SheetName, int HeaderRowIndex, bool HaveHeader)
        {
            HSSFWorkbook workbook = new HSSFWorkbook(ExcelFileStream);
            ISheet sheet = workbook.GetSheet(SheetName);

            DataTable table = new DataTable();

            IRow headerRow = sheet.GetRow(HeaderRowIndex);
            int cellCount = headerRow.LastCellNum;

            for (int i = headerRow.FirstCellNum; i < cellCount; i++)
            {
                string ColumnName = (HaveHeader == true) ? headerRow.GetCell(i).StringCellValue : "f" + i.ToString();
                DataColumn column = new DataColumn(ColumnName);
                table.Columns.Add(column);
            }

            int rowCount = sheet.LastRowNum;
            int RowStart = (HaveHeader == true) ? sheet.FirstRowNum + HeaderRowIndex + 1 : sheet.FirstRowNum;
            for (int i = RowStart; i <= sheet.LastRowNum; i++)
            {
                IRow row = sheet.GetRow(i);
                DataRow dataRow = table.NewRow();

                for (int j = row.FirstCellNum; j < cellCount; j++)
                    dataRow[j] = row.GetCell(j).ToString();
                table.Rows.Add(dataRow);
            }

            ExcelFileStream.Close();
            workbook = null;
            sheet = null;
            return table;
        }

    }
}

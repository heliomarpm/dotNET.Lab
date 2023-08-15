//using ClosedXML.Excel;

namespace Sample.UsandoClosedXml
{
    /*
     public class DadosCalculoExcel
        {
            private static DadosCalculoExcel _dados = new DadosCalculoExcel();
            private static Dictionary<int, XLWorkbook> _workbooks = new Dictionary<int, XLWorkbook>();

            public static DadosCalculoExcel Intance
            {
                get
                {
                    return _dados;
                }
            }

            public void Novo(int hashCode)
            {
                if (_workbooks.ContainsKey(hashCode))
                    _workbooks.Remove(hashCode);

                XLWorkbook workbook = new XLWorkbook();
                _workbooks.Add(hashCode, workbook);
            }

            public void Adicionar<T>(int hashCode, string sheetName, string nomeColuna, XLCellValues tipoColuna, T param)
            {
                IXLWorksheet worksheet = GetWorkSheet(hashCode, sheetName);

                if (worksheet != null)
                {
                    int rowsCount = worksheet.Rows().Count() + 1;

                    worksheet.Cell(rowsCount, 1).Value = nomeColuna.Replace((char)(0x1F), ' ');
                    worksheet.Cell(rowsCount, 1).DataType = XLCellValues.Text;
                    worksheet.Cell(rowsCount, 1).Style.Font.Bold = true;
                    worksheet.Cell(rowsCount, 1).WorksheetColumn().AdjustToContents();

                    if (param != null)
                    {
                        worksheet.Cell(rowsCount, 2).Value = param;
                        worksheet.Cell(rowsCount, 2).DataType = tipoColuna;
                        worksheet.Cell(rowsCount, 2).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Right;
                        worksheet.Cell(rowsCount, 2).WorksheetColumn().AdjustToContents();
                    }
                }
            }

            public void Adicionar<T>(int hashCode, string sheetName, string nomeColuna, XLCellValues tipoColuna, IEnumerable<T> lista)
            {
                IXLWorksheet worksheet = GetWorkSheet(hashCode, sheetName);

                if (worksheet != null)
                {
                    int columnsCount = worksheet.Columns().Count() + 1;

                    worksheet.Cell(1, columnsCount).Value = nomeColuna.Replace((char)(0x1F), ' ');
                    worksheet.Cell(1, columnsCount).DataType = XLCellValues.Text;
                    worksheet.Cell(1, columnsCount).Style.Font.Bold = true;

                    if (lista != null)
                    {
                        worksheet.Cell(2, columnsCount).DataType = tipoColuna;
                        worksheet.Cell(2, columnsCount).InsertData(lista);
                    }

                    worksheet.Column(columnsCount).AdjustToContents();
                }
            }

            public void Close(int hashCode)
            {
                if (_workbooks.ContainsKey(hashCode))
                {
                    XLWorkbook workbook = _workbooks[hashCode];

                    workbook.Dispose();

                    _workbooks.Remove(hashCode);
                }
            }

            private IXLWorksheet GetWorkSheet(int hashCode, string sheetName)
            {
                XLWorkbook workbook = null;
                IXLWorksheet worksheet = null;

                if (_workbooks.ContainsKey(hashCode))
                {
                    workbook = _workbooks[hashCode];

                    if (!workbook.Worksheets.TryGetWorksheet(sheetName, out worksheet))
                    {
                        worksheet = workbook.Worksheets.Add(sheetName);
                    }
                }

                return worksheet;
            }

            public XLWorkbook GeWorkbook(int hashCode)
            {
                XLWorkbook workbook = null;

                if (_workbooks.ContainsKey(hashCode))
                {
                    workbook = _workbooks[hashCode];
                }

                return workbook;
            }

            public byte[] Save(int hashCode)
            {
                XLWorkbook workbook = GeWorkbook(hashCode);
                byte[] bytes = null;

                if (workbook != null)
                {
                    MemoryStream stream = new MemoryStream();

                    workbook.SaveAs(stream);

                    bytes = stream.ToArray();

                    stream.Dispose();
                    stream.Close();
                }

                return bytes;
            }

            public void Save(int hashCode, string fileName)
            {
                XLWorkbook workbook = GeWorkbook(hashCode);

                if (workbook != null)
                {
                    FileStream stream = File.Create(fileName);
                    workbook.SaveAs(stream);
                    stream.Dispose();
                    stream.Close();
                }
            }
        }
     */
}

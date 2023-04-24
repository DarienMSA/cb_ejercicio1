using cb_ejercicio1.Models;
using ClosedXML.Excel;
using cb_ejercicio1.Data;
using DocumentFormat.OpenXml.Spreadsheet;
using Irony.Parsing;
using Microsoft.AspNetCore.Mvc;
using DocumentFormat.OpenXml.Drawing.Charts;
using Microsoft.EntityFrameworkCore;

namespace cb_ejercicio1.Logic
{
    public class ToExcel
    {
        private XLWorkbook _wb;
        private IXLWorksheet _worksheet;

        public ToExcel(string name)
        {
            _wb = new XLWorkbook();
            _worksheet = _wb.Worksheets.Add(name);
        }
        public byte[] CbcReglaInconsistenciaToExcel(List<CbcReglaInconsistencia> Rules)
        {

            var regla = new CbcReglaInconsistencia();
            var row = _worksheet.Row(1);
            row.Cell(1).Value = nameof(regla.ReglaId);
            row.Cell(2).Value = nameof(regla.TipoRegla);
            row.Cell(3).Value = nameof(regla.Regla);

            int rowIndex = 2;

            foreach (var rule in Rules)
            {
                row = _worksheet.Row(rowIndex);
                row.Cell(1).Value = rule.ReglaId;
                row.Cell(2).Value = rule.TipoRegla;
                row.Cell(3).Value = rule.Regla;

                rowIndex++;
            }
            using (var stream = new MemoryStream())
            {
                _wb.SaveAs(stream);
                byte[] content = stream.ToArray();

                return content;
            }
        }
    }
}

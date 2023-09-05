using System.Text;
using PdfSharpCore;
using PdfSharpCore.Pdf;
using TheArtOfDev.HtmlRenderer.PdfSharp;

public static class PdfHelper
{
	public static byte[]? GenerateHtmlPdf(string[] columns, Dictionary<string, string> rows)
	{
		using MemoryStream ms = new();
		var document = new PdfDocument();
 		PdfGenerator.AddPdfPages(document, GenerateHtml(columns, rows), PageSize.A4);
		document.Save(ms);
		return ms.ToArray();
	}

	private static string GenerateHtml(string[] columns, Dictionary<string, string> rows)
	{
		var stringBuilder = new StringBuilder();

		stringBuilder.Append("<table style=\"border-collapse: collapse;width:100%;\">");

		if (columns.Length > 0)
		{
			stringBuilder.Append("<tr>");

			foreach (var column in columns)
			{
				stringBuilder
					.Append("<th style=\"border: 1px solid black;\">")
					.Append(column)
					.Append("</th>");
			}

			stringBuilder.Append("</tr>");
		}

		if (columns.Length > 0)
		{
			foreach (var (rowKey, rowValue) in rows)
			{
				stringBuilder
					.Append("<tr>")
					.Append("<td style=\"border: 1px solid black;\">")
					.Append(rowKey)
					.Append("</td>")
					.Append("<td style=\"border: 1px solid black;\">")
					.Append(rowValue)
					.Append("</td>")
					.Append("</tr>");
			}
		}

		stringBuilder.Append("</table>");

		return stringBuilder.ToString();
	}
}

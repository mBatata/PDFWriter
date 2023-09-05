try
{
	var headers = new string[] { "Question", "Answer" };
	var rows = new Dictionary<string, string>()
	{
		{ "Question 1", "Answer 1" },
		{ "Question 2" , "<b style=\"font-size: 25px;\">Answer 2</b>"}
	};
	
	var fileData = PdfHelper.GenerateHtmlPdf(headers, rows) ?? throw new NullReferenceException("File not generated!");

	File.WriteAllBytes("PdfFile.pdf", fileData);
	
	Console.WriteLine("GENERATED!");
}
catch (Exception ex)
{
	Console.WriteLine("ERROR!");
	Console.WriteLine(ex.Message);
}

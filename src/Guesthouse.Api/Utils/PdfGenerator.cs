using System;
using System.Globalization;
using System.Threading.Tasks;
using Guesthouse.Core.Repositories;
using Guesthouse.Infrastructure.Extensions;
using HandlebarsDotNet;
using IronPdf;

namespace Guesthouse.Api.Utils
{
    public static class PdfGenerator
    {
        public async static Task Generate(Guid id, IUnitOfWork unitOfWork)
        {
            var invoice = await unitOfWork.InvoiceRepository.GetOrFailAsync(id);
            
            var source = @"<div class=""entry"">
                            <h1>Your reservation</h1>
                            <h2>{{title}}</h2>
                                <div class=""body"" >
                                    <br/>
                                    <h4>{{description}}</h3>
                                    <h4>{{company}}</h3>
                                    <h4>{{client}}</h3>
                                    <h4>{{employee}}</h3>
                                    <h4>{{issue}}</h3>
                                    <h4>{{pay}}</h3>
                                    <h4>{{charge}}</h3>
                                </div>
                            </div>";
            
            var template = Handlebars.Compile(source);

            var data = new
            {
                title = $"{invoice.ReservationId}",
                description = $"Description: {invoice.ReservationDescription}",
                company = $"Company name: {invoice.CompanyName}",
                client = $"Client: {invoice.ClientName}",
                employee = $"Employee: {invoice.EmployeeName}",
                issue = $"Issue: {invoice.IssueDate.ToString("dd-MM-yyyy", CultureInfo.InvariantCulture)}",
                pay = $"Pay to: {invoice.PayDate.Date.ToString("dd-MM-yyyy", CultureInfo.InvariantCulture)}",
                charge = $"Charge: {invoice.MoneyToPay}"
            };

            var result = template(data);
            
            var renderer = new HtmlToPdf();
            
            renderer.RenderHtmlAsPdf(result).SaveAs(@"Asserts\html-string.pdf");
            
        }
    }
}
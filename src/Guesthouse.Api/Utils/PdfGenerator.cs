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
            
            var source = @"<!doctype html>
                            <html>
                            <head>
                                <meta charset=""utf-8"">
                                <title>A simple, clean, and responsive HTML invoice template</title>
                                
                                <style>
                                .invoice-box {
                                    max-width: 800px;
                                    margin: auto;
                                    padding: 30px;
                                    border: 1px solid #eee;
                                    box-shadow: 0 0 10px rgba(0, 0, 0, .15);
                                    font-size: 16px;
                                    line-height: 24px;
                                    font-family: 'Helvetica Neue', 'Helvetica', Helvetica, Arial, sans-serif;
                                    color: #555;
                                }
                                
                                .invoice-box table {
                                    width: 100%;
                                    line-height: inherit;
                                    text-align: left;
                                }
                                
                                .invoice-box table td {
                                    padding: 5px;
                                    vertical-align: top;
                                }
                                
                                .invoice-box table tr td:nth-child(2) {
                                    text-align: right;
                                }
                                
                                .invoice-box table tr.top table td {
                                    padding-bottom: 20px;
                                }
                                
                                .invoice-box table tr.top table td.title {
                                    font-size: 45px;
                                    line-height: 45px;
                                    color: #333;
                                }
                                
                                .invoice-box table tr.information table td {
                                    padding-bottom: 40px;
                                }
                                
                                .invoice-box table tr.heading td {
                                    background: #eee;
                                    border-bottom: 1px solid #ddd;
                                    font-weight: bold;
                                }
                                
                                .invoice-box table tr.details td {
                                    padding-bottom: 20px;
                                }
                                
                                .invoice-box table tr.item td{
                                    border-bottom: 1px solid #eee;
                                }
                                
                                .invoice-box table tr.item.last td {
                                    border-bottom: none;
                                }
                                
                                .invoice-box table tr.total td:nth-child(2) {
                                    border-top: 2px solid #eee;
                                    font-weight: bold;
                                }
                                
                                @media only screen and (max-width: 600px) {
                                    .invoice-box table tr.top table td {
                                        width: 100%;
                                        display: block;
                                        text-align: center;
                                    }
                                    
                                    .invoice-box table tr.information table td {
                                        width: 100%;
                                        display: block;
                                        text-align: center;
                                    }
                                }
                                
                                /** RTL **/
                                .rtl {
                                    direction: rtl;
                                    font-family: Tahoma, 'Helvetica Neue', 'Helvetica', Helvetica, Arial, sans-serif;
                                }
                                
                                .rtl table {
                                    text-align: right;
                                }
                                
                                .rtl table tr td:nth-child(2) {
                                    text-align: left;
                                }
                                </style>
                            </head>
                            
                            <body>
                                <div class=""invoice-box"">
                                    <table cellpadding=""0"" cellspacing=""0"">
                                        <tr class=""top"">
                                            <td colspan=""2"">
                                                <table>
                                                    <tr>
                                                        <td class=""title"">
                                                            
                                                        </td>
                                                        
                                                        <td>
                                                            Invoice #: {{invoiceId}}<br>
                                                            Created: {{issue}}<br>
                                                            Due: {{pay}}
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        
                                        <tr class=""information"">
                                            <td colspan=""2"">
                                                <table>
                                                    <tr>
                                                        <td>
                                                            {{company}}<br>
                                                            {{employee}}
                                                        </td>
                                                        
                                                        <td>
                                                            {{client}}
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        
                                        <tr class=""heading"">
                                            <td>
                                                Payment Method
                                            </td>
                                            
                                            <td>
                                                Check #
                                            </td>
                                        </tr>
                                        
                                        <tr class=""details"">
                                            <td>
                                                Check
                                            </td>
                                            
                                            <td>
                                                1000
                                            </td>
                                        </tr>
                                        
                                        <tr class=""heading"">
                                            <td>Reservation</td>
                                            <td>Description</td>
                                        </tr>
                                        
                                        <tr class=""item"">
                                            <td>{{title}}</td>
                                            <td>{{description}}</td>
                                        </tr>
                                       <tr class=""total"">
                                            <td></td>
                                            
                                            <td>
                                                Total: {{charge}}
                                            </td>
                                       </tr>
                                    </table>
                                </div>
                            </body>
                            </html>";
            
            /*var source = @"
                        <html>
                            <head>
                            <style>
                                .header {
                                    color: green;
                                    padding-bottom: 35px;
                                }
                                 
                                table {
                                    width: 100%;
                                    border-collapse: collapse;
                                }
                                 
                                td, th {
                                    border: 1px solid gray;
                                    padding: 15px;
                                    font-size: 20px;
                                    text-align: center;
                                }
                                 
                                table th {
                                    background-color: green;
                                    color: white;
                                }
                            </style>
                            </head>
                            <body>
                                <div class='header'>
                                    <h1>Your reservation</h1>
                                    <h2>{{title}}</h2>
                                </div>
                                <table align='center'>
                                    <tr>
                                        <th>Description</th>
                                        <th>Client</th>
                                        <th>Employee</th>
                                        <th>Issue</th>
                                        <th>Pay to</th>
                                        <th>Charge</th>
                                    </tr>
                                    <tr>
                                        <td>{{description}}</td>
                                        <td>{{client}}</td>
                                        <td>{{employee}}</td>
                                        <td>{{issue}}</td>
                                        <td>{{pay}}</td>
                                        <td>{{charge}}</td>
                                  </tr>
                                </table>
                            </body>
                        </html>";*/
            
            var template = Handlebars.Compile(source);

            /*var data = new
            {
                title = $"{invoice.ReservationId}",
                description = $"Description: {invoice.ReservationDescription}",
                company = $"Company name: {invoice.CompanyName}",
                client = $"Client: {invoice.ClientName}",
                employee = $"Employee: {invoice.EmployeeName}",
                issue = $"Issue: {invoice.IssueDate.ToString("dd-MM-yyyy", CultureInfo.InvariantCulture)}",
                pay = $"Pay to: {invoice.PayDate.Date.ToString("dd-MM-yyyy", CultureInfo.InvariantCulture)}",
                charge = $"Charge: {invoice.MoneyToPay}"
            };*/
            
            var data = new
            {
                invoiceId = invoice.Id,
                title = invoice.ReservationId,
                description = invoice.ReservationDescription,
                company = invoice.CompanyName,
                client = invoice.ClientName,
                employee = invoice.EmployeeName,
                issue = invoice.IssueDate.ToString("dd-MM-yyyy", CultureInfo.InvariantCulture),
                pay = invoice.PayDate.Date.ToString("dd-MM-yyyy", CultureInfo.InvariantCulture),
                charge = invoice.MoneyToPay
            };

            var result = template(data);
            
            var renderer = new HtmlToPdf();
            renderer.RenderHtmlAsPdf(result).SaveAs($@"Asserts\invoice{invoice.Id}.pdf");
            
            invoice.SetPdfPath($@"Asserts\invoice{invoice.Id}.pdf");
            await unitOfWork.InvoiceRepository.UpdateAsync(invoice);
            await unitOfWork.Complete();
        }
    }
}
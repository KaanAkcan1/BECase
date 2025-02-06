namespace BECase.Business.Models.Requests.Invoice
{
    public class GetInvoiceListRequestDto
    {
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
    }
}

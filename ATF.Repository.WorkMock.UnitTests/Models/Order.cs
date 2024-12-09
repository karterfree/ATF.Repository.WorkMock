namespace ATF.Repository.WorkMock.UnitTests.Models;

using ATF.Repository.Attributes;

[Schema("Order")]
public class Order: BaseModel
{
	[SchemaProperty("Number")]
	public string Number { get; set; }
	
	[LookupProperty("Account")]
	public virtual Account Account { get; set; }

	[SchemaProperty("Date")]
	public DateTime Date { get; set; }
	
	[LookupProperty("Owner")]
	public virtual Contact Owner { get; set; }
	
	[SchemaProperty("Status")]
	public Guid StatusId { get; set; }
	
	[SchemaProperty("PaymentStatus")]
	public Guid PaymentStatusId { get; set; }
	
	[SchemaProperty("Contact")]
	public Guid ContactId { get; set; }

	[LookupProperty("Contact")]
	public virtual Contact Contact { get; set; }
	
	[SchemaProperty("DueDate")]
	public DateTime DueDate { get; set; }
	
	[SchemaProperty("ActualDate")]
	public DateTime ActualDate { get; set; }
	
	[SchemaProperty("CurrencyRate")]
	public decimal CurrencyRate { get; set; }
	
	[SchemaProperty("Amount")]
	public decimal Amount { get; set; }
	
	[SchemaProperty("Notes")]
	public string Notes { get; set; }
	
	[LookupProperty("CustomerBillingInfo")]
	public virtual AccountBillingInfo CustomerBillingInfo { get; set; }
	
	[LookupProperty("SupplierBillingInfoLic")]
	public virtual AccountBillingInfo SupplierBillingInfoLic { get; set; }
	
	[LookupProperty("SupplierBillingInfoSer")]
	public virtual AccountBillingInfo SupplierBillingInfoSer { get; set; }
	
	[LookupProperty("Currency")]
	public virtual Currency Currency { get; set; }
	
	[LookupProperty("FixCurrency")]
	public virtual Currency FixCurrency { get; set; }
	
	[SchemaProperty("FixCurrencyRate")]
	public decimal FixCurrencyRate { get; set; }
	
	[SchemaProperty("IsFixRate")]
	public bool IsFixRate { get; set; }
	
	[SchemaProperty("IsApproved")]
	public bool IsApproved { get; set; }
	
	[SchemaProperty("FixedExchangeRate")]
	public int FixedExchangeRate { get; set; }

	[DetailProperty("OrderId")]
	public virtual List<OrderProduct> OrderProducts { get; set; }
}
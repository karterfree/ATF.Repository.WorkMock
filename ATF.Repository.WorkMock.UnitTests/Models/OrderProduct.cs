namespace ATF.Repository.WorkMock.UnitTests.Models;

using ATF.Repository.Attributes;

[Schema("OrderProduct")]
public class OrderProduct: BaseModel
{
	[SchemaProperty("Order")]
	public Guid OrderId { get; set; }
	
	[SchemaProperty("Name")]
	public string Name { get; set; }
	
	[SchemaProperty("Product")]
	public Guid ProductId { get; set; } 
	
	[SchemaProperty("Quantity")]
	public decimal Quantity { get; set; }
	
	[SchemaProperty("Price")]
	public decimal Price { get; set; }
	
	[SchemaProperty("Amount")]
	public decimal Amount { get; set; }
	
	[SchemaProperty("DiscountAmount")]
	public decimal DiscountAmount { get; set; }

}
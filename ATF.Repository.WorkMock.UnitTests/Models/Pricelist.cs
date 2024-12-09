namespace ATF.Repository.WorkMock.UnitTests.Models;

using ATF.Repository.Attributes;

[Schema("Pricelist")]
public class Pricelist: BaseModel
{
	[SchemaProperty("Name")]
	public string Name { get; set; }
	
	[SchemaProperty("Description")]
	public string Description { get; set; }
	
	[SchemaProperty("IsBase")]
	public bool IsBase { get; set; }
	
	[LookupProperty("Currency")]
	public virtual Currency Currency { get; set; }
	
	[SchemaProperty("Territory")]
	public Guid TerritoryId { get; set; }
}
namespace ATF.Repository.WorkMock.UnitTests.Models;

using ATF.Repository.Attributes;

[Schema("AccountBillingInfo")]
public class AccountBillingInfo: BaseModel
{
	[SchemaProperty("Name")]
	public string Name { get; set; }
	
	[SchemaProperty("Description")]
	public string Description { get; set; }
	
	[LookupProperty("Account")]
	public virtual Account Account { get; set; }
	
	[LookupProperty("Country")]
	public virtual Country Country { get; set; }
	
	[LookupProperty("Region")]
	public virtual Country Region { get; set; }
	
	[LookupProperty("City")]
	public virtual City City { get; set; }
	
	[SchemaProperty("LegalAddress")]
	public string LegalAddress { get; set; }

}
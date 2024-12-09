namespace ATF.Repository.WorkMock.UnitTests.Models;

using ATF.Repository.Attributes;

[Schema("Account")]
public class Account: BaseModel
{
	[SchemaProperty("Name")]
	public string Name { get; set; }
	
	[LookupProperty("Owner")]
	public virtual Contact Owner { get; set; }
	
	[LookupProperty("PrimaryContact")]
	public virtual Contact PrimaryContact { get; set; }
	
	[SchemaProperty("Industry")]
	public Guid IndustryId { get; set; }
	
	[SchemaProperty("Type")]
	public Guid TypeId { get; set; }
	
	[SchemaProperty("Phone")]
	public string Phone { get; set; }
	
	[SchemaProperty("ExactNoOfEmployees")]
	public int ExactNoOfEmployees { get; set; }

}
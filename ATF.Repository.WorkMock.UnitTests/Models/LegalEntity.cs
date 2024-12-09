namespace ATF.Repository.WorkMock.UnitTests.Models;

using ATF.Repository.Attributes;

[Schema("LegalEntity")]
public class LegalEntity: BaseModel
{

	[SchemaProperty("Name")]
	public string Name { get; set; }
	
	[SchemaProperty("CompanyNumber")]
	public string CompanyNumber { get; set; }
	
	[LookupProperty("Account")]
	public virtual Account Account { get; set; }

	[LookupProperty("LegalAddress")]
	public virtual LegalAddress LegalAddress { get; set; }
	
	[SchemaProperty("VATPayer")]
	public Guid VATPayerId { get; set; }
	
	[SchemaProperty("VATID")]
	public string VATID { get; set; }
	
	[SchemaProperty("ValidationStatus")]
	public Guid ValidationStatusId { get; set; }
	
	[SchemaProperty("LegalEntityStatus")]
	public Guid LegalEntityStatusId { get; set; }

}
using ATF.Repository.Mock;
using FluentAssertions;
using NUnit.Framework;

namespace ATF.Repository.WorkMock.UnitTests;

using ATF.Repository.WorkMock.UnitTests.Models;

[TestFixture]
public class DataStoreExtensionUnitTests
{

	private MemoryDataProviderMock _dataProviderMock;
	private IAppDataContext _appDataContext;

	[SetUp]
	public void SetUp() {
		_dataProviderMock = new MemoryDataProviderMock();
		_dataProviderMock.DataStore.RegisterModelSchema<Order>();
		_appDataContext = AppDataContextFactory.GetAppDataContext(_dataProviderMock);
	}

	[Test]
	public void LoadDataFromExportedFile_WhenCallWithEmptyPath_ShouldThrowException() {
		var e = Assert.Throws<ArgumentException>(() => {
			_dataProviderMock.DataStore.LoadDataFromExportedFile(string.Empty);
		});
		e?.ParamName.Should().BeEquivalentTo("path");
	}

	[Test]
	public void LoadDataFromExportedFile_WhenCallWithWrongPath_ShouldThrowException() {
		var path = Path.Combine(Directory.GetCurrentDirectory(), "TestFiles", "test.test.ts");
		var e = Assert.Throws<ArgumentException>(() => {
			_dataProviderMock.DataStore.LoadDataFromExportedFile(path);
		});
		e?.ParamName.Should().BeEquivalentTo("path");
	}
	
	[Test]
	public void LoadDataFromExportedFile_WhenCallWithEmptyFile_ShouldThrowException() {
		var path = Path.Combine(Directory.GetCurrentDirectory(), "TestFiles", "data-export-empty.json");
		Assert.Throws<FormatException>(() => {
			_dataProviderMock.DataStore.LoadDataFromExportedFile(path);
		});
	}
	
	[Test]
	public void LoadDataFromExportedFile_WhenCallWithWrongFileContent_ShouldThrowException() {
		var path = Path.Combine(Directory.GetCurrentDirectory(), "TestFiles", "data-export-wrong-file-content.json");
		Assert.Throws<FormatException>(() => {
			_dataProviderMock.DataStore.LoadDataFromExportedFile(path);
		});
	}
	
	[Test]
	public void LoadDataFromExportedFile_WhenCallWithEmptyPrimaryValue_ShouldThrowException() {
		var path = Path.Combine(Directory.GetCurrentDirectory(), "TestFiles", "data-export-empty-primary-value.json");
		Assert.Throws<FormatException>(() => {
			_dataProviderMock.DataStore.LoadDataFromExportedFile(path);
		});
	}
	
	[Test]
	public void LoadDataFromExportedFile_WhenCallWithCorrectData_ShouldFillDataStore() {
		var path = Path.Combine(Directory.GetCurrentDirectory(), "TestFiles", "data-export-correct-data.json");

		//Act
		_dataProviderMock.DataStore.LoadDataFromExportedFile(path);

		// Assert
		var orderId = new Guid("492a3290-6a17-49b2-b916-2995ac193a3b");
		var model = _appDataContext.GetModel<Order>(orderId);
		model.Should().NotBeNull();
		model.Account.Should().NotBeNull();
		model.OrderProducts.Should().NotBeNull();
		model.OrderProducts.All(x=>x.OrderId == orderId).Should().BeTrue();
	}
}
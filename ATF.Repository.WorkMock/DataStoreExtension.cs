using System;

namespace ATF.Repository.WorkMock
{
	using System.Collections.Generic;
	using System.IO;
	using Newtonsoft.Json;
	using Terrasoft.Common;
	using Terrasoft.Core.Store;
	using Terrasoft.Nui.ServiceModel.Extensions;
	using IDataStore = ATF.Repository.Mock.IDataStore;

	internal class StoreDataDto
	{
		
		public List<StoreDataItemDto> Items { get; set; }

	}

	internal class StoreDataItemDto
	{

		public string Id { get; set; }
		public string SchemaName { get; set; }
		public Dictionary<string, object> Content { get; set; }
		public string Path { get; set; }

	}

	internal static class ExportedFileImporter
	{

		private static StoreDataDto GetStoreDataDto(string path) {
			if (string.IsNullOrEmpty(path)) {
				throw new ArgumentException("Path should be filled", nameof(path));
			}
			if (!File.Exists(path)) {
				throw new ArgumentException("Path not exists", nameof(path));
			}
			
			var fileContent = File.ReadAllText(path);
			var dto = JsonConvert.DeserializeObject<StoreDataDto>(fileContent);
			if (dto?.Items is null) {
				throw new FormatException($"Cannot convert file {path} to transferred DTO");
			}
			return dto;
		}

		private static void Import(IDataStore store, StoreDataDto dto) {
			dto.Items?.ForEach(x=>ImportItem(store, x));
		}

		private static void ImportItem(IDataStore store, StoreDataItemDto itemDto) {
			if (!Guid.TryParse(itemDto.Id, out var guidValue)) {
				throw new FormatException(
					$"Cannot import {itemDto.SchemaName} record because empty PrimaryColumn value");
			}
			store.AddModelRawData(itemDto.SchemaName, new List<Dictionary<string, object>>() {itemDto.Content});
		}


		public static void Import(IDataStore store, string path) {
			var dto = GetStoreDataDto(path);
			Import(store, dto);
		}

	}
	
	public static class DataStoreExtension
	{

		public static void LoadDataFromExportedFile(this IDataStore store, string path) {
			ExportedFileImporter.Import(store, path);
		}

	}
}
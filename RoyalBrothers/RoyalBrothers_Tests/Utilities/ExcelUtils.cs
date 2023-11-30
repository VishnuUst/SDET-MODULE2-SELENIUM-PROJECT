using ExcelDataReader;
using Microsoft.CodeAnalysis;
using RoyalBrothers_Tests.Utilities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoneyAndSpice_Tests.Utilities
{
    
    internal class ExcelUtils
    {
        public static List<SearchVehicleData> ReadExcelData(string excelFilePath,string sheetName)
        {
            List<SearchVehicleData> searchRoomDatas = new List<SearchVehicleData>();
            Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
            using (var stream = new FileStream(excelFilePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))

            {

                using (var reader = ExcelReaderFactory.CreateReader(stream))

                {

                    var result = reader.AsDataSet(new ExcelDataSetConfiguration()

                    {

                        ConfigureDataTable = (_) => new ExcelDataTableConfiguration()

                        {

                            UseHeaderRow = true,

                        }

                    });



                    var dataTable = result.Tables[sheetName];



                    if (dataTable != null)

                    {

                        foreach (DataRow row in dataTable.Rows)

                        {

                            SearchVehicleData excelData = new SearchVehicleData

                            {

                                City = GetValueOrDefault(row, "city"),
                                PickupDate = GetValueOrDefault(row, "checkInDate"),
                                PickupTime = GetValueOrDefault(row, "checkInTime"),
                                DropoffDate = GetValueOrDefault(row,"checkOutDate"),
                                DroppoffTime = GetValueOrDefault(row,"checkOutTime"),
                                Location = GetValueOrDefault(row,"location"),
                                Id = GetValueOrDefault(row, "id"),
                                Name = GetValueOrDefault(row, "name"),
                                Email = GetValueOrDefault(row, "email"),
                                Mobile = GetValueOrDefault(row,"phone"),
                                Password = GetValueOrDefault(row, "password"),



                                

                                

                            };



                            searchRoomDatas.Add(excelData);

                        }

                    }

                    else

                    {

                        Console.WriteLine($"Sheet '{sheetName}' not found in the Excel file.");

                    }

                }

            }



            return searchRoomDatas;

        }


        public static List<StoreData> ReadExcelDataStore(string excelFilePath, string sheetName)
        {
            List<StoreData> store = new List<StoreData>();
            Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
            using (var stream = new FileStream(excelFilePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))

            {

                using (var reader = ExcelReaderFactory.CreateReader(stream))

                {

                    var result = reader.AsDataSet(new ExcelDataSetConfiguration()

                    {

                        ConfigureDataTable = (_) => new ExcelDataTableConfiguration()

                        {

                            UseHeaderRow = true,

                        }

                    });



                    var dataTable = result.Tables[sheetName];



                    if (dataTable != null)

                    {

                        foreach (DataRow row in dataTable.Rows)

                        {

                            StoreData excelData = new StoreData

                            {

                                City = GetValueOrDefault(row, "city"),
                                Item = GetValueOrDefault(row, "item"),
                                SortBy = GetValueOrDefault(row,"sortBy"),
                                Qty = GetValueOrDefault(row,"qty"),
                                Email = GetValueOrDefault(row, "email"),
                                FirstName = GetValueOrDefault(row,"firstname"),
                                LastName = GetValueOrDefault(row,"lastname"),
                                Address = GetValueOrDefault(row, "address"),







                            };



                            store.Add(excelData);

                        }

                    }

                    else

                    {

                        Console.WriteLine($"Sheet '{sheetName}' not found in the Excel file.");

                    }

                }

            }



            return store;

        }

        static string GetValueOrDefault(DataRow row, string columnName)

        {

            Console.WriteLine(row + "  " + columnName);

            return row.Table.Columns.Contains(columnName) ? row[columnName]?.ToString() : null;

        }

    
    }
}

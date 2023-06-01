using ECountSDK;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace ECountSDK

{
	public class FileStore
	{
		// 파일명 : product.dat
		public static void Save(List<Product> products)
		{
			var formatter = new BinaryFormatter();

			// 파일 생성
			using (var writeStream = File.OpenWrite("Product.dat"))
			{
				formatter.Serialize(writeStream, products);
				writeStream.Close();
			}
		}

		// 파일명 : purchase.dat
		public static void Save(List<Purchase> purchases)
		{
			var formatter = new BinaryFormatter();

			// 파일 생성
			using (var writeStream = File.OpenWrite("purchase.dat"))
			{
				formatter.Serialize(writeStream, purchases);
				writeStream.Close();
			}
		}

		// 파일명 : sale.dat
		public static void Save(List<Sale> sales)
		{
			var formatter = new BinaryFormatter();

			// 파일 생성
			using (var writeStream = File.OpenWrite("sale.dat"))
			{
				formatter.Serialize(writeStream, sales);
				writeStream.Close();
			}
		}


		// 파일명 : product.dat
		public static List<Product> GetProductList()
		{
			var formatter = new BinaryFormatter();
			List<Product> result = null;
			// 파일 읽기
			using (var readStream = File.OpenRead("product.dat"))
			{
				result = (List<Product>)formatter.Deserialize(readStream);
				readStream.Close();

				return result;
			}
		}

		// 파일명 : purchases.dat
		public static List<Purchase> GetPurchaseList()
		{
			var formatter = new BinaryFormatter();
			List<Purchase> result = null;
			// 파일 읽기
			using (var readStream = File.OpenRead("purchase.dat")) 
																  
			{
				result = (List<Purchase>)formatter.Deserialize(readStream);
				readStream.Close();

				return result;
			}

		}

		// 파일명 : sale.dat
		public static List<Sale> GetSaleList()
		{
			var formatter = new BinaryFormatter();
			List<Sale> result = null;
			// 파일 읽기
			using (var readStream = File.OpenRead("sale.dat"))
			{
				result = (List<Sale>)formatter.Deserialize(readStream);
				readStream.Close();

				return result;
			}
		}
	}
}

using System;
using System.Diagnostics;
using System.IO;
using MongoDB;
using MongoDB.Bson.DateTime;
using System.Collections.Generic;



namespace SmartDeliveries.SalesOrder
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Smart Deliveries AB");
            MongoDatabaseSettings;


            var settings  = MongoClientSettings.FromConnectionString("mongodb+srv://demo_user:<password>@digitalarkitekt1-jlacy.mongodb.net/test?retryWrites=true&w=majority");
            IMongoClient client = new MongoClient(settings);

            var database = client.GetDatabse("SmartDeliveries-Esbjörn");
            var collection = databse.getCollection<SaleOrderDocument>;("Order");
            var salesOrderDocument = new SaleOrderDocument {
                CustomerID = "ABC",
                CustomerName = "A.Customer",
                orderID = "1",
            };

            // var productDocument  = new BsonDocument {
            //     {"Name", "Value"},
            //     {"SKU", "12345"},
            //     {"Cost", BsonDecimal128.Create(123.0m)},
            //     {"Version", BsonInt32.Create(1)},
            //     {"SupplierID",BsonInt64.Create(123456)},
            //     {"CreatedAt", BsonDateTime.Create(DateTime.Now)},
            //     {"Description", "Ny produkt"},
            //     {"Variants", new BsonArray{
            //         new BsonDocument{
            //             {"Price", BsonDecimal128.Create(240.0m)}
            //         }
            //     }
                
            //     }

            // };

            Debug.WriteLine(productDocument.ToJson());

            // var orderDocument = new BsonDocument
            // {

            // };

            //Debug.WriteLine(orderDocument.ToJson());
        }

        public class SaleOrderDocument{
            public string CustomerID{get; set;}
            public string CustomerAdress {get; set;}

            public string orderID {get;set;}

            [BsonID]
            public SalesOrderStatus Status {get; set;}
            public string CustomerName {get; set;}
            [BsonRepresentation(MongoDB.Bson.BsonType.Decimal128)]
            public decimal Price {get; set;}
            public bool SubscribeToNewsLetter {get; set;}
            public enum SalesOrderStatus{
                Open = 0,
                Closed = 1
            }
            public class LineItem{
                [BsonRepresentation.MongoDB.Bson.BsonType.BsonDecimal128]
                public decimal Price {get; set;}
                public int ProductID{get;set;}
                public int Quantity{get; set;}
            }
            public List<LineItem> LineItems {get; set;}
        }
    }
}

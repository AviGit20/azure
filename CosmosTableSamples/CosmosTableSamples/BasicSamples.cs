using System;

namespace CosmosTableSamples
{
    using System.Threading.Tasks;
    using Microsoft.Azure.Cosmos.Table;
    using Model;
    class BasicSamples
    {
        public async Task RumSample()
        {
            Console.WriteLine("Azure Cosmos DB Table - Basic Samples\n");
            Console.WriteLine();

            string tableName = "Employees";

            CloudTable table = await Common.CreateTableAsync(tableName);
            try
            {
                // Demonstrate basic CRUD functionality 
                await BasicDataOperationsAsync(table);
            }
            finally
            {
                // Delete the table
                // await table.DeleteIfExistsAsync();
            }
        }

        private static async Task BasicDataOperationsAsync(CloudTable table)
        {
            Console.WriteLine("Type I for insert or U for update or X for exit and press enter");
            string option = Console.ReadLine();

            Console.WriteLine("Enter last name:");
            string lName = Console.ReadLine();
            Console.WriteLine("Enter first name:");
            string fName = Console.ReadLine();
            Console.WriteLine("Enter email:");
            string email = Console.ReadLine();
            Console.WriteLine("Enter phone:");
            string phone = Console.ReadLine();


            CustomerEntity customer = new CustomerEntity(lName, fName)
            {
                Email = email,
                PhoneNumber = phone
            };
            if (option == "I")
            {
                Console.WriteLine("Insert an Entity.");
                await SampleUtils.InsertOrMergeEntityAsync(table, customer);
            }
            else if (option == "U")
            {
                Console.WriteLine("Update an existing Entity using the InsertOrMerge Upsert Operation.");
                //customer.PhoneNumber = phone;
                await SampleUtils.InsertOrMergeEntityAsync(table, customer);
                Console.WriteLine();
            }
            else
            {
                return;
            }
            // Demonstrate how to Read the updated entity using a point query 
            Console.WriteLine("Reading the Entity.");
            customer = await SampleUtils.RetrieveEntityUsingPointQueryasync(table, lName, fName);
            Console.WriteLine(customer.PartitionKey + " " + customer.RowKey + " " + customer.Email + " " + customer.PhoneNumber);

            // Demonstrate how to Delete an entity
            //Console.WriteLine("Delete the entity. ");
            //await SamplesUtils.DeleteEntityAsync(table, customer);
            //Console.WriteLine();
        }
    }
}

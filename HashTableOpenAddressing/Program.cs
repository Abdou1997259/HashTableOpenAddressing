// See https://aka.ms/new-console-template for more information

using HashTableOpenAddressing;

HashTable hashTable = new HashTable(20);
hashTable.Insert("Ahmed");
hashTable.Insert("Khalid");
hashTable.Insert("Samar");
hashTable.Delete("Samar");
hashTable.Insert("Kareem");
hashTable.Insert("Kareem");
hashTable.Insert("Kareem");

hashTable.Insert("Kareem");
Console.WriteLine(hashTable);
Console.ReadLine();
Console.WriteLine("Hello, World!");

namespace HashTableOpenAddressing
{
    //linear probing 
    public class HashTable
    {
        private string[] tables;
        private int size;
        private string deletedMarker = "//";
        private const double LoadFactorThreshold = 0.75;
        private int count;
        public HashTable(int size)
        {
            this.size = size;
            tables = new string[size];
            count = 0;
        }
        private void Resize()
        {
            int newSize = size * 2;
            string[] newTable = new string[newSize];
            for (int i = 0; i < size; i++)
            {
                if (tables[i] != deletedMarker && tables[i] != null)
                {
                    string key = tables[i];
                    int index = GetHash(key);
                    int j = 0;
                    while (newTable[index] != null)
                    {
                        index = (index + j) % size;
                        j++;
                    }
                    newTable[index] = key;

                }


            }
            tables = newTable;
            size = newSize;
        }
        private int GetHash(string key)
        {
            return Math.Abs(key.GetHashCode()) % size;
        }
        public void Insert(string key)
        {
            if ((double)count / size >= LoadFactorThreshold)
                Resize();


            int index = GetHash(key);
            int i = 0;
            while (tables[index] != null && tables[index] != deletedMarker)
            {

                index = (index + i) % size;
                i++;
            }
            tables[index] = key;
            count++;

        }
        public void Delete(string key)
        {
            int index = GetHash(key);
            int i = 0;
            while (tables[index] != null)
            {
                if (tables[index] == key)
                {
                    tables[index] = deletedMarker;
                    --count;
                    return;
                }

                index = (index + i) % size;
                i++;
            }

            Console.WriteLine($"Key '{key}' not found for deletion.");
        }
        public string Search(string key)
        {
            int index = GetHash(key);
            int i = 0;
            while (tables[index] != null)
            {
                if (tables[index] == key)
                    return tables[index];

                index = (index + i) % size;
                i++;
            };
            return null;
        }
        public override string ToString()
        {
            string[] output = new string[size];
            for (int i = 0; i < size; i++)
            {
                output[i] = tables[i] == null ? "NULL" : tables[i] == deletedMarker ? "DELETED" :
                    tables[i];
            }
            return string.Join(", ", output);
        }
    }
}

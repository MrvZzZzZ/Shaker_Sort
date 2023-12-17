namespace ShakerSort
{
    internal class Tests
    {

    }

    internal class DataBase
    {
        static private int s_ids = 0;

        private List<Record> _records = new List<Record>();

        public int CreateNewRecord()
        {

        }
    }
}
class Database
{
    size_t amountOfRecords = 0;
    string currentFile = "test.txt";
    Array* records = nullptr;
    vector<int> IDs;
    int CreateNewID();

    public:
Array& operator[] (size_t pos);
void SetFilename(string fileName);
    void UpdateDatabase();
    void ViewDatabase();
    Database() = default;
Database(string fileName);
    ~Database();
    void RemoveRecord(int id);
    int AddRecord(int* array, size_t sizeOfArray);
    void EditRecord(int id, size_t pos, int newValue);
    void SortRecord(int id);
    int Clear();
};
int CountAmountOfRecords(ifstream& file);

class Array
{
    friend class Database;
    private:
    string sortStatus;
    int id;
    size_t sizeOfArray;
    int* array = nullptr;
    public:
void GetArray(int*& destinedArray, size_t& sizeOfDenstinedArray);
    int& operator[] (size_t pos);
string GetSortStatus();
    // int GetID();
    //int GetSize();
    //void SetID(int newID);
    void SetArray(int* newArray, size_t newSize);
    void SetSortStatus(string newStatus);
    int ReadArrayFromFile(ifstream& file);
    void SaveIntoFile(ofstream& file);
    //~Array();
    void operator= (Array& a);
    void EditElement(size_t pos, int newValue);
    void SortArray();

};


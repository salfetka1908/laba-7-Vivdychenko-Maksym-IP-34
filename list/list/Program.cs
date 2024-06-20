using ListShort;
namespace list
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List list1 = new List(12, 213,21,233,123,1123,553,123,654);
            int y = list1.MultipleValue(6);
            list1.RemoveValueByIndex(0);
            list1.RemoveValueByIndex(list1.Size - 1);
            List list2 = list1.NewListWithBigerValues(553);
            int k = list2[0];
            
            
            
            List list = new List();
            list.AddValue(11);
            list.AddValue(23);
            list.AddValue(15);
            list.AddValue(10);
            list.AddValue(37);
            list.AddValue(1);
            list.RemoveOddIndexes();

            List list3 = new List(12, 213, 15, 233, 123, 2234, 553, 11, 212);
            list3.SwitchEvenToZero();
        }
    }
}
namespace LAP3
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Duration D1 = new Duration(2, 59, 40);
            Duration D2 = new Duration(1, 30, 30);
            Duration D3 = D1 + D2;
            Console.WriteLine($"D3 = {D3}");
            D3 = 666 + D3;
            Console.WriteLine($"D3 after adding 666 seconds = {D3}");
            D3 = D1++;
            Console.WriteLine($"D3 after D1++ = {D3}");
            D3 -= D2;
            Console.WriteLine($"D3 after D3 -= D2 = {D3}");
            if (D1 <= D2)
                Console.WriteLine("D1 is less than or equal to D2");
            else
                Console.WriteLine("D1 is greater than D2");
        }
    }
}

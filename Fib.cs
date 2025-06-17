namespace Asynchronous_methods;

internal class Fib
{
    private int number;

    public int Number { get; }

    public decimal Result { get; private set; }

    public Fib(int number)
    {
        this.number = number;
        Calculate();
    }

    private void Calculate()
    {
        if (number <= 1)
        {
            Result = number;
            return;
        }

        (decimal previous, decimal current) = (0, 1);
        for (int i = 2; i < number; i++)
        {
            Result = previous + current;
            previous = current;
            current = Result;
        }

        //long odd = 1;
        //long even = 1;
        //for (int i = 1; i < 99999999 ; i++)
        //{
        //    if ((i % 2) == 0)
        //    {
        //        odd = even * i; 
        //    } else
        //    {
        //        even = odd / i;
        //    }
        //}
    }
}

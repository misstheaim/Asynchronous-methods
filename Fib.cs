namespace Asynchronous_methods;

internal class Fib
{
    private uint number;

    public uint Number { get; }

    public ulong Result { get; private set; }

    public Fib(uint number)
    {
        this.number = number;
    }

    public ulong Calculate()
    {
        if (number <= 1)
        {
            Result = (ulong)number;
            return Result;
        }

        (ulong previous, ulong current) = (0, 1);
        for (int i = 2; i < number; i++)
        {
            Result = previous + current;
            previous = current;
            current = Result;
        }
        //LoadProcessor();
        return Result;
    }

    private void LoadProcessor()
    {
        long odd = 1;
        long even = 1;
        for (int i = 1; i < 9999999; i++)
        {
            if ((i % 2) == 0)
            {
                odd = even * i;
            }
            else
            {
                even = odd / i;
            }
        }
    }
}

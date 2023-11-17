namespace FactorialProcessorTasks
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();    
            var token = cancellationTokenSource.Token;

            FactorialProcessorTasks factorialProcessorTasks1 = new FactorialProcessorTasks();
            factorialProcessorTasks1.MathFactorial(15, true, token);
            Thread.Sleep(2000);

            while (true) 
            
            {
                var key = Console.ReadLine();
                if (key == "q")
                
                {
                    cancellationTokenSource.Cancel();
                    break;
                }
            }
            Console.ReadLine();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace FactorialProcessorTasks
{
    public class FactorialProcessorTasks
    {
        private Stopwatch _stopwatch;
        private int _maxVal;
        private int _passedNum;
        private object _lock = new();

        public FactorialProcessorTasks()
        {
            _stopwatch = new();
        }
        
        public void MathFactorial(int n, bool isParallel, CancellationToken token) 
        {
          _maxVal = n;
            if (isParallel)
            {
                StartFactorialParallel(n, token);
            }
            else 
            { 
                StartFactorialSequential(n); 
            }

            void StartFactorialSequential(int param)
            { 
                _stopwatch.Start();
                for (int i = 0; i < param; i++) 
                
                {
                    PrintFactorial(i);
                }
            }

            void StartFactorialParallel(int param, CancellationToken token) 
            
            {
                _stopwatch.Start();
                for (int i = 0; i < param; i++)

                {
                    int n = i;
                    PrintFactorial(i);
                    new Task(PrintFactorial, n, token).Start();
                }
            }
             void PrintFactorial(object? n)
            
            {
                int param = (int)n;
                var result = Factorial(param);
                Console.WriteLine($"Fact({param} is {result}\t\t");
                lock ( _lock ) 
                
                {
                    if (++_passedNum == _maxVal)
                    {
                        _stopwatch.Stop();
                        Console.WriteLine($"ms:\t{_stopwatch.ElapsedMilliseconds}");
                        Console.WriteLine($"ticks:\t{_stopwatch.ElapsedTicks}\n\n");
                    }
                }
            }
             static int Factorial(int n)
            
            {
                Thread.Sleep( 1000 );
                if(n==0 || n==1) return 1;
                return n*Factorial(n-1);
            }

        }
    }
}

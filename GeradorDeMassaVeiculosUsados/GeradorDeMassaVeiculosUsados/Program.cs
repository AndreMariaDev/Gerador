using System;
using System.Threading.Tasks;

namespace GeradorDeMassaVeiculosUsados
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Util obj = new Util();

            obj.CreateModelByBrandJson();
            obj.CreateModelByBrandSql();
        }
    }
}

using System;

namespace Polimorfismo
{
    class Program
    {

        static void Main(string[] args)
        {
            new Backtest().Run();

            Figura figura = null;

            Console.WriteLine("[C]írculo, [T]riângulo, [Q]uadrado, [P]entágono, [H]exágono");
            Console.Write("Que figura você quer criar?");

            char letra = Console.ReadLine().ToLower()[0];

            switch (letra)
            {
                case 'c': figura = new Circulo(); break;
                case 't': figura = new Triangulo(); break;
                case 'q': figura = new Quadrado(); break;
                case 'p': figura = new Pentagono(); break;
                case 'h': figura = new Hexagono(); break;
                default: return;
            }

            Console.WriteLine();
            Console.Write("Qual a medida (valor do lado ou raio)? ");

            double medida = Convert.ToInt32(Console.ReadLine());
            figura.medida = medida;

            Console.WriteLine();
            Console.WriteLine("tipo da figura: {0}", figura.GetType().Name);
            Console.WriteLine("\tmedida...: {0}", figura.medida);
            Console.WriteLine("\tperímetro: {0}", figura.CalcularPerimetro());
            Console.WriteLine("\tárea.....: {0}", figura.CalcularArea());

            Console.ReadKey();
        }
    }

    abstract class Figura
    {
        public double medida;
        public abstract double CalcularArea();
        public abstract double CalcularPerimetro();
    }
    class Circulo : Figura
    {

        public override double CalcularArea() => Math.PI * Math.Pow(this.medida, 2);
        public override double CalcularPerimetro() => 2 * Math.PI * this.medida;
    }
    class Triangulo : Figura
    {
        public override double CalcularArea()
        {
            double sp = this.CalcularPerimetro() / 2;
            return Math.Sqrt(sp * Math.Pow(sp - this.medida, 3));
        }
        public override double CalcularPerimetro() { return this.medida * 3; }
    }
    class Quadrado : Figura
    {
        public override double CalcularArea() { return Math.Pow(this.medida, 2); }
        public override double CalcularPerimetro() { return this.medida * 4; }
    }
    class Pentagono : Figura
    {
        public override double CalcularArea() { return (Math.Pow(this.medida, 2) * Math.Sqrt(25 + 10 * Math.Sqrt(5))) / 4; }
        public override double CalcularPerimetro() { return this.medida * 5; }
    }
    class Hexagono : Figura
    {
        public override double CalcularArea() { return Math.Pow(this.medida, 2) * 3 * Math.Sqrt(3) / 2; }
        public override double CalcularPerimetro() { return this.medida * 6; }
    }
}





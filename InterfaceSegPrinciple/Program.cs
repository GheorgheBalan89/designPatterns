using System;

namespace InterfaceSegPrinciple
{
    public class Document
    {

    }
    //breaks the principle
    public interface IMachine
    {
        void Print(Document d);
        void Scan(Document d);
        void Fax(Document d);
    }

    //respects it
    public interface IPrinter
    {
        void Print(Document d);
    }

    public interface IScanner
    {
        void Scan(Document d);
    }

    public interface IMultiFunctionDevice : IScanner, IPrinter
    {

    }

    public class MultiFunctionMachine : IMultiFunctionDevice
    {
        private IPrinter printer;
        private IScanner scanner;

        public MultiFunctionMachine(IPrinter printer, IScanner scanner)
        {
            this.printer = printer ?? throw new ArgumentNullException(nameof(printer));
            this.scanner = scanner ?? throw new ArgumentNullException(nameof(scanner));
        }

        public void Print(Document d)
        {
            printer.Print(d);
        }

        public void Scan(Document d)
        {
            scanner.Scan(d);
        } //decorator
    }
    public class MultiFunctionPrinter : IMachine
    {
        public void Print(Document d)
        {

        }

        public void Scan(Document d)
        {

        }

        public void Fax(Document d)
        {

        }
    }

    public class OldFashionedPrinter : IMachine
    {
        public void Print(Document d)
        {
        //
        }

        public void Scan(Document d)
        {
            throw new NotImplementedException();
        }

        public void Fax(Document d)
        {
            throw new NotImplementedException();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}

using System.Threading.Tasks;

namespace Factories
{

    public class Foo
    {
        private Foo()
        {
         //   
        }

        private async Task<Foo> InitAsync()
        {
            await Task.Delay(1000);
            return this;
        }

        public static Task<Foo> CreateAsync()
        {
            var result = new Foo();
            return result.InitAsync();
        }
    }
    public class AsyncFactory
    {
    }

    //public class Program
    //{
    //   public static async Task Main(string[] args)
    //   {
    //      Foo foo = await Foo.CreateAsync();
    //   }
    //}
}

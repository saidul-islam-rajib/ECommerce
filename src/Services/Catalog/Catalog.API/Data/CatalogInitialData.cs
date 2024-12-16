using Marten.Schema;

namespace Catalog.API.Data
{
    public class CatalogInitialData : IInitialData
    {
        public async Task Populate(IDocumentStore store, CancellationToken cancellation)
        {
            using var session = store.LightweightSession();
            if (await session.Query<Product>().AnyAsync())
            {
                return;
            }

            // Marten UPSERT will cater for existing records
            session.Store<Product>(GetPreConfiguredProducts());

            await session.SaveChangesAsync();
        }

        private static IEnumerable<Product> GetPreConfiguredProducts() => new List<Product>()
        {
            new Product()
            {
                Id = new Guid(),
                Name= "Product Name 7",
                Category= new List<string>{"Smart Phone"},
                Description= "Just for testing purpose only 7.",
                ImageFile= "phone.png",
                Price= 7
            },
            new Product()
            {
                Id = new Guid(),
                Name= "Product Name 7",
                Category= new List<string>{"Laptop"},
                Description= "this is all about laptp",
                ImageFile= "laptop.png",
                Price= 7
            },
            new Product()
            {
                Id = new Guid(),
                Name= "Product Name 7",
                Category= new List<string>{"Mouse"},
                Description= "this is all about mouse",
                ImageFile= "mouse.png",
                Price= 7
            },
            new Product()
            {
                Id = new Guid(),
                Name= "Product Name 7",
                Category= new List<string>{"Monitor"},
                Description= "this is all about monitor",
                ImageFile= "monitor.png",
                Price= 7
            }
        };
    }
}

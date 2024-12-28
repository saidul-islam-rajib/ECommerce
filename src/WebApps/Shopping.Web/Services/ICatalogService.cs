namespace Shopping.Web.Services;

public interface ICatalogService
{
    Task<GetProductsResponse> GetProducts(int? PageNumber = 1, int? PageSize = 10);
    Task<GetProductByIdResponse> GetProduct(Guid id);
    Task<GetProductByCateogryResponse> GetProductByCategory(string category);
}

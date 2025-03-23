using Carter;
using Command.Presentation.Abstractions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;



namespace Command.Presentation.APIs.Products;

public class ProductApi : ApiEndpoint, ICarterModule
{
    private const string BaseUrl = "/api/v{version:apiVersion}/products";
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        var group1 = app.NewVersionedApi("products")
            .MapGroup(BaseUrl).HasApiVersion(1);//.RequireAuthorization();

        group1.MapPost(string.Empty, CreateProductsV1);

    }

    #region ====== version 1 ======

    public static async Task<IResult> CreateProductsV1()
    {
        return Results.Ok("Product Created");
    }


    #endregion ====== version 1 ======

}

using Carter;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Query.Presentation.Abstractions;

namespace Query.Presentation.APIs.Products;

public class ProductApi : ApiEndpoint, ICarterModule
{
    private const string BaseUrl = "/api/v{version:apiVersion}/products";

    public void AddRoutes(IEndpointRouteBuilder app)
    {
        var group1 = app.NewVersionedApi("products")
            .MapGroup(BaseUrl).HasApiVersion(1); //.RequireAuthorization();

        group1.MapGet(string.Empty, GetProductsV1);
        //group1.MapGet("{productId}", GetProductsByIdV1);
    }

    #region ====== version 1 ======

    public static async Task<IResult> GetProductsV1()
    {
        //var result = await sender.Send(new QueryV1.GetProductsQuery());
        return Results.Ok("");
    }

    //public static async Task<IResult> GetProductsByIdV1(ISender sender, [FromRoute] Guid productId)
    //{
    //    var result = await sender.Send(new QueryV1.GetProductByIdQuery(productId));
    //    return Results.Ok(result);
    //}

    #endregion ====== version 1 ======
}

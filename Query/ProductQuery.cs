﻿using GraphQL;
using GraphQL.Types;
using GraphQLProject.Interfaces;
using GraphQLProject.Type;

namespace GraphQLProject.Query
{
    public class ProductQuery : ObjectGraphType
    {
        public ProductQuery(IProduct productService)
        {
            Field<ListGraphType<ProductType>>("products", resolve: context => { return productService.GetAllProducts(); });
            Field<ProductType>("product",
                arguments: new QueryArguments(new QueryArgument<IntGraphType> { Name = "id" } ),
                resolve: context => {
                    return productService.GetProductById(context.GetArgument<int>("id"));
                });
        }
    }
}

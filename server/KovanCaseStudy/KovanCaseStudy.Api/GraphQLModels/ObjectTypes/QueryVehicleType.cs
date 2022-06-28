using HotChocolate.Types;
using KovanCaseStudy.Api.GraphQLCore;
using KovanCaseStudy.KovanDummyApiClient.Models.Responses.Items;
using Microsoft.AspNetCore.Mvc.ApplicationParts;

namespace KovanCaseStudy.Api.GraphQLModels.ObjectTypes;

public class QueryObjectType: ObjectType<Query>
{
    protected override void Configure(IObjectTypeDescriptor<Query> descriptor)
    {
        descriptor.Field(_ => _.GetVehicle(default, default, default)).Type<ObjectType<ItemsResponse>>().Authorize();
    }
}
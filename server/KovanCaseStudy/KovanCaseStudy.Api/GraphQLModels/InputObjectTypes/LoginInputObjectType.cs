using HotChocolate.Types;
using KovanCaseStudy.Api.Jwt;

namespace KovanCaseStudy.Api.GraphQLModels.InputObjectTypes;

public class LoginInputObjectType : InputObjectType<LoginInput>
{
    protected override void Configure(IInputObjectTypeDescriptor<LoginInput> descriptor)
    {
        descriptor.Field(_ => _.Username).Name("Username").Type<StringType>();
        descriptor.Field(_ => _.Password).Name("Password").Type<StringType>();
    }
}
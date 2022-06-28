using System.Text;
using KovanCaseStudy.Api.GraphQLCore;
using KovanCaseStudy.Api.GraphQLModels.ObjectTypes;
using KovanCaseStudy.Api.Jwt;
using KovanCaseStudy.KovanDummyApiClient;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddCors(p => p.AddPolicy("corsapp", builder =>
{
    builder.WithOrigins("*").AllowAnyMethod().AllowAnyHeader();
}));
// builder.Services.AddSwaggerGen();
// builder.Services.AddInfrastructureEFCore(builder.Configuration);
builder.Services.AddGraphQLServer()
    .AddMutationType<Mutation>()
    .AddQueryType<QueryObjectType>().AddAuthorization();
builder.Services.AddScoped<KovanCaseStudy.Api.GraphQLCore.Query>();
builder.Services.AddScoped<KovanCaseStudy.Api.GraphQLCore.Mutation>();
builder.Services.AddKovanDummyApiClient(builder.Configuration);

builder.Services.Configure<TokenSettings>(builder.Configuration.GetSection("TokenSettings"));
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidIssuer = builder.Configuration.GetSection("TokenSettings").GetValue<string>("Issuer"),
            ValidateIssuer = true,
            ValidAudience = builder.Configuration.GetSection("TokenSettings").GetValue<string>("Audience"),
            ValidateAudience = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration.GetSection("TokenSettings").GetValue<string>("Key"))),
            ValidateIssuerSigningKey = true
        };
    });


// builder.Services.AddGraphQLServer().AddQueryType<Query>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    // app.UseSwagger();
    // app.UseSwaggerUI();
}
app.UseCors("corsapp");

app.UseHttpsRedirection();

app.MapControllers();

app.UseRouting();

app.UseAuthorization();
app.UseAuthentication();

app.UseEndpoints(endpoints =>
{
    endpoints.MapGraphQL();
});


app.Run();
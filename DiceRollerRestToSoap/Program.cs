using DiceRollerRESTToSoap.Output;
using SoapCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSoapCore();
builder.Services.AddScoped<IRestToSoap, DiceSoapService>();

var app = builder.Build();
app.UseRouting();
app.UseEndpoints(endpoints =>
{
    endpoints.UseSoapEndpoint<IRestToSoap>(
        path: "/Service.asmx",
        encoder: new SoapEncoderOptions(),
        serializer: SoapSerializer.XmlSerializer,
        caseInsensitivePath: true
    );
});

app.Run();
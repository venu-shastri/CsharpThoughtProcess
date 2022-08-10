var builder = WebApplication.CreateBuilder(args);

//Service Registration
//builder.Services.AddSingleton(typeof(PatientCRUDServiceApi.Repositories.IPatientDataRepository), typeof(PatientCRUDServiceApi.Repositories.LocalMemoryRepository));
builder.Services.AddControllers();

//Metadata Support
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

//setup custom request/reply pipeline using middlewares
app.UseSwagger();
app.UseSwaggerUI();


//app.MapControllers();//Endpoint Configuration


//Minimal Web Api
app.MapGet("/api/patientdata/all", () => {

    PatientCRUDServiceApi.Repositories.IPatientDataRepository _repo = new PatientCRUDServiceApi.Repositories.LocalMemoryRepository();
    return _repo.GetAllPatients();


});

app.Run();

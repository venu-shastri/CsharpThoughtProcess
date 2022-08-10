using Microsoft.EntityFrameworkCore.InMemory;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

//Service Registration
builder.Services.AddScoped(typeof(PatientCRUDServiceApi.Repositories.IPatientDataRepository), typeof(PatientCRUDServiceApi.Repositories.LocalDBRepository));
builder.Services.AddControllers();
builder.Services.AddDbContext<PatientCRUDServiceApi.DBContexts.PatientDBContext>(op => {
    op.UseInMemoryDatabase("PatientList");
});

//Metadata Support
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

//setup custom request/reply pipeline using middlewares
app.UseSwagger();
app.UseSwaggerUI();


//app.MapControllers();//Endpoint Configuration


//Minimal Web Api
app.MapGet("/api/patientdata/all", (PatientCRUDServiceApi.Repositories.IPatientDataRepository  _repo) => {

   
    return _repo.GetAllPatients();


});
app.MapPost("/api/patientdata/add", (PatientCRUDServiceApi.Repositories.IPatientDataRepository _repo,[FromBody] PatientCRUDServiceApi.Models.PatientDataModel model) => {

    return _repo.AddNewPatient(model);
});

app.Run();

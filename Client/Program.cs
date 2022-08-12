// See https://aka.ms/new-console-template for more information
using static ObjectValidationLib.ObjectValidator;

PatientDataModel _model = new() { Name=""};
Validate(_model);


class PatientDataModel
{
    [ObjectValidationLib.RequiredValidator(ErrorMessage ="MRN Requires Value")]
    
    public string MRN { get; } = Guid.NewGuid().ToString();
    [ObjectValidationLib.RequiredValidator(ErrorMessage = "Name Requires Value")]
    public string Name { get; set; }
}


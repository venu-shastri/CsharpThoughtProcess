// See https://aka.ms/new-console-template for more information
using static ObjectValidationLib.ObjectValidator;

PatientDataModel _model = new() { Name=""};
Validate(_model);


class PatientDataModel
{
    [ObjectValidationLib.RequiredValidator(ErrorMessage ="MRN Requires Value")]
    
    public string MRN { get; } = Guid.NewGuid().ToString();

    [ObjectValidationLib.RequiredValidator(ErrorMessage = "Name Requires Value")]
    [ObjectValidationLib.LengthValidator(MaxLength=15,ErrorMessage = "Name Requires Value")]
    public string Name { get; set; }

    [[ObjectValidationLib.RangeValidator(1,100,ErrorMessage = "Age Value Must be with in range 1-100")]]
    public int Age { get; set; }
}


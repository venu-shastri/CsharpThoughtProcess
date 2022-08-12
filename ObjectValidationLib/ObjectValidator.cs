namespace ObjectValidationLib
{
    public static class ObjectValidator
    {

        public static ValidationSummary Validate(object source)
        {
            System.Type _classRef = source.GetType();//null exception
           var properties= _classRef.GetProperties();//public properties
            foreach(var property in properties)
            {
                Console.WriteLine(property.Name);
               var requiredAttribute= property.GetCustomAttributes(typeof(RequiredValidatorAttribute), true)[0] as RequiredValidatorAttribute;
                //null check
                if(requiredAttribute != null)
                {
                  bool result=  requiredAttribute.Validate(property.GetValue(source));
                    if (result)
                    {
                        Console.WriteLine(requiredAttribute.ErrorMessage);
                    }
                }

            }
            return new ValidationSummary();

        }

    }
}
 class PropertyContainer : DynamicObject
    {
        Dictionary<string, object> properties = new Dictionary<string, object>();
        public override bool TrySetMember(SetMemberBinder binder, object? value)
        {
            properties[binder.Name] = value!;
            return true;
        }
        public override bool TryInvokeMember(InvokeMemberBinder binder, object?[]? args, out object? result)
        {
            result = null;
            if (binder.Name == "Dump")
            {
                foreach(var kvp in properties)
                {
                    Console.WriteLine($"{kvp.Key} -> {kvp.Value}");
                }
                return true;
            }
            return false;
        }
    }
    internal class DynamicProgramming
    {
       static void Main()
        {
            dynamic _patientInfo = new PropertyContainer(); // object _patientInfo = new PropertyContainer();

            // Generate Binder Class - Evaluate/Resolve @Runtime
            _patientInfo.MRN = "M100";//Property Setter Expression
            _patientInfo.Name = "Tom";
            _patientInfo.Dump();//Method Invoke Expression

            dynamic _appointment = new PropertyContainer();
            _appointment.MRN = "M100";
            _appointment.Date = "20/8/2022";
            _appointment.Time = "20:30";
            _appointment.Dump();
        }
    }

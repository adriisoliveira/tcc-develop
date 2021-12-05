using System;

namespace APIController.Business.Enum
{
    [Flags]
    public enum UserType : int
    {
        Unknown = 0,
        Teacher = 1,
        Student = 2,
        InstitutionAdministrator = 4
    }
}

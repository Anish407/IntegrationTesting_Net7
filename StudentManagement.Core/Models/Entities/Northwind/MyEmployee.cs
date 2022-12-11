using System;
using System.Collections.Generic;

namespace StudentManagement.API.Models;

public partial class MyEmployee
{
    public short EmployeeId { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string Title { get; set; } = null!;

    public short DeptId { get; set; }

    public int? ManagerId { get; set; }
}

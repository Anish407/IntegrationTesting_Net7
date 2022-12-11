using System;
using System.Collections.Generic;

namespace StudentManagement.API.Models;

public partial class EmployeesUppercase
{
    public int? EmployeeId { get; set; }

    public string LastName { get; set; } = null!;

    public string FirstName { get; set; } = null!;

    public DateTime? BirthDate { get; set; }

    public DateTime? HireDate { get; set; }

    public string? Address { get; set; }

    public string? City { get; set; }

    public string? PostalCode { get; set; }

    public string? HomePhone { get; set; }

    public string? Extension { get; set; }
}

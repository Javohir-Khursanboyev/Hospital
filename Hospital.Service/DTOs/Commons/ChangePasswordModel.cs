﻿namespace Hospital.Service.DTOs.Commons;

public class ChangePasswordModel
{
    public string OldPassword { get; set; }
    public string NewPassword { get; set; }
    public string ConfirmPassword { get; set; }
}
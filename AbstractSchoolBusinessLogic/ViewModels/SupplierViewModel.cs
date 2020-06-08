﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace AbstractSchoolBusinessLogic.ViewModels
{
    public class SupplierViewModel
    {
        public int Id { get; set; }
        [DisplayName("ФИО")]
        public string SupplierFIO { get; set; }
        [DisplayName("Логин")]
        public string Email { get; set; }
        [DisplayName("Пароль")]
        public string Password { get; set; }
    }
}

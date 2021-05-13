﻿using System.ComponentModel.DataAnnotations;

namespace DataAccess
{
    interface IBranch
    {
        [Key] public string Key { get; set; }
        public string AdrLat { get; set; }
        public string AdrRus { get; set; }
        public string Phones { get; set; }
    }
}

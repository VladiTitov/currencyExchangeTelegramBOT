﻿using System;
using System.Collections.Generic;
using System.Text;
using Banks._01_Inerfaces;

namespace Banks._02_Classes
{
    class Branches : IBank
    {
        public string Phone { get; set; }

        public Branches(List<string> branches) : base(branches) => Phone = branches[1];
    }
}
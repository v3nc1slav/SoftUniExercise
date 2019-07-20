﻿using System;

namespace PersonInfo.MilitaryElite
{
    public class Spy : Soldier, ISpy
    {
        public Spy(string id, string firstName, string lastName, int codeNumber) 
            : base(id, firstName, lastName)
        {
            CodeNumber = codeNumber;
        }

        public int CodeNumber
        { get; private set; }

        public override string ToString()
        {
            return base.ToString().TrimEnd() + Environment.NewLine + $"Code Number: {CodeNumber}";
        }
    }
}

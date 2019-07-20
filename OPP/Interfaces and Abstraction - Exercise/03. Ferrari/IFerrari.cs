using System;
using System.Collections.Generic;
using System.Text;

namespace PersonInfo
{
    public interface IFerrari
    {
        string NameDriver { get; }
        string Model { get; }
        string  Brakes();
        string Gas();
    }
}

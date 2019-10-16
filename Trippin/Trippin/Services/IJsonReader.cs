using System;
using System.Collections.Generic;
using System.Text;

namespace Trippin.Services
{
    public interface IJsonReader
    {
        JsonUser[] ReadUsers(String filename);
    }
}

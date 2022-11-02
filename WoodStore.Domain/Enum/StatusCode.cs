using System;
using System.Collections.Generic;
using System.Text;

namespace WoodStore.Domain.Enum
{
    public enum StatusCode
    {
        OrderNotFound = 0,
        Ok = 200,
        InternalServerError = 404
    }
}

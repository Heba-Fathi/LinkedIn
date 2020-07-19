using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LinkedIn.Web.Models
{
	public enum UserType
	{
        Connected,
        requested,
        pending,
        noConnection
    }
}
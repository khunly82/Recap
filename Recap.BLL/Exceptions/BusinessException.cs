using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recap.BLL.Exceptions
{
    public class BusinessException(string message): Exception(message)
    {
    }
}

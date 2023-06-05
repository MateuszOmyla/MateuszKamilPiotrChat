using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Entities;
public class UserMessages
{
    public int UserId { get; set; }
    public User User { get; set; }
    public int MessageID { get; set; }
    public Message Message { get; set; }

}

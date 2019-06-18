using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TodoApi.Entities
{
    [Table("Role")]
    public class Role
    {
        [Column("RoleID")]
        public int ID { get; set; }

        [Column("RoleName")]
        public string Name { get; set; }
    }
}

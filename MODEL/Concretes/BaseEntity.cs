using MODEL.Abstracts;
using MODEL.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MODEL.Concretes
{
    public abstract class BaseEntity : IEntity<string>
    {
        public BaseEntity()
        {
            CreatedDate = DateTime.Now;
            CreatedComputerName=System.Environment.MachineName;
            CreatedIpAddress = "192.168.1.1"; //todo: Dinamik Ip adresine alınacak
            MasterID = Guid.NewGuid().ToString();
            Status = DataStatus.Active;
        }
        public int ID { get ; set ; }
        public string MasterID { get ; set ; }
        public DateTime CreatedDate { get ; set ; }
        public string CreatedComputerName { get ; set ; }
        public string CreatedIpAddress { get ; set ; }


        public DateTime? UpdatedDate { get ; set ; }//nullable
        public string? UpdatedComputerName { get ; set ; }//nullable
        public string? UpdatedIpAddress { get ; set ; }//nullable
        public DataStatus Status { get ; set ; }
       
    }
}
